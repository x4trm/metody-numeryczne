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
    private static double[,] DeleteRowColumn(double [,] a,int row,int column)
    {
        int r=a.GetLength(0)-1;
        int c=a.GetLength(1)-1;
        double[,] result=new double[r,c];
        for(int i=0;i<r;i++)
        {
            for(int j=0;j<c;j++)
            {
                int tmpR=i<row?i:i+1;
                int tmpC=j<column?j:j+1;
                result[i,j]=a[tmpR,tmpC];
            }
        }
        return result;
    }
    public static double LaplaceDet(double[,]a)
    {
        int liczbaWierszy=a.GetLength(0);
        int liczbaKolumn=a.GetLength(1);
        double _sum=0;
        if(liczbaWierszy==liczbaKolumn)
        {
            if(liczbaWierszy==1)
            {
                return a[0,0];
            }
            for(int i=0;i<liczbaKolumn;i++)
            {
                double tmp=a[0,i];
                double b=LaplaceDet(DeleteRowColumn(a,0,i));
                if(i%2==0)
                {
                    _sum+=tmp*b;
                }
                else{
                    _sum-=tmp*b;
                }
            }
            return _sum;
        }
        else{
            throw new Exception("Error");
        }
    }
    public static double[,] MacierzOdwrotna(double[,] a)
    {
        int liczbaWierszy=a.GetLength(0);
        int liczbaKolumn=a.GetLength(1);
        if(liczbaKolumn==liczbaWierszy)
        {
            double wyznacznik=LaplaceDet(a);
            double[,] result=new double[liczbaWierszy,liczbaKolumn];
            for(int i=0;i<liczbaWierszy;i++)
            {
                for(int j=0;j<liczbaKolumn;j++)
                {
                    result[i,j]=1.0/wyznacznik*LaplaceDet(DeleteRowColumn(a,i,j));
                    if((i+j)%2==1)
                    {
                        result[i,j]=-result[i,j];
                    }
                }
            }
            return Transpose(result);
        }
        else{
            throw new Exception("Error");
        }
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
                    for(int k=i+1;k<n+1;k++)
                    {
                        if(k!=n)
                        {
                            a[j,k]-=tmp*a[i,k];
                        }
                        else{
                            b[j]-=tmp*b[i];
                        }
                    }// petla po kolumnach
                }
            }
        }
        // for(int i=n;n>=0;i--)
        // {
        //     result[i]=b[i]/a[i,i];
        //     for(int j=i;j>=0;j--)
        //     {
        //         a[i,i]+=a[j,i]*result[i];
        //     }
        // }
        // for(int i=n-1;i>=0;i--)
        // {
        //     result=
        //     for(int j=i;j<=n-1;j++)
        //     {
        //         tmp+=a[i,j]*result[j];
        //     }
        //     result[i]=(b[i]-tmp)/a[i,i];
        // }
        // for(int i=n-1;i>=0;i--)
        // {
        //     tmp=0;
        //     for(int j=i;j<=n-1;j++)
        //     {
        //         tmp+=a[i,j]*result[j];
        //     }
        //     result[i]=(b[i]-tmp)/a[i,i];
        // }
        return result;
    }
}