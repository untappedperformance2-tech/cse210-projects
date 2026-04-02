using System;

public class Assignment
{
    private string _studentName;
    private string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Public getter for student name
    public string GetStudentName()
    {
        return _studentName;
    }

    // Public getter for topic
    public string GetTopic()
    {
        return _topic;
    }

    // Method to return summary
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}