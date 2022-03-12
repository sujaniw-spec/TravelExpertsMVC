using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelExpertsData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace TravelExpertsData.Models.Tests
{
    [TestClass()]
    public class CustomerManagerTests
    {
        [TestMethod()]
        public void GetCustomerIdTest()
        {
            int custId = 1;
            Assert.AreEqual(1, custId);
            System.Console.WriteLine("Ok!");
        }

        [TestMethod()]
        public void GetCustomerName()
        {
            string customerName = "Sujani";
            Assert.AreEqual("Sujani", customerName);
            System.Console.WriteLine("Ok!!");
        }

        [TestMethod()]
        public void GetCustomerAge()
        {
            int age = 30;
            Assert.IsTrue(age > 20);
        }

        [TestMethod()]
        public void GetCustomerCity()
        {
            string custCity = "Calgary";
            Assert.AreEqual("Calgary",custCity);
        }
    }
}