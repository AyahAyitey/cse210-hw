using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("10 C# Tips Every Developer Should Know", "CodeWithMosh", 743);
        video1.AddComment(new Comment("Alice Johnson", "This was incredibly helpful, thank you!"));
        video1.AddComment(new Comment("Bob Martinez", "I had no idea about tip #7. Mind blown!"));
        video1.AddComment(new Comment("Carol White", "Clear explanations, subscribed immediately."));

        Video video2 = new Video("Understanding Object-Oriented Programming", "TechWithTim", 512);
        video2.AddComment(new Comment("Emma Davis", "Finally a video that makes OOP click for me."));
        video2.AddComment(new Comment("Frank Wilson", "The abstraction example was spot on."));
        video2.AddComment(new Comment("Grace Kim", "Would love a follow-up on polymorphism!"));

        Video video3 = new Video("How YouTube's Algorithm Really Works", "VidIQ", 630);
        video3.AddComment(new Comment("Henry Brown", "This explains so much about my channel growth."));
        video3.AddComment(new Comment("Isabella Garcia", "Sharing this with every creator I know."));
        video3.AddComment(new Comment("James Taylor", "The engagement metric part was eye-opening."));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine($"Title:    {video.Title}");
            Console.WriteLine($"Author:   {video.Author}");
            Console.WriteLine($"Length:   {video.LengthInSeconds} seconds");
            Console.WriteLine($"Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("----------------------------------------------");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}
