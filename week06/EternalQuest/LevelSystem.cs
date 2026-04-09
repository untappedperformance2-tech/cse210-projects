public class LevelSystem
{
    private int _currentLevel;

    public LevelSystem()
    {
        _currentLevel = 1;
    }

    public void UpdateLevel(int totalPoints)
    {
        int newLevel = 1 + (totalPoints / 1000);
        if (newLevel > _currentLevel)
        {
            _currentLevel = newLevel;
            Console.WriteLine($"\n🌟 CONGRATULATIONS! You reached LEVEL {_currentLevel}! 🌟");
        }
    }

    public int GetCurrentLevel() => _currentLevel;

    public int GetPointsToNextLevel(int totalPoints)
    {
        int nextThreshold = (_currentLevel + 1) * 1000;
        return nextThreshold - totalPoints;
    }
}