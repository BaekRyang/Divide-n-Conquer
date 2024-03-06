using System;

namespace Divide_n_Conquer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            foreach (int _i in RandomDataMaker.MakeData<int>(10, true))
            {
                Console.WriteLine(_i);
            }
        }
    }
}