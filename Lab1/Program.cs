using PeopleLibrary;

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
        Console.Write("Введите имя: ");
        string name = Console.ReadLine() ?? string.Empty;

        Console.Write("Введите фамилию: ");
        string surname = Console.ReadLine() ?? string.Empty;

        // Ввод возраста с проверкой правильности

        int age;

        while (true)
        {
            Console.Write("Введите возвраст: ");
            string ageInput = Console.ReadLine() ?? string.Empty;

            if (!int.TryParse(ageInput, out age))
            {
                Console.WriteLine("Возраст должен быть числом. " +
                    "Пожалуйста, введите значение повторно");
                continue;
            }

            if (age < 0)
            {
                Console.WriteLine("Возраст не может быть отрицательным. " +
                    "Пожалуйста, введите значение повторно");
                continue;
            }

            break;
        }

        // Ввод пола с проверкой правильности

        Gender gender;

        while (true)
        {
            Console.Write("Введите гендер (Male/Female): ");
            string genderInput = Console.ReadLine() ?? string.Empty;

            if (Enum.TryParse(genderInput, true, out gender) &&
                Enum.IsDefined(typeof(Gender), gender))
            {
                break;
            }

            Console.WriteLine("Некорректное значение пола. " +
                "Введите Male или Female");
        }

        // Создание объекта Person с повторным вводом

        while (true)
        {
            try
            {
                return new Person(name, surname, age, gender);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("Пожалуйста, проверьте введенные данные " +
                    "и исправьте ошибку");

                if (exception.ParamName == nameof(Person.Name))
                {
                    Console.Write("Введите имя: ");
                    name = Console.ReadLine() ?? string.Empty;
                }
                else if (exception.ParamName == nameof(Person.Surname))
                {
                    Console.Write("Введите фамилию: ");
                    surname = Console.ReadLine() ?? string.Empty;
                }
                else
                {
                    throw;
                }
            }
        }
    }

    /// <summary>
    /// Выводит информацию о человеке
    /// </summary>
    private static void PrintPerson(Person person)
    {
        Console.WriteLine("Пипл:");
        Console.WriteLine($"- имя: {person.Name}");
        Console.WriteLine($"- фамилия: {person.Surname}");
        Console.WriteLine($"- лет: {person.Age}");
        Console.WriteLine($"- гендер: {person.Gender}");
    }

}
