using System;

public class WritingAssignment : Assignment
{
    private string _title;

    // Constructor - calls base class constructor
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Method to return writing information
    public string GetWritingInformation()
    {
        // Get student name using the public getter from base class
        string studentName = GetStudentName();
        return $"{_title} by {studentName}";
    }
}