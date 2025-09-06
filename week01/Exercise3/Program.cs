using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");

        //Console.WriteLine("What is the magic number? ");
        //string answer = Console.ReadLine();
        //int magicnumber = int.Parse(answer);

        Random randomGenerator = new Random();
        int magicnumber = randomGenerator.Next(1, 101);

        int guess = -1;

        while (guess != magicnumber)
        {
            Console.Write("what is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magicnumber > guess)
            {
                Console.WriteLine(" Higher ");
            }
            else if (magicnumber < guess)
            {
                Console.WriteLine(" Lower ");
            }
            else
            {
                Console.WriteLine("Awesome. you guessed it!");
            }
        }

    }

}