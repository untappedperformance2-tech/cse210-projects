using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for grade percentage
        Console.Write("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());

        // Determine the letter grade
        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Stretch: Determine the sign (+ or -)
        string sign = "";
        int lastDigit = grade % 10;

        if (grade >= 60 && grade != 100) // No sign for F, and handle A+ exception later
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Special cases: No A+, no F+ or F-
        if (letter == "A" && sign == "+")
        {
            sign = ""; // A+ doesn't exist, just A
        }
        if (letter == "F")
        {
            sign = ""; // No + or - for F
        }

        // Print the final grade
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Determine if passed
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed the class!");
        }
        else
        {
            Console.WriteLine("Don't worry, keep working hard and you'll get it next time.");
        }
    }
}