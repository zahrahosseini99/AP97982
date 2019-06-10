using System;
using System.Collections.Generic;
using System.Timers;

namespace E2
{
    public class DuplicateNumberDetector
    {
        public Action a;
        public void AddNumber(int n)
        {
           
        }

        public event Action<int> DuplicateNumberAdded;
    }
}