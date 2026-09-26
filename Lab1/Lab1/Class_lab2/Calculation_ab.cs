using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Class_lab2
{
    public class Calculation_ab
    {
        int a, b;
        public Calculation_ab(int a, int b)
        {
            this.a = a;
            this.b = b;
        }
        public Calculation_ab()
        {
            this.a = 0;
            this.b = 0;
        }
        public Calculation_ab(int a)
        {
            this.a = a;
            this.b = 0;
        }
        public int A { get { return a; } }
        public int B { get { return b; } }
        public int Sum()
        {
            var sum = 0;
            if (a >=b)
            {
                throw
                    new ArgumentOutOfRangeException("A should be less than B");
            }
            else
            {
                for (int i = a; i <= b; i++)
                {

                    if (i % 11 == 0 && i % 8 == 5)
                    {
                        sum += i;
                    }
                }
                return sum;
            }
        }
    }
}




