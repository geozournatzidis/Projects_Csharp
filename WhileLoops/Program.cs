using System;

namespace WhileLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many times you want to print?");
            int timesToPrint = int.Parse(Console.ReadLine());

            //while (timesToPrint > 0)
            //{
            //    Console.WriteLine("Printing Document...");
            //    timesToPrint = timesToPrint - 1;
            //}

            do
            {
                Console.WriteLine("Printing Document...");
                timesToPrint--; // timesToPrint = timesToPrint - 1;
            } while (timesToPrint > 0);

            Console.WriteLine("End Printing.");
        }
    }
}
