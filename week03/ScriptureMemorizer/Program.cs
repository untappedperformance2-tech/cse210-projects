using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ScriptureMemorizer
{
    class Program
    {
        // Creative Enhancement: Load multiple scriptures from a file
        private static List<Scripture> _scriptureLibrary = new List<Scripture>();
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Scripture Memorizer!");
            Console.WriteLine("=".PadRight(50, '='));
            
            // Creative Enhancement: Load scriptures from file
            LoadScripturesFromFile();
            
            // If no scriptures loaded, use default scriptures
            if (_scriptureLibrary.Count == 0)
            {
                LoadDefaultScriptures();
            }
            
            bool keepPlaying = true;
            
            while (keepPlaying)
            {
                // Creative Enhancement: Random scripture selection
                Scripture currentScripture = GetRandomScripture();
                
                Console.Clear();
                Console.WriteLine("Scripture Memorization Practice");
                Console.WriteLine("=".PadRight(50, '='));
                Console.WriteLine();
                
                // Display the scripture
                Console.WriteLine(currentScripture.GetDisplayText());
                Console.WriteLine();
                
                // Creative Enhancement: Show progress meter
                ShowProgress(currentScripture);
                
                // Main game loop
                while (!currentScripture.IsCompletelyHidden())
                {
                    Console.WriteLine("\nPress Enter to hide more words, type 'quit' to exit, or type 'reset' to restart this scripture:");
                    string input = Console.ReadLine()?.ToLower().Trim();
                    
                    if (input == "quit")
                    {
                        Console.WriteLine("\nThank you for practicing! Goodbye!");
                        return;
                    }
                    else if (input == "reset")
                    {
                        // Creative Enhancement: Reset current scripture
                        currentScripture = ResetScripture(currentScripture);
                        Console.Clear();
                        Console.WriteLine("Scripture has been reset!");
                        Console.WriteLine();
                        Console.WriteLine(currentScripture.GetDisplayText());
                        Console.WriteLine();
                        ShowProgress(currentScripture);
                        continue;
                    }
                    else if (input == "new")
                    {
                        // Creative Enhancement: Choose a different scripture
                        break;
                    }
                    else if (string.IsNullOrEmpty(input) || input == "")
                    {
                        // Hide 3 random words (or adjust based on remaining words)
                        int wordsToHide = Math.Min(3, currentScripture.GetVisibleWordCount());
                        currentScripture.HideRandomWords(wordsToHide);
                        
                        Console.Clear();
                        Console.WriteLine(currentScripture.GetDisplayText());
                        Console.WriteLine();
                        ShowProgress(currentScripture);
                    }
                }
                
                // Check if the user completed the scripture
                if (currentScripture.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine("Congratulations! You've memorized this scripture!");
                    Console.WriteLine();
                    Console.WriteLine(currentScripture.GetDisplayText());
                    Console.WriteLine();
                    Console.WriteLine("All words are now hidden!");
                }
                
                // Creative Enhancement: Ask if they want to practice another scripture
                Console.WriteLine("\nWould you like to practice another scripture? (yes/no)");
                string response = Console.ReadLine()?.ToLower().Trim();
                if (response != "yes" && response != "y")
                {
                    keepPlaying = false;
                    Console.WriteLine("\nGreat job practicing! Keep up the good work!");
                }
            }
        }
        
        // Creative Enhancement: Load scriptures from a file
        static void LoadScripturesFromFile()
        {
            string filePath = "scriptures.txt";
            
            if (File.Exists(filePath))
            {
                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                        {
                            string[] parts = line.Split('|');
                            if (parts.Length >= 2)
                            {
                                string referenceText = parts[0].Trim();
                                string scriptureText = parts[1].Trim();
                                
                                Reference reference = ParseReference(referenceText);
                                if (reference != null)
                                {
                                    _scriptureLibrary.Add(new Scripture(reference, scriptureText));
                                }
                            }
                        }
                    }
                    
                    if (_scriptureLibrary.Count > 0)
                    {
                        Console.WriteLine($"Loaded {_scriptureLibrary.Count} scriptures from file.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading scriptures file: {ex.Message}");
                }
            }
        }
        
        // Creative Enhancement: Default scriptures if file doesn't exist
        static void LoadDefaultScriptures()
        {
            Console.WriteLine("Using default scriptures. Create a 'scriptures.txt' file to add your own!");
            Console.WriteLine();
            
            // Default scriptures
            Reference ref1 = new Reference("John", 3, 16);
            _scriptureLibrary.Add(new Scripture(ref1, "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life."));
            
            Reference ref2 = new Reference("Proverbs", 3, 5, 6);
            _scriptureLibrary.Add(new Scripture(ref2, "Trust in the Lord with all thine heart and lean not unto thine own understanding in all thy ways acknowledge him and he shall direct thy paths."));
            
            Reference ref3 = new Reference("Philippians", 4, 13);
            _scriptureLibrary.Add(new Scripture(ref3, "I can do all things through Christ which strengtheneth me."));
            
            Reference ref4 = new Reference("Psalm", 23, 1);
            _scriptureLibrary.Add(new Scripture(ref4, "The Lord is my shepherd I shall not want."));
        }
        
        // Creative Enhancement: Parse reference from string
        static Reference ParseReference(string referenceText)
        {
            try
            {
                // Handle formats like "John 3:16" or "Proverbs 3:5-6"
                string[] parts = referenceText.Split(' ');
                if (parts.Length >= 2)
                {
                    string book = parts[0];
                    string versePart = parts[1];
                    string[] verseParts = versePart.Split(':');
                    
                    if (verseParts.Length == 2)
                    {
                        int chapter = int.Parse(verseParts[0]);
                        string verseRange = verseParts[1];
                        
                        if (verseRange.Contains('-'))
                        {
                            string[] verses = verseRange.Split('-');
                            int startVerse = int.Parse(verses[0]);
                            int endVerse = int.Parse(verses[1]);
                            return new Reference(book, chapter, startVerse, endVerse);
                        }
                        else
                        {
                            int verse = int.Parse(verseRange);
                            return new Reference(book, chapter, verse);
                        }
                    }
                }
            }
            catch
            {
                // If parsing fails, return null
            }
            return null;
        }
        
        // Creative Enhancement: Random scripture selection
        static Scripture GetRandomScripture()
        {
            Random random = new Random();
            int index = random.Next(_scriptureLibrary.Count);
            return _scriptureLibrary[index];
        }
        
        // Creative Enhancement: Reset a scripture
        static Scripture ResetScripture(Scripture original)
        {
            // Create a new instance of the same scripture by parsing display text
            string displayText = original.GetDisplayText();
            string[] lines = displayText.Split('\n');
            if (lines.Length >= 2)
            {
                string referenceText = lines[0].Trim();
                string scriptureText = lines[1].Trim();
                
                Reference reference = ParseReference(referenceText);
                if (reference != null)
                {
                    return new Scripture(reference, scriptureText);
                }
            }
            return original;
        }
        
        // Creative Enhancement: Show progress meter
        static void ShowProgress(Scripture scripture)
        {
            int totalWords = GetTotalWordCount(scripture);
            int visibleWords = scripture.GetVisibleWordCount();
            int hiddenWords = totalWords - visibleWords;
            double percentage = (double)hiddenWords / totalWords * 100;
            
            // Create progress bar
            int barLength = 30;
            int filledLength = (int)(percentage / 100 * barLength);
            string progressBar = new string('█', filledLength) + new string('░', barLength - filledLength);
            
            Console.WriteLine($"Progress: [{progressBar}] {percentage:F1}% ({hiddenWords}/{totalWords} words hidden)");
            Console.WriteLine($"Words remaining to memorize: {visibleWords}");
        }
        
        // Helper to get total word count (this is a bit of a hack, but works for progress)
        static int GetTotalWordCount(Scripture scripture)
        {
            string displayText = scripture.GetDisplayText();
            string[] words = displayText.Split(new char[] { ' ', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            // Subtract the reference words (book, chapter, verse)
            return words.Length - 1; // Rough estimate
        }
    }
}