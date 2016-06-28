using System;
using System.Linq;
using System.Reflection;

public class Box
{
    private decimal length;
    private decimal width;
    private decimal height;

    public Box(decimal length, decimal width, decimal height)
    {
        this.length = length;
        this.width = width;
        this.height = height;
    }

    public decimal SurfaceArea()
    {
        return 2 * (this.length * this.width + this.length * this.height + this.width * this.height);
    }

    public decimal LateralSurfaceArea()
    {
        return 2 * (this.length * this.height + this.width * this.height);
    }

    public decimal Volume()
    {
        return this.width * this.height * this.length;
    }
}

class ClassBox
{
    static void Main(string[] args)
    {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());

        decimal length = decimal.Parse(Console.ReadLine());
        decimal width = decimal.Parse(Console.ReadLine());
        decimal height = decimal.Parse(Console.ReadLine());
        Box ourBox = new Box(length, width, height);
        Console.WriteLine($"Surface Area - {ourBox.SurfaceArea():f2}");
        Console.WriteLine($"Lateral Surface Area - {ourBox.LateralSurfaceArea():f2}");
        Console.WriteLine($"Volume - {ourBox.Volume():f2}");
    }
}