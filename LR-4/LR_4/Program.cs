using System;

// Класс для работы с массивами, включает методы вывода, получения суммы и обработки ошибок.
class ArrayHandler
{
    private int[] array;

    // Конструктор, создающий массив заданного размера.
    public ArrayHandler(int size)
    {
        if (size <= 0)
            throw new ArgumentException("Размер массива должен быть положительным числом.");
        array = new int[size];
    }

    // Конструктор, принимающий готовый массив.
    public ArrayHandler(int[] inputArray)
    {
        if (inputArray == null || inputArray.Length == 0)
            throw new ArgumentException("Массив не должен быть пустым.");
        array = inputArray;
    }

    // Индексатор для доступа к элементам массива с контролем выхода за пределы.
    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= array.Length)
                throw new IndexOutOfRangeException("Индекс вне диапазона массива.");
            return array[index];
        }
        set
        {
            if (index < 0 || index >= array.Length)
                throw new IndexOutOfRangeException("Индекс вне диапазона массива.");
            array[index] = value;
        }
    }

    // Выводит элементы массива.
    public void PrintElements()
    {
        Console.WriteLine("Элементы массива: " + string.Join(", ", array));
    }

    // Возвращает сумму всех элементов массива.
    public int GetSum()
    {
        int sum = 0;
        foreach (int num in array)
        {
            sum += num;
        }
        return sum;
    }

    // Выводит элементы массива после заданного значения.
    public void PrintElementsAfterValue(int value)
    {
        int index = Array.IndexOf(array, value);
        if (index == -1 || index == array.Length - 1)
        {
            Console.WriteLine("Нет элементов после введенного значения.");
            return;
        }

        Console.Write("Элементы после {0}: ", value);
        for (int i = index + 1; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    // Возвращает сумму элементов после заданного значения.
    public int GetSumAfterValue(int value)
    {
        int index = Array.IndexOf(array, value);
        if (index == -1 || index == array.Length - 1)
        {
            return 0;
        }

        int sum = 0;
        for (int i = index + 1; i < array.Length; i++)
        {
            sum += array[i];
        }
        return sum;
    }
}

class Program
{
    static void Main()
    {
        int size;
        while (true)
        {
            try
            {
                Console.Write("Введите размер массива: ");
                size = int.Parse(Console.ReadLine());
                if (size <= 0)
                {
                    Console.WriteLine("Размер массива должен быть положительным числом.");
                    continue;
                }
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка ввода: " + ex.Message);
            }
        }

        int[] numbers = new int[size];
        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < size; i++)
        {
            while (true)
            {
                try
                {
                    numbers[i] = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка ввода: " + ex.Message + ". Попробуйте снова.");
                }
            }
        }

        ArrayHandler handler = new ArrayHandler(numbers);
        handler.PrintElements();
        Console.WriteLine("Сумма всех элементов: " + handler.GetSum());

        while (true)
        {
            try
            {
                Console.Write("Введите значение: ");
                int inputValue = int.Parse(Console.ReadLine());
                handler.PrintElementsAfterValue(inputValue);
                Console.WriteLine("Сумма всех элементов после {0}: {1}", inputValue, handler.GetSumAfterValue(inputValue));
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message + ". Попробуйте снова.");
            }
        }
    }
}
