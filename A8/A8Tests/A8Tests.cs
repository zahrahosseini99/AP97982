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
            var Zahra = new Human("Zahra", "Hosseini", date, 170);
            Assert.AreEqual(Zahra.FirstName, "Zahra");
            Assert.AreEqual(Zahra.LastName, "Hosseini");
            Assert.AreEqual(Zahra.BirthDate, date);
            Assert.AreEqual(Zahra.Height, 170);

        }
        [TestMethod()]
        public void IsNotEqualTest()
        {
            string h = "7/24/1999";
            DateTime date = DateTime.Parse(h);
            Human h1 = new Human("Zahra", "Hosseini", DateTime.Today, 170);
            Human h2 = new Human("Zahra", "Hosseini", DateTime.Today, 170);
            Human h3 = new Human("MohammadReza", "Hosseini", date, 180);
            Assert.AreEqual(h1 != h3, true);
            Assert.AreEqual(h2 != h3, true);
            Assert.AreEqual(h1 != h2, false);
        }
        [TestMethod()]
        public void EqualsTest()
        {
            Human h1 = new Human("Zahra", "Hosseini", DateTime.Today, 170);
            Human h2 = new Human("Zahra", "Hosseini", DateTime.Today, 170);
            Human h3 = new Human("MohammadReza", "Hosseini", DateTime.Today, 180);
            Assert.IsTrue(h1.Equals(h2));
            Assert.IsFalse(h1.Equals(h3));


        }
        [TestMethod()]
        public void PlusTest()
        {
            Human h1 = new Human("Zahra", "Hosseini", DateTime.Today, 170);
            Human h2 = new Human("Zahra", "Hosseini", DateTime.Today, 170);
            Human h3 = new Human("MohammadReza", "Hosseini", DateTime.Today, 180);
            Human expected = new Human("ChildFirstName", "ChildLastName", DateTime.Today, 30);
            Assert.AreEqual(h1 + h3, expected);

        }

        [TestMethod()]
        public void EqualityTest()
        {
            string h = "10/8/1991";
            DateTime date = DateTime.Parse(h);
            Human h1 = new Human("Zahra", "Hosseini", DateTime.Today, 170);
            Human h2 = new Human("Zahra", "Hosseini", DateTime.Today, 170);
            Human h3 = new Human("Mahsa", "Hosseini", date, 160);
            Assert.AreEqual(h1 == h2, true);
            Assert.AreEqual(h1 == h3, false);
        }
        [TestMethod()]
        public void GreaterThanOrEqualToTest()
        {
            string h = "7/24/1999";
            DateTime date = DateTime.Parse(h);
            string hh = "7/24/2000";
            DateTime date1 = DateTime.Parse(hh);
            Human h1 = new Human("Zahra", "Hosseini", DateTime.Today, 170);
            Human h2 = new Human("Zahra", "Hosseini", DateTime.Today, 170);
            Human h3 = new Human("MohammadReza", "Hosseini", date, 180);
            Human h4 = new Human("MohammadReza", "Hosseini", date1, 180);
            Assert.AreEqual(h1 >= h2, true);
            Assert.AreEqual(h2 >= h3, true);
            Assert.AreEqual(h4 >= h1, false);
        }

        [TestMethod()]
        public void LessThanOrEqualToTest()
        {
            string h = "7/24/1999";
            DateTime date = DateTime.Parse(h);
            string hh = "7/24/2000";
            DateTime date1 = DateTime.Parse(hh);
            Human h1 = new Human("Zahra", "Hosseini", DateTime.Today, 170);
            Human h2 = new Human("Zahra", "Hosseini", DateTime.Today, 170);
            Human h3 = new Human("MohammadReza", "Hosseini", date, 180);
            Human h4 = new Human("MohammadReza", "Hosseini", date1, 180);
            Assert.AreEqual(h1 <= h2, true);
            Assert.AreEqual(h2 <= h3, false);
            Assert.AreEqual(h4 <= h1, true);
        }
        [TestMethod()]
        public void GreaterThanTest()
        {
            string h = "7/24/1999";
            DateTime date = DateTime.Parse(h);
            string hh = "7/24/2000";
            DateTime date1 = DateTime.Parse(hh);
            Human h1 = new Human("Zahra", "Hosseini", DateTime.Today, 170);
            Human h2 = new Human("Zahra", "Hosseini", DateTime.Today, 170);
            Human h3 = new Human("MohammadReza", "Hosseini", date, 180);
            Human h4 = new Human("MohammadReza", "Hosseini", date1, 180);
            Assert.AreEqual(h1 > h3, true);
            Assert.AreEqual(h3 > h4, false);
        }
        [TestMethod()]
        public void LessThanTest()
        {
            string h = "7/24/1999";
            DateTime date = DateTime.Parse(h);
            string hh = "7/24/2000";
            DateTime date1 = DateTime.Parse(hh);
            Human h1 = new Human("Zahra", "Hosseini", DateTime.Today, 170);
            Human h2 = new Human("Zahra", "Hosseini", DateTime.Today, 170);
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
            Human h1 = new Human("Zahra", "Hosseini", DateTime.Today, 170);
            Human h2 = new Human("MohammadReza", "Hosseini", date1, 180);
            Human h3 = new Human("Mahsa", "Hosseini", date, 160);

            Assert.AreNotEqual(h1.GetHashCode(), h2.GetHashCode());
            Assert.AreNotEqual(h2.GetHashCode(), h3.GetHashCode());
        }

    }
}