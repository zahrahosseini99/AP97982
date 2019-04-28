using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    public class Program
    {
        private static void Main(string[] args)
        {
<<<<<<< HEAD
=======

        }
>>>>>>> 100ad1cc82c95ac86463775aceea9c4f182ae879

        }
        public static void ArraySwap(ref int[] array1, ref int[] array2)
        {
            int[] tmp = array1;
            array1 = array2;
            array2 = tmp;
<<<<<<< HEAD
            Console.WriteLine(array2);
=======

            Console.WriteLine(array2);


>>>>>>> 100ad1cc82c95ac86463775aceea9c4f182ae879
        }

        public static void ArraySwap(int[] array1, int[] array2)
        {
            int temp = 0;
            for (int i = 0; i < array1.Length; i++)
            {
<<<<<<< HEAD
               temp = array1[i];
                array1[i] = array2[i];
                array2[i] = temp;
=======

                temp = array1[i];
                array1[i] = array2[i];
                array2[i] = temp;

>>>>>>> 100ad1cc82c95ac86463775aceea9c4f182ae879
            }

        }

        public static void AbsArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Math.Abs(array[i]);
            }
        }

        public static void Append(ref int[] array, int f)
        {
            int[] arr = new int[array.Length + 1];

            int temp;
            for (int i = 0; i < array.Length; i++)
            {
                temp = array[i];
                array[i] = arr[i];
                arr[i] = temp;
            }
            arr[array.Length] = f;
            array = arr;
        }

        public static void Sum(out int e, params int[] nums)
        {
            e = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                e += nums[i];
            }
        }

        public static void Swap(ref int c, ref int d)
        {
            int temp = c;
            c = d;
            d = temp;
        }

        public static void Square(ref int b)
        {
            b = b * b;
        }

        public static void AssignPi(out double a)
        {
            a = Math.PI;
        }
    }
}
