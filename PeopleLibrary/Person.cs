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
    }
}
