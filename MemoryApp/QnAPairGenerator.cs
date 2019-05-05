using System;

namespace MemoryApp
{
    /// <summary>
    /// generates QnA pairs.
    /// </summary>
    internal static class QnAPairGenerator
    {
        private static Random Rand = new Random();
        internal static QnA Generate(string variable)
        {
            var answer = Rand.Next(10);
            return new QnA(variable, answer.ToString());
        }
    }
}
