using Microsoft.VisualStudio.TestTools.UnitTesting;
using P1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace P1.Tests
{
    [TestClass()]
    public class FunctionTests
    {
      

        [TestMethod()]
        public void ParserTest()
        {
            var f = Function.Parser("2x^2+1");
            Assert.AreEqual(3, f(1));
        }

        [TestMethod()]
        public void PlusTest()
        {
            var f = Function.Plus(4,"2x^2+1");
            Assert.AreEqual(3, f(1));


        }
        [TestMethod()]
        public void SubtractTest()
        {
            var f = Function.Subtract(4, "2x^2-1");
            Assert.AreEqual(1, f(1));


        }

       


    }
}