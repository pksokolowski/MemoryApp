using System;

namespace MemoryApp
{
    /// <summary>
    /// Generates test questions and handles user's answers.
    /// Also tracks progression of the quiz (remembers the last
    /// question number).
    /// </summary>
    class Quiz
    {
        private int currentQuestion = -1;
        private int correctAnswersCount = 0;
        private Test Test;
        public Quiz(Test test)
        {
            Test = test;
        }

        public string ask()
        {
            currentQuestion++;
            if (currentQuestion >= Test.ItemsCount) return "";

            var item = Test.getItem(currentQuestion);
            return item.Question;
        }

        public bool CheckAnswer(String answer)
        {
            var item = Test.getItem(currentQuestion);

            var isAnswerCorrect = item.Answer == answer;
            if (isAnswerCorrect) correctAnswersCount++;

            return isAnswerCorrect;
        }

        /// <summary>
        /// Computes result when called after all answers were obtained. 
        /// Prior to that, returns null.
        /// </summary>
        /// <returns></returns>
        public Result computeResult()
        {
            if (currentQuestion != Test.ItemsCount) return null;

            var maxScore = (double)Test.ItemsCount;          
            var percentCorrect = correctAnswersCount / maxScore * 100;

            return new Result(Test, percentCorrect);
        }
    }
}
