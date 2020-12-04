using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Test_WhenAll_vs_WaitAll
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            List<Task<int>> tasks = new List<Task<int>>();
            for (int i = 1; i <= 5; i++)
            {
                Task<int> task = Task.Run(() => Test());
                tasks.Add(task);
            }

            foreach(var i in await Task.WhenAll(tasks))
            {
                Console.WriteLine(i);
            }
            timer.Stop();
            TimeSpan ts = timer.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
              ts.Hours, ts.Minutes, ts.Seconds,
              ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);

        }

        private static int Test()
        {
            Thread.Sleep(2000);
            Random random = new Random();
            return random.Next(1, 5);
        }
    }
}
