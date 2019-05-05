namespace MemoryApp
{
    /// <summary>
    /// Holds a question-answer pair.
    /// </summary>
    class QnA
    {
        public string Question { get; private set; }
        public string Answer { get; private set; }

        public QnA(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }

        public override string ToString()
        {
            return $"{Question} = {Answer}";
        }
    }
}
 