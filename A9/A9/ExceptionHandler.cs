using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace A9
{
    public class ExceptionHandler
    {

        public string ErrorMsg { get; set; }
        public readonly bool DoNotThrow;
        private string _Input;

        public string Input
        {
            get
            {
                try
                {
                    if (null != _Input)
                        return _Input;

                    else throw new NullReferenceException();

                }

                catch (NullReferenceException)
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in GetMethod";
                }
                return null;
            }
            set
            {

                try
                {
                    if (value.Length < 50)
                        _Input = value;
                    else
                        throw new NullReferenceException();
                }

                catch (NullReferenceException)
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in SetMethod";
                }
            }
        }



        public ExceptionHandler(
            string input,
            bool causeExceptionInConstructor,
            bool doNotThrow = false)
        {
            //CauseExceptionInConstructor = causeExceptionInConstructor;
            DoNotThrow = doNotThrow;
            this._Input = input;
            try
            {
                if (causeExceptionInConstructor)
                {
                    input = null;
                    Console.Write(input.Length);
                }


            }
            catch (NullReferenceException N)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception in constructor";
            }
        }

        public void OverflowExceptionMethod()
        {
            try
            {
                int i = int.MaxValue;
                int j = 9;
                checked
                {
                    j++;
                }
                checked
                {
                    i++;

                }
            }
            catch (OverflowException e)
            {
                if (!DoNotThrow)
                    throw;

                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FormatExceptionMethod()
        {
            try
            {
                int i = int.Parse(Input);
            }
            catch (FormatException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }


        public void FileNotFoundExceptionMethod()
        {
            try
            {
                Input = File.ReadAllLines("myfilename.txt").ToString();
            }
            catch (FileNotFoundException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }

        }

        public void IndexOutOfRangeExceptionMethod()
        {
            try
            {
                int[] array = new int[1] { 1 };
                Input = array[1].ToString();
            }
            catch (IndexOutOfRangeException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void OutOfMemoryExceptionMethod()
        {

            try
            {
                int[] newArray = new int[int.MaxValue];
                Input = newArray.ToString();

            }
            catch (OutOfMemoryException e)
            {
                if (!DoNotThrow)
                {
                    throw new OutOfMemoryException(); ;
                }
                else
                    ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void MultiExceptionMethod()
        {
            try
            {
                if (Input == int.MaxValue.ToString())
                {
                    Input = Convert.ToString(new string[int.MaxValue]);
                }

                if (Input == "1" && DoNotThrow)
                {

                    int[] range = new int[1] { 1 };
                    Input = Convert.ToString(range[1]);
                }
                if (Input == "1" && !DoNotThrow)
                {
                    int[] i = new int[int.MaxValue];
                    int a = int.MaxValue;
                    a++;
                }



            }
            catch (IndexOutOfRangeException e)
            {

                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";

            }
            catch (OutOfMemoryException e)
            {

                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";

            }

        }
        public string FinallyBlockStringOut { get; set; }
        public void FinallyBlockMethod(string s)
        {
            string result = null;
            try
            {
                if (s == "beautiful")
                {
                    result += "InTryBlock :beautiful:9:DoneWriting";
                }
                if (s == "ugly")
                {
                    result += "InTryBlock:";
                }

                if (s == null)
                {
                    result += "InTryBlock:";
                    Console.Write(s.Length);
                }

            }
            catch (NullReferenceException)
            {

                result += ":Object reference not set to an instance of an object.";

                if (!DoNotThrow)
                    throw;

            }
            finally
            {
                result += ":InFinallyBlock";
                if (s == null && !DoNotThrow)
                {
                    result += "";
                }
                if (s == null && DoNotThrow)
                {
                    result += ":EndOfMethod";
                }
                if (s == "beautiful")
                {
                    result += ":EndOfMethod";
                }
                FinallyBlockStringOut = result;
            }



        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void MethodA()
        {
            MethodB();
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void MethodB()
        {
            MethodC();
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void MethodC()
        {
            MethodD();
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void MethodD()
        {

            throw new NotImplementedException();

        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void NestedMethods()
        {
            MethodA();
        }

        public static void ThrowIfOdd(int n)
        {
            if (0 != n % 2)
            {
                throw new InvalidDataException();
            }
        }
    }
}
