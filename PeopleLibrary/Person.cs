using System.Text.RegularExpressions;

namespace PeopleLibrary
{
    /// <summary>
    /// Класс, представляющий человека
    /// Хранит имя, фамилию, возраст и пол, проверяет правильность
    /// значений при установке свойств и умеет создавать случайного человека
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Хранит имя человека в отформатированном виде
        /// </summary>
        private string _name = string.Empty;

        /// <summary>
        /// Хранит фамилию человека в отформатированном виде
        /// </summary>
        private string _surname = string.Empty;

        /// <summary>
        /// Хранит возраст человека. Не может быть отрицательным
        /// </summary>
        private int _age;

        /// <summary>
        /// Хранит пол человека
        /// </summary>
        private Gender _gender;

        /// <summary>
        /// Создает нового человека с заданными характеристиками
        /// Все значения проходят проверку через соответствующие свойства
        /// </summary>
        /// <param name="name">Имя человека. Не может быть пустым</param>
        /// <param name="surname">Фамилия человека. Не может быть пустой</param>
        /// <param name="age">Возраст человека. Не может быть отрицательным</param>
        /// <param name="gender">Пол человека</param>
        public Person(string name, string surname, int age, Gender gender) 
        { 
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Имя человека
        /// При установке значения проверяется, что оно не пустое и содержит
        /// только русские/английские буквы, пробелы и дефисы
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
                        " пробелы и дефисы!", nameof(Name));
                }
                _name = FormatName(value);
            }
        }

        /// <summary>
        /// Фамилия человека
        /// При установке значения проверяется, что оно не пустое и содержит
        /// только русские/английские буквы, пробелы и дефисы
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
        /// Возраст человека
        /// При установке значения проверяется, что оно не отрицательное
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
                    throw new ArgumentException("Возраст не должен быть" +
                        " отрицательным!", nameof(Age));
                }
                _age = value;
            }
        }

        /// <summary>
        /// Пол человека
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Генератор случайных значений
        /// Используется при создании случайного человека
        /// </summary>
        private static readonly Random _random = new Random();

        /// <summary>
        /// Список мужских имен для генерации случайного человека
        /// </summary>
        private static readonly string[] _maleNames =
        {
            "Иван", "Александр", "Дмитрий", "Сергей", "леонардо вильгельм"
        };

        /// <summary>
        /// Список женских имен для генерации случайного человека
        /// </summary>
        private static readonly string[] _femaleNames =
        {
            "Мария", "Анна", "АННА-МАРИЯ", "Екатерина", "Ольга"
        };

        /// <summary>
        /// Список мужских фамилий для генерации случайного человека
        /// </summary>
        private static readonly string[] _maleSurnames =
        {
            "ИвАнОв", "Петров", "Сидоров", "Смирнов", "SmiTh-JoNeS"
        };

        /// <summary>
        /// Список женских фамилий для генерации случайного человека
        /// </summary>
        private static readonly string[] _femaleSurnames =
        {
            "Иванова", "ПетРова", "СидОровА", "Смирнова"
        };

        /// <summary>
        /// Создает человека со случайными характеристиками
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
        /// Проверяет, является ли строка корректным именем или фамилией
        /// Строка считается корректной, если состоит из русских/английских
        /// букв, а слова разделены пробелами или дефисами
        /// </summary>
        private static bool IsValidName(string value)
        {
            return Regex.IsMatch(value, 
                @"^[A-Za-zА-Яа-яЁё]+([ -][A-Za-zА-Яа-яЁё]+)*$");
        }

        /// <summary>
        /// Приводит имя или фамилию к правильному регистру
        /// </summary>
        private static string FormatName(string value)
        {
            string[] words = value.ToLower().Split(' ', '-');

            for (int i = 0; i < words.Length; i++)
            {
                char[] letters = words[i].ToCharArray();
                letters[0] = char.ToUpper(letters[0]);
                words[i] = string.Join("", letters);
            }

            return string.Join(" ", words);
        }
    }
}
