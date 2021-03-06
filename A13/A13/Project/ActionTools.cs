﻿using System;
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

            var list = new List<Task>();
            Stopwatch time = new Stopwatch();
            time.Start();
            foreach (var s in actions)
            {
                list.Add(Task.Run(s));
            }
            var a = Task.WhenAll(list);
            a.Wait();
            time.Stop();
            return time.ElapsedMilliseconds;
        }

        public static long CallParallelThreadSafe(int count, params Action[] actions)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            foreach (var act in actions)
            {
                for (int i = 0; i < count; i++)
                {
                    Task t = new Task(() => act());
                    Task.Run(() => t.Start());
                    t.Wait();



                }
            }

            time.Stop();
            return time.ElapsedMilliseconds;
        }


        public static async Task<long> CallSequentialAsync(params Action[] actions)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            for (int i = 0; i < actions.Length; i++)
            {
                await Task.Run(() => actions[i]());

            }
            time.Stop();
            return time.ElapsedMilliseconds;

        }

        public static async Task<long> CallParallelAsync(params Action[] actions)
        {
            Stopwatch time = new Stopwatch();
            time.Start();
            var list = new List<Task>();
            foreach (var act in actions)
            {
                Task t = new Task(() => act());
                list.Add(t);
                await Task.Run(() => t.Start());
            }
            Task.WaitAll(list.ToArray());
            time.Stop();
            return time.ElapsedMilliseconds;
        }

        public static async Task<long> CallParallelThreadSafeAsync(int count, params Action[] actions)
        {

            Stopwatch time = new Stopwatch();
            time.Start();


            foreach (var act in actions)
            {
                for (int i = 0; i < count; i++)
                {
                    Task t = new Task(() => act());
                    await Task.Run(() => t.Start());
                    t.Wait();



                }
            }

            time.Stop();
            return time.ElapsedMilliseconds;
        }
    }
}