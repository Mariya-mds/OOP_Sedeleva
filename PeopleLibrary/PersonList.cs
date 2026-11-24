namespace PeopleLibrary
{
    /// <summary>
    /// This class represents a list of people
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Stores the array of people
        /// </summary>
        private Person[] _people;

        /// <summary>
        /// Stores the actual number of people in the list
        /// </summary>
        private int _count;

        /// <summary>
        /// Initializes a new instance of the PersonList class
        /// </summary>
        public PersonList()
        {
            _people = new Person[3];
            _count = 0;
        }

        /// <summary>
        /// Increases the capacity of the array when necessary
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
        /// Adds a person to the list
        /// </summary>
        public void AddPerson(Person person)
        {
            ProvCapacity();

            _people[_count] = person;
            _count++;
        }

        /// <summary>
        /// Gets the index of a person if they are in the list
        /// </summary>
        public int GetPersonIndex(Person person)
        {
            for (int i = 0; i < _count; i++)
            {
                if (object.ReferenceEquals(_people[i], person))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Removes a person by index
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
        /// Removes a person from the list
        /// </summary>
        /// <returns>True if the person was removed, otherwise false</returns>
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
        /// Gets a person by index
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
        /// Clears the list of people
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
        /// Gets information about people in the list
        /// </summary>
        public string GetListInfo()
        {
            string result = "People:\n";

            for (int i = 0; i < _count; i++)
            {
                Person currentPerson = _people[i];

                result += $"- name: {currentPerson.Name}\n" +
                          $"- surname: {currentPerson.Surname}\n" +
                          $"- age: {currentPerson.Age}\n" +
                          $"- gender: {currentPerson.Gender}\n" +
                          "\n";
            }

            return result;
        }

        /// <summary>
        /// Gets the number of people in the list
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
