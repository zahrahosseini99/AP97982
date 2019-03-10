using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A1S2
{
    class Program
    {
        static long sum = 0;
        static void Main(string[] args)
        {

            string path = Console.ReadLine();
            Console.WriteLine(FolderSize(path));
        }
        public static double FolderSize(string path)

        {

            string[] fileEntries = Directory.GetFiles(path);
            string[] folders = Directory.GetDirectories(path);

            foreach (string fileName in fileEntries)
            {
                FileInfo size = new FileInfo(fileName);
                sum += size.Length;

            }
            foreach (var sub in folders)
            {
                FolderSize(sub);
            }

            return sum;

        }
    }
}
