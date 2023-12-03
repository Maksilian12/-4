using System;
using System.Collections.Generic;

// Базовий клас для живих організмів
class LivingOrganism
{
    public double Energy { get; set; }
    public int Age { get; set; }
    public double Size { get; set; }

    public LivingOrganism(double energy, int age, double size)
    {
        Energy = energy;
        Age = age;
        Size = size;
    }
}

// Інтерфейс для репродукції
interface IReproducible
{
    void Reproduce();
}

// Інтерфейс для хижаків
interface IPredator
{
    void Hunt(LivingOrganism prey);
}

// Клас Тварина як спадкоємець від LivingOrganism
class Animal : LivingOrganism, IReproducible, IPredator
{
    public string Species { get; set; }

    public Animal(double energy, int age, double size, string species)
        : base(energy, age, size)
    {
        Species = species;
    }

    public void Reproduce()
    {
        // Логіка розмноження тварин
        Console.WriteLine($"{Species} is reproducing.");
    }

    public void Hunt(LivingOrganism prey)
    {
        // Логіка полювання тварин
        Console.WriteLine($"{Species} is hunting.");
    }
}

// Клас Рослина як спадкоємець від LivingOrganism
class Plant : LivingOrganism, IReproducible
{
    public string Type { get; set; }

    public Plant(double energy, int age, double size, string type)
        : base(energy, age, size)
    {
        Type = type;
    }

    public void Reproduce()
    {
        // Логіка розмноження рослин
        Console.WriteLine($"{Type} is reproducing.");
    }
}

// Клас Мікроорганізм як спадкоємець від LivingOrganism
class Microorganism : LivingOrganism, IReproducible
{
    public string Strain { get; set; }

    public Microorganism(double energy, int age, double size, string strain)
        : base(energy, age, size)
    {
        Strain = strain;
    }

    public void Reproduce()
    {
        // Логіка розмноження мікроорганізмів
        Console.WriteLine($"{Strain} is reproducing.");
    }
}

// Клас для моделювання екосистеми
class Ecosystem
{
    private List<LivingOrganism> organisms;

    public Ecosystem()
    {
        organisms = new List<LivingOrganism>();
    }

    public void AddOrganism(LivingOrganism organism)
    {
        organisms.Add(organism);
    }

    public void SimulateEcosystem()
    {
        // Логіка взаємодії організмів в екосистемі
        foreach (var organism in organisms)
        {
            if (organism is IReproducible)
            {
                ((IReproducible)organism).Reproduce();
            }

            if (organism is IPredator)
            {
                // Полювання на інші організми
                foreach (var prey in organisms)
                {
                    if (prey != organism)
                    {
                        ((IPredator)organism).Hunt(prey);
                    }
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Ecosystem ecosystem = new Ecosystem();

        Animal lion = new Animal(100, 5, 2, "Lion");
        Animal zebra = new Animal(80, 7, 1, "Zebra");
        Plant grass = new Plant(50, 1, 0.1, "Grass");
        Microorganism bacteria = new Microorganism(10, 2, 0.01, "Bacteria");

        ecosystem.AddOrganism(lion);
        ecosystem.AddOrganism(zebra);
        ecosystem.AddOrganism(grass);
        ecosystem.AddOrganism(bacteria);

        ecosystem.SimulateEcosystem();
    }
}
