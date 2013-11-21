using System;
using System.Linq;
using System.Collections.Generic;

public struct Point { 
    public int x, y;
  
    public Point(int a, int b) {
        x = a;
        y = b;
    }
}

public class Triangle {
    double[] sides;

    public double[] Sides
    {
        private get { return sides; }

        set{
            if (value.Length != 3)
            {
                throw new ArgumentException("Not three sides.");
            }

            foreach (double d in value)
            {
                if (d <= 0)
                {
                    throw new ArgumentException("Negative lengths are not ok.");
                }
            }
            sides = value;
        }
    }

    private void AddSide(double value){
        if (value <= 0){
            throw new ArgumentException("Can not set a side with a negative value.");
        }
        bool isFull = true;
        for (int i = 0; i < 3; i++){
            if (sides[i] == 0.0) {
                isFull = false;
                sides[i] = value;
                break;
            }
        }
        if (isFull)
        {
            throw new ArgumentException("Array is full");
        }
    }

    private double[] CreateArr(){
        return new double[3];
    }

    public Triangle(double a, double b, double c){
        sides = CreateArr();
        AddSide(a);
        AddSide(b);
        AddSide(c);
    } 

    public Triangle(double[] s) {
        sides = CreateArr();
        Sides = s;
    } 

    public Triangle(Point a, Point b, Point c) {
        sides = CreateArr();
        AddSide( Math.Sqrt(Math.Pow((double)(b.x - a.x), 2.0) + Math.Pow((double)(b.y - a.y), 2.0)) );
        AddSide( Math.Sqrt(Math.Pow((double)(b.x - c.x), 2.0) + Math.Pow((double)(b.y - c.y), 2.0)) );
        AddSide( Math.Sqrt(Math.Pow((double)(c.x - a.x), 2.0) + Math.Pow((double)(c.y - a.y), 2.0)) );
    }

    public Triangle(Point[] s) {
        if(s.Length != 3){
            throw new ArgumentException(String.Format("Can not create a triangle with {0} sides", s.Length));
        }
        sides = CreateArr();
        AddSide( Math.Sqrt(Math.Pow((double)(s[1].x - s[0].x), 2.0) + Math.Pow((double)(s[1].y - s[0].y), 2.0)) );
        AddSide( Math.Sqrt(Math.Pow((double)(s[1].x - s[2].x), 2.0) + Math.Pow((double)(s[1].y - s[2].y), 2.0)) );
        AddSide( Math.Sqrt(Math.Pow((double)(s[2].x - s[0].x), 2.0) + Math.Pow((double)(s[2].y - s[0].y), 2.0)) );
    }

    private int uniqueSides() {
        return sides.Distinct<double>().Count();
    }

    public bool isScalene() {
        if(uniqueSides()==3)
            return true;
        return false;
    }

    public bool isEquilateral() {
        if(uniqueSides()==1)
            return true;
        return false;
    }

    public bool isIsosceles() {
        if(uniqueSides()==2)
            return true;
        return false;
    }
}