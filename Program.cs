using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Divide_n_Conquer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IEnumerable<int> _randomIntData = RandomDataMaker.MakeData<int>(1000, false);

            IEnumerable<int> _sortedRandomIntData = _randomIntData.OrderBy(_d => _d);

            Search(_sortedRandomIntData.ToList());
        }

        private static void Search(List<int> _randomIntData)
        {
            Stopwatch _linearSearch = new Stopwatch(),
                      _binarySearch = new Stopwatch();
            
            _linearSearch.Start();
            Console.WriteLine(_randomIntData.LinearSearch(999));
            _linearSearch.Stop();

            _binarySearch.Start();
            Console.WriteLine(Divide_n_Conquer.Search.BinarySearch(_randomIntData, 99995));
            _binarySearch.Stop();

            Console.WriteLine("Linear Search: " + _linearSearch.Elapsed);
            Console.WriteLine("Binary Search: " + _binarySearch.Elapsed);
        }
    }
}