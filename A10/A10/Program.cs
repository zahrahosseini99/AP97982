using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A10
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector<int> v = new Vector<int>(2)
            {
                1,2
            };

            int i = v[1];

            v[0] = 4;
        }
    }
}
