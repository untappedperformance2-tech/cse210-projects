using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _userItems;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _userItems = new List<string>();
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Animation.PulsingText($"--- {prompt} ---", 3);
        Console.WriteLine();

        Console.Write("You may begin in: ");
        Animation.Countdown(5);
        Console.WriteLine();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        Console.WriteLine("Start listing items (press Enter after each one):");
        Console.WriteLine();

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                _userItems.Add(item);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {_userItems.Count} items!");
        Animation.SpinnerWithCountdown(3);

        DisplayEndingMessage();
    }
}