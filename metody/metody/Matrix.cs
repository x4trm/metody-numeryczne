using System.Diagnostics.CodeAnalysis;

namespace metody;

public static class Matrix
{
    public static double[,] mnozenie(double[,] a, double[,] b)
    {
        int liczbaWierszyA = a.GetLength(0);
        int liczbaKolumnA = a.GetLength(1);
        int liczbaWierszyB = b.GetLength(0);
        int liczbaKolumnB = b.GetLength(1);
        if (liczbaKolumnA == liczbaWierszyB)
        {
            double[,] c=new double[liczbaWierszyA,liczbaKolumnB];
            for (int i = 0; i < liczbaWierszyA; i++)
            {
                for (int j = 0; j < liczbaKolumnB; j++)
                {
                    c[i, j] = 0.0;
                    for (int k = 0; k < liczbaKolumnA; k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return c;
        }
        else
        {
            throw new Exception("Error");
        }
    }
}