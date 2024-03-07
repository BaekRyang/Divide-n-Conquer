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
            IEnumerable<int> _randomIntData = RandomDataMaker.MakeData<int>(9, false);

            // IEnumerable<int> _sortedRandomIntData = _randomIntData.OrderBy(_d => _d);
            // BinarySearchCompare(_sortedRandomIntData.ToList());

            Stopwatch _stopwatch = new Stopwatch();
            _stopwatch.Start();
            var _mergeSorted = _randomIntData.ToList().MergeSort();
            _stopwatch.Stop();
            Console.WriteLine("Merge Sort: " + _stopwatch.Elapsed);
            _mergeSorted.Print();
        }

        private static void Search(List<int> _randomIntData)
        {
            Stopwatch _linearSearch = new Stopwatch(),
                      _binarySearch = new Stopwatch();
            
            _linearSearch.Start();
            Console.WriteLine(_randomIntData.LinearSearch(42299));
            _linearSearch.Stop();

            _binarySearch.Start();
            Console.WriteLine(Divide_n_Conquer.Search.BinarySearch(_randomIntData, 42299));
            _binarySearch.Stop();

            Console.WriteLine("Linear Search: " + _linearSearch.Elapsed);
            Console.WriteLine("Binary Search: " + _binarySearch.Elapsed);
        }
        
        private static void BinarySearchCompare(List<int> _randomIntData, int _loopCount = 10000)
        {
            TimeSpan  _binarySearchTime = new TimeSpan();
            for (int i = 0; i < _loopCount; i++)
            {
                Stopwatch _binarySearch = new Stopwatch();
                _binarySearch.Start();
                Console.WriteLine(Divide_n_Conquer.Search.BinarySearch(_randomIntData, 42299));
                _binarySearch.Stop();
                _binarySearchTime += _binarySearch.Elapsed;
            }

            Console.WriteLine("Average Binary Search: " + _binarySearchTime.TotalMilliseconds / _loopCount);
        }
        

    }
}