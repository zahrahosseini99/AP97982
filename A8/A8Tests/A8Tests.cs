using Microsoft.VisualStudio.TestTools.UnitTesting;
using A8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace A8.Tests
{
    [TestClass()]
    public class HumanTests
    {
        [TestMethod()]
        public void HumanTest()
        {
            string h = "7/24/1999";
            DateTime date = DateTime.Parse(h);
            var zari = CreateHumanInstance(null as Human, "zahra", "hosseini", date, 170);

        }
        [TestMethod()]
        public void unEqualTest()
        {
            string h = "7/24/1999";
            DateTime date = DateTime.Parse(h);
            Human h1 = new Human("zahra", "Hosseini", DateTime.Today, 170);
            Human h2 = new Human("zahra", "Hosseini", DateTime.Today, 170);
            Human h3 = new Human("MohammadReza", "Hosseini", date, 180);
            Assert.AreEqual(h1 != h3, true);
            Assert.AreEqual(h2 != h3, true);
            Assert.AreEqual(h1 != h2, false);
        }
        [TestMethod()]
        public void EqualsTest()
        {
            Human h1 = new Human("zahra", "Hosseini", DateTime.Today, 170);
            Human h2 = new Human("zahra", "Hosseini", DateTime.Today, 170);
            Human h3 = new Human("MohammadReza", "Hosseini", DateTime.Today, 180);
            Assert.IsTrue(h1.Equals(h2));
            Assert.IsFalse(h1.Equals(h3));


        }
        [TestMethod()]
        public void sumTest()
        {
            Human h1 = new Human("zahra", "Hosseini", DateTime.Today, 170);
            Human h2 = new Human("zahra", "Hosseini", DateTime.Today, 170);
            Human h3 = new Human("MohammadReza", "Hosseini", DateTime.Today, 180);
            Human expected = new Human("ChildFirstName", "ChildLastName", DateTime.Today, 30);
            Assert.AreEqual(h1 + h3, expected);

        }

        [TestMethod()]
        public void equalityTest()
        {
            Human h1 = new Human("zahra", "Hosseini", DateTime.Today, 170);
            Human h2 = new Human("zahra", "Hosseini", DateTime.Today, 170);
            Assert.AreEqual(h1 == h2, true);
        }
        [TestMethod()]
        public void youngerTest()
        {
            string h = "7/24/1999";
            DateTime date = DateTime.Parse(h);
            string hh = "7/24/2000";
            DateTime date1 = DateTime.Parse(hh);
            Human h1 = new Human("zahra", "Hosseini", DateTime.Today, 170);
            Human h2 = new Human("zahra", "Hosseini", DateTime.Today, 170);
            Human h3 = new Human("MohammadReza", "Hosseini", date, 180);
            Human h4 = new Human("MohammadReza", "Hosseini", date1, 180);
            Assert.AreEqual(h1 >= h2, true);
            Assert.AreEqual(h2 >= h3, true);
            Assert.AreEqual(h4 >= h1, false);
        }

        [TestMethod()]
        public void oldererTest()
        {
            string h = "7/24/1999";
            DateTime date = DateTime.Parse(h);
            string hh = "7/24/2000";
            DateTime date1 = DateTime.Parse(hh);
            Human h1 = new Human("zahra", "Hosseini", DateTime.Today, 170);
            Human h2 = new Human("zahra", "Hosseini", DateTime.Today, 170);
            Human h3 = new Human("MohammadReza", "Hosseini", date, 180);
            Human h4 = new Human("MohammadReza", "Hosseini", date1, 180);
            Assert.AreEqual(h1 <= h2, true);
            Assert.AreEqual(h2 <= h3, false);
            Assert.AreEqual(h4 <= h1, true);
        }
        [TestMethod()]
        public void youngTest()
        {
            string h = "7/24/1999";
            DateTime date = DateTime.Parse(h);
            string hh = "7/24/2000";
            DateTime date1 = DateTime.Parse(hh);
            Human h1 = new Human("zahra", "Hosseini", DateTime.Today, 170);
            Human h2 = new Human("zahra", "Hosseini", DateTime.Today, 170);
            Human h3 = new Human("MohammadReza", "Hosseini", date, 180);
            Human h4 = new Human("MohammadReza", "Hosseini", date1, 180);
            Assert.AreEqual(h1 > h3, true);
            Assert.AreEqual(h3 > h4, false);
        }
        [TestMethod()]
        public void oldTest()
        {
            string h = "7/24/1999";
            DateTime date = DateTime.Parse(h);
            string hh = "7/24/2000";
            DateTime date1 = DateTime.Parse(hh);
            Human h1 = new Human("zahra", "Hosseini", DateTime.Today, 170);
            Human h2 = new Human("zahra", "Hosseini", DateTime.Today, 170);
            Human h3 = new Human("MohammadReza", "Hosseini", date, 180);
            Human h4 = new Human("MohammadReza", "Hosseini", date1, 180);
            Assert.AreEqual(h1 < h3, false);
            Assert.AreEqual(h3 < h4, true);
        }
        [TestMethod()]
        public void GetHashCodeTest()
        {
            string h = "7/24/1999";
            DateTime date = DateTime.Parse(h);
            string hh = "7/24/2000";
            DateTime date1 = DateTime.Parse(hh);
            Human h1 = new Human("zahra", "Hosseini", DateTime.Today, 170);
            Human h2 = new Human("MohammadReza", "Hosseini", date1, 180);
            Human h3 = new Human("Mahsa", "Hosseini", date, 160);

            Assert.AreNotEqual(h1.GetHashCode(), h2.GetHashCode());
            Assert.AreNotEqual(h2.GetHashCode(), h3.GetHashCode());
        }

        private dynamic CreateHumanInstance<_ReturnType, T1, T2, T3, T4>(_ReturnType rt, T1 o1, T2 o2, T3 o3, T4 o4)
            where _ReturnType : class
        {
            string h = "7/24/1999";

            DateTime date = DateTime.Parse(h);
            ConstructorInfo ctor = (typeof(_ReturnType)).GetConstructor(new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) });
            _ReturnType kz = ctor.Invoke(new object[] { "zahra", "hosseini", date, 170 }) as _ReturnType;
            return kz;
        }
    }
}