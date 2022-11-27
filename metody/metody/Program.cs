
namespace metody
{
    public class Program
    {
        static void foo()
        {
            double[,] A = { { -1, 4, 2, -2 }, { 1, 2, -3, 0 }, { -1, 0, 0, 5 } };
            double[,] B = { { 2, -1 }, { 1, 3 }, { -2, 0 }, { 0, -4 } };
            double[,] C = {{-1,2,-3,3,5},{8,0,7,4,-5},{-3,4,-3,2,-2},{8,-3,-2,1,2},{-2,-1,-6,9,0}};
            double[] D={56,62,-10,14,28};
            double[,] E={{1,3,2},{4,-1,2},{1,-1,0}};
            double [,]result=Matrix.MacierzOdwrotna(E);
            // Console.Write(Matrix.LaplaceDet(E));
            // for(int i=0;i<result.GetLength(0);i++)
            // {
            //     Console.WriteLine(result[i]);
            // }
            // double[,] result = Matrix.Transpose(B);
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j] + " ");
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