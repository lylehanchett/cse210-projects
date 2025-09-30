namespace Homework;


public class Assignment
{
    private readonly string _studentName;
    private readonly string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = string.IsNullOrWhiteSpace(studentName)
            ? throw new ArgumentException("Student name is required.", nameof(studentName))
            : studentName;

        _topic = string.IsNullOrWhiteSpace(topic)
            ? throw new ArgumentException("Topic is required.", nameof(topic))
            : topic;
    }


    public string GetSummary() => $"{_studentName} - {_topic}";

    public string GetStudentName() => _studentName;

    public string GetTopic() => _topic;
}
