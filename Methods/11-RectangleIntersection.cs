using System;
using System.Collections.Generic;
using System.Linq;

public class Rectangle
{
    public string ID;
    public double width;
    public double height;
    public double leftX;
    public double leftY;

    public Rectangle(string ID, double width, double height, double leftX, double leftY)
    {
        this.ID = ID;
        this.width = width;
        this.height = height;
        this.leftX = leftX;
        this.leftY = leftY;
    }
    public bool IntersectionCheck(Rectangle anotherRect)
    {
        double rightX = this.leftX + this.width;
        double rightY = this.leftY + this.height;

        bool intersectHorizontal = rightX >= anotherRect.leftX;
        bool intersectVertical = rightY >= anotherRect.leftY;
        return intersectVertical && intersectHorizontal;
    }
}

class RectangleIntersection
{
    static void Main(string[] args)
    {
        int[] linesInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = linesInfo[0];
        int m = linesInfo[1];
        Dictionary<string, Rectangle> ourDict = new Dictionary<string, Rectangle>();

        for (int i = 0; i < n; i++)
        {
            string[] rectInfo = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            string ID = rectInfo[0];
            double width = double.Parse(rectInfo[1]);
            double height = double.Parse(rectInfo[2]);
            double leftX = double.Parse(rectInfo[3]);
            double leftY = double.Parse(rectInfo[4]);
            Rectangle rect = new Rectangle(ID, width, height, leftX, leftY);
            ourDict.Add(ID, rect);
        }
        for (int i = 0; i < m; i++)
        {
            string[] pairIDs = Console.ReadLine().Split(new char[] {}, StringSplitOptions.RemoveEmptyEntries);
            string ID1 = pairIDs[0];
            string ID2 = pairIDs[1];
            bool result = false;
            if (ourDict[ID2].leftY >= ourDict[ID1].leftY && ourDict[ID2].leftX >= ourDict[ID1].leftX)
            {
                result = ourDict[ID1].IntersectionCheck(ourDict[ID2]);
            }
            else
            {
                result = ourDict[ID2].IntersectionCheck(ourDict[ID1]);
            }
            Console.WriteLine(result.ToString().ToLower());
        }
    }
}