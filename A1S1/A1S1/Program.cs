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

        public static  int CaculateLength(string str)
        {
           
            int sL = str.Length;
            return sL;
        }

        public static int LetterCount(string str)
        {
            string[] s = str.Split();
            int count = 0;
            foreach (string Ss in s)
            {
                count += Ss.Length;
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
           // string dir = Directory.GetCurrentDirectory();
           
            string content = File.ReadAllText(filePath);
            string[] lines = content.Split('\n');
            return lines.Length;


        }

        public static string[] ListFiles(string dirPath)
         {

             string[] filesArray = Directory.GetFiles(dirPath);
             return filesArray;
        }


public double FileSize(string filePath)
        {
            
            string[] files = Directory.GetFiles(filePath);
            foreach(string file in files)
            {
                FileInfo fi = new FileInfo(file);
                return fi.Length;
            }
            return 0;
        }

    }
}