using PeopleLibrary;

internal class Program
{
    static void Main(string[] args)
    {
        Person person = new Person("МАРИЯ", "СЕДЕЛЕВА", 23, Gender.Female);
        Console.WriteLine(person.Name);
        Console.WriteLine(person.Surname);
        Console.WriteLine(person.Age);
        Console.WriteLine(person.Gender);

        Console.ReadKey();
    }
}