using _03_WildFarm;

public abstract class Animal
{
    private string animalName;
    private string animalType;
    private double animalWeight;
    private int foodEaten;

    protected Animal(string animalName, string animalType, double animalWeight, int foodEaten)
    {
        this.AnimalName = animalName;
        this.AnimalType = animalType;
        this.AnimalWeight = animalWeight;
        this.FoodEaten = foodEaten;
    }

    public string AnimalName { get; protected set; }
    public string AnimalType { get; protected set; }
    public double AnimalWeight { get; protected set; }
    public int FoodEaten { get; protected set; }


    public abstract void MakeSound();

    public abstract void Eat(Food food);

    public override string ToString()
    {
        return $"{this.AnimalType}[{this.AnimalName}, {this.AnimalWeight}, {this.FoodEaten}]";
    }
}