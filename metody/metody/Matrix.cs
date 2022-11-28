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
    public static double[] Cramer(double[,] a,double[] b)
    {
        int liczbaWierszy=a.GetLength(0);
        if(liczbaWierszy!=a.GetLength(1) || liczbaWierszy!=b.Length)
        {
            throw new Exception("Error");
        }
        double[] result= new double[liczbaWierszy];
        double[] tmp=new double[liczbaWierszy];
        double wyznacznik=LaplaceDet(a);
        for(int i=0;i<liczbaWierszy;i++)
        {
            for(int j=0;j<liczbaWierszy;j++)
            {
                tmp[j]=a[j,i];
            }
            for(int j=0;j<liczbaWierszy;j++)
            {
                a[j,i]=b[j];
            }
            double det=LaplaceDet(a);
            for(int j=0;j<liczbaWierszy;j++)
            {
                a[j,i]=tmp[j];
            }
            result[i]=det/wyznacznik;
        }
        return result;
    }
    public static double[] Gauss(double[,] a, double[] b)
        {

            int liczbaWierszy = a.GetLength(0);
            if (liczbaWierszy != a.GetLength(1) || liczbaWierszy != b.Length)
                throw new Exception("Error");

            double[] result = new double[liczbaWierszy];
            double[,] a2 = new double[liczbaWierszy, liczbaWierszy];
            for (int i = 0; i < liczbaWierszy; i++)
            {
                for (int j = 0; j < liczbaWierszy; j++)
                    a2[i, j] = a[i, j];
            }
            double[] b2 = new double[liczbaWierszy];
            for (int i = 0; i < liczbaWierszy; i++)
                b2[i] = b[i];

            
            for (int i = 0; i < liczbaWierszy; i++) 
            {
                for (int j = i + 1; j < liczbaWierszy; j++)
                {
                    double tmp = a2[j, i] / a2[i, i];
                    a2[j, i] = 0;
                    for (int k = i + 1; k < liczbaWierszy; k++)
                    {
                        a2[j, k] = a2[j, k] - tmp * a2[i, k];
                    }
                    b2[j] = b2[j] - tmp * b2[i];
                }
            }

            for (int i = liczbaWierszy - 1; i >= 0; i--)
            {
                double tmp = b2[i];
                for (int j = i + 1; j < liczbaWierszy; j++)
                    tmp -= a2[i, j] * result[j];
                tmp /= a2[i, i];
                result[i] = tmp;
            }
            return result;

        }
 
}