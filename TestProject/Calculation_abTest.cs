using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab1.Class_lab2;
namespace TestProject;

[TestClass]
public class Calculation_abTest
{
    [TestMethod]
    public void Sum_RangeHasMatchingNumbers_ReturnsCorrectSum()
    {
        var calc=new Calculation_ab(50, 200);
        var testRes = 242;
        var res = calc.Sum();
        Assert.AreEqual(testRes, res);
    }
    [TestMethod]
    public void Sum_RangeHasNoMatchingNumbers_ReturnsZero()
    {
        var calc=new Calculation_ab(1, 10);
        var testRes = 0;
        var res = calc.Sum();
        Assert.AreEqual(testRes, res);
    }
    [TestMethod]
    public void Sum_AIsGreaterThanB_ThrowsArgumentOutOfRangeException()
    {
        var calc = new Calculation_ab(10, 5);
        Assert.Throws<ArgumentOutOfRangeException>(() => calc.Sum());
    }
}
