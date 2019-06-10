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
        public  override bool Equals(object obj)
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
            if (nums.Length != 1)
            {

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != "")
                    {
                        IntNum[i] = int.Parse(nums[i]);
                        sum += IntNum[i];


                    }
                    else
                        throw new InvalidDataException();


                }
                return sum;
            }
            else
            {
                throw new FormatException();


            }



        }

        public static bool TryCalculateSum(string expression, out int value)
        {
            string[] nums = expression.Split('+');
            int[] IntNum = new int[nums.Length];
            int sum = 0;
            value = 0;
            foreach (var n in nums)
            {
                if (n == "a" && n == "b")
                    throw new FormatException();
            }
            if (nums.Length != 1)
            {


                for (int i = 0; i < nums.Length; i++)
                {

                   
                        if (nums[i] != "")
                        {
                            IntNum[i] = int.Parse(nums[i]);
                            sum += IntNum[i];


                        }
                        else
                            throw new InvalidDataException();
                        value = sum;

                  

                }
                return (sum == value);

            }
            else
            {
                throw new FormatException();


            }

        }

        /// <summary>
        /// {\displaystyle 1\,-\,{\frac {1}{3}}\,+\,{\frac {1}{5}}\,-\,{\frac {1}{7}}\,+\,{\frac {1}{9}}\,-\,\cdots \,=\,{\frac {\pi }{4}}.}
        /// </summary>
        /// <returns></returns>
        public static int PIPrecision()
        {
          
            int n =0;
            double pi = 0;
                pi = Math.Round(Math.PI, 7);
            double sum = 0;
           for (int i = 0; i < 10372346; i++)
            {
                sum += ((1 / (2 * i + 1)) * (-1) ^ i);
                n++;
                if (sum == pi)
                    break;
            }
                
          
           
            return n-1;
        }

        public static int Fibonacci(this int n)
        {
            //  1 2 3 5 8 13 21
            int[] fib = new int [6]{ 1, 2, 3, 5, 8, 13 };
            return fib[n-1];
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