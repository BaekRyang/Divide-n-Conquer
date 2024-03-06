using System;
using System.Collections;

namespace Divide_n_Conquer
{
    public static class Tools
    {
        public static void Print(this IEnumerable _data)
        {
            int _idx = 0;
            foreach (var _d in _data)
            {
                Console.Write(_idx++ + ". " + _d + "\n");
            }
            Console.WriteLine();
        }
    }
}