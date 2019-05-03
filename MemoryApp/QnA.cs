using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
