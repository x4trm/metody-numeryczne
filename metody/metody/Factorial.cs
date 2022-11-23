using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metody
{
    public class Factorial
    {

        public static int SolveInt(int n)
        {
            int result = 1;
            if(n == 0)
            {
                return result;
            }
            while(n> 0)
            {
                result*=n;
                n--;
            }
            return result;
        }
        public static short SolveShort(int n)
        {
            short result = Convert.ToInt16(1);
            if (n == 0)
            {
                return result;
            }
            while (n > 0)
            {
                result *= Convert.ToInt16(n);
                n--;
            }
            return result;
        }
        public static long SolveLong(int n)
        {
            long result = Convert.ToInt64(1);
            if (n == 0)
            {
                return result;
            }
            while (n > 0)
            {
                result *= Convert.ToInt64(n);
                n--;
            }
            return result;
        }
        public static decimal SolveDecimal(decimal n)
        {
            decimal result = Convert.ToDecimal(1);
            if (n == 0)
            {
                return result;
            }
            while (n > 0)
            {
                result *= Convert.ToDecimal(n);
                n--;
            }
            return result;
        }
    }
}