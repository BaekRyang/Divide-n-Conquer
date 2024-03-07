using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Divide_n_Conquer
{
    public class RandomDataMaker
    {
        private const  int    MAX_NUM_SIZE = 100000;
        private static Random _random;

        public static IEnumerable<T> MakeData<T>(int _size, bool _allowDuplicates = false)
        {
            Type _type = typeof(T);

            switch (_type)
            {
                case Type _t when _t == typeof(int):
                {
                    return MakeIntData<T>(_size, _allowDuplicates);
                }
                default:
                    throw new NotImplementedException();
            }
        }

        private static IEnumerable<T> MakeIntData<T>(int _size, bool _allowDuplicates)
        {
            if (_size <= 0 || _size > MAX_NUM_SIZE) throw new ArgumentOutOfRangeException(nameof(_size));
            _random = new Random();
            
            //랜덤 시드 지정

            //임시 데이터 생성
            ICollection<int> _data = Enumerable.Range(1, MAX_NUM_SIZE).ToList();
            
            if (_allowDuplicates)
            {
                for (int i = 0; i < _size; i++) 
                    yield return (T) Convert.ChangeType(_random.Next(1, MAX_NUM_SIZE), typeof(T));
            }
            else
            {
                for (int i = 0; i < _size; i++)
                {
                    int _randomData = _data.ElementAt(_random.Next(0, _data.Count));
                    _data.Remove(_randomData);
                    yield return (T) Convert.ChangeType(_randomData, typeof(T));
                }
            }
        }
    }
}