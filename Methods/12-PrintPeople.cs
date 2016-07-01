using System;
using System.Collections.Generic;

public class Person : IComparable<Person>
{
    public string name;
    public int age;
    public string occupation;

    public Person(string name, int age, string occupation)
    {
        this.name = name;
        this.age = age;
        this.occupation = occupation;
    }

    public override string ToString()
    {
        return $"{this.name} - age: {this.age}, occupation: {this.occupation}";
    }

    public int CompareTo(Person anotherPers)
    {
        return this.age.CompareTo(anotherPers.age);
    }
}

class PrintPeople
{
    static void Main()
    {
        string input = Console.ReadLine();
        List<Person> people = new List<Person>();
        while (input != "END")
        {
            string[] personInfo = input.Split();
            string name = personInfo[0];
            int age = int.Parse(personInfo[1]);
            string occupation = personInfo[2];
            Person ourPerson = new Person(name, age, occupation);
            people.Add(ourPerson);
            input = Console.ReadLine();
        }
        people.Sort();
        foreach (var person in people)
        {
            Console.WriteLine(person);
        }
    }
}