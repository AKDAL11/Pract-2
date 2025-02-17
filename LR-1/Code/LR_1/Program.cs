using System;

string buf; // Переменная для временного хранения введённых значений

// Ввод значения x
Console.Write("Введите x: ");
buf = Console.ReadLine(); // Читаем ввод пользователя в виде строки
double x = Convert.ToDouble(buf); // Преобразуем строку в число (double)

// Ввод значения y
Console.Write("Введите y: ");
buf = Console.ReadLine();
double y = Convert.ToDouble(buf);

// Ввод значения z
Console.Write("Введите z: ");
buf = Console.ReadLine();
double z = Convert.ToDouble(buf);

// Вывод введённых значений
Console.WriteLine($"Для x={x}; y={y}; z={z}");

// Вычисление выражения a:
// (1 + y)^2 * ( (x^2 + 4) / (e^(-x) + x^2 + 4) )
double a = Math.Pow((1 + y), 2) * ((Math.Pow(x, 2) + 4) / (Math.Exp(-x) + Math.Pow(x, 2) + 4));

Console.WriteLine($"Результат a = {a}");

// Вычисление выражения b:
// 1 / ( (x^4)/2 + sin^4(z) + 1 )
double b = 1 / (((Math.Pow(x, 4)) / 2) + Math.Pow(Math.Sin(z), 4) + 1);

Console.WriteLine($"Результат b = {b}");