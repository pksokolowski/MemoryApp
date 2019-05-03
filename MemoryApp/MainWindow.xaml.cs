using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MemoryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TestRunner Runner = new TestRunner();

        public MainWindow()
        {
            InitializeComponent();
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
            Test test = new Test(4, 2000);
            Runner.ItemRevealed += Runner_ItemRevealed;
            Runner.AllItemsRevealed += Runner_AllItemsRevealed;

            Runner.StartTest(test);
        }

        private void Runner_AllItemsRevealed()
        {
            output.Dispatcher.Invoke(() =>
            {
                output.Text = "";
                input.Visibility = Visibility.Visible;
                input.Focus();
            });
        }

        private void Runner_ItemRevealed(object sender, QnA e)
        {
            var runner = (TestRunner)sender;
            output.Dispatcher.Invoke(() =>
            {              
                output.Text = $"{e.Question} = {e.Answer}";
            });          
        }
    }
}
