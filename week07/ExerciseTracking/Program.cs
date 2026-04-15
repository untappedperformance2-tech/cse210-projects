using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to hold all activities
            List<Activity> activities = new List<Activity>();

            // Create at least one activity of each type
            Running running = new Running(new DateTime(2022, 11, 3), 30, 3.0);
            StationaryBicycle bicycle = new StationaryBicycle(new DateTime(2022, 11, 4), 45, 15.0);
            Swimming swimming = new Swimming(new DateTime(2022, 11, 5), 60, 40);

            // Add all activities to the list
            activities.Add(running);
            activities.Add(bicycle);
            activities.Add(swimming);

            // Iterate through the list and display summaries
            Console.WriteLine("Exercise Tracking Program");
            Console.WriteLine("=========================\n");

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
                Console.WriteLine();
            }
        }
    }
}