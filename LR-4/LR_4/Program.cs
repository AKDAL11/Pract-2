using System;

class ArrayHandler
{
    private int[] array;

    public ArrayHandler(int size)
    {
        if (size <= 0)
            throw new ArgumentException("Размер массива должен быть больше нуля.");
        array = new int[size];
    }

    public ArrayHandler(int[] inputArray)
    {
        if (inputArray == null || inputArray.Length == 0)
            throw new ArgumentException("Массив не может быть пустым или null.");
        array = inputArray;
    }

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

    public void PrintElements()
    {
        Console.WriteLine("Элементы массива: " + string.Join(", ", array));
    }

    public int GetSum()
    {
        int sum = 0;
        foreach (int num in array)
        {
            sum += num;
        }
        return sum;
    }

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
        try
        {
            Console.Write("Введите размер массива: ");
            int size = int.Parse(Console.ReadLine());
            if (size <= 0)
            {
                Console.WriteLine("Ошибка: размер массива должен быть положительным числом.");
                return;
            }

            int[] numbers = new int[size];
            Console.WriteLine("Введите элементы массива:");
            for (int i = 0; i < size; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            ArrayHandler handler = new ArrayHandler(numbers);
            handler.PrintElements();
            Console.WriteLine("Сумма всех элементов: " + handler.GetSum());

            Console.Write("Введите значение: ");
            int inputValue = int.Parse(Console.ReadLine());
            handler.PrintElementsAfterValue(inputValue);

            Console.WriteLine("Сумма всех элементов после {0}: {1}", inputValue, handler.GetSumAfterValue(inputValue));
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: введено некорректное число.");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла неожиданная ошибка: " + ex.Message);
        }
    }
}
