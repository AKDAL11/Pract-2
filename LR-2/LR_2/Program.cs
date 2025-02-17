using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Для выхода из цикла нажмите '0'");
        Console.WriteLine("Вводите символы для проверки, к какому алфавиту они относятся.");

        while (true)
        {
            Console.Write("Введите символ: ");
            string buf = Console.ReadLine();

            if (buf == "0") // Проверяем, ввёл ли пользователь '0' для выхода
            {
                Console.WriteLine("Выход из программы");
                break;
            }

            if (buf.Length != 1) // Проверяем, что введён только один символ
            {
                Console.WriteLine("Ошибка: Введите только один символ.");
                continue;
            }

            char a = char.ToLower(buf[0]); // Приводим к нижнему регистру

            switch (a)
            {
                default:
                    if ("abcdefghijklmnopqrstuvwxyz".Contains(a))
                        Console.WriteLine("Символ из латинского алфавита");
                    else if ("абвгдеёжзийклмнопрстуфхцчшщъыьэюя".Contains(a))
                        Console.WriteLine("Символ из русского алфавита");
                    else
                        Console.WriteLine("Символ не из латинского и не из русского алфавита");
                    break;
            }
        }
    }
}
