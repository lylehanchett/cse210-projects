namespace Mindfulness;

public class ListingActivity : Activity
{
    private readonly List<string> _prompts;
    private readonly List<string> _responses = new();
    private int _count;
    private readonly Random _rand = new();

    public ListingActivity()
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
            45
        )
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        _count = 0;
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine($"\nList as many responses as you can to the following prompt:");
        Console.WriteLine($">>> {prompt} <<<");

        Console.Write("\nYou may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            string? line = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(line))
            {
                AddResponse(line.Trim());
            }
        }

        Console.WriteLine($"\nYou listed {_count} item(s).");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt() => _prompts[_rand.Next(_prompts.Count)];

    private void AddResponse(string response)
    {
        _responses.Add(response);
        _count++;
    }

    public int GetResponseCount() => _count;
    public List<string> GetResponses() => new(_responses);
}
