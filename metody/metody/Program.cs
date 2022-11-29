
namespace metody
{
    public class Program
    {
        static void foo()
        {
            double[,] C = {{-1,2,-3,3,5},{8,0,7,4,-1},{-3,4,-3,2,-2},{8,-3,-2,1,2},{-2,-1,-6,9,0}};
            double[] D={56,62,-10,14,28};

            (double[,] L,double[,] U)=Matrix.Doolitle(C);
            // double[] result=Matrix.SolveLU(matrix.L,D);
            // double[] resultU=Matrix.SolveLU(matrix.U,D);


            // for(int i=0;i<result.GetLength(0);i++)
            // {
            //     Console.WriteLine(result[i]);
            // }
            // Console.WriteLine("=================");
            // for(int i=0;i<resultU.GetLength(0);i++)
            // {
            //     Console.WriteLine(resultU[i]);
            // }
            double[,] R=Matrix.Mnozenie(L,U);
            for (int i = 0; i < L.GetLength(0); i++)
            {
                for (int j = 0; j < L.GetLength(1); j++)
                {
                    Console.Write(L[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------U----------");
            for (int i = 0; i < L.GetLength(0); i++)
            {
                for (int j = 0; j < L.GetLength(1); j++)
                {
                    Console.Write(U[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Multiply----------");
            for (int i = 0; i < R.GetLength(0); i++)
            {
                for (int j = 0; j < R.GetLength(1); j++)
                {
                    Console.Write(R[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            foo();
        }
    }
};