using System;
using System.Collections.Generic;
using System.Threading;

// Клас, що представляє дорогу
class Road
{
    public double Length { get; set; }
    public double Width { get; set; }
    public int Lanes { get; set; }
    public int TrafficLevel { get; set; }

    public Road(double length, double width, int lanes)
    {
        Length = length;
        Width = width;
        Lanes = lanes;
        TrafficLevel = 0;
    }
}

// Клас, що представляє транспортний засіб
class Vehicle : IDriveable
{
    public double Speed { get; set; }
    public string Type { get; set; }
    public double Size { get; set; }

    public Vehicle(double speed, string type, double size)
    {
        Speed = speed;
        Type = type;
        Size = size;
    }

    public void Move()
    {
        Console.WriteLine($"The {Type} is moving at {Speed} km/h.");
    }

    public void Stop()
    {
        Console.WriteLine($"The {Type} has stopped.");
    }
}

// Інтерфейс для руху
interface IDriveable
{
    void Move();
    void Stop();
}

// Клас, що моделює рух і зміну руху транспортних засобів
class TrafficSimulation
{
    private List<Vehicle> vehicles;
    private Road road;

    public TrafficSimulation(Road road)
    {
        this.road = road;
        vehicles = new List<Vehicle>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void SimulateTraffic()
    {
        Console.WriteLine($"Simulating traffic on a road of {road.Length} km with {road.Lanes} lanes...");
        while (true)
        {
            foreach (var vehicle in vehicles)
            {
                vehicle.Move();
            }

            Thread.Sleep(1000); // Симуляція трафіку протягом 1 секунди
        }
    }
}

class Program
{
    static void Main()
    {
        Road cityRoad = new Road(10.0, 3.5, 2);
        Vehicle car = new Vehicle(60.0, "car", 2.0);
        Vehicle bus = new Vehicle(50.0, "bus", 3.0);

        TrafficSimulation simulation = new TrafficSimulation(cityRoad);
        simulation.AddVehicle(car);
        simulation.AddVehicle(bus);

        simulation.SimulateTraffic();
    }
}
