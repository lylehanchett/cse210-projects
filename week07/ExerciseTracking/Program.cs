using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Fitness Tracker App ===");
        Console.WriteLine("Tracking your running, cycling, and swimming progress!\n");

        List<Activity> activities = new List<Activity>();

        activities.Add(new Running("Nov 3, 2022", 30, 3.0));
        activities.Add(new Cycling("Nov 3, 2022", 30, 12.0));
        activities.Add(new Swimming("Nov 3, 2022", 30, 20));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine("\nProgram finished. Press any key to close.");
        Console.ReadKey();
    }
}
