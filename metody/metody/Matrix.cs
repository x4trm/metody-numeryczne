
namespace metody;

public static class Matrix
{
#region Mnozenie
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
    public static double[] Mnozenie(double[,] a, double[] b)
    {
        int liczbaWierszy = a.GetLength(0);
        int liczbaKolumn = a.GetLength(1);
        if (liczbaKolumn != b.Length)
            throw new Exception("Error");

        double[] result = new double[liczbaWierszy];
        for (int i = 0; i < liczbaWierszy; i++)
        {
            double _sum = 0;
            for (int j = 0; j < liczbaKolumn; j++)
            {

                _sum += a[i, j] * b[j];
            }
            result[i] = _sum;
        }
        return result;
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
#endregion
#region Wyznaczniki
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
#endregion
#region Transpose
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
#endregion
#region Helper
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
#endregion
#region LaplaceWyznacznik
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
#endregion
#region MacierzOdwrotna
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
#endregion
#region Cramer
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
#endregion
#region GaussElimination
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
#endregion
#region GaussJordan
	    public static double[] GaussJordan(double[,] a,double[] b)
	    {
	        int liczbaWierszy=a.GetLength(0);
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
	
	        for(int i=0;i<liczbaWierszy;i++)
	        {
	            for(int j=0;j<liczbaWierszy;j++)
	            {
	                if(j!=i)
	                {
	                    double tmp=a[j,i]/a[i,i];
	                    for(int k=0;k<liczbaWierszy+1;k++)
	                    {
	                        if(k!=liczbaWierszy)
	                        {
	                            a[j,k]=a[j,k]-tmp*a[i,k];
	                        }
	                        else{
	                            b[j]=b[j]-tmp*b[i];
	                        }
	                    }
	                }
	            }
	        }
	        for(int i=liczbaWierszy-1; i>=0; i--)
	        {
	            double tmp=0;
	            for(int j=i; j<=liczbaWierszy-1; j++)
	                tmp+=a[i,j]*result[j];
	            
	            result[i]=(b[i]-tmp)/a[i,i];
	        }
	
	        return result;
	                      
	    }
#endregion
#region GaussPivoting
	public static double[] GaussPivoting(double[,] a,double[] b)
	{
	    int liczbaWierszy=a.GetLength(0);
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
	
	    for(int i=0;i<liczbaWierszy;i++)
	    {
	        int rowMaxAbs=i;
	        for(int j=i+1;j<liczbaWierszy;j++)
	        {
	            if(Math.Abs(a2[j,i])>Math.Abs(a2[rowMaxAbs,i]))
	            {
	                rowMaxAbs=j;
	            }
	        }
	        if(rowMaxAbs!=i)
	        {
	            double tmp;
	            for(int k=i;k<liczbaWierszy;k++)
	            {
	                tmp=a2[i,k];
	                a2[i,k]=a2[rowMaxAbs,k];
	                a2[rowMaxAbs,k]=tmp;
	            }
	            tmp=b2[i];
	            b2[i]=b2[rowMaxAbs];
	            b2[rowMaxAbs]=tmp;
	        }
	        for(int w=0;w<liczbaWierszy;w++)
	        {
	            for(int j=0;j<liczbaWierszy;j++)
	            {
	                if(j!=w)
	                {
	                    double tmp=a2[j,w]/a2[w,w];
	                    for(int k=0;k<liczbaWierszy+1;k++)
	                    {
	                        if(k!=liczbaWierszy)
	                        {
	                            a2[j,k]=a2[j,k]-tmp*a2[w,k];
	                        }
	                        else
                            {
	                            b2[j]=b2[j]-tmp*b2[w];
	                        }
	                    }
	                }
	            }
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
#endregion
#region OdwracanieMacierzyGauss
	public static double[,] OdwracanieMacierzyGauss(double[,] a)
	{
	    int liczbaWierszy=a.GetLength(0);
	    if (liczbaWierszy != a.GetLength(1))
	        throw new Exception("Error");
	
	    double[,] result = new double[liczbaWierszy,liczbaWierszy];
	    double[] e = new double[liczbaWierszy];
	    for(int i=0;i<liczbaWierszy;i++)
	    {
	        for(int j=0;j<liczbaWierszy;j++)
	        {
	            if(j==i)
	                e[j]=1;
	            else
	                e[j]=0;
	        }
	        double[] tmp=Gauss(a,e);
	        for(int j=0;j<liczbaWierszy;j++)
	        {
	            result[j,i]=tmp[j];
	        }
	
	    }
	    return result;
	}
	
#endregion
#region LU
	public static (double[,],double[,]) Doolitle(double[,] a)
	{
		int liczbaWierszy=a.GetLength(0);
		if(liczbaWierszy!=a.GetLength(1))
		{
			throw new Exception("Error");
		}
		double[,] U=new double[liczbaWierszy,liczbaWierszy];
		double[,] L=new double[liczbaWierszy,liczbaWierszy];
		for(int i=0;i<liczbaWierszy;i++)
		{
			for(int j=0;j<liczbaWierszy;j++)
			{
				U[i,j]=a[i,j];
			}
		}
		for(int i=0;i<liczbaWierszy;i++)
		{
			L[i,i]=1;
		}
		for (int i = 0; i < liczbaWierszy; i++) 
        {
            for (int j = i + 1; j < liczbaWierszy; j++)
            {
                double x = U[j, i] / U[i, i];
                U[j, i] = 0;
                for (int k = i + 1; k < liczbaWierszy; k++)
                {
                    U[j, k] = U[j, k] - x * U[i, k];
                }
                L[j, i] = x;
            }
        }
		return (L,U);
	} 
	public static double[] SolveLU(double[,] L,double[] b)
	{
        int liczbaWierszy = L.GetLength(0);
        if (liczbaWierszy != L.GetLength(1) || liczbaWierszy != b.Length)
            throw new Exception("Error");

        double[] result= new double [liczbaWierszy];
        for(int i=0; i<liczbaWierszy; i++)
        {

            double x = b[i];
            for(int j=0; j<liczbaWierszy; j++)
            {
                x -= result[j] * L[i, j];
            }
            x /= L[i, i];
            result[i] = x;
        }
        return result;	
	}
	public static double[] SolveL(double[,] L,double[]b)
	{
        int liczbaWierszy = L.GetLength(0);
        if (liczbaWierszy != L.GetLength(1) || liczbaWierszy != b.Length)
            throw new Exception("Error");
		double[] result=new double[liczbaWierszy];
		for(int i=0;i<liczbaWierszy;i++)
		{
			double tmp=b[i];
			for(int j=0;j<liczbaWierszy;j++)
			{
				tmp-=result[j]*L[i,j];
			}
			tmp/=L[i,i];
			result[i]=tmp;
		}
		return result;
	}
	public static double[] SolveU(double[,] U,double[] b)
	{
        int liczbaWierszy = U.GetLength(0);
        if (liczbaWierszy != U.GetLength(1) || liczbaWierszy != b.Length)
            throw new Exception("Error");	
		double[] result=new double[liczbaWierszy];
		for(int i=liczbaWierszy-1;i>=0;i--)
		{
			double tmp=b[i];
			for(int j=i+1;j<liczbaWierszy;j++)
			{
				tmp-=result[j]*U[i,j];
			}
			tmp/=U[i,i];
			result[i]=tmp;
		}
		return result;	
	}
#endregion
}