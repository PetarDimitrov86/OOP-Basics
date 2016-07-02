using System;

class TemperatureConverter
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] commandInfo = input.Split();
            int degrees = int.Parse(commandInfo[0]);
            string type = commandInfo[1];
            Console.WriteLine(ConvertTemperature(degrees, type));
            input = Console.ReadLine();
        }      
    }
    public static string ConvertTemperature(int degrees, string type)
    {
        string result = string.Empty;
        double convertedDegrees = 0.0;
        switch (type)
        {
            case "Celsius":
                result = "Fahrenheit";
                convertedDegrees = degrees*1.8 + 32;
                break;
            case "Fahrenheit":
                result = "Celsius";
                convertedDegrees = (degrees - 32)*5/9.0;
                break;
        }
        return string.Format($"{convertedDegrees:f2} {result}");
    }
}