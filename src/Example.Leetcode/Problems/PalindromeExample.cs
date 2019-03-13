using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Leetcode.Problems
{
    public class PalindromeExample
    {
        public static bool IsPalindrome(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            var i = 0;
            var j = value.Length - 1;
            for (; i <= j; i++, j--)
            {
                if (value[i] != value[j])
                    return false;
            }
            return true;
        }

        private static LinkedList<string> _linked = new LinkedList<string>();
        public static bool IsPalindromeLinked(string value)
        {
            value.ToCharArray().ToList().ForEach(p => _linked.AddLast(p + ""));
            //var node = _linked.First.Previous;
            var head = _linked.First;
            var tail = _linked.Last;
            while (head.Next != null)
            {
                while (tail.Previous != null)
                {
                    if (head.Value != tail.Value)
                        return false;
                    tail = tail.Previous;
                    if (tail == head) return true;
                    break;
                }
                head = head.Next;
            }
            return true;
        }
    }
}
