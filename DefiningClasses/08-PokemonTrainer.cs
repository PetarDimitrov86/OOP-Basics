using System;
using System.Collections.Generic;
using System.Linq;
public class Trainer
{
    public Trainer(string name)
    {
        this.name = name;
        badges = 0;
        pokemons = new List<Pokemon>();
    }
    public string name;
    public int badges = 0;
    public List<Pokemon> pokemons;
}
public class Pokemon
{
    public string name;
    public string element;
    public int health;

    public Pokemon(string name, string element, int health)
    {
        this.name = name;
        this.element = element;
        this.health = health;
    }
}
class PokemonTrainer
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        List<Trainer> trainerList = new List<Trainer>();
        List<Pokemon> pokemonList = new List<Pokemon>();
        while (input != "Tournament")
        {
            string[] trainerInfo = input.Split().ToArray();
            string trainerName = trainerInfo[0];
            string pokemonName = trainerInfo[1];
            string pokemonElement = trainerInfo[2];
            int pokemonHealth = int.Parse(trainerInfo[3]);
            Pokemon tempPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            bool trainerExists = false;
            if (trainerList.Any(x=>x.name == trainerName))
            {
                trainerList.FirstOrDefault(x=>x.name == trainerName).pokemons.Add(tempPokemon);
                trainerExists = true;
            }
            if (trainerExists == false)
            {
                Trainer tempTrainer = new Trainer(trainerName);
                tempTrainer.pokemons.Add(tempPokemon);
                trainerList.Add(tempTrainer);
            }      
            input = Console.ReadLine();
        }
        input = Console.ReadLine();
        while (input != "End")
        {
            foreach (var trainer in trainerList)
            {
                bool foundPokemon = false;
                if (trainer.pokemons.Any(x=>x.element == input))
                {
                    foundPokemon = true;
                    trainer.badges++;
                }
                if (foundPokemon == false)
                {
                    foreach (var pokemon in trainer.pokemons)
                    {
                        pokemon.health -= 10;
                    }
                }
                for (int i = 0; i < trainer.pokemons.Count; i++)
                {
                    if (trainer.pokemons[i].health <= 0)
                    {
                        trainer.pokemons.Remove(trainer.pokemons[i]);
                        i--;
                    }
                }
            }
            input = Console.ReadLine();
        }
        var result = trainerList.OrderByDescending(x => x.badges);
        foreach (var trainer in result)
        {
            Console.WriteLine($"{trainer.name} {trainer.badges} {trainer.pokemons.Count}");
        }
    }
}