using System;
using System.Collections;
using System.Collections.Generic;

namespace Divide_n_Conquer
{
    public static class Tools
    {
        public static void Print(this IEnumerable _data)
        {
            int _idx = 0;
            foreach (object _d in _data)
            {
                Console.Write(_idx++ + ". " + _d + "\n");
            }

            Console.WriteLine();
        }

        public static void Print(this IList _data, int _target1, int _target2) //변경사항 표시용 프린트
        {
            for (int _index = 0; _index < _data.Count; _index++)
            {
                int _maxDigitCount = RandomDataMaker.MAX_NUM_SIZE.GetDigitCount() - 1;
                    
                if (_index == _target1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{_index}. {_data[_target1].ToString().PadRight(_maxDigitCount)} -> ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{_data[_target2].ToString().PadRight(_maxDigitCount)}\n");
                    Console.ResetColor();
                }
                else if (_index == _target2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{_index}. {_data[_target2].ToString().PadRight(_maxDigitCount)} -> ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{_data[_target1].ToString().PadRight(_maxDigitCount)}\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"{_index}. {_data[_index].ToString().PadRight(_maxDigitCount)} -> ");
                    Console.Write($"{_data[_index].ToString().PadRight(_maxDigitCount)}\n");
                }
            }

            Console.WriteLine();
        }

        public static void Swap<T>(this IList<T> _target, int _idx1, int _idx2)
        {
            (_target[_idx1], _target[_idx2]) = (_target[_idx2], _target[_idx1]);
        }

        public static int GetDigitCount(this int _num)
        {
            int _count = 0;
            while (_num > 0)
            {
                _num /= 10;
                _count++;
            }

            return _count;
        }
    }
}