namespace Mindfulness;

public class ReflectionActivity : Activity
{
    private readonly List<string> _prompts;
    private readonly List<string> _questions;
    private readonly Random _rand = new();

    public ReflectionActivity()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
            60
        )
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine($"\nConsider the following prompt:");
        Console.WriteLine($">>> {prompt} <<<");
        Console.WriteLine("\nWhen you have a specific experience in mind, press Enter to continue...");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions...");
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < end)
        {
            string q = GetRandomQuestion();
            Console.WriteLine($"\n> {q}");
            ShowSpinner(6); 
        }

        DisplayEndingMessage();
    }

    private string GetRandomPrompt() => _prompts[_rand.Next(_prompts.Count)];
    private string GetRandomQuestion() => _questions[_rand.Next(_questions.Count)];
}
