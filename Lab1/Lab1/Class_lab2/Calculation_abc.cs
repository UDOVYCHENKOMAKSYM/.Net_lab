using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Class_lab2
{
    public class Calculation_abc
    {
        int a, b, c;
        public Calculation_abc(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public Calculation_abc()
        {
            a = 0;
            b = 0;
            c = 0;
        }
        public Calculation_abc(Calculation_abc obj)
        {
            this.a = obj.a;
            this.b = obj.b;
            this.c = obj.c;
        }
        public int A
        {
            get { return a; }
            set { a = value; }
        }
                public int B
        {
            get { return b; }
            set { b = value; }
        }
        public int C
        {
            get { return c; }
            set { c = value; }
        }
        public int D ()
        {
            int sum = 0;
            if(a%7==0)
            {
                sum += a*a*a;
            }
            if(b % 7 == 0)
            {
                sum += b*b*b;
            }
            if(c % 7 == 0)
            {
                sum += c*c*c;
            }
            return sum;
        }
    }
}
