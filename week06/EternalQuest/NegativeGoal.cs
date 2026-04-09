public class NegativeGoal : Goal
{
    private int _timesRecorded;

    public NegativeGoal(string name, string description, int points) : base(name, description, points)
    {
        _timesRecorded = 0;
    }

    public override int RecordEvent()
    {
        _timesRecorded++;
        Console.WriteLine($"\n⚠ Oops! You recorded '{_shortName}'. You lose {_points} points!");
        return -_points;
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return $"[!] {_shortName} ({_description}) -- Recorded {_timesRecorded} times (lose {_points} pts each time)";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_shortName},{_description},{_points},{_timesRecorded}";
    }
}