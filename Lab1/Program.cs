using PeopleLibrary;

internal class Program
{
    static void Main(string[] args)
    {
        // 3a.Creating two person lists 
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

        // 3b.Displaying the contents of both lists
        Console.WriteLine("Первый список:");
        Console.WriteLine(firstList.GetListInfo());

        Console.WriteLine("Второй список:");
        Console.WriteLine(secondList.GetListInfo());

        Console.ReadKey();

        // 3c.Adding a new person to the first list
        Person seventhPerson = new Person("яна", "СМИРНОВА", 29, Gender.Female);
        firstList.AddPerson(seventhPerson);
        Console.WriteLine("Первый список после добавления человека: ");
        Console.WriteLine(firstList.GetListInfo());

        Console.ReadKey();

        // 3d.Adding the second person from the first list to the second list
        Person personFromFirstList = firstList.GetPersonAt(1);
        secondList.AddPerson(personFromFirstList);
        
        Console.WriteLine("Первый список после копирования:");
        Console.WriteLine(firstList.GetListInfo());

        Console.WriteLine("Второй список после копирования:");
        Console.WriteLine(secondList.GetListInfo());

        // Checking whether both lists contain the same person object
        bool isSamePerson = object.ReferenceEquals(firstList.GetPersonAt(1), 
            secondList.GetPersonAt(3));
        Console.WriteLine($"Это один и тот же объект? - {isSamePerson}");
        Console.WriteLine("");

        Console.ReadKey();

        // 3e.Removing the second person from the first list
        bool isRemovedFromFirstList = firstList.RemovePerson(secondPerson);
        Console.WriteLine($"Иван удален из первого списка: {isRemovedFromFirstList}");

        Console.WriteLine("Первый список после удаления Ивана:");
        Console.WriteLine(firstList.GetListInfo());

        Console.WriteLine("Второй список после удаления Ивана из первого:");
        Console.WriteLine(secondList.GetListInfo());

        // Checking whether the person object still exists in the second list
        bool isIvanAfterRemoval = object.ReferenceEquals(personFromFirstList,
            secondList.GetPersonAt(3));

        Console.WriteLine(
            $"Иван остался тем же объектом во втором списке? - {isIvanAfterRemoval}");
        Console.WriteLine("");

        Console.ReadKey();

        // 3f.Clearing the second list
        secondList.ClearPeople();

        Console.WriteLine("Первый список после очистки второго:");
        Console.WriteLine(firstList.GetListInfo());

        Console.WriteLine("Второй список после очистки:");
        Console.WriteLine(secondList.GetListInfo());

        Console.WriteLine(
            $"Количество людей во втором списке: {secondList.Count}");

        Console.ReadKey();
    }
}
