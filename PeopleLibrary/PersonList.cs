namespace PeopleLibrary
{
    /// <summary>
    /// Класс который представляет список людей
    /// Хранит людей в массиве, автоматически увеличивает емкость массива
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Массив для хранения людей
        /// Емкость массива может быть больше фактического количества людей
        /// </summary>
        private Person[] _people;

        /// <summary>
        /// Фактическое количество людей в списке
        /// </summary>
        private int _count;

        /// <summary>
        /// Создает новый пустой список людей
        /// Начальная емкость массива 3
        /// </summary>
        public PersonList()
        {
            _people = new Person[3];
            _count = 0;
        }

        /// <summary>
        /// Увеличивает емкость массива, когда необходимо
        /// Если массив заполнен, создается новый массив вдвое большего размера,
        /// в который копируются все существующие элементы
        /// </summary>
        private void ProvCapacity()
        {
            if (_count < _people.Length)
            {
                return;
            }

            Person[] newPeople = new Person[_people.Length * 2];

            for (int i = 0; i < _count; i++)
            {
                newPeople[i] = _people[i];
            }

            _people = newPeople;
        }

        /// <summary>
        /// Добавляет человека в список
        /// При необходимости предварительно увеличивает емкость массива
        /// </summary>
        public void AddPerson(Person person)
        {
            ProvCapacity();

            _people[_count] = person;
            _count++;
        }

        /// <summary>
        /// Возвращает индекс человека в списке, если он там присутствует
        /// </summary>
        public int GetPersonIndex(Person person)
        {
            for (int i = 0; i < _count; i++)
            {
                if (ReferenceEquals(_people[i], person))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Удаляет человека по указанному индексу
        /// Все элементы после удаленного сдвигаются на одну позицию влево,
        /// а последняя ячейка очищается
        /// </summary>
        public void RemovePersonAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            for (int i = index; i < _count - 1; i++)
            {
                _people[i] = _people[i + 1];
            }

            _count--;
            _people[_count] = null;
            //Array.Clear(_people, _count, 1);
        }

        /// <summary>
        /// Удаляет человека из списка
        /// </summary>
        /// <returns>True если человек был найден и удален, иначе false</returns>
        public bool RemovePerson(Person person)
        {
            int index = GetPersonIndex(person);

            if (index == -1)
            {
                return false;
            }

            RemovePersonAt(index);
            return true;
        }

        /// <summary>
        /// Возвращает человека по указанному индексу
        /// </summary>
        public Person GetPersonAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return _people[index];
        }

        /// <summary>
        /// Очищает список людей
        /// </summary>
        public void ClearPeople()
        {
            for (int i = 0; i < _count; i++)
            {
                _people[i] = null;
            }
            //Array.Clear(_people, 0, _count);

            _count = 0;
        }

        /// <summary>
        /// Возвращает информацию обо всех людях в списке
        /// </summary>
        public string GetListInfo()
        {
            string result = "Люди в списке:\n";

            for (int i = 0; i < _count; i++)
            {
                Person currentPerson = _people[i];

                result += $"- имя: {currentPerson.Name}\n" +
                          $"- фамилия: {currentPerson.Surname}\n" +
                          $"- лет: {currentPerson.Age}\n" +
                          $"- гендер: {currentPerson.Gender}\n" +
                          "\n";
            }

            return result;
        }

        /// <summary>
        /// Возвращает количество людей в списке
        /// </summary>
        public int Count
        {
            get
            {
                return _count;
            }
        }
    }
}
