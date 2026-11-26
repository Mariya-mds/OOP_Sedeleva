using PeopleLibrary;
using System;

/// <summary>
/// Точка входа в программу
/// </summary>
internal class Program
{
    /// <summary>
    /// Точка входа
    /// </summary>
    private static void Main(string[] args)
    {
        // 3a. Создание двух списков людей

        PersonList firstList = new PersonList();
        
        Person firstPerson = new Person("МАРИЯ", "СЕДЕЛЕВА", 23, Gender.Female);
        Person secondPerson = new Person("ИВАН", "ПЕТРОВ", 25, Gender.Male);
        Person thirdPerson = new Person("анна", "семенова", 34, Gender.Female);
        
        firstList.AddPerson(firstPerson);
        firstList.AddPerson(secondPerson);
        firstList.AddPerson(thirdPerson);

        PersonList secondList = new PersonList();

        Person fourthPerson = new Person("ольга", "иванова", 28, Gender.Female);
        Person fifthPerson = new Person("дмитрий", "иванов", 64, Gender.Male);
        Person sixthPerson = new Person("арина", "горбачева", 33, Gender.Female);

        secondList.AddPerson(fourthPerson);
        secondList.AddPerson(fifthPerson);
        secondList.AddPerson(sixthPerson);

        // 3b. Вывод содержимого обоих списков

        Console.WriteLine("Первый список:");
        Console.WriteLine(firstList.GetListInfo());

        Console.WriteLine("Второй список:");
        Console.WriteLine(secondList.GetListInfo());

        Console.ReadKey();

        // 3c. Добавление нового человека в первый список

        Person seventhPerson = new Person("яна", "СМИРНОВА", 29, Gender.Female);
        firstList.AddPerson(seventhPerson);
        Console.WriteLine("Первый список после добавления человека: ");
        Console.WriteLine(firstList.GetListInfo());

        Console.ReadKey();

        // 3d. Добавление второго человека из первого списка во второй список

        Person personFromFirstList = firstList.GetPersonAt(1);
        secondList.AddPerson(personFromFirstList);
        
        Console.WriteLine("Первый список после добавления Ивана во второй:");
        Console.WriteLine(firstList.GetListInfo());

        Console.WriteLine("Второй список после добавления Ивана:");
        Console.WriteLine(secondList.GetListInfo());

        // Проверка, содержат ли оба списка один и тот же объект person

        bool isSamePerson = ReferenceEquals(firstList.GetPersonAt(1), 
            secondList.GetPersonAt(3));
        Console.WriteLine($"Это один и тот же объект? - {isSamePerson}");
        Console.WriteLine();

        Console.ReadKey();

        // 3e. Удаление второго человека из первого списка

        bool isRemovedFromFirstList = firstList.RemovePerson(secondPerson);
        Console.WriteLine($"Иван удален из первого списка: " +
            $"{isRemovedFromFirstList}");

        Console.WriteLine("Первый список после удаления Ивана:");
        Console.WriteLine(firstList.GetListInfo());

        Console.WriteLine("Второй список после удаления Ивана из первого:");
        Console.WriteLine(secondList.GetListInfo());

        // Проверка, существует ли объект person все еще во втором списке

        bool isIvanAfterRemoval = ReferenceEquals(personFromFirstList,
            secondList.GetPersonAt(3));

        Console.WriteLine($"Иван остался тем же объектом " +
            $"во втором списке? - {isIvanAfterRemoval}");
        Console.WriteLine("");

        Console.ReadKey();

        // 3f. Очистка второго списка

        secondList.ClearPeople();

        Console.WriteLine("Первый список после очистки второго:");
        Console.WriteLine(firstList.GetListInfo());

        Console.WriteLine("Второй список после очистки:");
        Console.WriteLine(secondList.GetListInfo());

        Console.WriteLine(
            $"Количество людей во втором списке: {secondList.Count}");

        Console.ReadKey();

        // Создание человека с вводом данных с клавиатуры

        Console.WriteLine();
        Console.WriteLine("Введите данные нового человека:");

        Person enteredPerson = ReadPersonFromConsole();
        PrintPerson(enteredPerson);

        Console.ReadKey();

        // Генерация случайных людей 

        Console.WriteLine();
        Console.WriteLine("Рандом:");

        for (int i = 0; i < 5; i++)
        {
            Person randomPerson = Person.GetRandomPerson();
            PrintPerson(randomPerson);
            Console.WriteLine();
        }

        Console.ReadKey();
    }

    /// <summary>
    /// Читает информацию о человеке с клавиатуры
    /// </summary>
    private static Person ReadPersonFromConsole()
    {
        //TODO: refactor +
        Person person = new Person("Имя", "Фамилия", Person.MinAge, Gender.Male);

        while (true)
        {
            try
            {
                Console.Write("Введите имя: ");
                person.Name = Console.ReadLine() ?? string.Empty;
                break;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        while (true)
        {
            try
            {
                Console.Write("Введите фамилию: ");
                person.Surname = Console.ReadLine() ?? string.Empty;
                break;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
        while (true)
        {
            try
            {
                Console.Write("Введите возраст: ");
                person.Age = int.Parse(Console.ReadLine() ?? string.Empty);
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Возраст должен быть целым числом!");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        while (true)
        {
            try
            {
                Console.Write("Введите гендер (Male/Female): ");
                person.Gender = Enum.Parse<Gender>(Console.ReadLine() ?? string.Empty, true);

                if (!Enum.IsDefined(typeof(Gender), person.Gender))
                {
                    throw new ArgumentException();
                }

                break;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Некорректное значение пола. Введите Male или Female");
            }
        }

        return person;
    }

    /// <summary>
    /// Выводит информацию о человеке
    /// </summary>
    private static void PrintPerson(Person person)
    {
        Console.WriteLine("Пипл:");
        //TODO: duplication +
        Console.WriteLine(person.GetInfo());
    }

}
