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
        //TODO: XML +
        //TODO: refactor +
        /// <summary>
        /// Максимальное возможное число для ввода возраста
        /// </summary>
        public const int MaxAge = 100;

        //TODO: XML +
        //TODO: refactor +
        /// <summary>
        /// Минимальное возможное число для ввода возраста
        /// </summary>
        public const int MinAge = 0;

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
        /// Проверяет и форматирует значение имени/фамилии
        /// </summary>
        /// <param name="value">Проверяемое значение</param>
        /// <param name="fieldName">Название поля для сообщения</param>
        /// <param name="paramName">Имя свойства для ParamName</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static string Validate(string value, 
            string fieldName, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    $"{fieldName} не может быть пустым!", paramName);
            }

            if (!IsValidName(value))
            {
                throw new ArgumentException(
                    $"{fieldName} может содержать только русские/английские буквы," +
                    " пробелы и дефисы!", paramName);
            }

            return FormatName(value);
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
                _name = Validate(value, "Имя", nameof(Name));
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
                _surname = Validate(value, "Фамилия", nameof(Surname));
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
                if (value < 0 || value > MaxAge)
                {
                    //TODO: redo +
                    throw new ArgumentException("Возраст должен быть" +
                        $" положительным и в диапазоне от {MinAge} до {MaxAge}!", nameof(Age));
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
        /// Создает человека со случайными характеристиками
        /// </summary>
        public static Person GetRandomPerson()
        {
            string[] maleNames =
            {
                "Иван", "Александр", "Дмитрий", "Сергей", "леонардо вильгельм"
            };

            string[] femaleNames =
            {
                "Мария", "Анна", "АННА-МАРИЯ", "Екатерина", "Ольга"
            };

            string[] maleSurnames =
            {
                "ИвАнОв", "Петров", "Сидоров", "Смирнов", "SmiTh-JoNeS"
            };

            string[] femaleSurnames =
            { 
                "Иванова", "ПетРова", "СидОровА", "Смирнова"
            };


            Gender gender = _random.Next(2) == 0 
                ? Gender.Male 
                : Gender.Female;

            string[] names = gender == Gender.Male 
                ? maleNames 
                : femaleNames;
            string[] surnames = gender == Gender.Male 
                ? maleSurnames 
                : femaleSurnames;

            string name = names[_random.Next(names.Length)];
            string surname = surnames[_random.Next(surnames.Length)];

            int age = _random.Next(MinAge, MaxAge);

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
                @"^([A-Za-z]+([ -][A-Za-z]+)*|[А-Яа-яЁё]+([ -][А-Яа-яЁё]+)*)$");
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

        /// <summary>
        /// Представление человека
        /// </summary>
        public string GetInfo()
        {
            return $"- имя: {Name}\n" +
                   $"- фамилия: {Surname}\n" +
                   $"- лет: {Age}\n" +
                   $"- гендер: {Gender}\n";
        }
    }
}
