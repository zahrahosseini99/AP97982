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
    public class TaylorTests
    {
        [TestMethod()]
        public void TaylorTest()
        {
          

        }

        [TestMethod()]
        public void ETaylorTest()
        {
            Assert.AreEqual(5, Taylor.ETaylor(2, 3));
            Assert.AreEqual(1, Taylor.ETaylor(0, 4));
          
           
        }

        [TestMethod()]
        public void CosTaylorTest()
        {
            Assert.AreEqual(1, Taylor.CosTaylor(0, 4));
            Assert.AreEqual(0, Math.Ceiling(Taylor.CosTaylor(2, 3)));
        }

        [TestMethod()]
        public void SinTaylorTest()
        {
            Assert.AreEqual(0, Taylor.SinTaylor(0, 4));
            Assert.AreEqual(1,Math.Ceiling( Taylor.SinTaylor(2, 3)));
        }

        [TestMethod()]
        public void factTest()
        {
            Assert.AreEqual(6, Taylor.fact(3));
            Assert.AreEqual(1, Taylor.fact(0));
        }

       

       

       
    }
}