using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Square
{
    public int size;

    public Square(int size)
    {
        this.size = size;
    }

    public void Draw()
    {
        Console.WriteLine("|{0}|", new string('-', this.size));
        for (int i = 0; i < this.size - 2; i++)
        {
            Console.WriteLine("|{0}|", new string(' ', this.size));
        }
        Console.WriteLine("|{0}|", new string('-', this.size));
    }
}

public class Rectangle
{
    public int width;
    public int height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }
    public void Draw()
    {
        Console.WriteLine("|{0}|", new string('-', this.width));
        for (int i = 0; i < this.height - 2; i++)
        {
            Console.WriteLine("|{0}|", new string(' ', this.width));
        }
        Console.WriteLine("|{0}|", new string('-', this.width));
    }
}

class DrawingTool
{
    static void Main(string[] args)
    {
        string shape = Console.ReadLine();
        switch (shape)
        {
            case "Square":
                int size = int.Parse(Console.ReadLine());
                Square ourSquare = new Square(size);
                ourSquare.Draw();
                break;
            case "Rectangle":
                int width = int.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                Rectangle ourRect = new Rectangle(width, height);
                ourRect.Draw();
                break;
        }
    }
}