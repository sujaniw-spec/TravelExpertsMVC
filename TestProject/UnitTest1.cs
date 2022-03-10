using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCustomerTest()
        {
            int custId = 1;


            Assert.assertThat(1, custId);
        }
    }
}
