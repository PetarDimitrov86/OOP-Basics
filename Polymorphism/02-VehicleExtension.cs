using System;

public abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumption;
    private double tankCapacity;

    public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
        this.TankCapacity = tankCapacity;
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            this.fuelQuantity = value;
        }
    }

    protected double FuelConsumption
    {
        get { return this.fuelConsumption; }
        set { this.fuelConsumption = value; }
    }
    protected double TankCapacity
    {
        get { return this.tankCapacity; }
        set { this.tankCapacity = value; }
    }

    public abstract void Drive(double distance);

    public virtual void Refuel(double liters)
    {
        if (liters + this.FuelQuantity > this.TankCapacity)
        {
            Console.WriteLine("Cannot fit fuel in tank");
        }
        else
        {
            this.FuelQuantity += liters;
        }
    }
}

public class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
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
            base.FuelQuantity -= distance * (base.FuelConsumption + 0.9);
            Console.WriteLine($"{nameof(Car)} travelled {distance} km");
        }
    }
}

public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
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
        base.FuelQuantity += 0.95 * liters;
    }
}

public class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    public override void Drive(double distance)
    {
        if (distance > this.FuelQuantity / (this.FuelConsumption + 1.4))
        {
            Console.WriteLine($"{nameof(Bus)} needs refueling");
        }
        else
        {
            base.FuelQuantity -= distance * (base.FuelConsumption + 1.4);
            Console.WriteLine($"{nameof(Bus)} travelled {distance} km");
        }
    }


    public void DriveEmpty(double distance)
    {
        if (distance > this.FuelQuantity / this.FuelConsumption)
        {
            Console.WriteLine($"{nameof(Bus)} needs refueling");
        }
        else
        {
            base.FuelQuantity -= distance * base.FuelConsumption;
            Console.WriteLine($"{nameof(Truck)} travelled {distance} km");
        }
    }
}

class VehicleExtension
{
    static void Main(string[] args)
    {
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();
            string[] busInfo = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carInfo[1]);
            double carFuelConsumption = double.Parse(carInfo[2]);
            double carTankCapacity = double.Parse(carInfo[3]);

            double truckFuelQuantity = double.Parse(truckInfo[1]);
            double truckFuelConsumption = double.Parse(truckInfo[2]);
            double truckTankCapacity = double.Parse(truckInfo[3]);

            double busFuelQuantity = double.Parse(busInfo[1]);
            double busFuelConsumption = double.Parse(busInfo[2]);
            double busTankCapacity = double.Parse(busInfo[3]);

            Car car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);
            Truck truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);
            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            int numberOfCommands = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split();
                string commandType = command[0];
                string vehicleType = command[1];
                double ammount = double.Parse(command[2]);

                switch (commandType.ToLower())
                {
                    case "drive":
                        switch (vehicleType.ToLower())
                        {
                            case "car": car.Drive(ammount); break;
                            case "bus": bus.Drive(ammount); break;
                            case "truck": truck.Drive(ammount); break;
                        }
                        break;
                    case "refuel":
                        switch (vehicleType.ToLower())
                        {
                            case "car": car.Refuel(ammount); break;
                            case "bus": bus.Refuel(ammount); break;
                            case "truck": truck.Refuel(ammount); break;
                        }
                        break;
                    case "driveempty":
                        bus.DriveEmpty(ammount);
                        break;
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }
    }
}
