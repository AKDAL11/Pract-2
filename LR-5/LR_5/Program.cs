using System;

class FixedStringArray
{
    private string[] array;

    // Конструктор по умолчанию
    public FixedStringArray(int size)
    {
        array = new string[size];
    }

    // Конструктор с передачей массива
    public FixedStringArray(string[] inputArray)
    {
        array = new string[inputArray.Length];
        Array.Copy(inputArray, array, inputArray.Length);
    }

    // Индексатор для доступа к элементам массива
    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= array.Length)
                throw new IndexOutOfRangeException("Индекс выходит за границы массива");
            return array[index];
        }
        set
        {
            if (index < 0 || index >= array.Length)
                throw new IndexOutOfRangeException("Индекс выходит за границы массива");
            array[index] = value;
        }
    }

    // Перегрузка оператора == для поэлементного сравнения массивов
    public static bool operator ==(FixedStringArray a, FixedStringArray b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        if (a.array.Length != b.array.Length) return false;

        for (int i = 0; i < a.array.Length; i++)
        {
            if (a.array[i] != b.array[i])
                return false;
        }
        return true;
    }

    // Перегрузка оператора !=
    public static bool operator !=(FixedStringArray a, FixedStringArray b)
    {
        return !(a == b);
    }

    // Метод для отображения массива
    public void Display()
    {
        Console.WriteLine("[ " + string.Join(", ", array) + " ]");
    }
}

class Program
{
    static void Main()
    {
        string[] words1 = { "стол", "стул", "мышка" };
        string[] words2 = { "стол", "стул", "мышка" };
        string[] words3 = { "стул", "мышка", "стол" };

        FixedStringArray array1 = new FixedStringArray(words1);
        FixedStringArray array2 = new FixedStringArray(words2);
        FixedStringArray array3 = new FixedStringArray(words3);

        Console.WriteLine("Массив 1:");
        array1.Display();
        Console.WriteLine("Массив 2:");
        array2.Display();
        Console.WriteLine("Массив 3:");
        array3.Display();

        Console.WriteLine("Массив1 == Массив2: " + (array1 == array2)); 
        Console.WriteLine("Массив1 == Массив3: " + (array1 == array3)); 
    }
}