using System;

namespace _03_WildFarm
{
    public class Zebra : Mammal
    {
        public Zebra(string animalName, string animalType, double animalWeight, int foodEaten, string livingRegion) : base(animalName, animalType, animalWeight, foodEaten, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Zs");
        }

        public override void Eat(Food food)
        {
            if (food is Meat)
            {
                this.FoodEaten -= food.Quantity;
                Console.WriteLine($"{this.AnimalType}s are not eating that type of food!");
            }
        }
    }
}