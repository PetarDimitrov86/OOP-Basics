using System;
using System.Reflection;
class Person
{
    public string name;
    public int age;

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}

class DefineAClassPerson
{
    static void Main(string[] args)
    {
        Type personType = typeof(Person);
        FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        Console.WriteLine(fields.Length);

        Person firstPerson = new Person("Pesho", 20);

        Console.WriteLine(firstPerson.age);
        Console.WriteLine(firstPerson.name);
    }
}