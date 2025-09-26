using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1: Hobby
        Video video1 = new Video("My Lego Tower", "Tommy", 120);
        video1.AddComment(new Comment("Jenny", "Cool tower!"));
        video1.AddComment(new Comment("Sam", "I want to build one too."));
        video1.AddComment(new Comment("Leo", "Nice job!"));
        videos.Add(video1);

        // Video 2: Pets
        Video video2 = new Video("Playing with my cat", "Emma", 90);
        video2.AddComment(new Comment("Max", "So cute!"));
        video2.AddComment(new Comment("Lucy", "I love cats."));
        video2.AddComment(new Comment("Anna", "Made me smile."));
        videos.Add(video2);

        // Video 3: Cooking
        Video video3 = new Video("Making scrambled eggs", "Ben", 150);
        video3.AddComment(new Comment("Mia", "Simple and easy!"));
        video3.AddComment(new Comment("Jack", "I tried it, yummy."));
        video3.AddComment(new Comment("Zoe", "Thanks for sharing."));
        videos.Add(video3);

        // Video 4: Fun
        Video video4 = new Video("Jumping into the pool", "Lily", 60);
        video4.AddComment(new Comment("Chris", "Haha so funny!"));
        video4.AddComment(new Comment("Ella", "I laughed a lot."));
        video4.AddComment(new Comment("Tom", "Cool jump."));
        videos.Add(video4);

        // Display all videos
        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}

