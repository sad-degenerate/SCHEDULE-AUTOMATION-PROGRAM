using System;
using System.Collections.Generic;

namespace BL
{
    public static class Shuffles<T>
    {
        public static List<T> Shuffle(List<T> list)
        {
            var rand = new Random();

            for (int i = list.Count - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);

                T temp = list[j];
                list[j] = list[i];
                list[i] = temp;
            }

            return list;
        }
    }
}