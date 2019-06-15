using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace E2
{
    public static class DotNetInterfaces
    {
        public static IEnumerable<long> GetElapsedTimes(int max = 100)
        {

            //Stopwatch time = new Stopwatch();
            //yield return 0;
            //long t;
            //for (int i = 0; i < max; i++)
            //{
            //   time.Start();

            //    t = time.ElapsedMilliseconds;
            //    yield return t ;
            //}


            //time.Stop();
            Stopwatch time = new Stopwatch();
            time.Start();
            yield return 0;
            for (int i = 0; i < max; i++)
            {
                time.Stop();
                long time1 = time.ElapsedMilliseconds;
                time = new Stopwatch();
                time.Start();
                yield return time1;

            }
            time.Stop();


        }
    }
}