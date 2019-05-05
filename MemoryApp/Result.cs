using System;

namespace MemoryApp
{
    class Result
    {
        public double PercentCorrect { get; private set; }
        public Test Test { get; private set; }

        public Result(Test test, double percentCorrect)
        {
            PercentCorrect = percentCorrect;
            Test = test;
        }

        public override string ToString()
        {          
            return String.Format("{0:N0}% correct out of {1}\n{2}", PercentCorrect, Test.ItemsCount, Test.ToString());
        }
    }
}
