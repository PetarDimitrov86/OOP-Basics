using System;
public class Number
{
    public int num;
    public bool isPrime;

    public Number(int num)
    {
        this.num = num;
        this.isPrime = CheckPrimeStatus(num);
    }

    public bool CheckPrimeStatus(int num)
    {
        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    public static int GetNextPrime(int num)
    {
        bool numFound;
        for (int i = num + 1; i < Int32.MaxValue; i++)
        {
            numFound = false;
            for (int j = 2; j <= num; j++)
            {
                if (i % j == 0)
                {
                    numFound = true;
                }
            }
            if (numFound == false)
            {
                return i;
            }
        }
        return 0;
    }
}

class PrimeChecker
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Number ourNum = new Number(0);
        ourNum = new Number(n);
        int numToDisplay = Number.GetNextPrime(ourNum.num);
        string trueOrFalse = ourNum.isPrime.ToString().ToLower();
        Console.WriteLine($"{numToDisplay}, {trueOrFalse}");
    }
}