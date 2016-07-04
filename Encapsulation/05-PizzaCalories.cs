using System;
using System.Collections.Generic;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;
    private int numberOfToppings;
    private decimal totalCalories;

    public Pizza(string name, int numberOfToppings)
    {
        this.Name = name;
        this.NumberOfToppings = numberOfToppings;
        this.toppings = new List<Topping>();
        this.Dough = new Dough(1, new List<string>());
    }

    private string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }

    private int NumberOfToppings
    {
        get { return this.numberOfToppings; }
        set {
            if (value < 0 || value > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.numberOfToppings = value;
        }
    }

    public Dough Dough
    {
        get { return this.dough; }
        set { this.dough = value; }
    }

    public void AddTopping(Topping topping)
    {
        toppings.Add(topping);
    }

    public decimal GetTotalCalories()
    {
        this.totalCalories += this.dough.CaloriesPerGram*this.dough.Weight;
        foreach (var topping in toppings)
        {
            totalCalories += topping.CaloriesPerGram*topping.Weight;
        }
        return totalCalories;
    }
}

public class Dough
{
    private decimal weight;
    private List<string> types;
    private static decimal totalCalories = 0;
    private static decimal ourModifier = 1;
    private decimal caloriesPerGram;

    public Dough(decimal weight, List<string> doughs)
    {
        ourModifier = 1;
        this.Weight = weight;
        this.types = new List<string>();
        this.types.AddRange(doughs);

        for (int i = 0; i < types.Count; i++)
        {
            this.CalculateModifier(types[i]);
        }
        this.CalculateCalories(this.Weight);
        this.CaloriesPerGram = totalCalories/this.Weight;
    }

    public decimal CaloriesPerGram
    {
        get { return this.caloriesPerGram; }
        private set { this.caloriesPerGram = value; }
    }

    public decimal Weight
    {
        get { return this.weight;}
        private set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weight = value;
        }
    }

    private void CalculateModifier(string givenIngredientType)
    {
        switch (givenIngredientType.ToLower())
        {
            case "white": ourModifier *= 1.5m; break;
            case "wholegrain": ourModifier *= 1.0m; break;
            case "crispy": ourModifier *= 0.9m; break;
            case "chewy": ourModifier *= 1.1m; break;
            case "homemade": ourModifier *= 1.0m; break;
            default: throw new ArgumentException("Invalid type of dough.");
        }
    }

    private void CalculateCalories(decimal weight)
    {
        totalCalories = weight*ourModifier * 2;
    }
}

public class Topping
{
    private decimal weight;
    private string topping;
    private decimal modifier = 1;
    private decimal caloriesPerGram;

    public Topping(string topping, decimal weight)
    {
        modifier = 1;
        this.topping = topping;
        switch (topping.ToLower())
        {
            case "meat": modifier *= 1.2m; break;
            case "veggies": modifier *= 0.8m; break;
            case "cheese": modifier *= 1.1m; break;
            case "sauce": modifier *= 0.9m; break;
            default: throw new ArgumentException($"Cannot place {topping} on top of your pizza.");
        }
        this.Weight = weight;
        CaloriesPerGram = modifier*2;
    }

    public decimal Weight
    {
        get { return this.weight; }
        private set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.topping} weight should be in the range[1..50].");
            }
            this.weight = value;
        }
    }

    public decimal CaloriesPerGram
    {
        get { return this.caloriesPerGram; }
        private set { this.caloriesPerGram = value; }
    }
}

class PizzaCalories
{
    static void Main(string[] args)
    {
        string firstLine = Console.ReadLine();

        if (!firstLine.Contains("Pizza"))
        {
            string[] onlyDoughInfo = firstLine.Split();
            decimal weightD = decimal.Parse(onlyDoughInfo[onlyDoughInfo.Length - 1]);
            List<string> typesD = new List<string>();
            for (int i = 1; i < onlyDoughInfo.Length - 1; i++)
            {
                typesD.Add(onlyDoughInfo[i]);
            }
            Dough doughFirst = new Dough(1, new List<string>());
            try
            {
                doughFirst = new Dough(weightD, typesD);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
            Console.WriteLine(doughFirst.Weight*doughFirst.CaloriesPerGram);
            string toppingsLine = Console.ReadLine();
            while (toppingsLine != "END")
            {
                string[] toppingInfo = toppingsLine.Split();
                string toppingType = toppingInfo[1];
                decimal toppingWeight = decimal.Parse(toppingInfo[2]);
                Topping currentTopping = new Topping("sauce", 2);
                try
                {
                    currentTopping = new Topping(toppingType, toppingWeight);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    return;
                }
                Console.WriteLine($"{currentTopping.CaloriesPerGram * currentTopping.Weight:f2}");
                toppingsLine = Console.ReadLine();
            }
            return;
        }
       
        string[] pizzaInfo = firstLine.Split();
        string pizzaName = pizzaInfo[1];
        int numberOfToppings = int.Parse(pizzaInfo[2]);
        Pizza ourPizza = new Pizza("bla", 1);
        try
        {
            ourPizza = new Pizza(pizzaName, numberOfToppings);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
            return;
        }

        string doughInfo = Console.ReadLine();
        string[] command = doughInfo.Split();
        decimal weight = decimal.Parse(command[command.Length - 1]);
        List<string> types = new List<string>();
        for (int i = 1; i < command.Length - 1; i++)
        {
            types.Add(command[i]);
        }
        Dough dough = new Dough(1, new List<string>());
        try
        {
            dough = new Dough(weight, types);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
            return;
        }
        ourPizza.Dough = dough;
        string topping = Console.ReadLine();
        while (topping != "END")
        {
            string[] toppingInfo = topping.Split();
            string toppingType = toppingInfo[1];
            decimal toppingWeight = decimal.Parse(toppingInfo[2]);
            try
            {
                Topping currentTopping = new Topping(toppingType, toppingWeight);
                ourPizza.AddTopping(currentTopping);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
                return;
            }
            topping = Console.ReadLine();
        }
        Console.WriteLine($"{pizzaName} - {ourPizza.GetTotalCalories()} Calories.");
    }
}