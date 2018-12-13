using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.HUmanity
{
    public  class Worker : Human
    {
        private const double minWeeklySalary = 200;
        private const int minWorkHoursPerDay = 1;
        private const int maxWorkHoursPerDay = 12;
        private int workHoursPerDay;
        private double weeklysalary, hourlyRate;
        private double WeeklySalary
        {
            get
            {
                return weeklysalary;
            }

            set
            {
                if (value < minWeeklySalary)
                {
                    throw new ArgumentException("Below Minimum Salary");
                }
                weeklysalary = value;
            }
        }
        private int WorkHoursPerDay
        {
            get
            {
                return workHoursPerDay;
            }

            set
            {
                if (value < minWorkHoursPerDay || value > maxWorkHoursPerDay)
                {
                    throw new ArgumentException("Inalid Working Hours");
                }
                this.workHoursPerDay = value;
            }
        }
        

        public Worker()
        {

        }

        public Worker(string firstName, string lastName, int workHoursPerDay, double weeklySalary) 
            : base(firstName, lastName)
        {
            WorkHoursPerDay = workHoursPerDay;
            WeeklySalary = weeklySalary;
        }

        public double CalculateHourlyRate()
        {
            double hourlyRate = WeeklySalary / (WorkHoursPerDay * 5);

            return hourlyRate;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Weekly salary: {WeeklySalary = System.Math.Round(WeeklySalary, 2)}");
            Console.WriteLine($"Working hours per day: {WorkHoursPerDay}");
            Console.WriteLine($"Hourly rate is: {hourlyRate = System.Math.Round(hourlyRate, 2)}");
        }

        public void InputWorker()
        {
            Console.Write("Give first name: ");
            base.FirstName = Console.ReadLine();
            Console.Write("Give last name: ");
            base.LastName = Console.ReadLine();
            Console.Write("Give WeeklySalary >= 200: ");
            this.WeeklySalary = Convert.ToDouble(Console.ReadLine());
            Console.Write("Give WorkHoursPerDay 1-12: ");
            this.WorkHoursPerDay = Convert.ToInt32(Console.ReadLine());
            hourlyRate = CalculateHourlyRate();

        }

        //public void PrintWorker()
        //{

        //    Console.WriteLine("Worker's first name is: {0}", base.FirstName);
        //    Console.WriteLine("Worker's last name is: {0}", this.LastName);
        //    Console.WriteLine("Worker's weekly salary is: {0}", this.WeeklySalary);
        //    Console.WriteLine("Worker's work hour per day are: {0}", this.WorkHoursPerDay);
        //    Console.WriteLine("Worker's hourly rate is: {0}", CalculateHourlyRate());
        //}
    }
}

