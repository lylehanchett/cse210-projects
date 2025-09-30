namespace Homework;

public class WritingAssignment : Assignment
{
    private readonly string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = string.IsNullOrWhiteSpace(title)
            ? throw new ArgumentException("Title is required.", nameof(title))
            : title;
    }

    public string GetWritingInformation() => $"{_title} by {GetStudentName()}";
}
