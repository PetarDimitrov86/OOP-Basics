using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Car
{
    public Car(string model, decimal fuelAmount, decimal fuelCostPerKm)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelCostPerKm = fuelCostPerKm;
    }
    public string model;
    public decimal fuelAmount;
    public decimal fuelCostPerKm;
    public decimal distanceTravelled = 0;

    public static bool CanMove(decimal fuelAmount, decimal fuelCost, decimal KMtoTravel)
    {
        if (KMtoTravel <= fuelAmount / fuelCost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static decimal UsedFuel(decimal fuelAmount, decimal fuelCost, decimal KMtoTravel)
    {
        return fuelAmount - fuelCost * KMtoTravel;
    }
}

class SpeedRacing
{
    static void Main(string[] args)
    {
        int carsToTrack = int.Parse(Console.ReadLine());
        List<Car> listCars = new List<Car>();
        for (int i = 0; i < carsToTrack; i++)
        {
            string[] carInfo = Console.ReadLine().Split(' ').ToArray();
            string model = carInfo[0];
            decimal fuelAmount = decimal.Parse(carInfo[1]);
            decimal fuelCost = decimal.Parse(carInfo[2]);
            Car tempCar = new Car(model, fuelAmount, fuelCost);
            listCars.Add(tempCar);
        }
        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] drivingInfo = input.Split().ToArray();
            string carModel = drivingInfo[1];
            decimal distanceToTravel = decimal.Parse(drivingInfo[2]);
            foreach (var car in listCars)
            {
                if (car.model == carModel)
                {
                    if (Car.CanMove(car.fuelAmount, car.fuelCostPerKm, distanceToTravel))
                    {
                        car.fuelAmount = Car.UsedFuel(car.fuelAmount, car.fuelCostPerKm, distanceToTravel);
                        car.distanceTravelled += distanceToTravel;
                    }
                    else
                    {
                        Console.WriteLine("Insufficient fuel for the drive");
                    }
                }
            }
            input = Console.ReadLine();
        }
        foreach (var car in listCars)
        {
            Console.WriteLine($"{car.model} {car.fuelAmount:f2} {car.distanceTravelled}");
        }
    }
}