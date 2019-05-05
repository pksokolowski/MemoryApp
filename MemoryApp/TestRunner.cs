using System;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryApp
{
    /// <summary>
    /// Manages the Task used to handle async operation of the test.
    /// Holds the instance of Test it's currently running. When it's 
    /// null, it means no test is running at the moment.
    /// </summary>
    class TestRunner
    {
        private Task Task;

        private Test CurrentTest;

        internal void StartTest(Test test)
        {
            if (Task != null) return;

            CurrentTest = test;
            Task = new Task(() =>
            {
                for (int i = 0; i < CurrentTest.ItemsCount; i++)
                {
                    var item = CurrentTest.getItem(i);
                    OnItemRevealed(item);

                    Thread.Sleep(CurrentTest.ItemShowingTime);
                }
                Task = null;
                AllItemsRevealed();
            });
            Task.Start();
        }

        protected virtual void OnItemRevealed(QnA item)
        {
            ItemRevealed?.Invoke(this, item);
        }

        public event EventHandler<QnA> ItemRevealed;
        public event Action AllItemsRevealed;
    }

}