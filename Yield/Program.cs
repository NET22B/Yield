using System;
using System.Collections.Generic;
using System.Linq;

namespace Yield
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (int item in GetNumbers())
            {
                Console.WriteLine(item);
            }

            var numbers = GetNumbers();
            IEnumerator<int> enumerator = numbers.GetEnumerator();

            while (enumerator.MoveNext())
            {
                int item = enumerator.Current;
                Console.WriteLine(item);
            }

            foreach (var item in GetNumbersOrdinary().Take(10))
            {
                Console.WriteLine(item);
            }
            
            foreach (var item in GetNumbersYield().Take(10))
            {
                Console.WriteLine(item);
            }
        }

        private static IEnumerable<int> GetNumbersYield()
        {
            var i  = 0;

            while (true)
            {
                yield return ++i;
            }
        }

        private static IEnumerable<int> GetNumbersOrdinary()
        {
            int i = 0;
            var result = new List<int>();

            while(i < 1000000)
            {
                result.Add(++i);
            }

            return result;
        }

        private static IEnumerable<int> GetNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
            yield return 6;
        }
    }
}
