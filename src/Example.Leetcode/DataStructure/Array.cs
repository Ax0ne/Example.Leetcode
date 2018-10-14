using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Leetcode.DataStructure
{
    public class Array<T>
    {
        // 数组实际个数
        private int count = 0;
        // 初始化大小
        private int size = 0;
        // 存储数据的data
        private T[] data;

        public Array(int capacity)
        {
            data = new T[capacity];
            size = capacity;
        }

        private int FindIndex(T value)
        {
            for (int i = 0; i < count; i++)
            {
                if (data[i].Equals(value))
                    return i;
            }
            return -1;
        }
        public T Find(int index)
        {
            if (index > count - 1)
                return default(T);
            return data[index];
        }

        public void Insert(T value)
        {
            // 不能超过数组大小
            if (count == size) return;
            data[count++] = value;
        }
        // index后面的数据向后移动一位
        public void Insert(int index, T value)
        {
            if (index >= count || index < 0)
                return;
            // 如果是直接插入到尾部 O(1)
            if (index == count - 1)
            {
                data[index] = value;
                return;
            }

            var temp = value;
            for (int i = count - 1; i > 0; i--)
            {
                data[i] = data[i - 1];
            }
            data[index] = value;
            ++count;
        }
        // 删除 index后的数据向前移动一位
        public bool Delete(int index)
        {
            if (index > count - 1)
                return false;
            if (index == count - 1)
            {
                --count;
                return true;
            }
            for (; index < count - 1; index++)
            {
                data[index] = data[index + 1];
            }
            --count;
            return true;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append(data[i] + "-");
            }

            return sb.ToString().TrimEnd('-');
        }
    }
}
