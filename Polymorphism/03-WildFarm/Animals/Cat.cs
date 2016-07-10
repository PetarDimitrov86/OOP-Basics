using System;

namespace _03_WildFarm
{
    public class Cat : Felime
    {
        private string breed;

        public Cat(string animalName, string animalType, double animalWeight, int foodEaten, string livingRegion, string breed) : base(animalName, animalType, animalWeight, foodEaten, livingRegion)
        {
            this.Breed = breed;
        }

        public string Breed { get; private set; }

        public override void MakeSound()
        {
            Console.WriteLine("Meowwww");
        }

        public override string ToString()
        {
            return $"{base.AnimalType}[{base.AnimalName}, {this.Breed}, {base.AnimalWeight}, {base.LivingRegion}, {base.FoodEaten}]";
        }
    }
}