using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private LevelSystem _levelSystem;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _levelSystem = new LevelSystem();
    }

    public void Start()
    {
        int choice = 0;
        while (choice != 6)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoals(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
                case 6: Console.WriteLine("Goodbye!"); break;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    private void DisplayPlayerInfo()
    {
        _levelSystem.UpdateLevel(_score);
        Console.WriteLine($"\n📊 Score: {_score} points");
        Console.WriteLine($"🏆 Level: {_levelSystem.GetCurrentLevel()}");
        int pointsToNext = _levelSystem.GetPointsToNextLevel(_score);
        if (pointsToNext > 0)
            Console.WriteLine($"✨ {pointsToNext} points until next level!");
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal (Extra - lose points)");
        Console.Write("Which type? ");
        int type = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description? ");
        string desc = Console.ReadLine();
        Console.Write("How many points? ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case 3:
                Console.Write("How many times to complete? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points on completion? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            case 4:
                _goals.Add(new NegativeGoal(name, desc, points));
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
        Console.WriteLine("Goal created!");
    }

    private void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals yet. Create some!");
            return;
        }
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        ListGoals();
        if (_goals.Count == 0) return;
        Console.Write("Which goal did you accomplish? (number) ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < _goals.Count)
        {
            Goal goal = _goals[index];
            int pointsEarned = goal.RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"\nYour new score is {_score}.");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    private void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"Goals saved to {filename}");
    }

    private void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string type = parts[0];
                string[] data = parts[1].Split(',');
                switch (type)
                {
                    case "SimpleGoal":
                        SimpleGoal sg = new SimpleGoal(data[0], data[1], int.Parse(data[2]));
                        if (bool.Parse(data[3]))
                        {
                            sg.RecordEvent();
                        }
                        _goals.Add(sg);
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                        break;
                    case "ChecklistGoal":
                        ChecklistGoal cg = new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[4]), int.Parse(data[3]));
                        int completed = int.Parse(data[5]);
                        for (int j = 0; j < completed; j++) cg.RecordEvent();
                        _goals.Add(cg);
                        break;
                    case "NegativeGoal":
                        NegativeGoal ng = new NegativeGoal(data[0], data[1], int.Parse(data[2]));
                        int recorded = int.Parse(data[3]);
                        for (int j = 0; j < recorded; j++) ng.RecordEvent();
                        _goals.Add(ng);
                        break;
                }
            }
            Console.WriteLine("Goals loaded.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}