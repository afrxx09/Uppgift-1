using System;
using System.Reflection;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TriangleUnitTest
{
    [TestClass]
    public class TriUnitTest
    {

        [TestMethod]
        public void ThreeDouble_ConstructorTest()
        {
            Triangle tri = new Triangle(3.0, 4.0, 5.0);
            double[] sides = (double[])GetFieldValue(tri, "sides");
            Assert.IsTrue(sides[0] == 3.0 && sides[1] == 4.0 && sides[2] == 5.0);
        }

        [TestMethod]
        public void DoubleArray_ConstructorTest()
        {
            Triangle tri = new Triangle(new double[] { 3.0, 4.0, 5.0 });
            double[] sides = (double[])GetFieldValue(tri, "sides");
            Assert.IsTrue(sides[0] == 3.0 && sides[1] == 4.0 && sides[2] == 5.0);
        }

        [TestMethod]
        public void ThreePoint_ConstructorTest()
        {
            Point a = new Point(0, 0);
            Point b = new Point(0, 3);
            Point c = new Point(3, 4);
            double[] s = new double[3];
            s[0] = Math.Sqrt(Math.Pow((double)(b.x - a.x), 2.0) + Math.Pow((double)(b.y - a.y), 2.0));
            s[1] = Math.Sqrt(Math.Pow((double)(b.x - c.x), 2.0) + Math.Pow((double)(b.y - c.y), 2.0));
            s[2] = Math.Sqrt(Math.Pow((double)(c.x - a.x), 2.0) + Math.Pow((double)(c.y - a.y), 2.0));

            Triangle tri = new Triangle(a, b, c);
            double[] sides = (double[])GetFieldValue(tri, "sides");

            Assert.IsTrue(Array.IndexOf(sides, s[0]) != -1);
            Assert.IsTrue(Array.IndexOf(sides, s[1]) != -1);
            Assert.IsTrue(Array.IndexOf(sides, s[2]) != -1);

            Point a2 = new Point(0, 0);
            Point b2 = new Point(0, -3);
            Point c2 = new Point(-3, -4);
            double[] s2 = new double[3];
            s2[0] = Math.Sqrt(Math.Pow((double)(b2.x - a2.x), 2.0) + Math.Pow((double)(b2.y - a2.y), 2.0));
            s2[1] = Math.Sqrt(Math.Pow((double)(b2.x - c2.x), 2.0) + Math.Pow((double)(b2.y - c2.y), 2.0));
            s2[2] = Math.Sqrt(Math.Pow((double)(c2.x - a2.x), 2.0) + Math.Pow((double)(c2.y - a2.y), 2.0));

            Triangle tri2 = new Triangle(a, b, c);
            double[] sides2 = (double[])GetFieldValue(tri, "sides");

            Assert.IsTrue(Array.IndexOf(sides, s2[0]) != -1);
            Assert.IsTrue(Array.IndexOf(sides, s2[1]) != -1);
            Assert.IsTrue(Array.IndexOf(sides, s2[2]) != -1);
        }

        
        [TestMethod]
        public void PointArray_ConstructorTest()
        {
            Point a = new Point(0, 0);
            Point b = new Point(0, 3);
            Point c = new Point(3, 4);            double[] s = new double[3];
            s[0] = Math.Sqrt(Math.Pow((double)(b.x - a.x), 2.0) + Math.Pow((double)(b.y - a.y), 2.0));
            s[1] = Math.Sqrt(Math.Pow((double)(b.x - c.x), 2.0) + Math.Pow((double)(b.y - c.y), 2.0));
            s[2] = Math.Sqrt(Math.Pow((double)(c.x - a.x), 2.0) + Math.Pow((double)(c.y - a.y), 2.0));

            Triangle tri = new Triangle(new Point[] { a, b, c });
            double[] sides = (double[])GetFieldValue(tri, "sides");

            Assert.IsTrue(Array.IndexOf(sides, s[0]) != -1);
            Assert.IsTrue(Array.IndexOf(sides, s[1]) != -1);
            Assert.IsTrue(Array.IndexOf(sides, s[2]) != -1);

            //---------------
            Point a2 = new Point(0, 0);
            Point b2 = new Point(0, -3);
            Point c2 = new Point(-3, -4);
            double[] s2 = new double[3];
            s2[0] = Math.Sqrt(Math.Pow((double)(b2.x - a2.x), 2.0) + Math.Pow((double)(b2.y - a2.y), 2.0));
            s2[1] = Math.Sqrt(Math.Pow((double)(b2.x - c2.x), 2.0) + Math.Pow((double)(b2.y - c2.y), 2.0));
            s2[2] = Math.Sqrt(Math.Pow((double)(c2.x - a2.x), 2.0) + Math.Pow((double)(c2.y - a2.y), 2.0));

            Triangle tri2 = new Triangle(new Point[] {a2, b2, c2});
            double[] sides2 = (double[])GetFieldValue(tri, "sides");

            Assert.IsTrue(Array.IndexOf(sides, s2[0]) != -1);
            Assert.IsTrue(Array.IndexOf(sides, s2[1]) != -1);
            Assert.IsTrue(Array.IndexOf(sides, s2[2]) != -1);
        }
        
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TheeDouble_FaultyConstructorTest()
        {
            //inkorrekt triangel
            Triangle tri = new Triangle(1, 2, 1);
            //med nollvärde
            Triangle tri2 = new Triangle(1, 0, 4);
            //med negativt värde
            Triangle tri3 = new Triangle(-1.0, 2, -3.1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DoubleArray_FaultyConstructorTest()
        {
            //för få sidor
            Triangle tri = new Triangle(new double[] { 1, 2 });
            //tom array
            Triangle tri2 = new Triangle(new double[] { });
            //för många sidor
            Triangle tri3 = new Triangle(new double[] { 1, 2, 3, 4 });
            //med negativt värde
            Triangle tri4 = new Triangle(new double[] { -1, 3, 4 });
            //med nollvärde
            Triangle tri5 = new Triangle(new double[] { 2, 0, 4 });
            //med inkorrekta värden
            Triangle tri6 = new Triangle(new double[] { 1, 2, 3 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TheePoints_FaultyConstructorTest()
        {
            //alla punkter är samma
            Triangle tri = new Triangle(new Point(3,3), new Point(3,3), new Point(3,3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PointsArray_FaultyConstructorTest()
        {
            //tom array med points
            Triangle tri = new Triangle(new Point[] {});
            //för få points
            Triangle tri1 = new Triangle(new Point[] { new Point(3, 3), new Point(1, 2) });
            //för många points
            Triangle tri2 = new Triangle(new Point[] { new Point(1, 1), new Point(2, 2), new Point(3, 3), new Point(4, 4) });
            //array där alla punkter är samma
            Triangle tri3 = new Triangle(new Point[] { new Point(3, 3), new Point(3, 3), new Point(3, 3) });
        }
        
        [TestMethod]
        public void isIsoscelesTest()
        {
            //likbent är likbent
            Triangle tri = new Triangle(1.1, 2.1, 1.1);
            Assert.IsTrue(tri.isIsosceles());
            //liksidig är inte likbent
            Triangle tri2 = new Triangle(3.3, 3.3, 3.3);
            Assert.IsFalse(tri2.isIsosceles());
            //oliksidig är inte likbent
            Triangle tri3 = new Triangle(3.0, 4.0, 5.0);
            Assert.IsFalse(tri3.isIsosceles());
        }

        [TestMethod]
        public void isEquilateralTest()
        {
            //liksidig är liksidig
            Triangle tri = new Triangle(3.3, 3.3, 3.3);
            Assert.IsTrue(tri.isEquilateral());
            //likbent är inte liksidig
            Triangle tri2 = new Triangle(3.3, 2.2, 3.3);
            Assert.IsFalse(tri2.isEquilateral());
            //oliksidig är inte liksidig
            Triangle tri3 = new Triangle(3.0, 4.0, 5.0);
            Assert.IsFalse(tri3.isEquilateral());
        }

        [TestMethod]
        public void isScaleneTest()
        {
            //oliksidig är oliksidig
            Triangle tri = new Triangle(3.0, 4.0, 5.0);
            Assert.IsTrue(tri.isScalene());
            //liksidig är inte oliksidig
            Triangle tri2 = new Triangle(3.3, 3.3, 3.3);
            Assert.IsFalse(tri2.isScalene());
            //likbent är inte oliksidig
            Triangle tri3 = new Triangle(4.0, 2.0, 4.0);
            Assert.IsFalse(tri3.isScalene());
        }



        private static object GetFieldValue(object o, string name)
        {
            var field = o.GetType().GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);
            if (field == null)
            {
                throw new ApplicationException(String.Format("FEL! Det privata fältet {0} saknas.", name));
            }
            return field.GetValue(o);
        }
    }
}
