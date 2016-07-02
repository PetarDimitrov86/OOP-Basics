using System;

public class MathUtil
{
    public static double Sum(double firstNum, double secondNum)
    {
        return firstNum + secondNum;
    }
    public static double Subtract(double firstNum, double secondNum)
    {
        return firstNum - secondNum;
    }
    public static double Multiply(double firstNum, double secondNum)
    {
        return firstNum * secondNum;
    }
    public static double Divide(double firstNum, double secondNum)
    {
        return firstNum / secondNum;
    }
    public static double Percentage(double firstNum, double secondNum)
    {
        return (firstNum * secondNum) / 100;
    }
}

class BasicMath
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] command = input.Split();
            string type = command[0];
            double firstNum = double.Parse(command[1]);
            double secondNum = double.Parse(command[2]);

            switch (type)
            {
                case "Sum":
                    Console.WriteLine("{0:f2}", MathUtil.Sum(firstNum, secondNum));
                    break;
                case "Subtract":
                    Console.WriteLine("{0:f2}", MathUtil.Subtract(firstNum, secondNum));
                    break;
                case "Multiply":
                    Console.WriteLine("{0:f2}", MathUtil.Multiply(firstNum, secondNum));
                    break;
                case "Divide":
                    Console.WriteLine("{0:f2}", MathUtil.Divide(firstNum, secondNum));
                    break;
                case "Percentage":
                    Console.WriteLine("{0:f2}", MathUtil.Percentage(firstNum, secondNum));
                    break;
            }
            input = Console.ReadLine();
        }
    }
}
