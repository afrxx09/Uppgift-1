using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriangleUnitTest
{
    [TestClass]
    public class TriUnitTest
    {
        [TestMethod]
        public void isIsoscelesTest()
        {
            Triangle tri = new Triangle(1.1, 2.1, 1.1);
            Assert.IsTrue(tri.isIsosceles());
        }
    }
}
