using System;
using System.Collections.Generic;
using System.Linq;

public class Cat
{
    public string breed;
    public string name;

    public Cat()
    {
        
    }

    public Cat(string breed, string name)
    {
        this.breed = breed;
        this.name = name;
    }
}

public class Siamese : Cat
{
    public decimal earSize;

    public Siamese(decimal earSize)
    {
        this.earSize = earSize;
    }

    public override string ToString()
    {
        return $"{this.breed} {this.name} {this.earSize}";
    }
}

public class Cymric : Cat
{
    public decimal furLength;

    public Cymric(decimal furLength)
    {
        this.furLength = furLength;
    }

    public override string ToString()
    {
        return $"{this.breed} {this.name} {this.furLength:f2}";
    }
}

public class StreetExtraordinaire : Cat
{
    public decimal decibelOfMeows;

    public StreetExtraordinaire(decimal decibelOfMeows)
    {
        this.decibelOfMeows = decibelOfMeows;
    }

    public override string ToString()
    {
        return $"{this.breed} {this.name} {this.decibelOfMeows}";
    }
}

class CatLady
{
    static void Main(string[] args)
    {
        List<Cat> cats = new List<Cat>();
        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] catInfo = input.Split();
            string breed = catInfo[0];
            string name = catInfo[1];
            Cat newCat = new Cat();
            switch (breed)
            {
                case "Siamese":
                    newCat = new Siamese(decimal.Parse(catInfo[2]));

                    break;
                case "Cymric":
                    newCat= new Cymric(decimal.Parse(catInfo[2]));
                    break;
                case "StreetExtraordinaire":
                    newCat = new StreetExtraordinaire(decimal.Parse(catInfo[2]));
                    break;
            }
            newCat.name = name;
            newCat.breed = breed;
            cats.Add(newCat);
            input = Console.ReadLine();
        }
        string desiredCatName = Console.ReadLine();
        Cat desiredCat = cats.First(x => x.name == desiredCatName);
        Console.WriteLine(desiredCat);
    }
}