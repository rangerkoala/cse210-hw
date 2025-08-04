using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("How to Cook Pasta", "Chef Luigi", 420);
        video1.AddComment(new Comment("Anna", "I tried this recipe, it's delicious!"));
        video1.AddComment(new Comment("Marco", "Easy to follow, thanks!"));
        video1.AddComment(new Comment("Lucia", "Can you make a gluten-free version?"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("10-Minute Home Workout", "FitWithMia", 600);
        video2.AddComment(new Comment("John", "I'm sweating already!"));
        video2.AddComment(new Comment("Sara", "Day 3 and still going strong."));
        video2.AddComment(new Comment("Alex", "Perfect for busy mornings."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Unboxing New Tech Gadgets", "TechGuru", 300);
        video3.AddComment(new Comment("Tim", "That phone looks amazing."));
        video3.AddComment(new Comment("Nina", "Can you review the camera in detail?"));
        video3.AddComment(new Comment("Leo", "I just bought one after watching this."));
        videos.Add(video3);

        // Display all videos and their comments
        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}