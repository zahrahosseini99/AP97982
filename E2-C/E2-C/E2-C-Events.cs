using System;
using System.Collections.Generic;
using System.Timers;

namespace E2
{
    public class DuplicateNumberDetector
    {
        int i=0;
        List<int> Numbers = new List<int>();
        public void AddNumber(int n)
        {
            if (Numbers.Contains(n))
                DuplicateNumberAdded(i++);
            else
                Numbers.Add(n);
           
           
        }

        public event Action<int> DuplicateNumberAdded;
    }
}