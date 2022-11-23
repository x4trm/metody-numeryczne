
namespace metody
{
    public class Program
    {
        static void MnozenieDwochMacierzy()
        {
            double[,] A = { { -1, 4, 2, -2 }, { 1, 2, -3, 0 }, { -1, 0, 0, 5 } };
            double[,] B = { { 2, -1 }, { 1, 3 }, { -2, 0 }, { 0, -4 } };
            double[,] result = Matrix.mnozenie(A, B);
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
            MnozenieDwochMacierzy();
        }
    }
};