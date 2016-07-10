using System;
using System.Collections.Generic;
using System.Linq;
using _03_WildFarm;

class WildFarm
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] animalInfo = input.Split();
            string[] foodInfo = Console.ReadLine().Split();

            string foodType = foodInfo[0];
            int foodQuantity = int.Parse(foodInfo[1]);

            string animalType = animalInfo[0];
            string animalName = animalInfo[1];
            double animalWeight = double.Parse(animalInfo[2]);
            string animalRegion = animalInfo[3];
            Animal animal = new Mouse(" ", " ", 3.4, 3, " ");
            if (animalInfo.Length == 5)
            {
                string catBreed = animalInfo[4];
                animal = new Cat(animalName, animalType, animalWeight, foodQuantity, animalRegion, catBreed);
            }
            else
            {
                switch (animalType.ToLower())
                {
                    case "tiger":
                        animal = new Tiger(animalName,animalType,animalWeight,foodQuantity, animalRegion);
                        break;
                    case "zebra":
                        animal = new Zebra(animalName, animalType, animalWeight, foodQuantity, animalRegion);
                        break;
                    case "mouse":
                        animal = new Mouse(animalName, animalType, animalWeight, foodQuantity, animalRegion);
                        break;
                }
            }
            Food food = new Meat(2);
            switch (foodType.ToLower())
            {
                case "meat": food = new Meat(foodQuantity); break; 
                case "vegetable": food = new Vegetable(foodQuantity); break;
            }
            animal.MakeSound();
            animal.Eat(food);
            Console.WriteLine(animal);

            input = Console.ReadLine();
        }
    }
}
