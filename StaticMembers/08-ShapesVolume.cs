using System;

public class VolumeCalculater
{
    public static double CalcPrismVolume(TriangularPrism prism)
    {
        return (prism.height*prism.length*prism.side)/2;
    }

    public static double CalcCubeVolume(Cube cube)
    {
        return cube.length*cube.length*cube.length;
    }

    public static double CalcCylinderVolume(Cylinder cylinder)
    {
        return Math.PI*cylinder.height*cylinder.radius*cylinder.radius;
    }
}

public class TriangularPrism
{
    public double side;
    public double height;
    public double length;

    public TriangularPrism(double side, double height, double length)
    {
        this.side = side;
        this.height = height;
        this.length = length;
    }
}

public class Cube
{
    public double length;

    public Cube(double length)
    {
        this.length = length;
    }
}

public class Cylinder
{
    public double radius;
    public double height;

    public Cylinder(double radius, double height)
    {
        this.radius = radius;
        this.height = height;
    }
}

class ShapesVolume
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        while (input != "End")
        {
            string[] parameters = input.Split();
            string type = parameters[0];
            switch (type)
            {
                case "Cube":
                    double side = double.Parse(parameters[1]);
                    Cube cube = new Cube(side);
                    Console.WriteLine($"{VolumeCalculater.CalcCubeVolume(cube):f3}");
                    break;
                case "TrianglePrism":
                    double trSide = double.Parse(parameters[1]);
                    double trHeigth = double.Parse(parameters[2]);
                    double trLength = double.Parse(parameters[3]);
                    TriangularPrism prism = new TriangularPrism(trSide, trHeigth, trLength);
                    Console.WriteLine($"{VolumeCalculater.CalcPrismVolume(prism):f3}");
                    break;
                case "Cylinder":
                    double radius = double.Parse(parameters[1]);
                    double height = double.Parse(parameters[2]);
                    Cylinder cylinder = new Cylinder(radius, height);
                    Console.WriteLine($"{VolumeCalculater.CalcCylinderVolume(cylinder):f3}");
                    break;
            }
            input = Console.ReadLine();
        }
    }
}