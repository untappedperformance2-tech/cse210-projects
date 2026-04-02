using System;
using System.Threading;

public class Animation
{
    // Spinner with countdown - shows spinner and seconds remaining
    public static void SpinnerWithCountdown(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        
        for (int i = seconds; i > 0; i--)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write($"\r{spinner[j]} {i} seconds remaining...");
                Thread.Sleep(250);
            }
        }
        Console.Write("\r" + new string(' ', 40) + "\r");
    }

    // Simple spinner - just spins without numbers
    public static void Spinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i++;
        }
    }

    // Countdown timer - shows numbers counting down
    public static void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // Breathing animation - shows expanding/shrinking text
    public static void BreatheIn(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string expanding = new string('>', seconds - i + 1);
            Console.Write($"\rBreathe in... {expanding} {i}");
            Thread.Sleep(1000);
        }
        Console.Write("\r" + new string(' ', 40) + "\r");
    }

    public static void BreatheOut(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            string shrinking = new string('<', i);
            Console.Write($"\rBreathe out... {shrinking} {i}");
            Thread.Sleep(1000);
        }
        Console.Write("\r" + new string(' ', 40) + "\r");
    }

    // Simple dots animation
    public static void Dots(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        while (DateTime.Now < endTime)
        {
            Console.Write(".");
            Thread.Sleep(500);
        }
        Console.WriteLine();
    }

    // Pulsing text animation
    public static void PulsingText(string text, int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        
        while (DateTime.Now < endTime)
        {
            // Pulse in
            for (int i = 1; i <= 3; i++)
            {
                Console.Write($"\r{text}");
                for (int j = 0; j < i; j++)
                {
                    Console.Write("!");
                }
                Console.Write(new string(' ', 10 - i));
                Thread.Sleep(150);
            }
            
            // Pulse out
            for (int i = 3; i >= 1; i--)
            {
                Console.Write($"\r{text}");
                for (int j = 0; j < i; j++)
                {
                    Console.Write("!");
                }
                Console.Write(new string(' ', 10 - i));
                Thread.Sleep(150);
            }
        }
        Console.Write("\r" + new string(' ', 50) + "\r");
    }
}