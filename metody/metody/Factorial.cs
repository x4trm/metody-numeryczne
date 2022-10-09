using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metody
{
    public class Factorial
    {
        public int n { get; set; }
        public Factorial(int n)
        {
            if (n < 0)
            {
                throw new Exception("n<0");
            }
            else
            {
                this.n = n;
            }
        }
        public int SolveInt()
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
        public short SolveShort()
        {
            short result = 1;
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
        public long SolveLong()
        {
            long result = 1;
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
    }
}
