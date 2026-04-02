// EXCEEDING REQUIREMENTS:
// 1. Added ActivityLog class to track how many times each activity is performed
// 2. Log saves to mindfulness_log.txt and loads on startup (persistent data)
// 3. Enhanced breathing animation with expanding/shrinking bars [>>>>    ]
//    that changes speed (slower on inhale, faster on exhale)





using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("========================================");
        Console.WriteLine("   Welcome to the Mindfulness Program!");
        Console.WriteLine("========================================\n");
        Animation.Dots(2);

        bool running = true;

        while (running)
        {
            Console.WriteLine("Please choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("\nEnter your choice (1-4): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    break;
                case "2":
                    ReflectingActivity reflecting = new ReflectingActivity();
                    reflecting.Run();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Thanks for using the Mindfulness Program!");
                    Console.WriteLine("Have a great day! :)");
                    Animation.Dots(2);
                    break;
                default:
                    Console.WriteLine("That's not a valid choice. Please enter 1, 2, 3, or 4.");
                    Animation.Dots(2);
                    break;
            }

            Console.WriteLine();
        }
    }
}