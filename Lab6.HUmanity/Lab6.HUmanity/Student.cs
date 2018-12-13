using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.HUmanity
{
    public class Student : Human
    {
        private string FacultyNumber
        {
            get
            {
                return facultyNumber;
            }
            set
            {
                if (value.Length < MinFacultyNumber || value.Length > MaxFacultyNumber ||
                    !value.All(char.IsLetterOrDigit))
                {
                    throw new ArgumentException("Invalid Faculty Number!");
                }
                this.facultyNumber = value;
            }
        }
        private string facultyNumber;
        const int MinFacultyNumber = 5;
        const int MaxFacultyNumber = 10;

        public Student()
        {

        }

        public Student(string firstName, string lastName, string facultyNumber)
            : base(firstName, lastName)
        {
            FacultyNumber = facultyNumber;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"FacultyNumber is: {FacultyNumber}");
        }

        public void InputStudent()
        {
            Console.Write("Give first name: ");
            base.FirstName = Console.ReadLine();
            Console.Write("Give last name: ");
            base.LastName = Console.ReadLine();
            Console.Write("Give faculty number 5 to 10 chars: ");
            this.FacultyNumber = Console.ReadLine();

        }
    }
}
