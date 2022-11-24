using System.Diagnostics.CodeAnalysis;

namespace metody;

public static class Matrix
{
    public static double[,] Mnozenie(double[,] a, double[,] b)
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
    public static double[,] MnozeniePrzezSkalar(double[,] a,double b)
    {
        int liczbaWierszyA = a.GetLength(0);
        int liczbaKolumnA = a.GetLength(1);
        for(int i=0;i<liczbaWierszyA;i++)
        {
            for(int j=0;j<liczbaKolumnA;j++)
            {
                a[i,j]*=b;
            }
        }
        return a;
    }
    public static double Wyznacznik2x2(double[,] a)
    {
        return a[0,0]*a[1,1]-a[0,1]*a[1,0];
    }
    public static double Wyznacznik3x3(double[,] a)
    {
        double A=a[0,0]*a[1,1]*a[2,2]+a[1,0]*a[2,1]*a[0,2]+a[2,0]*a[0,1]*a[1,2];
        double B=a[1,0]*a[0,1]*a[2,2]+a[0,0]*a[2,1]*a[1,2]+a[2,0]*a[1,1]*a[0,2];
        return A-B;
    }
    public static double[,] Transpose(double[,] a)
    {
        int liczbaWierszyA = a.GetLength(0);
        int liczbaKolumnA = a.GetLength(1);
        double[,] result=new double[liczbaKolumnA,liczbaWierszyA];
        for(int i=0;i<liczbaWierszyA;i++)
        {
            for(int j=0;j<liczbaKolumnA;j++)
            {
                result[j,i]=a[i,j];
            }
        }
        return result;
    }
    public static double[] Gauss(double[,] a,double[]b)
    {
        int n = a.GetLength(0);
        double[] result=new double[n];
        double tmp=0;
        for(int i=0;i<n;i++)
        {
            for(int j=0;j<n;j++)
            {    
                if(j>i)
                {
                    tmp = a[j,i] / a[i,i]; // mnożnik
                    for(int k=i;k<n+1;k++)
                    {
                        if(k!=n)
                        {
                            a[j,k]-=tmp*a[i,k];
                        }
                        else{
                            b[j]=b[j]-tmp*b[i];
                        }
                    }// petla po kolumnach
                }
            }
        }

        for(int i=n-1;i>=0;i--)
        {
            tmp=0;
            for(int j=i;j<=n-1;j++)
            {
                tmp+=a[i,j]*result[j];
            }
            result[i]=(b[i]-tmp)/a[i,i];
        }
        return result;
    }
}