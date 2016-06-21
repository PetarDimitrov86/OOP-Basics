using System;
using System.Collections.Generic;
using System.Linq;
class Person
{
    public string name;
    public int age;

    public Person()
    {
        this.name = "No name";
        this.age = 1;
    }

    public Person(int age)
    {
        this.name = "No name";
        this.age = age;
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}
class OpinionPoll
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Person> personList = new List<Person>();
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            string name = input[0];
            int age = int.Parse(input[1]);

            Person tempPerson = new Person(name, age);
            personList.Add(tempPerson);
        }
        var result = personList.Where(x => x.age > 30).OrderBy(x => x.name);
        foreach (var person in result)
        {
            Console.WriteLine($"{person.name} - {person.age}");
        }
    }
}