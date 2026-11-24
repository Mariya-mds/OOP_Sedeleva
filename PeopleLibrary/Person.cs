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
                    throw new ArgumentException("Name cannot be empty!",
                        nameof(Name));
                }
                _name = value[0].ToString().ToUpper() + 
                    value.Substring(1).ToLower();
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
                    throw new ArgumentException("Surname cannot be empty!",
                        nameof(Surname));
                }
                _surname = value[0].ToString().ToUpper() +
                    value.Substring(1).ToLower();
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
                    throw new ArgumentException("The age should not be negative!",
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
            "Иван", "Александр", "Дмитрий", "Сергей"
        };


        /// <summary>
        /// Stores female names
        /// </summary>
        private static readonly string[] _femaleNames =
        {
            "Мария", "Анна", "Екатерина", "Ольга"
        };

        /// <summary>
        /// Stores male surnames
        /// </summary>
        private static readonly string[] _maleSurnames =
        {
            "Иванов", "Петров", "Сидоров", "Смирнов"
        };

        /// <summary>
        /// Stores female surnames
        /// </summary>
        private static readonly string[] _femaleSurnames =
        {
            "Иванова", "Петрова", "Сидорова", "Смирнова"
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
    }
}
