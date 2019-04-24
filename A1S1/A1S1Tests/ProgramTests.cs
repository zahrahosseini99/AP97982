using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1S1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A1S1.Tests
{
    [TestClass()]
    public class ProgramTests
    {


        [TestMethod()]
        public void CaculateLengthTest()
        {
            int expectedResult = 21;

            string str = "this is a test string";
            int sL = str.Length;
            int functionResult = Program.CaculateLength(str);
            Assert.AreEqual(expectedResult, actual: functionResult);
        }

        [TestMethod()]
        public void LetterCountTest()
        {
            int expectedResult = 17;

            string str = "this ! is a . @ test string";

            int functionResult = Program.LetterCount(str);
            Assert.AreEqual(expectedResult, actual: functionResult);

        }

        [TestMethod()]
        public void LineCountTest()
        {
            int expectedResult = 3;

            string str = "It looks like you are calling a non static property from a static method." + "\n" +
                " You will need to either make the property static," + "\n" +
                " or create an instance of Form1.";

            int functionResult = Program.LineCount(str);
            Assert.AreEqual(expectedResult, actual: functionResult);
            string str1 = "salam javane irani";
            int expectedResult1 = 1;
            int functionResult1 = Program.LineCount(str1);
            Assert.AreEqual(expectedResult1, actual: functionResult1);

        }


        [TestMethod()]
        public void FileLineCountTest()
        {
            int linecount;

            int charCount;
            string str = GetTestFile(out linecount, out charCount);
            int expectedResult = linecount;
            int functionResult = Program.FileLineCount(str);
            Assert.AreEqual(expectedResult, functionResult);


        }

        [TestMethod()]
        public void ListFilesTest1()
        {
            string Dir;

            List<string> files = new List<string>();
            files.AddRange(GetTestDir(out Dir));
            files.Sort();
            string[] functionResult = Program.ListFiles(Dir);

            Assert.AreEqual(files.ToArray(), functionResult);

        }

        [TestMethod()]
        public void FileSizeTest()
        {
            int lineCount;
            int charCount;
            string s = GetTestFile(out lineCount, out charCount);
            double functionResualt = Program.FileSize(s);
            double expectedResult = charCount;
            Assert.AreEqual(expectedResult, functionResualt);
        }
        private static string[] GetTestDir(out string tmpDir)
        {
            tmpDir = Path.GetTempFileName();
            if (File.Exists(tmpDir))
                File.Delete(tmpDir);

            if (!Directory.Exists(tmpDir))
                Directory.CreateDirectory(tmpDir);
            else
                foreach (string file in Directory.GetFiles(tmpDir))
                    File.Delete(file);

            int rndNum = new Random(0).Next(10, 20);
            List<string> files = new List<string>();
            for (int i = 0; i < rndNum; i++)
            {
                string fileName = Path.Combine(tmpDir, $"file{i}.txt");
                File.WriteAllText(fileName, $"file{i}.txt content");
                files.Add(fileName);
            }
            return files.ToArray();
        }
        private static string GetTestFile(out int lineCount, out int charCount)
        {
            charCount = 0;
            string tmpFile = Path.GetTempFileName();
            lineCount = new Random(0).Next(10, 100);
            List<string> lines = new List<string>();
            for (int i = 0; i < lineCount; i++)
            {
                string line = $"Line number {i}";
                charCount += line.Length;
                lines.Add(line);
            }
            File.WriteAllLines(tmpFile, lines);
            return tmpFile;
        }
    }
}