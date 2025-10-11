// EXCEEDING REQUIREMENTS: I have added a level - up system(every 1000 points = +1 level) with a visual XP progress bar using █ and > symbols and a message of how many points are still
// needed to progress to the next level.  I also added color - coded interface and "LEVEL UP!" message. this helps to gamify the progression system.


using System;

class Program
{
    static void Main()
    {
        var manager = new GoalManager();
        manager.Start();
    }
}

