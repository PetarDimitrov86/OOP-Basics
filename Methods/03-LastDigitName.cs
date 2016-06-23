using System;
using System.Collections.Generic;
using System.Linq;
public class Number
{
    public int number;

    public Number(int number)
    {
        this.number = number;
    }

    public string GetLastDigitName()
    {
        string numberAsString = number.ToString();
        char lastDigit = numberAsString[numberAsString.Length - 1];
        switch (lastDigit)
        {
            case '0': return "zero"; break;
            case '1': return "one"; break;
            case '2': return "two"; break;
            case '3': return "three"; break;
            case '4': return "four"; break;
            case '5': return "five"; break;
            case '6': return "six"; break;
            case '7': return "seven"; break;
            case '8': return "eight"; break;
            case '9': return "nine"; break;
        }
        return "empty";
    }
}

class LastDigitName
{
    static void Main(string[] args)
    {
        int num = int.Parse(Console.ReadLine());
        Number givenNum = new Number(num);
        Console.WriteLine(givenNum.GetLastDigitName());
    }
}