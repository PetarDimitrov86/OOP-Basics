using System;

public class Calculation
{
    public static double plankConst = 6.62606896e-34;
    public static double PI = 3.14159;

    public static double ReturnResult()
    {
        double result = plankConst/(2*PI);
        return result;
    }
}

class PlanckConstant
{
    static void Main(string[] args)
    {
        Console.WriteLine(Calculation.ReturnResult());
    }
}