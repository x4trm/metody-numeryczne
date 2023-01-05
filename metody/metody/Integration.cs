namespace metody;
public static class Integration
{
    public static double MetodaProstokatow(double a,double b,int steps,Func<double,double>f)
    {
        double h=(b-a)/steps,x=a,result=0.0;
        for(int i =0;i<=steps;i++)
        {
            result+=f(x)*h;
            x+=h;
        }
        return result;
    }
    public static double MetodaTrapezow(double a,double b,int steps,Func<double,double>f)
    {
        double h=(b-a)/steps,x=a,result=0.0;
        for(int i=0;i<=steps-1;i++)
        {
            result+=0.5*h*(f(x)+f(x+h));
            x+=h;
        }
        return result;
    }
    public static double MetodaSimpsona(double a,double b,int steps,Func<double,double> f)
    {
        double h=(b-a)/steps;
        double x=a,result=0.0;
        for (int i = 0; i <= steps-1; i++)
        {
            result += f(x)+4*f((x+x+h)/2)+f(x+h);
            x += h;
        }
        return 1.0/6.0*h*result;
    }
    public static double f1(double x)
    {
        return 4*x*x*x+5*x*x+1;
    }
    public static double f2(double x)
    {
        return 2.0/Math.Sqrt(Math.PI) * Math.Exp(-x*x);        
    }
    public static double f3(double x)
    {
        return Math.Cos(x) + Math.Exp(x) + Math.Tan(x);        
    }
    private static double Pojazd(double t)
    {
        return 5*Math.Sin(t)*Math.Sin(t);
    }
    public static void Ex7()
    {
        double correct = 149.2742360197346071383;
        
        int steps = 3000;
        double result = MetodaProstokatow(0, 60, steps, Pojazd);
        double err = Math.Abs(result - correct);
        Console.WriteLine($"Metoda Prostokatow: Kroki={steps}, wynik={result}, Error={err}");
        
        steps = 500;
        result = MetodaTrapezow(0, 60, steps, Pojazd);
        err = Math.Abs(result - correct);
        Console.WriteLine($"Metoda Trapezow: Kroki={steps}, wynik={result}, Error={err}");
        
        steps = 80;
        result = MetodaSimpsona(0, 60, steps, Pojazd);
        err = Math.Abs(result - correct);
        Console.WriteLine($"Metoda Simpsona: Kroki={steps}, wynik={result}, Error={err}");        
    }
}
