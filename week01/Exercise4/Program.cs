using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");

        List<int> numbers = new List<int>();

        int usernumber = -1;

        while (usernumber != 0)
        {
            Console.Write("Enter a number to add to the list. (0 to quit): ");

            string inputnumber = Console.ReadLine();
            usernumber = int.Parse(inputnumber);

            if (usernumber != 0)
            {
                numbers.Add(usernumber);
            }
        }
            int sum = 0;

            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine($"the sum of the list is: {sum}");

            float average = ((float)sum) / numbers.Count;
            Console.WriteLine($"The average is: {average}");

            int max = numbers[0];

            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            Console.WriteLine($"The max is: {max}");

        }



    }
