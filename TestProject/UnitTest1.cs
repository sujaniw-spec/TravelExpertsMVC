﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCustomerIdTest()
        {
            int custId = 1;
            Assert.Equals(1, custId);
        }
    }
}
