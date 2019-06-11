using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace A13
{
    public static class ActionTools
    {
        public static long CallSequential(params Action[] actions)
        {
            Stopwatch time = new Stopwatch();
            List<Action> a = new List<Action>();
            time.Start();
            for (int i = 0; i < actions.Length; i++)
            {
                actions[i]();

            }
            time.Stop();
            return time.ElapsedMilliseconds;
        }

        public static long CallParallel(params Action[] actions)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            Parallel.Invoke(actions);
            time.Stop();
            return time.ElapsedMilliseconds;
        }
        public static object async = new object();
        public static long CallParallelThreadSafe(int count, params Action[] actions)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            for (int i = 0; i < count; i++)
            {
                lock (async)
                {
                    Parallel.Invoke(actions);
                }
            }
            time.Stop();
            return time.ElapsedMilliseconds;
        }


        public static async Task<long> CallSequentialAsync(params Action[] actions)
        {
            Stopwatch time = new Stopwatch();
            List<Action> a = new List<Action>();
            time.Start();
            for (int i = 0; i < actions.Length; i++)
            {
              await Task.Run(()=>actions[i]());

            }
            time.Stop();
            return time.ElapsedMilliseconds;

        }

        public static async Task<long> CallParallelAsync(params Action[] actions)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            List<Task> mytasks = new List<Task>();
            foreach (var act in actions)
            {
                Task t = new Task(() =>act());
                mytasks.Add(t);
                await Task.Run(()=>t.Start());
            }
            Task.WaitAll(mytasks.ToArray());
            time.Stop();
            return time.ElapsedMilliseconds;
        }

        public static async Task<long> CallParallelThreadSafeAsync(int count, params Action[] actions)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            for (int i = 0; i < count; i++)
            {    Task t = new Task(() => actions[i]());
                    await Task.Run(() => t.Start());
                    t.Wait();
}
            time.Stop();
            return time.ElapsedMilliseconds;
        }
    }
}