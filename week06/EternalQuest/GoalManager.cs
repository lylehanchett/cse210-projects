using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private readonly List<Goal> _goals = new();
    private int _score = 0;
    private int _level = 1;

    public void Start()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            DisplayPlayerInfo();
            Console.WriteLine("=== Eternal Quest ===");
            Console.WriteLine("1) Create New Goal");
            Console.WriteLine("2) List Goal Names");
            Console.WriteLine("3) List Goal Details");
            Console.WriteLine("4) Record Event");
            Console.WriteLine("5) Save Goals");
            Console.WriteLine("6) Load Goals");
            Console.WriteLine("7) Quit");
            Console.Write("\nChoose an option (1-7): ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); Pause(); break;
                case "2": ListGoalNames(); Pause(); break;
                case "3": ListGoalDetails(); Pause(); break;
                case "4": RecordEvent(); Pause(); break;
                case "5": SaveGoals(); Pause(); break;
                case "6": LoadGoals(); Pause(); break;
                case "7": running = false; break;
                default:
                    Console.WriteLine("Invalid option.");
                    Pause();
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        _level = 1 + (_score / 1000);
        int pointsToNext = (_level * 1000) - _score;

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"Score: {_score}");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n  🔹 LEVEL {_level} 🔹");
        Console.ResetColor();

        int currentLevelBase = (_level - 1) * 1000;
        int progress = _score - currentLevelBase;
        double percent = Math.Min(1.0, progress / 1000.0);

        int barWidth = 30;
        int filledBars = (int)(barWidth * percent);
        string filled = new string('█', filledBars);
        string empty = new string('>', barWidth - filledBars);
        string progressBar = "[" + filled + empty + "]";

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n  {progressBar}");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine($"  {pointsToNext} points to next level\n");
        Console.ResetColor();
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals created yet.");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals created yet.");
            return;
        }

        Console.WriteLine("\nGoal Details:");
        for (int i = 0; i < _goals.Count; i++)
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nSelect Goal Type:");
        Console.WriteLine("1) Simple Goal");
        Console.WriteLine("2) Eternal Goal");
        Console.WriteLine("3) Checklist Goal");
        Console.Write("Choice: ");
        string? type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Description: ");
        string description = Console.ReadLine() ?? "";

        Console.Write("Points for each completion: ");
        int points = ReadIntOrDefault(0);

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                Console.WriteLine("SimpleGoal created.");
                break;

            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                Console.WriteLine("EternalGoal created.");
                break;

            case "3":
                Console.Write("Target completions: ");
                int target = ReadIntOrDefault(1);
                Console.Write("Bonus points upon completion: ");
                int bonus = ReadIntOrDefault(0);
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                Console.WriteLine("ChecklistGoal created.");
                break;

            default:
                Console.WriteLine("Unknown goal type.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals to record yet.");
            return;
        }

        ListGoalNames();
        Console.Write("\nWhich goal did you accomplish? (number): ");
        int index = ReadIntOrDefault(-1) - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        var goal = _goals[index];
        int earned = goal.RecordEvent();

        int oldLevel = _level;
        _score += earned;
        int newLevel = 1 + (_score / 1000);

        Console.WriteLine($"\nEvent recorded! You earned {earned} points.");
        Console.WriteLine($"New score: {_score}");

        if (newLevel > oldLevel)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n🎉 LEVEL UP! You reached Level {newLevel}! 🎉");
            Console.ResetColor();
        }

        _level = newLevel;
    }

    public void SaveGoals()
    {
        Console.Write("\nEnter filename to save (e.g., goals.txt): ");
        string filename = Console.ReadLine() ?? "goals.txt";

        using var writer = new StreamWriter(filename);
        writer.WriteLine(_score);

        foreach (var g in _goals)
            writer.WriteLine(g.GetStringRepresentation());

        Console.WriteLine($"Saved {_goals.Count} goals to '{filename}'.");
    }

    public void LoadGoals()
    {
        Console.Write("\nEnter filename to load (e.g., goals.txt): ");
        string filename = Console.ReadLine() ?? "goals.txt";

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();

        if (lines.Length == 0)
        {
            Console.WriteLine("File empty.");
            _score = 0;
            return;
        }

        _score = int.TryParse(lines[0], out int s) ? s : 0;

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split(':', 2);
            if (parts.Length != 2) continue;

            string type = parts[0];
            string[] fields = parts[1].Split('|');

            switch (type)
            {
                case "SimpleGoal":
                    if (fields.Length >= 4)
                    {
                        var sg = new SimpleGoal(fields[0], fields[1], ParseInt(fields[2]));
                        if (bool.TryParse(fields[3], out bool done) && done) sg.ForceComplete();
                        _goals.Add(sg);
                    }
                    break;

                case "EternalGoal":
                    if (fields.Length >= 3)
                        _goals.Add(new EternalGoal(fields[0], fields[1], ParseInt(fields[2])));
                    break;

                case "ChecklistGoal":
                    if (fields.Length >= 6)
                    {
                        var cg = new ChecklistGoal(fields[0], fields[1], ParseInt(fields[2]),
                                                   ParseInt(fields[4]), ParseInt(fields[5]));
                        cg.ForceAmountCompleted(ParseInt(fields[3]));
                        _goals.Add(cg);
                    }
                    break;
            }
        }

        Console.WriteLine($"Loaded {_goals.Count} goals and score = {_score} from '{filename}'.");
    }

    private static int ReadIntOrDefault(int fallback)
    {
        string? raw = Console.ReadLine();
        return int.TryParse(raw, out int n) ? n : fallback;
    }

    private static int ParseInt(string s) => int.TryParse(s, out int n) ? n : 0;

    private static void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}
