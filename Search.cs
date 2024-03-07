using System;
using System.Collections.Generic;

namespace Divide_n_Conquer
{
    public static class Search
    {
        public static (bool, int) LinearSearch<T>(this List<T> _data, T _targetData)
        {
            int _loopCount = 0;
            foreach (T _d in _data)
            {
                _loopCount++;
                if (_d != null && _d.Equals(_targetData))
                    return (true, _loopCount);
            }

            return (false, _loopCount);
        }

        public static (bool, int) BinarySearch(this List<int> _data, int _targetData) //이진 탐색 : 정렬이 필수이며, >, < 연산이 불가능한 경우에는 사용할 수 없다.
        {
            int _loopCount = 0;

            int _firstIndex = 0,
                _lastIndex  = _data.Count;

            while (true)
            {
                _loopCount++;
                int _length   = _lastIndex - _firstIndex + 1, //길이
                    _midIndex = _length / 2,                  //중간 인덱스
                    _midValue = _data[_midIndex];             //중간 값

                _firstIndex = 0;           //첫 인덱스
                _lastIndex  = _length - 1; //마지막 인덱스

                // Console.Write(_data[_firstIndex]);
                // for (int i = _firstIndex + 1; i < _lastIndex; i++)
                // {
                //     Console.Write(", ");
                //     if (i == _midIndex)
                //         Console.ForegroundColor = ConsoleColor.Red;
                //     Console.Write(_data[i]);
                //     Console.ResetColor();
                // }
                //
                // Console.WriteLine("");

                if (_midValue == _targetData)    //값을 찾았으면
                    return (true, _loopCount);   //true 반환
                if (_midValue > _targetData)     //중간 값이 찾는 값보다 크면 => 찾는 값은 중간 값보다 오른쪽에 있다.
                    _lastIndex = _midIndex - 1;  //마지막 인덱스를 중간 인덱스 - 1로 설정
                else                             //중간 값이 찾는 값보다 작으면 => 찾는 값은 중간 값보다 왼쪽에 있다.
                    _firstIndex = _midIndex + 1; //첫 인덱스를 중간 인덱스 + 1로 설정

                if (_length <= 1)                       //길이가 1보다 작거나 같으면
                    return (false, _loopCount);         //false 반환
                
                if (_data[_firstIndex] > _targetData || //첫 인덱스의 값이 찾는 값보다 크면
                    _data[_lastIndex]  < _targetData)   //마지막 인덱스의 값이 찾는 값보다 작으면
                    // 첫번째와 마지막 인덱스를 비교하는 과정을 추가하면 loopCount는 줄어들지만 성능에는 크게 관여하지 않음
                    return (false, _loopCount);         //false 반환
            }
        }
    }
}