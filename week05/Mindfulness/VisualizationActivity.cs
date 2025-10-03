namespace Mindfulness;

public class VisualizationActivity : Activity
{
    private readonly List<string> _visualPrompts;
    private readonly Random _rand = new();

    public VisualizationActivity()
        : base(
            "Visualization Activity",
            "This activity will help you find calm by guiding you through imagining peaceful and relaxing scenarios.",
            45
        )
    {
        _visualPrompts = new List<string>
        {
            "Imagine yourself sitting on a quiet beach, listening to the gentle waves.",
            "Visualize walking through a calm forest, hearing the rustle of leaves underfoot.",
            "Picture yourself on a mountain peak, breathing in the fresh, cool air.",
            "Imagine lying in a meadow, watching clouds drift slowly across the sky.",
            "Visualize sitting beside a peaceful river, watching the water flow by."
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = _visualPrompts[_rand.Next(_visualPrompts.Count)];
        Console.WriteLine($"\nVisualization Prompt:");
        Console.WriteLine($">>> {prompt} <<<");

        Console.Write("\nTake a few moments to immerse yourself in this scene...");
        Console.WriteLine("\nClose your eyes if you wish.");
        ShowCountdown(5);

        DateTime end = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < end)
        {
            Console.WriteLine("\nFocus on the details of the scene: sights, sounds, smells, and feelings.");
            ShowSpinner(7); 
        }

        DisplayEndingMessage();
    }
}
