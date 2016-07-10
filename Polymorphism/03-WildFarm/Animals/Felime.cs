using System;

namespace _03_WildFarm
{
    public abstract class Felime : Mammal
    {
        public Felime(string animalName, string animalType, double animalWeight, int foodEaten, string livingRegion) : base(animalName, animalType, animalWeight, foodEaten, livingRegion)
        {
        }
        public override void Eat(Food food)
        {
        }
    }
}