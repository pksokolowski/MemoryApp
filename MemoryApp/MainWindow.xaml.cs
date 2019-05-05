using System.Windows;
using System.Windows.Input;

namespace MemoryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TestRunner Runner = new TestRunner();
        private Quiz currentQuiz;

        public MainWindow()
        {
            InitializeComponent();
            input.Visibility = Visibility.Hidden;
            Runner.ItemRevealed += Runner_ItemRevealed;
            Runner.AllItemsRevealed += Runner_AllItemsRevealed;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            var itemsCount = (int)itemsCountSlider.Value;
            var itemDuration = (int)perItemTimeSlider.Value;

            Test test = new Test(itemsCount, itemDuration);   
            
            currentQuiz = new Quiz(test);
            Runner.StartTest(test);
        }

        private void Runner_AllItemsRevealed()
        {
            output.Dispatcher.Invoke(() =>
            {
                output.Text = currentQuiz.ask();
                input.Visibility = Visibility.Visible;
                input.Focus();
            });
        }

        private void Runner_ItemRevealed(object sender, QnA e)
        {
            var runner = (TestRunner)sender;
            output.Dispatcher.Invoke(() =>
            {              
                output.Text = e.ToString();
            });          
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                processInput();
            }
        }

        private void processInput()
        {
            if (currentQuiz == null) return;

            var answer = input.Text;
            var isAnswerCorrect = currentQuiz.CheckAnswer(answer);
            output.Text = currentQuiz.ask();
            checkResultsIfAvailable();
            input.Text = "";
        }

        private void checkResultsIfAvailable()
        {
            var results = currentQuiz.computeResult();
            if (results == null) return;

            output.Text = results.ToString();
            currentQuiz = null;
            input.Visibility = Visibility.Hidden;
        }
    }
}
