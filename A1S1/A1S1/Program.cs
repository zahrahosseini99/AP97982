using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace A1S1
{
    public class Program
    {
        public static void Main(string[] args)
        {

        }

        public static int CaculateLength(string str)
        {
            int sL = str.Length;
            return sL;
        }

        public static int LetterCount(string str)
        {
            string[] s = str.Split();
            int count = 0;
            foreach (string Subs in s)
            {
                char[] charofs = Subs.ToCharArray();
                foreach (char ch in charofs)
                {
                    if (char.IsLetter(ch))
                        count++;
                }
            }
            return count;
        }

        public static int LineCount(string str)
        {
            string[] lines = str.Split('\n');
            return lines.Length;

        }
        public static int FileLineCount(string filePath)
        {

            string content = File.ReadAllText(filePath);
            string[] lines = content.Split('\n');
            return lines.Length-1;
        }

        public static string[] ListFiles(string dirPath)
        {
            List<string> files = new List<string>();
            files.AddRange(Directory.GetFiles(dirPath));
            files.Sort();
            return files.ToArray();

        }


        public static double FileSize(string filePath)
        {
            double Count = 0;
            string[] content = File.ReadAllText(filePath).Split('\n');
            foreach (var s in content)
            {
                Count += s.Length;
            }
            return Count;
        }
    }
}