using System;
using System.Linq;

public class Car
{
    public decimal speed;
    public decimal fuel;
    public decimal fuelEconomy;

    public decimal distanceTravelled = 0;
    public int hours = 0;
    public int minutes = 0;

    public Car(decimal speed, decimal fuel, decimal fuelEconomy)
    {
        this.speed = speed;
        this.fuel = fuel;
        this.fuelEconomy = fuelEconomy;
    }

    public void Travel(decimal distance)
    {
        decimal possibleDistance = Math.Min((fuel / fuelEconomy) * speed, distance);
        distanceTravelled += possibleDistance;        
        fuel -= fuelEconomy * possibleDistance/speed ;
        hours += (int)(possibleDistance / speed);
        minutes += (int)(possibleDistance % speed);
    }

    public void Refuel(decimal liters)
    {
        this.fuel += liters;
    }

    public void Distance()
    {
        Console.WriteLine("Total distance: {0:f1} kilometers", distanceTravelled);
    }
    public void Time()
    {
        Console.WriteLine("Total time: {0} hours and {1} minutes", hours, minutes);
    }
    public void Fuel()
    {
        Console.WriteLine("Fuel left: {0:f1} liters", fuel);
    }
}

class CarExercise
{
    static void Main(string[] args)
    {
        decimal[] carInfo = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
        Car ourCar = new Car(carInfo[0], carInfo[1], carInfo[2]);
        string input = Console.ReadLine();
        while (input != "END")
        {
            string[] command = input.Split();
            if (command.Length>1)
            {
                if (command[0] == "Travel")
                {
                    ourCar.Travel(decimal.Parse(command[1]));
                }
                else if (command[0] == "Refuel")
                {
                    ourCar.Refuel(decimal.Parse(command[1]));
                }
            }
            else
            {
                if (input == "Distance")
                {
                    ourCar.Distance();
                }
                else if (input == "Time")
                {
                    ourCar.Time();
                }
                else if (input == "Fuel")
                {
                    ourCar.Fuel();
                }
            }
            input = Console.ReadLine();
        }
    }
}
