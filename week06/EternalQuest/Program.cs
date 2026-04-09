// ============================================================
// EXCEEDING REQUIREMENTS:
// ============================================================
// 1. LEVEL SYSTEM - Every 1000 points, the user levels up
//    with a celebration message. Shows points needed for next level.
//
// 2. NEGATIVE GOALS - Added a fourth goal type that SUBTRACTS
//    points when recorded (e.g., for breaking bad habits).
//
// 3. PROGRESSIVE MOTIVATION - The level system keeps users
//    engaged by showing how close they are to the next level.
// ============================================================


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("🌟 Welcome to Eternal Quest! 🌟\n");
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}