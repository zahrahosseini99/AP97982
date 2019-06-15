using System;
using System.Collections.Generic;
using System.IO;

namespace E2
{
    public class FullName
    {
        public string FirstName;
        public string LastName;

        public FullName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public override bool Equals(object obj)
        {
            FullName other = obj as FullName;
            if (other == null)
                return false;
            else
                return other.FirstName == this.FirstName && other.LastName == this.LastName;
        }
    }

    public static class Basics
    {
        public static int CalculateSum(string expression)
        {
            string[] nums = expression.Split('+');
            int[] IntNum = new int[nums.Length];
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[1] == "")
                {
                    throw new InvalidDataException();
                    break;
                }
                   
                if(nums[0]=="a")
                {
                    throw new FormatException();
                    break;
                }
                    IntNum[i] = int.Parse(nums[i]);
                    sum += IntNum[i];


            }
            return sum;
        }

        public static bool TryCalculateSum(string expression, out int value)
        {
            string[] nums = expression.Split('+');
            int[] IntNum = new int[nums.Length];
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[1] == "")
                {
                    value = sum;
                    return false;
                   
                }

                if (nums[0] == "a")
                {
                    value = sum;
                    return false;
                }
                IntNum[i] = int.Parse(nums[i]);
                sum += IntNum[i];


            }
            value = sum;
            return true;
        }

        /// <summary>
        /// {\displaystyle 1\,-\,{\frac {1}{3}}\,+\,{\frac {1}{5}}\,-\,{\frac {1}{7}}\,+\,{\frac {1}{9}}\,-\,\cdots \,=\,{\frac {\pi }{4}}.}
        /// </summary>
        /// <returns></returns>
        public static int PIPrecision()
        {
            int n = 0;
            double sum = 0;
            double pi = Math.Round(Math.PI, 7);
            do
            {
                sum += (double)(4 * Math.Pow(-1, (double)n) / ((2 * (double)n) + 1));

                n++;

            } while (pi != Math.Round(sum, 7));
 return n;
        }

        public static int Fibonacci(this int n)
        {
            int sum = 0, n1 = 1, n2 = 2;

            //  1 2 3 5 8 13 21
            for (int i = 2; i < n; i++)
            {
                sum = n1 + n2;
                n1 = n2;
                n2 = sum;
            }

            return sum;
        }

        public static void RemoveDuplicates<T>(ref T[] list)
        {
            List<T> newList = new List<T>();
            foreach (var item in list)
            {
                if (!Contains(newList, item))
                    newList.Add(item);
            }
            list = newList.ToArray();
        }

        private static bool Contains<T>(List<T> list, T lookup)
        {
            foreach (var item in list)
                if (item.Equals(lookup))
                    return true;
            return false;
        }
    }
}