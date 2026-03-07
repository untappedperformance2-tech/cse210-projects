using System;
using System.Collections.Generic;  // Required for List
using System.Linq;                 // Required for some stretch features (Min, OrderBy)

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int userNumber;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Collect numbers until the user enters 0
        do
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }

        } while (userNumber != 0);

        // Core Requirement 1: Compute sum
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Core Requirement 2: Compute average
        // Use double for more precision
        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Core Requirement 3: Find largest number
        int largest = numbers[0];
        foreach (int num in numbers)
        {
            if (num > largest)
            {
                largest = num;
            }
        }
        Console.WriteLine($"The largest number is: {largest}");

        // ----- Stretch Challenges -----

        // Stretch 1: Smallest positive number (closest to zero)
        int? smallestPositive = null;  // nullable int
        foreach (int num in numbers)
        {
            if (num > 0)
            {
                if (smallestPositive == null || num < smallestPositive)
                {
                    smallestPositive = num;
                }
            }
        }
        if (smallestPositive.HasValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        // Stretch 2: Sort the list and display
        numbers.Sort();  // This sorts the list in place
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}