using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Homework Assignment Program ===\n");

        // Test the base Assignment class
        Console.WriteLine("Testing Base Assignment Class:");
        Assignment simpleAssignment = new Assignment("Samuel Bennett", "Multiplication");
        Console.WriteLine(simpleAssignment.GetSummary());
        Console.WriteLine();

        // Test the MathAssignment class
        Console.WriteLine("Testing Math Assignment Class:");
        MathAssignment mathAssignment = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());
        Console.WriteLine();

        // Test the WritingAssignment class
        Console.WriteLine("Testing Writing Assignment Class:");
        WritingAssignment writingAssignment = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
        Console.WriteLine();

        // Additional test cases
        Console.WriteLine("=== Additional Test Cases ===\n");

        MathAssignment math2 = new MathAssignment("Sarah Johnson", "Algebra", "4.2", "1-25 odd");
        Console.WriteLine(math2.GetSummary());
        Console.WriteLine(math2.GetHomeworkList());
        Console.WriteLine();

        WritingAssignment writing2 = new WritingAssignment("Thomas Edison", "Science", "The Light Bulb Invention");
        Console.WriteLine(writing2.GetSummary());
        Console.WriteLine(writing2.GetWritingInformation());
        Console.WriteLine();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}