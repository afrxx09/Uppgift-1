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
        public void ThreeDoubles_ConstructorTest()
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
        public void ThreePoints_PositiveNumbers_ConstructorTest()
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

        }

        [TestMethod]
        public void ThreePoints_NegativeNumbers_ConstructorTest()
        {
            Point a = new Point(0, 0);
            Point b = new Point(0, -3);
            Point c = new Point(-3, -4);
            double[] s = new double[3];
            s[0] = Math.Sqrt(Math.Pow((double)(b.x - a.x), 2.0) + Math.Pow((double)(b.y - a.y), 2.0));
            s[1] = Math.Sqrt(Math.Pow((double)(b.x - c.x), 2.0) + Math.Pow((double)(b.y - c.y), 2.0));
            s[2] = Math.Sqrt(Math.Pow((double)(c.x - a.x), 2.0) + Math.Pow((double)(c.y - a.y), 2.0));

            Triangle tri = new Triangle(a, b, c);
            double[] sides = (double[])GetFieldValue(tri, "sides");

            Assert.IsTrue(Array.IndexOf(sides, s[0]) != -1);
            Assert.IsTrue(Array.IndexOf(sides, s[1]) != -1);
            Assert.IsTrue(Array.IndexOf(sides, s[2]) != -1);
        }

        
        [TestMethod]
        public void PointArray_PositiveNumbers_ConstructorTest()
        {
            Point a = new Point(0, 0);
            Point b = new Point(0, 3);
            Point c = new Point(3, 4);
            //double[] s = new double[]{3, 4, 5}
            double[] s = new double[3];
            s[0] = Math.Sqrt(Math.Pow((double)(b.x - a.x), 2.0) + Math.Pow((double)(b.y - a.y), 2.0));
            s[1] = Math.Sqrt(Math.Pow((double)(b.x - c.x), 2.0) + Math.Pow((double)(b.y - c.y), 2.0));
            s[2] = Math.Sqrt(Math.Pow((double)(c.x - a.x), 2.0) + Math.Pow((double)(c.y - a.y), 2.0));

            Triangle tri = new Triangle(new Point[] { a, b, c });
            double[] sides = (double[])GetFieldValue(tri, "sides");

            Assert.IsTrue(Array.IndexOf(sides, s[0]) != -1);
            Assert.IsTrue(Array.IndexOf(sides, s[1]) != -1);
            Assert.IsTrue(Array.IndexOf(sides, s[2]) != -1);
        }

        [TestMethod]
        public void PointArray_NegativeNumbers_ConstructorTest()
        {
            Point a = new Point(0, 0);
            Point b = new Point(0, -3);
            Point c = new Point(-3, -4);
            //double[] s = new double[]{3, 4, 5}
            double[] s = new double[3];
            s[0] = Math.Sqrt(Math.Pow((double)(b.x - a.x), 2.0) + Math.Pow((double)(b.y - a.y), 2.0));
            s[1] = Math.Sqrt(Math.Pow((double)(b.x - c.x), 2.0) + Math.Pow((double)(b.y - c.y), 2.0));
            s[2] = Math.Sqrt(Math.Pow((double)(c.x - a.x), 2.0) + Math.Pow((double)(c.y - a.y), 2.0));

            Triangle tri = new Triangle(new Point[] { a, b, c });
            double[] sides = (double[])GetFieldValue(tri, "sides");

            Assert.IsTrue(Array.IndexOf(sides, s[0]) != -1);
            Assert.IsTrue(Array.IndexOf(sides, s[1]) != -1);
            Assert.IsTrue(Array.IndexOf(sides, s[2]) != -1);
        }

        /*
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TheeDoubles_IncorrectTriangle_FaultyConstructorTest()
        {
            Triangle tri = new Triangle(1.1, 2.0, 1.1);
        }
        */
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TheeDoubles_ZeroValues_FaultyConstructorTest()
        {
            Triangle tri = new Triangle(1, 0, 4);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TheeDoubles_NegativeNumbers_FaultyConstructorTest()
        {
            Triangle tri = new Triangle(-1.0, 2, -3.1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DoubleArray_OneSide_FaultyConstructorTest()
        {
            Triangle tri = new Triangle(new double[] { 1.5 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DoubleArray_TwoSides_FaultyConstructorTest()
        {
            Triangle tri = new Triangle(new double[] { 1, 2 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DoubleArray_EmptyArray_FaultyConstructorTest()
        {
            Triangle tri = new Triangle(new double[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DoubleArray_FourSides_FaultyConstructorTest()
        {
            Triangle tri = new Triangle(new double[] { 1, 2, 3, 4 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DoubleArray_NegativeNumber_FaultyConstructorTest()
        {
            Triangle tri = new Triangle(new double[] { -1, 3, 4 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DoubleArray_ZeroValue_FaultyConstructorTest()
        {
            Triangle tri = new Triangle(new double[] { 2, 0, 4 });
        }

        /*
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DoubleArray_IncorrectTriangle_FaultyConstructorTest()
        {
            Triangle tri = new Triangle(new double[] { 1, 2, 3 });
        }
        */
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TheePoints_AllSameCoordinates_FaultyConstructorTest()
        {
            Triangle tri = new Triangle(new Point(3,3), new Point(3,3), new Point(3,3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PointsArray_EmptyArray_FaultyConstructorTest()
        {
            Triangle tri = new Triangle(new Point[] {});
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PointsArray_OnePoint_FaultyConstructorTest()
        {
            Triangle tri1 = new Triangle(new Point[] { new Point(3, 3) });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PointsArray_TwoPoints_FaultyConstructorTest()
        {
            Triangle tri = new Triangle(new Point[] { new Point(3, 3), new Point(1, 2) });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PointsArray_TooManyPoints_FaultyConstructorTest()
        {
            Triangle tri = new Triangle(new Point[] { new Point(1, 1), new Point(2, 2), new Point(3, 3), new Point(4, 4) });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PointsArray_AllSameCoordinates_FaultyConstructorTest()
        {
            Triangle tri = new Triangle(new Point[] { new Point(3, 3), new Point(3, 3), new Point(3, 3) });
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


        //Stulit från Mats.
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
