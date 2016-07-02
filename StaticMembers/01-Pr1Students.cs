using System;

public class Student
{
    public static int numberOfStudents = 0;
    public string name;

    public Student(string name)
    {
        numberOfStudents++;
        this.name = name;
    }
}

class Pr1Students
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        while (input != "End")
        {
            string name = input;
            Student st = new Student(name);
            input = Console.ReadLine();
        }
        Console.WriteLine(Student.numberOfStudents);
    }
}