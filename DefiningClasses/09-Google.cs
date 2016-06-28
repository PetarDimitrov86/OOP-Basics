using System;
using System.Collections.Generic;

public class Person
{
    public string name;
    public string companyName;
    public string department;
    public decimal salary;
    public Car car;
    public List<Parent> parents;
    public List<Child> children;
    public List<Pokemon> pokemons;

    public Person(string name)
    {
        this.name = name;
        this.parents = new List<Parent>();
        this.children = new List<Child>();
        this.pokemons = new List<Pokemon>();
    }
}

public class Parent
{
    public string parentName;
    public string parentBirthday;

    public Parent(string parentName, string parentBirthday)
    {
        this.parentName = parentName;
        this.parentBirthday = parentBirthday;
    }
}

public class Child
{
    public string childName;
    public string childBirthday;

    public Child(string childName, string childBirthday)
    {
        this.childName = childName;
        this.childBirthday = childBirthday;
    }
}

public class Pokemon
{
    public string name;
    public string type;

    public Pokemon(string name, string type)
    {
        this.name = name;
        this.type = type;
    }
}

public class Car
{
    public string carModel;
    public decimal carSpeed;

    public Car(string carModel, decimal carSpeed)
    {
        this.carModel = carModel;
        this.carSpeed = carSpeed;
    }
}

class Google
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        Dictionary<string, Person> dict = new Dictionary<string, Person>();
        while (input != "End")
        {
            string[] personInfo = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            string name = personInfo[0];
            string infoGiven = personInfo[1];
            Person tempPerson = new Person(name);
            if (!dict.ContainsKey(name))
            {
                dict.Add(name, tempPerson);
            }
            switch (infoGiven)
            {
                case "company":
                    string companyName = personInfo[2];
                    string department = personInfo[3];
                    decimal salary = decimal.Parse(personInfo[4]);
                    dict[name].companyName = companyName;
                    dict[name].department = department;
                    dict[name].salary = salary;
                    break;
                case "car":
                    string carModel = personInfo[2];
                    decimal carSpeed = decimal.Parse(personInfo[3]);
                    Car newCar = new Car(carModel, carSpeed);
                    dict[name].car = newCar;
                    break;
                case "pokemon":
                    string pokemonName = personInfo[2];
                    string pokemonType = personInfo[3];
                    Pokemon newPokemon = new Pokemon(pokemonName, pokemonType);
                    dict[name].pokemons.Add(newPokemon);
                    break;
                case "parents":
                    string parentName = personInfo[2];
                    string parentBirthday = personInfo[3];
                    Parent newParent = new Parent(parentName, parentBirthday);
                    dict[name].parents.Add(newParent);
                    break;
                case "children":
                    string childName = personInfo[2];
                    string childBirthday = personInfo[3];
                    Child newChild = new Child(childName, childBirthday);
                    dict[name].children.Add(newChild);
                    break;
            }
            input = Console.ReadLine();
        }
        string personToSpyOn = Console.ReadLine();
        Person result = dict[personToSpyOn];
        Console.WriteLine(result.name);
        Console.WriteLine("Company:");
        if (!string.IsNullOrEmpty(result.companyName))
            Console.WriteLine($"{result.companyName} {result.department} {result.salary:f2}");
        Console.WriteLine("Car:");
        if (result.car != null)
            Console.WriteLine($"{result.car.carModel} {result.car.carSpeed}");
        Console.WriteLine("Pokemon:");
            foreach (var pokemon in result.pokemons)
                Console.WriteLine($"{pokemon.name} {pokemon.type}");
        Console.WriteLine("Parents:");
            foreach (var parent in result.parents)
                Console.WriteLine($"{parent.parentName} {parent.parentBirthday}");
        Console.WriteLine("Children:");
            foreach (var child in result.children)
                Console.WriteLine($"{child.childName} {child.childBirthday}");
    }
}