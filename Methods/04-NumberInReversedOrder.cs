using System;
using System.Text;

public class DecimalNumber
{
    public decimal number;

    public DecimalNumber(decimal number)
    {
        this.number = number;
    }

    public decimal ReverseNumbers()
    {
        string decimalAsString = number.ToString();
        StringBuilder reversed = new StringBuilder();
        for (int i = decimalAsString.Length - 1; i >= 0 ; i--)
        {
            reversed.Append(decimalAsString[i]);
        }
        return decimal.Parse(reversed.ToString());
    }
}

class NumberInReversedOrder
{
    static void Main(string[] args)
    {
        decimal n = decimal.Parse(Console.ReadLine());
        DecimalNumber decN = new DecimalNumber(n);
        Console.WriteLine(decN.ReverseNumbers());
    }
}