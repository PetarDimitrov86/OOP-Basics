using System;

namespace _03_WildFarm
{
    public class Tiger : Felime
    {
        private string livingRegion;

        public Tiger(string animalName, string animalType, double animalWeight, int foodEaten, string livingRegion)
            : base(animalName, animalType, animalWeight, foodEaten, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("ROAAR!!!");
        }

        public override void Eat(Food food)
        {
            if (food is Vegetable)
            {
                this.FoodEaten -= food.Quantity;
                Console.WriteLine($"{this.AnimalType}s are not eating that type of food!");
            }
        }
    }
}