using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Learn C#", "Code Academy", 420);
        video1.AddComment(new Comment("James", "This was very helpful!"));
        video1.AddComment(new Comment("Sarah", "I learned a lot from this video."));
        video1.AddComment(new Comment("Michael", "Great explanation for beginners."));
        videos.Add(video1);

        Video video2 = new Video("Building Your First Computer", "Tech World", 615);
        video2.AddComment(new Comment("Daniel", "This made building a computer look easy."));
        video2.AddComment(new Comment("Grace", "Thanks for explaining each step."));
        video2.AddComment(new Comment("John", "Very useful video!"));
        videos.Add(video2);

        Video video3 = new Video("5 Tips for Better Photography", "Creative Studio", 350);
        video3.AddComment(new Comment("Emma", "I will try these tips."));
        video3.AddComment(new Comment("David", "The lighting tip was really useful."));
        video3.AddComment(new Comment("Sophia", "Great video. Thanks for sharing!"));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}