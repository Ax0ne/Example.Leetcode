using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Leetcode.DataStructure
{
    public interface IQueue
    {
        bool Enqueue(int value);
        int Dequeue();
    }
    public class ArrayQueue:IQueue
    {
        public bool Enqueue(int value)
        {
            var q = new System.Collections.Queue();
            //Array.Clear
            //Array.Copy()
            q.Dequeue();
            throw new NotImplementedException();
        }

        public int Dequeue()
        {
            throw new NotImplementedException();
        }
    }
}
