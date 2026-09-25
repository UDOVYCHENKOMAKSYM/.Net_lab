using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab1.Class_lab2;
namespace TestProject
{
    [TestClass]
    public class Calculation_abcTest
    {
        [TestMethod]
        public void D_AllNumbersDivisibleBy7_ReturnsSumOfCubes()
        {
            var cal=new Calculation_abc(7, 14, 21);
            var testRes = 12348;
            var res= cal.D();
            Assert.AreEqual(testRes, res);
        }
        [TestMethod]
        public void D_NoNumbersDivisibleBy7_ReturnsZero()
        {
            var cal = new Calculation_abc(1, 2, 3);
            var testRes = 0;
            var res = cal.D();
            Assert.AreEqual(testRes, res);
        }
        [TestMethod]
        public void D_TwoNumbersDivisibleBy7_ReturnsSumOfCubes()
        {
            var cal = new Calculation_abc(7, 2, 21);
            var testRes = 9604;
            var res = cal.D();
            Assert.AreEqual(testRes, res);
        }
        [TestMethod]
        public void D_OneNumberDivisibleBy7_ReturnsSumOfCubes()
        {
            var cal = new Calculation_abc(7, 2, 3);
            var testRes = 343;
            var res = cal.D();
            Assert.AreEqual(testRes, res);
        }

    }
}
