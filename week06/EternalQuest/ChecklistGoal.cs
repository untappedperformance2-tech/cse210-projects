public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _amountCompleted++;
            int earned = _points;
            if (IsComplete())
            {
                earned += _bonus;
                Console.WriteLine($"\n✓ Progress! You earned {_points} points plus a bonus of {_bonus}!");
                Console.WriteLine($"🎉 You completed the goal {_target} times! Total this time: {earned} points.");
            }
            else
            {
                Console.WriteLine($"\n✓ Progress! You earned {_points} points. ({_amountCompleted}/{_target})");
            }
            return earned;
        }
        else
        {
            Console.WriteLine($"\n⚠ This checklist goal is already complete.");
            return 0;
        }
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        string check = IsComplete() ? "[X]" : "[ ]";
        return $"{check} {_shortName} ({_description}) -- Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
    }
}