using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

public class Pizza
{
    public string name;
    public int group;

    public Pizza(string name, int group)
    {
        this.name = name;
        this.group = group;
    }

    public static SortedDictionary<int, List<string>> GetDictionary(params Pizza[] pizzas)
    {
        SortedDictionary<int, List<string>> ourDict = new SortedDictionary<int, List<string>>();
        foreach (var pizza in pizzas)
        {
            if (!ourDict.ContainsKey(pizza.group))
            {
                ourDict.Add(pizza.group, new List<string>());
            }
            ourDict[pizza.group].Add(pizza.name);
        }
        return ourDict;
    }
}
public class PizzaTime
{
    public static void Main(string[] args)
    {
        MethodInfo[] methods = typeof(Pizza).GetMethods();
        bool containsMethod = methods.Any(m => m.ReturnType.Name.Equals("SortedDictionary"));
        if (containsMethod)
        {
            throw new Exception();
        }

        string input = Console.ReadLine();
        string[] inputSplit = input.Split();
        Pizza[] pizzas = new Pizza[inputSplit.Length];
        string pattern = @"(\d+)(\w+)";
        Regex regex = new Regex(pattern);
        for (int i = 0; i < inputSplit.Length; i++)
        {
            Match match = regex.Match(inputSplit[i]);
            int pizzaGroup = int.Parse(match.Groups[1].Value);
            string pizzaName = match.Groups[2].Value;
            Pizza ourPizza = new Pizza(pizzaName, pizzaGroup);
            pizzas[i] = ourPizza;
        }
        var result = Pizza.GetDictionary(pizzas);
        foreach (var outerPair in result)
        {
            Console.Write("{0} - ", outerPair.Key);
            Console.WriteLine(string.Join(", ", outerPair.Value ));
        }
    }
}