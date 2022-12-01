namespace metody;

public static class Interpolation
{
    public static double[] Solve(double[,] U, double[] f)
    {
        double[] result=Matrix.Gauss(U,f);
        return result; 
    }
}