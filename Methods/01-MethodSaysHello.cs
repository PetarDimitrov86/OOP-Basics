using System;
using System.Reflection;
public class Person
{
    public string name;

    public Person(string name)
    {
        this.name = name;
    }

    public string SayHello()
    {
        return $"{name} says \"Hello\"!";
    }
}
class MethodSaysHello
{
    static void Main(string[] args)
    {
        Type personType = typeof(Person);
        FieldInfo[] fields = personType.GetFields(BindingFlags.Public | BindingFlags.Instance);
        MethodInfo[] methods = personType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

        if (fields.Length != 1 || methods.Length != 5)
        {
            throw new Exception();
        }
        string personName = Console.ReadLine();
        Person person = new Person(personName);

        Console.WriteLine(person.SayHello());
    }
}