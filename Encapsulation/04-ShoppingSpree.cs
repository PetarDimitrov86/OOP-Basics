using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> products;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.products = new List<Product>();
    }

    public string Name
    {
        get { return this.name; }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{nameof(Name)} cannot be empty");
            }
            this.name = value;
        }
    }

    public decimal Money
    {
        get { return this.money; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(Money)} cannot be negative");
            }
            this.money = value;
        }
    }

    public void TryPurchaseProduct(Product product)
    {
        if (this.Money >= product.Cost)
        {
            this.products.Add(product);
            this.Money -= product.Cost;
            Console.WriteLine($"{this.Name} bought {product.Name}");
        }
        else
        {
            Console.WriteLine($"{this.Name} can't afford {product.Name}");
        }
    }

    public void DisplayPersonProducts()
    {
        if (this.products.Count > 0)
        {
            Console.WriteLine($"{this.Name} - {string.Join(", ", this.products)}");
        }
        else
        {
            Console.WriteLine($"{this.Name} - Nothing bought");
        }
    }
}

public class Product
{
    private string name;
    private decimal cost;

    public Product(string name, decimal cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

    public string Name
    {
        get { return this.name; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{nameof(Name)} cannot be empty");
            }
            this.name = value;
        }
    }

    public decimal Cost
    {
        get { return this.cost; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            this.cost = value;
        }
    }

    public override string ToString()
    {
        return this.Name;
    }
}

class ShoppingSpree
{
    static void Main(string[] args)
    {
        string[] peopleAndTheirKaChing = Console.ReadLine().Split(new char[] { ';', ' '}, StringSplitOptions.RemoveEmptyEntries);
        string[] expensiveFood = Console.ReadLine().Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        List<Person> people = new List<Person>();
        List<Product> products = new List<Product>();

        foreach (var person in peopleAndTheirKaChing)
        {
            string[] personCash = person.Split('=');
            string name = personCash[0];
            decimal cash = decimal.Parse(personCash[1]);
            try
            {
                Person ourPerson = new Person(name, cash);
                people.Add(ourPerson);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        foreach (var food in expensiveFood)
        {
            string[] foodInfo = food.Split('=');
            string foodName = foodInfo[0];
            decimal foodPrice = decimal.Parse(foodInfo[1]);
            try
            {
                Product ourProduct = new Product(foodName, foodPrice);
                products.Add(ourProduct);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        string input = Console.ReadLine();
        while (input != "END")
        {
            string[] purchaseInfo = input.Split();
            string personName = purchaseInfo[0];
            string productName = purchaseInfo[1];

            Person desiredPerson = people.First(x => x.Name == personName);
            Product productToBuy = products.First(x => x.Name == productName);

            desiredPerson.TryPurchaseProduct(productToBuy);          
            input = Console.ReadLine();
        }
        foreach (var person in people)
        {
            person.DisplayPersonProducts();
        }
    }
}