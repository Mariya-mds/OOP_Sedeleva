using System.Text.RegularExpressions;
namespace PeopleLibrary
{
    /// <summary>
    /// This class represents a person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Saves the person's name
        /// </summary>
        private string _name = string.Empty;

        /// <summary>
        /// Saves the person's surname
        /// </summary>
        private string _surname = string.Empty;

        /// <summary>
        /// Saves the person's age
        /// </summary>
        private int _age;

        /// <summary>
        /// Saves the person's gender
        /// </summary>
        private Gender _gender;

        /// <summary>
        /// The constructor creates a person with the characteristics
        /// </summary>
        public Person(string name, string surname, int age, Gender gender) 
        { 
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Name verification and case adjustment
        /// </summary>
        public string Name
        { 
            get 
            { 
                return _name; 
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Имя не может быть пустым!",
                        nameof(Name));
                }
                
                if (!IsValidName(value))
                {
                    throw new ArgumentException(
                        "Имя может содержать только русские/английские буквы," +
                        " пробелы и дефисы!",
                        nameof(Name));
                }
                _name = FormatName(value);
            }
        }

        /// <summary>
        /// Surname verification and case adjustment
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Фамилия не может быть пустой!",
                        nameof(Surname));
                }

                if (!IsValidName(value))
                {
                    throw new ArgumentException(
                        "Фамилия может содержать только русские/английские буквы," +
                        " пробелы и дефисы!",
                        nameof(Surname));
                }
                _surname = FormatName(value);
            }
        }

        /// <summary>
        /// Age verification
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Возраст не должен быть отрицательным!",
                        nameof(Age));
                }
                _age = value;
            }
        }

        /// <summary>
        /// Gender verification
        /// </summary>
        public Gender Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
            }
        }

        /// <summary>
        /// Generates random values
        /// </summary>
        private static readonly Random _random = new Random();

        /// <summary>
        /// Stores male names
        /// </summary>
        private static readonly string[] _maleNames =
        {
            "Иван", "Александр", "Дмитрий", "Сергей", "леонардо вильгельм"
        };


        /// <summary>
        /// Stores female names
        /// </summary>
        private static readonly string[] _femaleNames =
        {
            "Мария", "Анна", "АННА-МАРИЯ", "Екатерина", "Ольга"
        };

        /// <summary>
        /// Stores male surnames
        /// </summary>
        private static readonly string[] _maleSurnames =
        {
            "ИвАнОв", "Петров", "Сидоров", "Смирнов", "SmiTh-JoNeS"
        };

        /// <summary>
        /// Stores female surnames
        /// </summary>
        private static readonly string[] _femaleSurnames =
        {
            "Иванова", "ПетРова", "СидОровАа", "Смирнова",
        };

        /// <summary>
        /// Creates a person with random characteristics
        /// </summary>
        public static Person GetRandomPerson()
        {
            Gender gender;

            if (_random.Next(2) == 0)
            {
                gender = Gender.Male;
            }
            else
            {
                gender = Gender.Female;
            }

            string name;
            string surname;

            if (gender == Gender.Male)
            {
                name = _maleNames[_random.Next(_maleNames.Length)];
                surname = _maleSurnames[_random.Next(_maleSurnames.Length)];
            }
            else
            {
                name = _femaleNames[_random.Next(_femaleNames.Length)];
                surname = _femaleSurnames[_random.Next(_femaleSurnames.Length)];
            }

            int age = _random.Next(0, 101);

            return new Person(name, surname, age, gender);
        }

        /// <summary>
        /// Checks whether the string is a valid first or last name
        /// </summary>
        private static bool IsValidName(string value)
        {
            return Regex.IsMatch(value, 
                @"^[A-Za-zА-Яа-яЁё]+([ -][A-Za-zА-Яа-яЁё]+)*$");
        }


        /// <summary>
        /// Formats the first and last name
        /// </summary>
        private static string FormatName(string value)
        {
            string result = "";
            bool capitalizeNext = true;

            foreach (char character in value)
            {
                if (character == ' ' || character == '-')
                {
                    result += character;
                    capitalizeNext = true;
                }
                else if (capitalizeNext)
                {
                    result += char.ToUpper(character);
                    capitalizeNext = false;
                }
                else
                {
                    result += char.ToLower(character);
                }
            }

            return result;
        }
    }
}
