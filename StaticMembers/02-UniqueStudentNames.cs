using System;
using System.Collections.Generic;

public class Student
{
    public static HashSet<Student> students;
    public string name;

    static Student()
    {
        students = new HashSet<Student>();
    }

    public Student(string name)
    {
        this.name = name;
    }

    public override bool Equals(object other)
    {
        return this.GetHashCode().Equals(other.GetHashCode());
    }

    public override int GetHashCode()
    {
        return this.name.GetHashCode();
    }
}

class UniqueStudentNames
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        while (input != "End")
        {
            Student.students.Add(new Student(input));
            input = Console.ReadLine();
        }
        Console.WriteLine(Student.students.Count);
    }
}