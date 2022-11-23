using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metody
{
    public class NaturalLogarithm
    {
        public static decimal Solve(decimal n)
        {
            decimal e=0;
            while(n>=0)
            {
                e+=(1/Factorial.SolveDecimal(n));
                n--;
            }
            return e;
        }
    }
}