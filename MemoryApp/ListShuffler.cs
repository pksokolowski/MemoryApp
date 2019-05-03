using System;
using System.Collections.Generic;

namespace MemoryApp
{
    internal static class ListShuffler
    {
        private static Random Rand = new Random();
        internal static void Shuffle<E>(this List<E> list)
        {
            int iterations = list.Count + 2;
            for (int i = 0; i < iterations; i++)
            {
                var a = Rand.Next(list.Count);
                var b = Rand.Next(list.Count);

                swap(list, a, b);
            }
        }

        private static void swap<E>(List<E> list, int a, int b)
        {
            var holder = list[a];
            list[a] = list[b];
            list[b] = holder;
        }
    }
}
