using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public string name;
    public int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}

public class Family
{
    public List<Person> personList;

    public Family ()
    {
        this.personList = new List<Person>();
    }

    public void AddMember(Person member)
    {
        personList.Add(member);
    }

    public Person GetOldestMember()
    {
        Person result = personList.OrderByDescending(x => x.age).First();
        return result;
    }
}
class OldestFamilyMember
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Family familyList = new Family();
        for (int i = 0; i < n; i++)
        {
            string[] familyMemberInfo = Console.ReadLine().Split().ToArray();
            string name = familyMemberInfo[0];
            int age = int.Parse(familyMemberInfo[1]);
            Person familyMember = new Person(name, age);
            familyList.AddMember(familyMember);
        }
        Console.WriteLine($"{familyList.GetOldestMember().name} {familyList.GetOldestMember().age}");        
    }
}