using System;
using System.Collections.Generic;

public class Animal
{
    public string name;
    public string breed;

    public Animal(string name, string breed)
    {
        this.name = name;
        this.breed = breed;
        AnimalClinic.patiendID++;
    }
    public override string ToString()
    {
        return $"{this.name} {this.breed}";
    }
}

public class AnimalClinic
{
    public static int patiendID;
    public static int healedAnimalsCount;
    public static int rehabilitatedAnimalsCount;

    public static List<Animal> healedAnimals;
    public static List<Animal> rehabilitatedAnimals;

    static AnimalClinic()
    {
        healedAnimals = new List<Animal>();
        rehabilitatedAnimals = new List<Animal>();
    }

    public static void HealAnimal(Animal animal)
    {
        healedAnimalsCount++;
        healedAnimals.Add(animal);
        Console.WriteLine($"Patient {patiendID}: [{animal.name} ({animal.breed})] has been healed!");
    }

    public static void RehabilitateAnimal(Animal animal)
    {
        rehabilitatedAnimalsCount++;
        rehabilitatedAnimals.Add(animal);
        Console.WriteLine($"Patient {patiendID}: [{animal.name} ({animal.breed})] has been rehabilitated!");
    }
}

class Pr5AnimalClinic
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] animalInfo = input.Split();
            string animalName = animalInfo[0];
            string animalBreed = animalInfo[1];
            Animal currentAnimal = new Animal(animalName, animalBreed);
            string command = animalInfo[2];
            switch (command)
            {
                case "heal":
                    AnimalClinic.HealAnimal(currentAnimal);
                    break;
                case "rehabilitate":
                    AnimalClinic.RehabilitateAnimal(currentAnimal);
                    break;
            }
            input = Console.ReadLine();
        }
        Console.WriteLine($"Total healed animals: {AnimalClinic.healedAnimalsCount}");
        Console.WriteLine($"Total rehabilitated animals: {AnimalClinic.rehabilitatedAnimalsCount}");
        string type = Console.ReadLine();
        switch (type)
        {
            case "heal":
                foreach (var animal in AnimalClinic.healedAnimals)
                {
                    Console.WriteLine(animal);
                }
                break;
            case "rehabilitate":
                foreach (var animal in AnimalClinic.rehabilitatedAnimals)
                {
                    Console.WriteLine(animal);
                }
                break;
        }
    }
}