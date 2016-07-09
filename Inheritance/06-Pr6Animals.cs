using System;
using System.Text;

public class Animal
{
    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    protected string Name
    {
        get { return this.name; }
        private set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            this.name = value;
        }
    }

    protected int Age
    {
        get
        {
            return this.age;
        }

        private set
        {
            if (string.IsNullOrEmpty(value.ToString()) || string.IsNullOrWhiteSpace(value.ToString()) || value <= 0)
            {
                throw new ArgumentException("Invalid input!");
            }
            this.age = value;
        }
    }

    protected string Gender
    {
        get { return this.gender; }
        set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }

            this.gender = value;
        }
    }

    public virtual string ProduceSound()
    {
        return "Not implemented!";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append($"{this.name} {this.age} {this.gender}");
        sb.Append(Environment.NewLine);
        sb.Append(ProduceSound());
        return sb.ToString();
    }
}

public class Dog : Animal
{
    public Dog(string name, int age, string gender) : base(name, age, gender)
    {        
    }

    public override string ProduceSound()
    {
        return "BauBau";
    }
}
public class Frog : Animal
{
    public Frog(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string ProduceSound()
    {
        return "Frogggg";
    }
}

public class Cat : Animal
{
    public Cat(string name, int age, string gender) : base(name, age, gender)
    {
    }

    public override string ProduceSound()
    {
        return "MiauMiau";
    }
}

public class Kitten : Cat
{
    public Kitten(string name, int age) : base(name, age, "Female")
    {
    }

    public override string ProduceSound()
    {
        return "Miau";
    }
}

public class Tomcat : Cat
{
    public Tomcat(string name, int age) : base(name, age, "Male")
    {
    }

    public override string ProduceSound()
    {
        return "Give me one million b***h";
    }
}

public class Pr6Animals
{
    static void Main(string[] args)
    {
        string type = Console.ReadLine();
        while (type != "Beast!")
        {
            try
            {
                string[] animalInfo = Console.ReadLine().Split();
                string animalName = animalInfo[0];
                int animalAge = int.Parse(animalInfo[1]);
                string animalGender = animalInfo[2];
                switch (type.ToLower())
                {
                    case "cat":
                        Cat cat = new Cat(animalName, animalAge, animalGender);
                        Console.WriteLine(type);
                        Console.WriteLine(cat);
                        break;
                    case "dog":
                        Dog dog = new Dog(animalName, animalAge, animalGender);
                        Console.WriteLine(type);
                        Console.WriteLine(dog);
                        break;
                    case "frog":
                        Frog frog = new Frog(animalName, animalAge, animalGender);
                        Console.WriteLine(type);
                        Console.WriteLine(frog);
                        break;
                    case "kitten":
                        Kitten kitten = new Kitten(animalName, animalAge);
                        Console.WriteLine(type);
                        Console.WriteLine(kitten);
                        break;
                    case "tomcat":
                        Tomcat tomcat = new Tomcat(animalName, animalAge);
                        Console.WriteLine(type);
                        Console.WriteLine(tomcat);
                        break;
                    default:
                        Animal animal = new Animal(animalName, animalAge, animalGender);
                        Console.WriteLine(type);
                        Console.WriteLine(animal);
                        break;
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
           
            type = Console.ReadLine();
        }
    }
}