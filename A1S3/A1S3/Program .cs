using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A1S3
{
    public class Program
    {
        static void Main(string[] args)
        {



            string pospath = @"C:\git\AP97982\A1S3\A1S3\TwitterData\Words\positive.txt";
            string[] posWords = Q1_GetWords(pospath);

            string negpath = @"C:\git\AP97982\A1S3\A1S3\TwitterData\Words\negative.txt";
            string[] negWords = Q1_GetWords(negpath);

            string[] filePath = Directory.GetFiles(@"C:\git\AP97982\A1S3\A1S3\TwitterData\Tweets");
            string[] data = new string[19];
            for (int i = 0; i < 19; i++)
            {
                string tweetpath = filePath[i];
                int index = tweetpath.LastIndexOf('\\');
                string name1 = tweetpath.Substring(index + 1);
                int index1 = name1.LastIndexOf('.');
                string name = name1.Substring(0, index1);
                string[] tweets = File.ReadAllLines(tweetpath);
                //string[] TweetAndMentions = alltweet.Split('\n');
                //string tweet = Convert.ToString(tweets);

                data[i] = name + ":" + Q5_GetAvgPopChargeOfTweets(tweets, negWords, posWords);


            }
            File.WriteAllLines(@"..\..\result.txt", data);

        }
        public static string[] Q1_GetWords(string path)
        {
            string content = File.ReadAllText(path);
            string[] words = content.Split(new char[] { '\n', '\r', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return words;
        }
        public static bool Q2_IsInWords(string[] words, string word)
        {
            foreach (string w in words)
            {
                if (w == word)
                    return true;
            }
            return false;
        }
        public static string[] Q3_GetWordsOfTweet(string tweet)
        {
            List<string> res = new List<string>();
            string[] str = tweet.Split(' ', '?', '@', '!');
            foreach (var s in str)
            {
                if (s != "")
                {
                    res.Add(s);
                }
            }
            string[] res1 = new string[res.Count];
            for (int i = 0; i < res.Count; i++)
            {
                res1[i] = res[i];
            }
            return res1;
        }
        public static int Q4_GetPopChargeOfTweet(string tweet, string[] posWords, string[] negWords)
        {
            int score = 0;
            foreach (string pos in posWords)
            {

                if (tweet.Contains(pos))

                    score++;

            }
            foreach (string neg in negWords)
            {

                if (tweet.Contains(neg))

                    score--;

            }
            return score;
        }



        public static double Q5_GetAvgPopChargeOfTweets(string[] tweets, string[] negWords, string[] posWords)
        {
            double countpos = 0;
            double countneg = 0;
            double sum = 0;
            foreach (string tweetline in tweets)
            {
                var tweetWords = Q3_GetWordsOfTweet(tweetline);
                foreach (string word in tweetWords)
                {
                    if (negWords.Contains(word) && word != "")
                        countneg--;
                    sum++;
                }
            }
            foreach (string tweetline in tweets)
            {
                var tweetWords = Q3_GetWordsOfTweet(tweetline);
                foreach (string word in tweetWords)
                {
                    if (posWords.Contains(word) && word != "")
                        countpos++;
                    sum++;
                }
            }
            return (countpos + countneg) / sum;

        }
    }
}
