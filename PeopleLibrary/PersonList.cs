namespace PeopleLibrary
{
    /// <summary>
    /// This class represents a list of people
    /// </summary>
    public class PersonList
    {
        /// <summary>
        /// Stores the list of people
        /// </summary>
        private List<Person> _people = new List<Person>();

        /// <summary>
        /// Adds a person to the list
        /// </summary>
        public void AddPerson(Person person)
        {
            _people.Add(person);
        }

        /// <summary>
        /// Removes a person from the list
        /// </summary>
        /// <returns>True if the person was removed; otherwise, false</returns>
        public bool RemovePerson(Person person)
        {
            return _people.Remove(person);
        }

        /// <summary>
        /// Removes a person by index
        /// </summary>
        public void RemovePersonAt(int index)
        {
            _people.RemoveAt(index);
        }

        /// <summary>
        /// Gets a person by index
        /// </summary>
        public Person GetPersonAt(int index)
        {
            return _people[index];
        }

        /// <summary>
        /// Gets the index of a person in the list
        /// </summary>
        public int GetPersonIndex(Person person)
        {
            return _people.IndexOf(person);
        }

        /// <summary>
        /// Clears the list of people
        /// </summary>
        public void ClearPeople()
        {
            _people.Clear();
        }

        /// <summary>
        /// Gets the number of people in the list
        /// </summary>
        public int Count
        {
            get
            {
                return _people.Count;
            }
        }
    }
}
