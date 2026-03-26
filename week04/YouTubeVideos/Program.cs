using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store all videos
            List<Video> videos = new List<Video>();

            // Create Video 1
            Video video1 = new Video("C# Programming Tutorial for Beginners", 
                                      "TechAcademy", 
                                      720); // 12 minutes (12 * 60 = 720 seconds)
            
            // Add comments to Video 1
            video1.AddComment(new Comment("Sarah Johnson", "Great tutorial! Very helpful for beginners."));
            video1.AddComment(new Comment("Mike Chen", "The explanation of classes was crystal clear."));
            video1.AddComment(new Comment("Emily Rodriguez", "Can you make a video about inheritance next?"));
            video1.AddComment(new Comment("David Kim", "Best C# tutorial I've found on YouTube!"));
            
            videos.Add(video1);

            // Create Video 2
            Video video2 = new Video("10 Tips for Better Productivity", 
                                      "ProductivityPro", 
                                      480); // 8 minutes (8 * 60 = 480 seconds)
            
            // Add comments to Video 2
            video2.AddComment(new Comment("Alex Thompson", "Tip #5 really changed my workflow. Thanks!"));
            video2.AddComment(new Comment("Jessica Lee", "Great content as always!"));
            video2.AddComment(new Comment("Chris Martin", "The pomodoro technique works wonders."));
            
            videos.Add(video2);

            // Create Video 3
            Video video3 = new Video("Understanding Abstraction in Object-Oriented Programming", 
                                      "CodeMaster", 
                                      900); // 15 minutes (15 * 60 = 900 seconds)
            
            // Add comments to Video 3
            video3.AddComment(new Comment("Rachel Green", "Finally I understand abstraction! Great explanation."));
            video3.AddComment(new Comment("Tom Wilson", "The real-world examples really helped."));
            video3.AddComment(new Comment("Nina Patel", "This should be required viewing for all CS students."));
            video3.AddComment(new Comment("Kevin Zhang", "Clear and concise. Subscribed!"));
            video3.AddComment(new Comment("Lisa Wong", "Can you make a video about polymorphism next?"));
            
            videos.Add(video3);

            // Create Video 4
            Video video4 = new Video("How to Make Perfect Pancakes | Cooking Tutorial", 
                                      "ChefMaster", 
                                      360); // 6 minutes (6 * 60 = 360 seconds)
            
            // Add comments to Video 4
            video4.AddComment(new Comment("FoodLover99", "Tried this recipe and they were amazing!"));
            video4.AddComment(new Comment("HealthyEater", "What can I substitute for buttermilk?"));
            video4.AddComment(new Comment("CookingFan", "The fluffiest pancakes ever!"));
            
            videos.Add(video4);

            // Display all videos and their comments
            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine("YOUTUBE VIDEO TRACKING SYSTEM");
            Console.WriteLine("=".PadRight(80, '='));
            Console.WriteLine();

            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.GetFormattedLength()} ({video.LengthInSeconds} seconds)");
                Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
                Console.WriteLine();
                Console.WriteLine("Comments:");
                Console.WriteLine("-".PadRight(60, '-'));

                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($"  {comment.CommenterName}: \"{comment.CommentText}\"");
                }

                Console.WriteLine();
                Console.WriteLine("=".PadRight(80, '='));
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}