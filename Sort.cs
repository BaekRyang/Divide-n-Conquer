using System;
using System.Collections.Generic;

namespace Divide_n_Conquer
{
    public static class Sort
    {
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

        private static List<T> Merge<T>(List<T> _left, List<T> _right)
        {
            var _sortedData = new List<T>();

            while (_left.Count * _right.Count > 0) //둘 중 하나라도 데이터가 없을 때 까지
            {
                if (_left[0] as dynamic > (_right[0] as dynamic)) //둘 중 작은 값을 정렬된 데이터에 추가
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
    }
}