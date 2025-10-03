namespace Mindfulness;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.",
            30
        )
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int total = GetDuration();
        DateTime end = DateTime.Now.AddSeconds(total);

        while (DateTime.Now < end)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);

            if (DateTime.Now >= end) break;

            Console.Write("\nBreathe out... ");
            ShowCountdown(6);

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
