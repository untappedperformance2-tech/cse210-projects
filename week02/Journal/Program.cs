using System;

// W02 Journal Project - Aaron Morris
// This program helps users journal by giving them daily prompts.
// It uses abstraction through the Entry, Journal, and PromptGenerator classes.

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("\nJournal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                Entry newEntry = new Entry();
                newEntry._date = DateTime.Now.ToShortDateString();
                newEntry._prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine($"\n{newEntry._prompt}");
                Console.Write("> ");
                newEntry._response = Console.ReadLine();

                myJournal.AddEntry(newEntry);
                Console.WriteLine("Entry added!");
            }
            else if (choice == "2")
            {
                Console.WriteLine("\n--- Journal Entries ---");
                myJournal.Display();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to save to: ");
                string filename = Console.ReadLine();
                myJournal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load from: ");
                string filename = Console.ReadLine();
                myJournal.LoadFromFile(filename);
            }
            else if (choice != "5")
            {
                Console.WriteLine("Invalid option, please try again.");
            }
        }

        Console.WriteLine("Goodbye!");
    }
}