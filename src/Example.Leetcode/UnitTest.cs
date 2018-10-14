using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS = Example.Leetcode.DataStructure;

namespace Example.Leetcode
{
    public class UnitTest
    {
        public class TestArrayObj
        {
            public int Value { get; set; }
            public override string ToString()
            {
                return Value.ToString();
            }
        }
        public void TestArray()
        {
            var array = new DS.Array<int>(10);
            for (int i = 0; i < 11; i++)
            {
                array.Insert(i);
            }

            Console.WriteLine("插入");
            Console.WriteLine(array);
            Console.WriteLine($"删除index={0}");
            array.Delete(0);
            Console.WriteLine(array);
            Console.WriteLine($"删除index={5}");
            array.Delete(5);
            Console.WriteLine(array);
            Console.WriteLine($"删除index={7}");
            array.Delete(7);
            Console.WriteLine(array);
        }
    }
}
