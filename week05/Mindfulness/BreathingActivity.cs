using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        Console.WriteLine();
        
        while (DateTime.Now < endTime)
        {
            Animation.BreatheIn(4);
            
            if (DateTime.Now >= endTime) break;

            Console.WriteLine();
            
            Animation.BreatheOut(4);
            
            Console.WriteLine();
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}