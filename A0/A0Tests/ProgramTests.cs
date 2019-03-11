using Microsoft.VisualStudio.TestTools.UnitTesting;
using A0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A0.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AddTest()
        {
            long expectedResult = 4;
            long functionResult = Program.Add(a: 1 ,b: 3);

            Assert.AreEqual(expectedResult, actual:functionResult ); 
        }

        [TestMethod()]
        public void SubtractTest()
        {
            long expectedResult = -2;
            long functionResult = Program.Subtract(a: 1, b: 3);

            Assert.AreEqual(expectedResult, actual: functionResult );
           
        }

        [TestMethod()]
        public void NegateTest()
        {
            long expectedResult = -1;
            long functionResult = Program.Negate(a: 1);

            Assert.AreEqual(expectedResult, actual: functionResult);
        }

        [TestMethod()]
        public void ProductTest()
        {
            long expectedResult = 3;
            long functionResult = Program.Product(a: 1, b: 3);

            Assert.AreEqual(expectedResult, actual: functionResult);
        }

        [TestMethod()]
        public void SqrtTest()
        {
            double expectedResult = 9;
            double functionResult = Program.Sqrt(a:81);

            Assert.AreEqual(expectedResult, actual: functionResult);
        }

        [TestMethod()]
        public void SquareTest()
        {
            long expectedResult = 9;
            long functionResult = Program.Square(a:3);

            Assert.AreEqual(expectedResult, actual: functionResult);
        }

        [TestMethod()]
        public void factorilTest()
        {
            long expectedResult =6;
            long functionResult = Program.factoril(a:3);

            Assert.AreEqual(expectedResult, actual: functionResult);
        }
    }
}