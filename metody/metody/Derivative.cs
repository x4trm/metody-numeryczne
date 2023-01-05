namespace metody;

public static class Derivative
{
    // Zadanie 6.1
    public static double DerivativeSin(double x)
    {
        //f(x)=xsin(x^2)+1
        return Math.Sin(x*x)+2*x*x*Math.Cos(x*x);
    }
    // Zadanie 6.2
    // 3x^3-2x^2+1
    private static double func(double x)
    {
        return 3*x*x*x-2*x*x+1;
    }
    public static void DerivativeFunc(double x)
    {
        for (double h=1; h>1E-15; h/=10)
        {
            Console.WriteLine($"h = {h}");
            double f1 = (func(x + h) - func(x)) / h;
            Console.WriteLine($"Dwupunktowe roznice zwykle: {f1}");
            double f2 = (func(x+h)-func(x-h))/(2*h);
            Console.WriteLine($"Dwupunktowe roznice centralne: {f2}");
            double f3 = ((4 * func(x + h)) - (3 * func(x)) - func(x + (2 * h))) / (2 * h);
            Console.WriteLine($"Trzypunktowe roznice zwykle: {f3}");
        }
    }
    // Zadanie 6.3
    private static double funcSin(double x)
    {
        return x*Math.Sin(x*x)+1;
    }
    public static void DerivativeFuncSin(double x)
    {
        for(double h=1;h>1E-15;h/=10)
        {
            Console.WriteLine($"h = {h}");
            double f1 = (funcSin(x + h) - funcSin(x)) / h;
            Console.WriteLine($"Dwupunktowe roznice zwykle: {f1}");
            double f2 = (funcSin(x+h)-funcSin(x-h))/(2*h);
            Console.WriteLine($"Dwupunktowe roznice centralne: {f2}");
        }
    }

    // Zadanie 6.4
    public static void DerivativeFuncExp(double x)
    {
        for(double h=1;h>1E-15;h/=10)
        {
            Console.WriteLine($"h = {h}");
            double f2 = (Math.Exp(x+h)-Math.Exp(x-h))/(2*h);
            Console.WriteLine($"Dwupunktowe roznice centralne: {f2}");
            double f3 = ((4 * Math.Exp(x + h)) - (3 * Math.Exp(x)) - Math.Exp(x + (2 * h))) / (2 * h);
            Console.WriteLine($"Trzypunktowe roznice zwykle: {f3}");
        }
    }
    // Zadanie 6.5
    public static void SecondDerivativeFunc(double x)
    {
        for (double h=1; h>1E-10; h/=10)
        {
            Console.WriteLine($"h = {h}");
            double f1 = (func(x)-2*func(x+h)+func(x+2*h)) / h*h;
            Console.WriteLine($"Trzypunktowe roznice zwykle: {f1}");
            double f2 = (func(x+h)-2*func(x)+func(x-h))/(2*h);
            Console.WriteLine($"Trzypunktowe roznice centralne: {f2}");
        }        
    }
    // Zadanie 6.6
    public static void SecondDerivativeFuncExp(double x)
    {
        for(double h=1;h>1E-7;h/=10)
        {
            Console.WriteLine($"h = {h}");
            double f1 = (Math.Exp(x)-2*Math.Exp(x+h)+Math.Exp(x+2*h)) / h*h;
            Console.WriteLine($"Trzypunktowe roznice zwykle: {f1}");
            double f2 = (Math.Exp(x+h)-2*Math.Exp(x)+Math.Exp(x-h))/(2*h);
            Console.WriteLine($"Trzypunktowe roznice centralne: {f2}");
        }
    }
}