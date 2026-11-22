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
        /// Name verification
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
                _name = value[0].ToString().ToUpper()+value.Substring(1).ToLower();
            }
        }
    }
}
