// Exceeding Requirements 
// I added a fourth activity: Visualization Activity.  This guides the user through calming imagery (beach, forest, mountains, etc.) to enhance mindfulness.



using Mindfulness;

class Program
{
    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness Program ===");
            Console.WriteLine("1) Breathing Activity");
            Console.WriteLine("2) Reflection Activity");
            Console.WriteLine("3) Listing Activity");
            Console.WriteLine("4) Visualization Activity");
            Console.WriteLine("5) Quit");
            Console.Write("\nChoose an option (1-5): ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run();
                    PauseToMenu();
                    break;

                case "2":
                    new ReflectionActivity().Run();
                    PauseToMenu();
                    break;

                case "3":
                    new ListingActivity().Run();
                    PauseToMenu();
                    break;

                case "4":
                    new VisualizationActivity().Run();
                    PauseToMenu();
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("\nGoodbye! Stay mindful.");
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Please choose 1–5.");
                    Thread.Sleep(1200);
                    break;
            }
        }
    }

    static void PauseToMenu()
    {
        Console.WriteLine("\nPress Enter to return to the main menu...");
        Console.ReadLine();
    }
}

