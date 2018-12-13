using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Joker
{
//    1st Stage:
//Ask from user to enter 5 numbers from 1 - 45.
//Ask from user to enter 1 number from 1 - 20.
//Numbers MUST be Unique.

//Next there should be take place a Draw.
//Draw 5 Random Numbers from 1 - 45.
//Draw 1 Number from 1 - 20.
//Draw Numbers MUST be Unique.

//Result should be presented! 
//Result : Draw + Selected User Numbers

//This is not the JOKER Project...

    class JokerProject
    {
        static void Main(string[] args)
        {
            // define variables and Lists
            int num, joker, randJoker;
            Random rand = new Random();
            List<int> jokerList = new List<int>();
            List<int> drawList = new List<int>();

            // User 5 numbers inputand validation
            Console.WriteLine("Enter five different numbers from 1 to 45\n");

            //loop and validation
            for (int i = 0; i < 5; i++)
            {
                do
                {
                    Console.Write("Enter number " + (i + 1) + ": ");
                    if (!int.TryParse(Console.ReadLine(), out num))
                    {
                        Console.WriteLine("Invalid Entry, Try Again.");
                    }
                } while ((num < 1 || num > 45) || (jokerList.Contains(num)));
                jokerList.Add(num);
            }

            // Joker's input and validation
            do
            {
                Console.Write("Choose a special Number from 1 to 20: ");
                if (!int.TryParse(Console.ReadLine(), out joker))
                {
                    Console.WriteLine("Invalid entry, Try Again.");
                }

            } while (joker < 1 || joker > 20);  //((joker < 1 || joker > 20) || (jokerList.Contains(joker)));

            // Random results
            for (int i = 0; i < 5; i++)
            {
                do
                {
                    num = rand.Next(1, 45);
                } while ((num < 1 || num > 45) || (drawList.Contains(num)));
                drawList.Add(num);
            }

            do
            {
                randJoker = rand.Next(1, 20);
            } while (randJoker < 1 || randJoker > 20);  //((randJoker < 1 || randJoker > 20) || (drawList.Contains(randJoker)));

            // Printing results
            Console.Write("\nThe Numbers you chose are: ");

            foreach (int i in jokerList)
            {
                
                Console.Write(i +",");
            }            

            Console.WriteLine("\nThe special Number you chose is: {0}", joker);

            Console.Write("\nThe winning numbers are: ");

            foreach (int i in drawList)
            {

                Console.Write(i + ",");
            }

            Console.WriteLine("\nThe winning special Number is: {0}", randJoker);


        }
    }
}
