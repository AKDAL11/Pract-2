using System;
using System.Collections.Generic;
using System.Linq;

class Car : IComparable<Car>
{
    public string Brand { get; set; }
    public string Owner { get; set; }
    public int Year { get; set; }
    public int Mileage { get; set; }

    public Car(string brand, string owner, int year, int mileage)
    {
        Brand = brand;
        Owner = owner;
        Year = year;
        Mileage = mileage;
    }

    // Реализация сравнения автомобилей по пробегу
    public int CompareTo(Car other)
    {
        return Mileage.CompareTo(other.Mileage);
    }

    public override string ToString()
    {
        return $"Марка: {Brand}, Владелец: {Owner}, Год: {Year}, Пробег: {Mileage} км";
    }
}

class Program
{
    static void Main()
    {
        List<Car> cars = new List<Car>();

        Console.Write("Введите количество автомобилей: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите данные для автомобиля {i + 1}:");
            Console.Write("Марка: ");
            string brand = Console.ReadLine();
            Console.Write("Фамилия владельца: ");
            string owner = Console.ReadLine();
            Console.Write("Год приобретения: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Пробег (км): ");
            int mileage = int.Parse(Console.ReadLine());

            cars.Add(new Car(brand, owner, year, mileage));
        }

        Console.Write("Введите предельный год выпуска: ");
        int limitYear = int.Parse(Console.ReadLine());

        // Фильтрация автомобилей по году
        List<Car> oldCars = cars.Where(car => car.Year < limitYear).ToList();
        oldCars.Sort(); // Сортировка по пробегу

        Console.WriteLine("\nАвтомобили, выпущенные ранее заданного года, отсортированные по пробегу:");
        foreach (var car in oldCars)
        {
            Console.WriteLine(car);
        }
    }
}
