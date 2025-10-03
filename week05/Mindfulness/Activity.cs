namespace Mindfulness;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "Activity";
        _description = "Default description.";
        _duration = 30;
    }

    public Activity(string name, string description, int duration = 30)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---\n");
        Console.WriteLine(_description);

        Console.Write("\nEnter the duration in seconds (e.g., 30): ");
        var input = Console.ReadLine();
        if (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            _duration = 30; 
            Console.WriteLine("Using default duration of 30 seconds.");
        }

        Console.WriteLine("\nPrepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(2);
        Console.WriteLine($"\nYou have completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        string[] frames = ["|", "/", "-", "\\"];
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < end)
        {
            Console.Write(frames[i % frames.Length]);
            Thread.Sleep(150);
            Console.Write("\b \b");
            i++;
        }
    }

    protected void ShowCountdown(int seconds)
    {
        for (int s = seconds; s > 0; s--)
        {
            Console.Write($"{s}");
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public int GetDuration() => _duration;
}
