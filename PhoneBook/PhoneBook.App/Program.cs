// -
using System;
using System.Collections.Generic;
using System.Linq;

using PhoneBook.Models;


namespace PhoneBook.App;

internal class Program
{
    private enum InputResult
    {
        PageNumber,
        WrongInput,
        EscInput,
    }


    /// <summary>
    /// Функция, выводящая список контактов постранично,
    ///  как это было в задании 14.2.10
    ///  и дополненная сортировкой сначала по имени, затем по фамилии
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        Console.WriteLine("PhoneBook");
        Console.WriteLine("---");
        int result = 0;

        //  создаём пустой список с типом данных Contact
        List<Contact> phoneBook = [];
    
        // добавляем контакты
        phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
        phoneBook.Add(new Contact("Сергей", "Довлатов",79990000010, "serge@example.com"));
        phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
        phoneBook.Add(new Contact("Валерий", "Леонтьев",79990000012, "valera@example.com"));
        phoneBook.Add(new Contact("Сергей", "Брин",  799900000013, "serg@example.com"));
        phoneBook.Add(new Contact("Иннокентий", "Смоктуновский",799900000013, "innokentii@example.com"));

        // сортируем контакты сперва по имени, затем по фамилии
        phoneBook = phoneBook.OrderBy(x => x.Name).ThenBy(x => x.LastName).ToList();

        // запрашиваем ввод пользователя в цикле
        (InputResult inputResult, int pageNumber) input;
        do
        {
            Console.WriteLine("enter a page number (1 - 3) or Esc: ");
            input = GetUserDataFromConsole();
            if (input.inputResult == InputResult.PageNumber)
            {
                // пропускаем нужное количество элементов и берем 2 для показа на странице
                var pageContent = phoneBook.Skip((input.pageNumber - 1) * 2).Take(2);

                // очищаем экран
                Console.Clear();

                // выводим результат
                foreach (var entry in pageContent)
                    Console.WriteLine(entry.Name + " " + entry.LastName +  ": " + entry.PhoneNumber);
            }
            else if (input.inputResult == InputResult.WrongInput)
            {
                // возвращаемся в цикл
                Console.WriteLine("error: wrong page number was entered");
            }
            Console.WriteLine("---");
        } while (input.inputResult != InputResult.EscInput);

        Console.WriteLine($"return: [{result}]");
        Console.ReadKey();
    }


    /// <summary>
    ///  Обработка единичного ввода пользователя
    /// </summary>
    /// <returns>характер полученных данных, номер введенной страницы</returns>
    private static (InputResult inputResult, int pageNumber)
        GetUserDataFromConsole()
    {
        InputResult res = InputResult.WrongInput;
        int pageNumber = 0;

        // Читаем введенный с консоли символ
        ConsoleKeyInfo info = Console.ReadKey(true);

        // если нажата клавиша Esc, то выходим
        if (info.Key == ConsoleKey.Escape)
        {
            res = InputResult.EscInput;
        }
        // проверяем, число ли введено
        else if (int.TryParse(info.KeyChar.ToString(), out pageNumber)
            && (0 < pageNumber) && (pageNumber < 4))
        {
            Console.WriteLine(pageNumber.ToString());
            res = InputResult.PageNumber;
        }

        return (inputResult: res, pageNumber);
    }
}
