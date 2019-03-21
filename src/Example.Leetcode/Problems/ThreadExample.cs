using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example.Leetcode.Problems
{
    public class ThreadExample
    {
        /// <summary>
        /// 两个线程交替打印0~100的奇偶数
        /// </summary>
        public static void PrintOddEvenNumber()
        {
            var work = new TheadWorkTest();
            var thread1 = new Thread(work.PrintOddNumer) { Name = "奇数线程" };
            var thread2 = new Thread(work.PrintEvenNumber) { Name = "偶数线程" };
            thread1.Start();
            thread2.Start();
        }
        /// <summary>
        /// N个线程顺序循环打印从0至100
        /// </summary>
        /// <param name="n"></param>
        public static void PrintNumber(int n = 3)
        {
            var work = new TheadWorkTest { Semaphores = new Semaphore[n] };
            for (var i = 0; i < n; i++)
            {
                work.Semaphores[i] = new Semaphore(1, 1);
                if (i != n - 1)
                    work.Semaphores[i].WaitOne();
            }
            for (var i = 0; i < n; i++)
            {
                new Thread(work.PrintNumber) { Name = "线程" + i }.Start(i);
            }
        }
    }

    public class TheadWorkTest
    {
        private static readonly AutoResetEvent oddAre = new AutoResetEvent(false);
        private static readonly AutoResetEvent evenAre = new AutoResetEvent(false);
        public void PrintOddNumer()
        {
            oddAre.WaitOne();
            for (var i = 0; i < 100; i++)
            {
                if (i % 2 != 1) continue;
                Console.WriteLine($"{Thread.CurrentThread.Name}：{i}");
                evenAre.Set();
                oddAre.WaitOne();
            }
        }
        public void PrintEvenNumber()
        {
            for (var i = 0; i < 100; i++)
            {
                if (i % 2 != 0) continue;
                Console.WriteLine($"{Thread.CurrentThread.Name}：{i}");
                oddAre.Set();
                evenAre.WaitOne();
            }
        }
        public Semaphore[] Semaphores { get; set; }
        public static int index;
        public void PrintNumber(object c)
        {
            var i = Convert.ToInt32(c);
            var preSemaphore = i == 0 ? Semaphores[Semaphores.Length - 1] : Semaphores[i - 1];
            var curSemaphore = Semaphores[i];
            while (true)
            {
                preSemaphore.WaitOne();
                Interlocked.Increment(ref index);
                if (index > 99)
                    return;
                Console.WriteLine($"{Thread.CurrentThread.Name}：{index}");
                curSemaphore.Release();
            }
        }
    }
}
