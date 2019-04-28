using Microsoft.VisualStudio.TestTools.UnitTesting;
using A2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2.Tests
{
    [TestClass()]
    public class ProgramTests
    {


        [TestMethod()]
        public void ArraySwapTest()
        {
            int[] array1 = { 1, 2, 3, 4 };
            int[] array3 = { 8, 9, 0 };
            int[] array2 = { 8, 9, 0 };
            int[] array4 = { 1, 2, 3, 4 };
            Program.ArraySwap(ref array1, ref array2);
            CollectionAssert.AreEqual(array3, array1);
            CollectionAssert.AreEqual(array4, array2);
        }

        [TestMethod()]
        public void ArraySwapTest1()
        {
            int[] array1 = { 1, 2, 3 };
            int[] array3 = { 8, 9, 0 };
            int[] array2 = { 8, 9, 0 };
            int[] array4 = { 1, 2, 3 };
            Program.ArraySwap(array1, array2);
            CollectionAssert.AreEqual(array3, array1);
            CollectionAssert.AreEqual(array4, array2);
        }

        [TestMethod()]
        public void AbsArrayTest()
        {
            int[] array = { -1, -3, -5 };
            int[] array1 = { 1, 3, 5 };
            Program.AbsArray(array);
            CollectionAssert.AreEqual(array1, array);
        }

        [TestMethod()]
        public void AppendTest()
        {
            int[] a = new int[3] { 1, 2, 3 };
            int b = 4;
            int[] expectedValue = new int[] { 1, 2, 3, 4 };
            Program.Append(ref a, b);
            CollectionAssert.AreEqual(expectedValue, a);
        }

        [TestMethod()]
        public void SumTest()
        {

            int e = 0;
            Program.Sum(out e, 1, 2, 3);
            Assert.AreEqual(6, e);

        }

        [TestMethod()]
        public void SwapTest()
        {
            int c = 4;
            int d = 5;
            Program.Swap(ref c, ref d);
            Assert.AreEqual(5, c);
            Assert.AreEqual(4, d);
        }

        [TestMethod()]
        public void SquareTest()
        {
            int b = 3;
            Program.Square(ref b);
            Assert.AreEqual(9, b);

        }

        [TestMethod()]
        public void AssignPiTest()
        {
            double s;
            Program.AssignPi(out s);
            Assert.AreEqual(Math.PI, s);

        }
    }
}