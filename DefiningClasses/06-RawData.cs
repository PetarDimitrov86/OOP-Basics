using System;
using System.Collections.Generic;
using System.Linq;

class Car
{
    public string model;
    public Engine engine;
    public Cargo cargo;
    public Tire tire1;
    public Tire tire2;
    public Tire tire3;
    public Tire tire4;

    public Car(string model, Engine engine, Cargo cargo, Tire tire1, Tire tire2, Tire tire3, Tire tire4)
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tire1 = tire1;
        this.tire2 = tire2;
        this.tire3 = tire3;
        this.tire4 = tire4;
    }
}

public class Engine
{
    public int speed;
    public int power;

    public Engine(int speed, int power)
    {
        this.speed = speed;
        this.power = power;
    }
}

public class Cargo
{
    public int weight;
    public string type;

    public Cargo(int weight, string type)
    {
        this.weight = weight;
        this.type = type;
    }
}

public class Tire
{
    public int age;
    public double pressure;

    public Tire(double pressure, int age)
    {
        this.pressure = pressure;
        this.age = age;
    }
}
public class RawData
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Car> carList = new List<Car>();
        for (int i = 0; i < n; i++)
        {
            string[] carInfo = Console.ReadLine().Split(' ').ToArray();
            string model = carInfo[0];
            int engineSpeed = int.Parse(carInfo[1]);
            int enginePower = int.Parse(carInfo[2]);
            int cargoWeight = int.Parse(carInfo[3]);
            string cargoType = carInfo[4];
            double tire1Pressure = double.Parse(carInfo[5]);
            int tire1Age = int.Parse(carInfo[6]);
            double tire2Pressure = double.Parse(carInfo[7]);
            int tire2Age = int.Parse(carInfo[8]);
            double tire3Pressure = double.Parse(carInfo[9]);
            int tire3Age = int.Parse(carInfo[10]);
            double tire4Pressure = double.Parse(carInfo[11]);
            int tire4Age = int.Parse(carInfo[12]);
            Engine tempEngine = new Engine(engineSpeed, enginePower);
            Cargo tempCargo = new Cargo(cargoWeight, cargoType);
            Tire temptire1 = new Tire(tire1Pressure, tire1Age);
            Tire temptire2 = new Tire(tire2Pressure, tire2Age);
            Tire temptire3 = new Tire(tire3Pressure, tire3Age);
            Tire temptire4 = new Tire(tire4Pressure, tire4Age);
            Car tempCar = new Car(model, tempEngine, tempCargo, temptire1, temptire2, temptire3, temptire4);
            carList.Add(tempCar);
        }
        string searchedType = Console.ReadLine();
        var result = carList.Where(x => x.cargo.type == "fragile" && (x.tire1.pressure <1 
                                 || x.tire2.pressure < 1 || x.tire3.pressure < 1 || x.tire4.pressure < 1));
        if (searchedType == "flamable")
        {
            result = carList.Where(x => x.cargo.type == "flamable" && x.engine.power > 250);
        }
        foreach (var item in result)
        {
            Console.WriteLine(item.model);
        }
    }
}
