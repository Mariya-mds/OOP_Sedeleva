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
    }
}
