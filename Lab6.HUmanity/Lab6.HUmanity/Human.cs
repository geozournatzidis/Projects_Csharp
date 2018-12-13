using System;
    using System.Collections.Generic; 
namespace Lab6.HUmanity
{
     public class Human
    {
        private const int firstNameMinLength = 4;
        private const int lastNameMinLength = 3;
        private string firstname, lastname;
        public string FirstName
        {
            get
            {
                return this.firstname;
            }

            set
            {
                if (value.Length < firstNameMinLength)
                {
                    throw new ArgumentException($"Expected length at least {firstNameMinLength}");
                }
                firstname = char.ToUpper(value[0]) + value.Substring(1);
            }
        }
        public string LastName
        {
            get
            {
                return this.lastname;
            }

            set
            {
                if (value.Length < lastNameMinLength)
                {
                    throw new ArgumentException($"Expected length at least {lastNameMinLength}");
                }
                lastname = char.ToUpper(value[0]) + value.Substring(1);
            }
        }

        public Human()
        {

        }

        public Human(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public virtual void Print()
        {
            Console.WriteLine($"First name: {FirstName}");
            Console.WriteLine($"Last name: {LastName}");
        }


    }
}
