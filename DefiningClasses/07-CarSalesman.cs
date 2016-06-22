using System;
using System.Collections.Generic;
using System.Linq;

public class Car
{
    public string model;
    public Engine engine;
    public string weight = "n/a";
    public string colour = "n/a";

    public Car(string model, Engine engine)
    {
        this.model = model;
        this.engine = engine;
    }
}

public class Engine
{
    public string model;
    public int power;
    public string displacement = "n/a";
    public string efficiency = "n/a";

    public Engine(string model, int power)
    {
        this.model = model;
        this.power = power;
    }
}

class CarSalesman
{
    static void Main(string[] args)
    {
        int engineLines = int.Parse(Console.ReadLine());
        List<Engine> engineList = new List<Engine>();
        for (int i = 0; i < engineLines; i++)
        {
            string[] engineInfo = Console.ReadLine().Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string engineModel = engineInfo[0];
            int enginePower = int.Parse(engineInfo[1]);
            Engine tempEngine = new Engine(engineModel, enginePower);
            if (engineInfo.Length > 2)
            {
                int tryDisplacement;
                bool displacementAvailable = Int32.TryParse(engineInfo[2], out tryDisplacement);
                if (displacementAvailable)
                {
                    tempEngine.displacement = engineInfo[2];
                }
                else
                {
                    tempEngine.efficiency= engineInfo[2];
                }
            }
            if (engineInfo.Length > 3)
            {
                string efficiency = engineInfo[3];
                tempEngine.efficiency = efficiency;
            }
            engineList.Add(tempEngine);
        }
        List<Car> carList = new List<Car>();
        int numberOfCars = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCars; i++)
        {
            string[] carsInfo = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string model = carsInfo[0];
            string engineName = carsInfo[1];
            Engine tempEngine = new Engine(" ", 5);
            foreach (var engine in engineList)
            {
                if (engine.model == engineName)
                {
                    tempEngine = engine;
                }
            }
            Car tempCar = new Car(model, tempEngine);
            if (carsInfo.Length > 2)
            {
                int tryWeight;
                bool weightAvailable = Int32.TryParse(carsInfo[2], out tryWeight);
                if (weightAvailable)
                {
                    tempCar.weight = carsInfo[2];
                }
                else
                {
                    tempCar.colour = carsInfo[2];
                }
            }
            if (carsInfo.Length > 3)
            {
                string colour = carsInfo[3];
                tempCar.colour = colour;
            }
            carList.Add(tempCar);
        }
        foreach (var car in carList)
        {
            Console.WriteLine("{0}:", car.model);
            Console.WriteLine("  {0}:", car.engine.model);
            Console.WriteLine("    Power: {0}", car.engine.power);
            Console.WriteLine("    Displacement: {0}", car.engine.displacement);
            Console.WriteLine("    Efficiency: {0}", car.engine.efficiency);
            Console.WriteLine("  Weight: {0}", car.weight);
            Console.WriteLine("  Color: {0}", car.colour);
        }
    }
}