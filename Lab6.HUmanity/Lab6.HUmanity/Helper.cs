using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.HUmanity
{
    class Helper 
    {
        public static List<Worker> WorkersList = new List<Worker>();

        public static void ChooseType()
        {
            Console.Write("Choose your input: 1:Student 2:Worker 3:Exit \nInput: ");
            int choice;

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid entry, please try again..\n");
                ChooseType();
            }

            if (choice == 1)
            {
                Student student = new Student();
                student.InputStudent();
                Console.WriteLine();
                student.Print();
                Console.WriteLine();
                ChooseType();

            }

            if (choice == 2)
            {
                //int select;
                do
                {
                    Worker worker = new Worker();
                    worker.InputWorker();
                    WorkersList.Add(worker);
                    //Console.WriteLine("1: Add New Worker 2: Print Workers");


                    //Int32.TryParse(Console.ReadLine(), out select);
                    //if (select == 2)
                    //{
                    //    break;
                    //}
                    Console.WriteLine("Add more workers?: (Y/N)");
                } while (String.Equals(Console.ReadLine(), "y", StringComparison.CurrentCultureIgnoreCase));

                Console.WriteLine($"Number of workers: {WorkersList.Count()}");

                foreach (Worker w in WorkersList)
                {
                    
                    Console.WriteLine();
                    w.CalculateHourlyRate();
                    w.Print();

                }


            }

            if (choice == 3)
            {
                Environment.Exit(0);
            }

            else
            {
                Console.WriteLine("Invalid entry, please try again..\n");
                ChooseType();
            }

            ChooseType();

        }

    }
}
