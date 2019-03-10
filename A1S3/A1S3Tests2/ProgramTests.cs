using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void Q1_GetWordsTest()
        {
            string[] expectedResult = {"salam","","vaght","","bekhir"};

            string path = @"..\..\..\test.txt";

            string[] functionResult = Program.Q1_GetWords(path);

            CollectionAssert.AreEqual(expectedResult, actual: functionResult);
        }

        [TestMethod()]
        public void Q2_IsInWordsTest()
        {

            bool expectedResult =true;

            string []words = { "this", "is", "test" };
            string word = "this";
            bool functionResult = Program.Q2_IsInWords(words,word);
            Assert.AreEqual(expectedResult, actual: functionResult);
        }

        [TestMethod()]
        public void Q3_GetWordsOfTweetTest()
        {
            string[] expectedResult = {"is","it"};

            string tweet = "is?it";

            string [] functionResult = Program.Q3_GetWordsOfTweet(tweet);
           
               CollectionAssert.AreEqual(expectedResult, actual: functionResult);
            
           
        }

        [TestMethod()]
        public void Q4_GetPopChargeOfTweetTest()
        {
            int expectedResult = 1;
            string tweet = "ziba khandan ama gahi biadab ast";
            string[] posWords = { "ziba", "khandan" };
            string[] negWords = { "biadab" };
            int functionResult = Program.Q4_GetPopChargeOfTweet(tweet, posWords, negWords);
            Assert.AreEqual(expectedResult, actual: functionResult);
        }
        [TestMethod()]
        public void Q5_GetAvgPopChargeOfTweetsTest()
        {
            double expectedResult = 0;
            string[] tweet = {"ziba"," khandan","ama","gahi","biadab","zesht"};
            string[] posWords = { "ziba", "khandan" };
            string[] negWords = { "biadab","zesht" };
            double functionResult = Program.Q5_GetAvgPopChargeOfTweets(tweet, posWords, negWords);
            Assert.AreEqual(expectedResult, actual: functionResult);
        }
    }
}