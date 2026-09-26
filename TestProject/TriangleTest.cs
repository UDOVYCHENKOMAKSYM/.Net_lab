using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab1.Class_lab2;

namespace TestProject;

[TestClass]
public class TriangleTest
{
    [TestMethod]
    public void CalculateArea_Sides3_4_5_Returns6()
    {
        var t = new Triangle(3.0, 4.0, 5.0);
        var testRes = 6.0;

        var res = t.CalculateArea();

        Assert.AreEqual(testRes, res, 0.0000001);
    }
    [TestMethod]
    public void CalculateArea_InvalidSides_ThrowsArgumentException()
    {
        var t = new Triangle(1.0, 2.0, 10.0);
        Assert.Throws<ArgumentException>(() => t.CalculateArea());
    }
    [TestMethod]
    public void GetTriangleType_RightTriangle_ReturnsRight()
    {
        var t = new Triangle(3.0, 4.0, 5.0);

        var testRes = t.GetTriangleType();

        Assert.AreEqual("Прямокутний", testRes);
    }

    [TestMethod]
    public void GetTriangleType_AcuteTriangle_ReturnsAcute()
    {
        var t = new Triangle(6.0, 6.0, 6.0);

        var testRes = t.GetTriangleType();

        Assert.AreEqual("Гострокутний", testRes);
    }

    [TestMethod]
    public void GetTriangleType_ObtuseTriangle_ReturnsObtuse()
    {
        var t = new Triangle(4.0, 5.0, 8.0);

        var testRes = t.GetTriangleType();

        Assert.AreEqual("Тупокутний", testRes);
    }
    [TestMethod]
    public void GetTriangleType_NegativeSide_ThrowsArgumentException()
    {
        var t = new Triangle(-3.0, 4.0, 5.0);
        Assert.Throws<ArgumentException>(() => t.GetTriangleType());
    }
}
