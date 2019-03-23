using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Example.Leetcode.Algorithm
{
    public class AlgorithmTest
    {
        public static void TestSnowflake()
        {
            var array = new long[1000];
            Parallel.For(0, 1000, i => { array[i] = SnowFlake.Instance().NextId(); });
            Console.WriteLine("Distinct count:" + array.Distinct().Count());
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
