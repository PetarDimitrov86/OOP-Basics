using System;

public abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumption;

    public Vehicle(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        set { this.fuelQuantity = value; }
    }

    protected double FuelConsumption
    {
        get { return this.fuelConsumption; }
        set { this.fuelConsumption = value; }
    }

    public abstract void Drive(double distance);
    public abstract void Refuel(double liters);
}

public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumption) 
        : base(fuelQuantity, fuelConsumption)
    {
    }

    public override void Drive(double distance)
    {
        if (distance > this.FuelQuantity / (this.FuelConsumption + 0.9))
        {
            Console.WriteLine($"{nameof(Car)} needs refueling");
        }
        else
        {
            base.FuelQuantity -= distance*(base.FuelConsumption + 0.9);
            Console.WriteLine($"{nameof(Car)} travelled {distance} km");
        }
    }

    public override void Refuel(double liters)
    {
        base.FuelQuantity += liters;
    }
}

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption)
        : base(fuelQuantity, fuelConsumption)
    {
    }

    public override void Drive(double distance)
    {
        if (distance > this.FuelQuantity / (this.FuelConsumption + 1.6))
        {
            Console.WriteLine($"{nameof(Truck)} needs refueling");
        }
        else
        {
            base.FuelQuantity -= distance * (base.FuelConsumption + 1.6);
            Console.WriteLine($"{nameof(Truck)} travelled {distance} km");
        }
    }

    public override void Refuel(double liters)
    {
        base.FuelQuantity += 0.95*liters;
    }

}
public class Vehicles
{
    static void Main(string[] args)
    {
        string[] carInfo = Console.ReadLine().Split();
        string[] truckInfo = Console.ReadLine().Split();

        double carFuelQuantity = double.Parse(carInfo[1]);
        double carFuelConsumption = double.Parse(carInfo[2]);

        double truckFuelQuantity = double.Parse(truckInfo[1]);
        double truckFuelConsumption = double.Parse(truckInfo[2]);

        Car car = new Car(carFuelQuantity, carFuelConsumption);
        Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption);

        int numberOfCommands = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCommands; i++)
        {
            string[] command = Console.ReadLine().Split();
            string commandType = command[0];
            string vehicleType = command[1];
            double ammount = double.Parse(command[2]);
            if (commandType.ToLower() == "drive")
            {
                if (vehicleType.ToLower() == "car")
                {
                    car.Drive(ammount);
                }
                else
                {
                    truck.Drive(ammount);
                }
            }
            else if (commandType.ToLower() == "refuel")
            {
                if (vehicleType.ToLower() == "car")
                {
                    car.Refuel(ammount);
                }
                else
                {
                    truck.Refuel(ammount);
                }
            }
        }
        Console.WriteLine($"Car: {car.FuelQuantity:f2}");
        Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
    }
}