using System;

class Vector3D
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }

    public Vector3D(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    // Сложение векторов
    public static Vector3D operator +(Vector3D v1, Vector3D v2)
    {
        return new Vector3D(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
    }

    // Вычитание векторов
    public static Vector3D operator -(Vector3D v1, Vector3D v2)
    {
        return new Vector3D(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
    }

    // Скалярное произведение
    public static double DotProduct(Vector3D v1, Vector3D v2)
    {
        return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
    }

    // Длина вектора
    public double Length()
    {
        return Math.Sqrt(X * X + Y * Y + Z * Z);
    }

    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }

    // Метод для ввода вектора пользователем с обработкой исключений
    public static Vector3D InputVector(string vectorName)
    {
        Console.WriteLine($"Введите координаты для {vectorName}:");
        double x = InputCoordinate("X");
        double y = InputCoordinate("Y");
        double z = InputCoordinate("Z");

        return new Vector3D(x, y, z);
    }

    private static double InputCoordinate(string coordinateName)
    {
        while (true)
        {
            try
            {
                Console.Write($"{coordinateName}: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    throw new ArgumentException("Ввод не может быть пустым!");

                if (!double.TryParse(input, out double value))
                    throw new FormatException("Ошибка: введите числовое значение!");

                return value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка ввода: {ex.Message} Попробуйте снова.");
            }
        }
    }
}

// Основная программа
class Program
{
    static void Main()
    {
        try
        {
            Vector3D v1 = Vector3D.InputVector("вектора 1");
            Vector3D v2 = Vector3D.InputVector("вектора 2");

            Vector3D sum = v1 + v2;
            Vector3D difference = v1 - v2;
            double dotProduct = Vector3D.DotProduct(v1, v2);
            double lengthV1 = v1.Length();
            double lengthV2 = v2.Length();

            Console.WriteLine($"\nРезультаты операций:");
            Console.WriteLine($"Сложение: {sum}");
            Console.WriteLine($"Вычитание: {difference}");
            Console.WriteLine($"Скалярное произведение: {dotProduct}");
            Console.WriteLine($"Длина вектора 1: {lengthV1}");
            Console.WriteLine($"Длина вектора 2: {lengthV2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
        }
    }
}
