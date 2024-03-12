using System;
using System.Collections.Generic;
using System.Linq;

namespace Divide_n_Conquer
{
    public static class Sort
    {
        public static List<T> BubbleSort<T>(this List<T> _data) where T : IComparable<T>
        {
            var _dataCopy = new List<T>(_data);
            for (int i = 0; i < _dataCopy.Count - 1; i++)
            {
                for (int j = i + 1; j < _dataCopy.Count; j++)
                {
                    if (_dataCopy[i].CompareTo(_dataCopy[j]) <= 0) continue; //i번째 데이터가 j번째 데이터보다 크면 바꾼다.

                    _data.Print(i, j);
                    _dataCopy.Swap(i, j);
                }
            }

            return _dataCopy;
        }

        public static IEnumerable<T> SelectionSort<T>(this IList<T> _data) where T : IComparable<T>
        {
            var _dataCopy = new List<T>(_data);
            while (_dataCopy.Count > 0)
            {
                int _minimumDataIndex = 0;
                for (int i = 1; i < _dataCopy.Count; i++)
                {
                    if (_dataCopy[i].CompareTo(_dataCopy[_minimumDataIndex]) < 0)
                        _minimumDataIndex = i;
                }

                yield return _dataCopy[_minimumDataIndex];
                _dataCopy.RemoveAt(_minimumDataIndex);
            }
        }

        public static List<T> InsertionSort<T>(this List<T> _data) where T : IComparable<T>
        {
            //삽입 정렬의 중요한 점은 현재 검사중인 수 이전의 데이터는 정렬되어 있다는 것이다.

            for (int i = 1; i < _data.Count; i++) //배열의 2번째 데이터부터 시작해서 모든 데이터를 검사
            {
                T   _key = _data[i];                             //현재 검사중인 데이터를 키로 설정
                int _j   = i - 1;                                //현재 검사중인 데이터의 이전 데이터부터 시작
                while (_j >= 0 && _data[_j].CompareTo(_key) > 0) //이전 데이터가 키보다 크면 (_j >= 0 조건은 배열의 범위를 벗어나지 않기 위함)
                    _data[_j + 1] = _data[_j--];                 //이전 데이터를 한 칸 뒤로 이동하며 j를 하나 빼면서 전부 검사 하면서 _key가 들어갈 자리가 나올 때 까지 데이터를 뒤로 민다.

                _data[_j + 1] = _key;
            }

            return _data;
        }

        public static List<T> MergeSort<T>(this List<T> _data) where T : IComparable<T> //T는 비교가 가능해야 정렬이 가능
        {
            if (_data.Count <= 1)
                return _data; //데이터가 1개 이하면 정렬할 필요가 없다.

            //반으로 쪼개서
            int _midIndex = _data.Count / 2;

            //재귀적으로 전달
            var _left  = _data.GetRange(0,         _midIndex).MergeSort();
            var _right = _data.GetRange(_midIndex, _data.Count - _midIndex).MergeSort();

            //정렬하여 병합하고 반환
            return Merge(_left, _right);
        }

        private static List<T> Merge<T>(List<T> _left, List<T> _right) where T : IComparable<T>
        {
            var _sortedData = new List<T>();

            while (_left.Count * _right.Count > 0) //둘 중 하나라도 데이터가 없을 때 까지
            {
                if (_left[0].CompareTo(_right[0]) > 0)

                    // if (_left[0] as dynamic > (_right[0] as dynamic)) //둘 중 작은 값을 정렬된 데이터에 추가
                {
                    _sortedData.Add(_right[0]);
                    _right.RemoveAt(0);
                }
                else
                {
                    _sortedData.Add(_left[0]);
                    _left.RemoveAt(0);
                }
            }

            //남은 데이터를 추가
            _sortedData.AddRange(_left);
            _sortedData.AddRange(_right);

            return _sortedData;
        }

        public static List<T> QuickSort<T>(this List<T> _data) where T : IComparable<T>
        {
            if (_data.Count <= 1) //데이터가 1개 이하면 정렬할 필요가 없다.
                return _data;

            T   _pivot = _data[0]; //피벗을 첫번째 데이터로 설정
            var _left  = new List<T>();
            var _right = new List<T>();

            for (int i = 1; i < _data.Count; i++)
            {
                if (_data[i].CompareTo(_pivot) > 0) //피벗보다 크면 오른쪽에 추가
                    _right.Add(_data[i]);
                else //피벗보다 작으면 왼쪽에 추가
                    _left.Add(_data[i]);
            }

            var _sortedData  = new List<T>();
            var _leftSorted  = QuickSort(_left);
            var _rightSorted = QuickSort(_right);

            //정렬된 데이터를 순서대로 병합
            _sortedData.AddRange(_leftSorted);
            _sortedData.Add(_pivot);
            _sortedData.AddRange(_rightSorted);

            return _sortedData;
        }
    }
}