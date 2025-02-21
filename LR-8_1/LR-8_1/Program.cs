using System;

interface Ix
{
    void IxF0(int w);
    void IxF1();
}

interface Iy
{
    void F0(int w);
    void F1();
}

interface Iz
{
    void F0(int w);
    void F1();
}

class TestClass : Ix, Iy, Iz
{
    private int w;

    public TestClass(int w)
    {
        this.w = w;
    }

    // Реализация интерфейса Ix
    public void IxF0(int w)
    {
        Console.WriteLine($"IxF0: {w + 5}");
    }

    public void IxF1()
    {
        Console.WriteLine($"IxF1: {w}");
    }

    // Неявная реализация интерфейсов Iy и Iz
    public void F0(int w)
    {
        Console.WriteLine($"F0: {3}");
    }

    public void F1()
    {
        Console.WriteLine($"F1: {7 * w - 2}");
    }

    // Явная реализация интерфейса Iz
    void Iz.F0(int w)
    {
        Console.WriteLine($"Iz.F0: {3}");
    }

    void Iz.F1()
    {
        Console.WriteLine($"Iz.F1: {7 * w - 2}");
    }
}

class Program
{
    static void Main()
    {
        TestClass obj = new TestClass(4);

        // Вызовы через объект
        obj.IxF0(4);
        obj.IxF1();
        obj.F0(4);
        obj.F1();

        // Вызов через интерфейсную ссылку
        Iy iy = obj;
        iy.F0(4);
        iy.F1();

        // Вызов явной реализации интерфейса Iz
        Iz iz = obj;
        iz.F0(4);
        iz.F1();
    }
}
