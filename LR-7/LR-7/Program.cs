using System;

// Базовый класс "Населенный пункт"
class Settlement
{
    protected string name;

    public Settlement(string name)
    {
        this.name = name;
    }

    // Виртуальный метод расчета плотности населения
    public virtual double GetPopulationDensity()
    {
        return 0;
    }

    // Виртуальный метод вывода информации
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Населенный пункт: {name}");
    }
}

// Производный класс "Село"
class Village : Settlement
{
    private int houses;
    private int residentsPerHouse;
    private double area;

    public Village(string name, int houses, int residentsPerHouse, double area)
        : base(name)
    {
        this.houses = houses;
        this.residentsPerHouse = residentsPerHouse;
        this.area = area;
    }

    public override double GetPopulationDensity()
    {
        return (houses * residentsPerHouse) / area;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Село: {name}, Количество домов: {houses}, Жителей в доме: {residentsPerHouse}, Площадь: {area} кв. км, Плотность населения: {GetPopulationDensity():F2} чел/кв. км");
    }
}

// Производный класс "Город"
class City : Settlement
{
    private int population;
    private double area;

    public City(string name, int population, double area)
        : base(name)
    {
        this.population = population;
        this.area = area;
    }

    public override double GetPopulationDensity()
    {
        return population / area;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Город: {name}, Население: {population}, Площадь: {area} кв. км, Плотность населения: {GetPopulationDensity():F2} чел/кв. км");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите количество населенных пунктов: ");
        int count = int.Parse(Console.ReadLine());

        Settlement[] settlements = new Settlement[count];

        for (int i = 0; i < count; i++)
        {
            Console.Write("Введите тип населенного пункта (1 - село, 2 - город): ");
            int type = int.Parse(Console.ReadLine());

            Console.Write("Введите название населенного пункта: ");
            string name = Console.ReadLine();

            if (type == 1)
            {
                Console.Write("Введите количество домов: ");
                int houses = int.Parse(Console.ReadLine());

                Console.Write("Введите количество жителей в доме: ");
                int residentsPerHouse = int.Parse(Console.ReadLine());

                Console.Write("Введите площадь села (кв. км): ");
                double area = double.Parse(Console.ReadLine());

                settlements[i] = new Village(name, houses, residentsPerHouse, area);
            }
            else if (type == 2)
            {
                Console.Write("Введите население города: ");
                int population = int.Parse(Console.ReadLine());

                Console.Write("Введите площадь города (кв. км): ");
                double area = double.Parse(Console.ReadLine());

                settlements[i] = new City(name, population, area);
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Повторите попытку.");
                i--;
            }
        }

        Console.WriteLine("\nИнформация о населенных пунктах:");
        foreach (var settlement in settlements)
        {
            settlement.DisplayInfo();
            Console.WriteLine();
        }
    }
}