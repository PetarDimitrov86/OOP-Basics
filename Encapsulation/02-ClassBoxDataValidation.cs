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
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public decimal Length
    {
        get { return this.length; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            this.length = value;
        }
    }
    public decimal Width
    {
        get { return this.width; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            this.width = value;
        }
    }

    public decimal Height
    {
        get { return this.height; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Height cannot be zero or negative.");
            }
            this.height = value;
        }
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

class ClassBoxDataValidation
{
    static void Main(string[] args)
    {
        Type boxType = typeof(Box);
        FieldInfo[] fields = boxType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        Console.WriteLine(fields.Count());

        decimal length = decimal.Parse(Console.ReadLine());
        decimal width = decimal.Parse(Console.ReadLine());
        decimal height = decimal.Parse(Console.ReadLine());
        try
        {
            Box ourBox = new Box(length, width, height);
            Console.WriteLine($"Surface Area - {ourBox.SurfaceArea():f2}");
            Console.WriteLine($"Lateral Surface Area - {ourBox.LateralSurfaceArea():f2}");
            Console.WriteLine($"Volume - {ourBox.Volume():f2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}