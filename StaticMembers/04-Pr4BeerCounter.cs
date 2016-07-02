using System;
using System.Linq;

public class BeerCounter
{
    public static int beerInStock;
    public static int beersDrankCount;

    public static void BuyBeer(int bottlesCount)
    {
        beerInStock += bottlesCount;
    }

    public static void DrinkBeer(int bottlesCount)
    {
        beersDrankCount += bottlesCount;
        beerInStock -= bottlesCount;
    }
}

class Pr4BeerCounter
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        while (input != "End")
        {
            int[] beerInfo = input.Split().Select(int.Parse).ToArray();
            int beerBought = beerInfo[0];
            int beerDrank = beerInfo[1];
            BeerCounter.BuyBeer(beerBought);
            BeerCounter.DrinkBeer(beerDrank);
            input = Console.ReadLine();
        }
        Console.WriteLine($"{BeerCounter.beerInStock} {BeerCounter.beersDrankCount}");
    }
}