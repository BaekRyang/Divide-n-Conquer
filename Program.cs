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
            //IEnumerable은 지연 평가를 지원하므로 데이터가 필요한 시점에만 평가한다.
            //따라서 ToList를 미리 하지 않으면 데이터가 필요한 시점에 계속해서 랜덤 데이터를 생성하게 된다.
            var _randomIntData = RandomDataMaker.MakeData<int>(9, false).ToList();
            
            _randomIntData.Print();

            // IEnumerable<int> _sortedRandomIntData = _randomIntData.OrderBy(_d => _d);
            // BinarySearchCompare(_sortedRandomIntData.ToList());
            
            Stopwatch _stopwatch = new Stopwatch();
            _stopwatch.Start();
            var _mergeSorted = _randomIntData.MergeSort();
            _stopwatch.Stop();
            Console.WriteLine("Merge Sort: " + _stopwatch.Elapsed);
            _mergeSorted.Print();
            
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            var _quickSorted = _randomIntData.QuickSort();
            _stopwatch.Stop();
            Console.WriteLine("Quick Sort: " + _stopwatch.Elapsed);
            _quickSorted.Print();
            
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            var _bubbleSorted = _randomIntData.BubbleSort();
            _stopwatch.Stop();
            Console.WriteLine("Bubble Sort: " + _stopwatch.Elapsed);
            _bubbleSorted.Print();
            
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            var _selectionSorted = _randomIntData.SelectionSort();
            _stopwatch.Stop();
            Console.WriteLine("Selection Sort: " + _stopwatch.Elapsed);
            _selectionSorted.Print();
            
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
            var _insertionSorted = _randomIntData.InsertionSort();
            _stopwatch.Stop();
            Console.WriteLine("Insertion Sort: " + _stopwatch.Elapsed);
            _insertionSorted.Print();
            
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