using System;

namespace _03_WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string animalName, string animalType, double animalWeight, int foodEaten, string livingRegion) : base(animalName, animalType, animalWeight, foodEaten, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable)
            {
                Console.WriteLine("A cheese was just eaten!");
            }
            else
            {
                this.FoodEaten -= food.Quantity;
                Console.WriteLine("Mouses are not eating that type of food!");
            }
        }

        public override void MakeSound()
        {
            Console.WriteLine("SQUEEEAAAK!");
        }
    }
}