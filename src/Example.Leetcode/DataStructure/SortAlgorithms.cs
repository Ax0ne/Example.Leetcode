using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Leetcode.DataStructure
{
    public interface ISortAlgorithm
    {
        int[] Run(int[] array);
    }
    public class SortAlgorithms //: ISortAlgorithm
    {
        public static int[] BubbleSort(int[] array)
        {
            if (array == null || array.Length == 0)
                return new int[0];
            for (var i = 0; i < array.Length; i++)
            {
                var flag = false;
                for (var j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        flag = true;
                    }
                }

                if (!flag) break;
            }
            return array;
        }
        public static int[] InsertSort(int[] array)
        {
            if (array == null || array.Length == 0)
                return new int[0];
            for (var i = 1; i < array.Length; i++)
            {
                var value = array[i];
                var j = i - 1;
                for (; j >= 0; j--)
                {
                    if (array[j] > value)
                    {
                        array[j + 1] = array[j];
                    }
                    else
                        break;
                }
                array[j + 1] = value;
            }
            return array;
        }
        public static int[] MergeSort(int[] array)
        {
            if (array == null || array.Length == 0)
                return new int[0];
            if (array.Length == 1) return array;
            var mi = array.Length / 2;
            var left = array.Take(mi).ToArray();
            var right = array.Skip(mi).ToArray();
            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }
        private static int[] Merge(int[] left, int[] right)
        {
            var result = new int[left.Length + right.Length];
            int li = 0, ri = 0, mi = 0;
            while (li < left.Length && ri < right.Length)
            {
                if (left[li] < right[ri])
                {
                    result[mi] = left[li];
                    ++li;
                }
                else
                {
                    result[mi] = right[ri];
                    ++ri;
                }
                ++mi;
            }

            if (li < left.Length)
            {
                for (var i = li; i < left.Length; i++)
                {
                    result[mi] = left[i];
                    ++mi;
                }
            }
            else
            {
                for (var i = ri; i < right.Length; i++)
                {
                    result[mi] = right[i];
                    ++mi;
                }
            }

            return result;
        }
        // 非原地排序
        public static List<int> QuickSort(List<int> list)
        {
            if (list == null || list.Count == 0)
                return new List<int>();
            if (list.Count == 1)
                return list;
            var pivotIndex = list.Count / 2;
            var pivot = list[pivotIndex];
            var left = new List<int>();
            var right = new List<int>();
            if (list.Count == 2)
            {
                left.Add(list.Min());
                right.Add(list.Max());
            }
            else
            {
                foreach (var value in list)
                {
                    if (value < pivot)
                        left.Add(value);
                    else
                        right.Add(value);
                }
            }

            var result = QuickSort(left).Concat(QuickSort(right));
            return result.ToList();
        }
        // 原地排序
        public static int[] QuickSort(int[] array)
        {
            Partition(array, 0, array.Length - 1);
            return array;
        }
        private static void Partition(int[] array, int left, int right)
        {
            if (left < right)
            {
                var pivot = array[(left + right) / 2];
                var i = left - 1;
                var j = right + 1;
                while (true)
                {
                    while (array[++i] < pivot) ;
                    while (array[--j] > pivot) ;
                    if (i >= j)
                        break;
                    Swap(array, i, j);
                }

                Partition(array, left, i - 1);
                Partition(array, j + 1, right);
            }
        }

        public static int[] BucketSort(int[] array)
        {
            int min = array[0], max = array[0];
            foreach (var n in array)
            {
                if (n < min)
                    min = n;
                if (n > max)
                    max = n;
            }

            //var elementCount = array.Length <= 10 ? 1 : 10;
            var baseCount = 10;
            var bucketCount = max / baseCount - min / baseCount + 1;
            var buckets = new List<List<int>>();
            while (--bucketCount >= 0)
            {
                buckets.Add(new List<int>());
            }

            foreach (var value in array)
            {
                buckets[(value - min) / baseCount].Add(value);
            }

            var index = 0;
            foreach (var bucket in buckets)
            {
                var nums = InsertSort(bucket.ToArray());
                foreach (var v in nums)
                {
                    array[index] = v;
                    ++index;
                }
            }

            return array;
        }

        private static void Swap(int[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
