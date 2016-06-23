using System;
using System.Collections.Generic;
using System.Linq;

public class Fibonacci
{
    List<long> fibList = new List<long>();

    public Fibonacci(long n)
    {
        List<long> resultList = new List<long>();
        long num1 = 0;
        long num2 = 1;
        resultList.Add(num1);
        resultList.Add(num2);
        long num3 = 0;
        for (int i = 0; i <= n; i++)
        {
            num3 = num1 + num2;
            num1 = num2;
            num2 = num3;
            resultList.Add(num3);
        }
        this.fibList = resultList;
    }

    public List<long> GetNumbersInRange(int startPos, int endPos)
    {
        List<long> numbersInRange = new List<long>();
        for (int i = startPos; i < endPos; i++)
        {
            numbersInRange.Add(fibList[i]);
        }
        return numbersInRange;
    }
}

class FibonacciNumbers
{
    static void Main(string[] args)
    {
        int startPos = int.Parse(Console.ReadLine());
        int endPos = int.Parse(Console.ReadLine());
        Fibonacci fibNums = new Fibonacci(endPos);
        Console.WriteLine(string.Join(", ", fibNums.GetNumbersInRange(startPos, endPos)));
    }
}
