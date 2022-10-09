using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metody
{
    public class Complex
    {
        public double re;
        public double im;
        //public float re;
        //public float im;
        public Complex(float re, float im)
        {
            this.re = re;
            this.im = im;
        }
        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        public static Complex operator +(Complex a, Complex b)=>new Complex(a.re + b.re, a.im + b.im);
        
        public static Complex operator *(Complex a, Complex b)=>new Complex(a.re * b.re - a.im * b.im, a.re * b.im + b.re * a.im);
        public override string ToString()=>$"{re}+{im}i";
        
    }
}
