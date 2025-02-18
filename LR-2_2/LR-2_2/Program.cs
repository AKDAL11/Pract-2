Console.WriteLine("Введите последовательность чисел для того что-бы программа могла удалить числа 1 и 3");
string input = Console.ReadLine();

Console.WriteLine("Последовательность чисел после удаления:");
string result = input.Replace("1", "").Replace("3","");
Console.WriteLine(result);