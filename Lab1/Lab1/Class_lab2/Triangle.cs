using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Class_lab2
{
    public class Triangle
    {
        double a, b, c;
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public Triangle()
        {
            this.a = 3.0;
            this.b = 4.0;
            this.c = 5.0;
        }
        public Triangle(double a)
        {
            this.a = a;
            this.b = a;
            this.c = a;
        }
        public double A { get { return a; } }
        public double B { get { return b; } }
        public double C { get { return c; } }
        public double CalculateArea()
        {
            if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArgumentException("Трикутник із такими сторонами не існує.");
            }
            double p = (a + b + c) / 2.0;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        public string GetTriangleType()
        {
            if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArgumentException("Трикутник із такими сторонами не існує.");
            }

            double max = a;
            double s1 = b;
            double s2 = c;

            if (b > max)
            {
                max = b;
                s1 = a;
                s2 = c;
            }
            if (c > max)
            {
                max = c;
                s1 = a;
                s2 = b;
            }

            double maxSquare = max * max;
            double sumOfSquares = s1 * s1 + s2 * s2;
            double eps = 0.0000001; // 10^-7

            if (Math.Abs(maxSquare - sumOfSquares) <= eps)
            {
                return "Прямокутний";
            }
            else if (maxSquare < sumOfSquares)
            {
                return "Гострокутний";
            }
            else
            {
                return "Тупокутний";
            }
        }
    }
}
