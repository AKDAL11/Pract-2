using System;

// Базовый класс "Тетрадь"
class Notebook
{
    private string name;
    private int sheets;

    // Конструктор с параметрами
    public Notebook(string name, int sheets)
    {
        this.name = name;
        this.sheets = sheets;
    }

    // Методы доступа
    public string GetName() => name;
    public int GetSheets() => sheets;

    // Метод расчета стоимости
    public virtual int GetCost()
    {
        return 15 * sheets;
    }

    // Метод вывода информации
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Тетрадь: {name}, Листов: {sheets}, Стоимость: {GetCost()} р.");
    }
}

// Производный класс "Общая тетрадь"
class CommonNotebook : Notebook
{
    private string coverMaterial;

    // Конструктор с параметрами
    public CommonNotebook(string name, int sheets, string coverMaterial)
        : base(name, sheets)
    {
        this.coverMaterial = coverMaterial;
    }

    // Переопределенный метод расчета стоимости
    public override int GetCost()
    {
        return base.GetCost() + 50; // Надбавка за обложку
    }

    // Переопределенный метод вывода информации
    public override void DisplayInfo()
    {
        Console.WriteLine($"Общая тетрадь: {GetName()}, Листов: {GetSheets()}, Обложка: {coverMaterial}, Стоимость: {GetCost()} р.");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Сколько видов тетрадей вы хотите внести? ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.Write("Введите название тетради: ");
            string name = Console.ReadLine();

            Console.Write("Введите количество листов: ");
            int sheets = int.Parse(Console.ReadLine());

            Notebook notebook = new Notebook(name, sheets);
            notebook.DisplayInfo();

            Console.Write("Введите материал обложки: ");
            string coverMaterial = Console.ReadLine();

            CommonNotebook commonNotebook = new CommonNotebook(name, sheets, coverMaterial);
            commonNotebook.DisplayInfo();
        }
    }
}
