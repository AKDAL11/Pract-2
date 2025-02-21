using System;

// Абстрактный базовый класс "Населенный пункт"
abstract class Settlement
{
    private string name;

    public Settlement(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    // Абстрактный метод расчета плотности населения
    public abstract double GetPopulationDensity();

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
        Console.WriteLine($"Село: {GetName()}, Количество домов: {houses}, Жителей в доме: {residentsPerHouse}, Площадь: {area} кв. км, Плотность населения: {GetPopulationDensity():F2} чел/кв. км");
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
        Console.WriteLine($"Город: {GetName()}, Население: {population}, Площадь: {area} кв. км, Плотность населения: {GetPopulationDensity():F2} чел/кв. км");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Введите количество населенных пунктов: ");
            int count = int.Parse(Console.ReadLine());

            if (count <= 0)
            {
                throw new ArgumentException("Количество населенных пунктов должно быть положительным числом.");
            }

            Settlement[] settlements = new Settlement[count];

            for (int i = 0; i < count; i++)
            {
                try
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

                        Console.Write("Введите площадь (кв. км): ");
                        double area = double.Parse(Console.ReadLine());

                        settlements[i] = new Village(name, houses, residentsPerHouse, area);
                    }
                    else if (type == 2)
                    {
                        Console.Write("Введите население: ");
                        int population = int.Parse(Console.ReadLine());

                        Console.Write("Введите площадь (кв. км): ");
                        double area = double.Parse(Console.ReadLine());

                        settlements[i] = new City(name, population, area);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: некорректный тип населенного пункта. Повторите ввод.");
                        i--;
                        continue;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: некорректный ввод. Повторите попытку.");
                    i--;
                }
            }

            Console.WriteLine("\nИнформация о населенных пунктах:");
            Settlement minDensitySettlement = settlements[0];

            foreach (var settlement in settlements)
            {
                settlement.DisplayInfo();
                Console.WriteLine();

                if (settlement.GetPopulationDensity() < minDensitySettlement.GetPopulationDensity())
                {
                    minDensitySettlement = settlement;
                }
            }

            Console.WriteLine($"Населенный пункт с наименьшей плотностью населения: {minDensitySettlement.GetName()} ({minDensitySettlement.GetPopulationDensity():F2} чел/кв. км)");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: введено некорректное значение. Пожалуйста, используйте числовые данные.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
