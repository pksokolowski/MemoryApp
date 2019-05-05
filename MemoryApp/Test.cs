using System.Collections.Generic;
using System.Text;

namespace MemoryApp
{
    /// <summary>
    /// manages a single test case
    /// </summary>
    class Test
    {
        public int ItemsCount {
            get { return Qnas.Count; }
        }
        public int ItemShowingTime { get; private set; }
        private List<QnA> Qnas;
        private List<QnA> TestOrder;

        public QnA getItem(int index)
        {
            return Qnas[index];
        }

        /// <param name="itemsCount">The test will consist of this many variables for which user will be asked
        /// to remember values.</param>
        /// <param name="itemShowingTime">determines time each variable-value pair will be shown to the user</param>
        public Test(int itemsCount, int itemShowingTime)
        {
            ItemShowingTime = itemShowingTime;

            // setting up questions themselves.
            // variable name is chosen and a value for it.
            // the user will be asked to remember the pair.
            Qnas = new List<QnA>(itemsCount);
            for (int i = 0; i < itemsCount; i++)
            {
                var variableName = alphabetLetter(i);
                var item = QnAPairGenerator.Generate(variableName);
                Qnas.Add(item);
            }          
            Qnas.Shuffle();

            // setting up the order in which test questions will be
            // later asked.
            TestOrder = new List<QnA>(itemsCount);
            TestOrder.AddRange(Qnas);
            TestOrder.Shuffle();
        }

        private string alphabetLetter(int index)
        {
            return ((char)(65 + index)).ToString();
        }

        public override string ToString()
        {
            var correctAnswers = new StringBuilder();
            foreach (QnA qna in Qnas)
            {
                correctAnswers.AppendLine(qna.ToString());
            }
            return correctAnswers.ToString();
        }
    }
}
