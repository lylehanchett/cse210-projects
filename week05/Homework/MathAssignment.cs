namespace Homework;

public class MathAssignment : Assignment
{
    private readonly string _textbookSection;
    private readonly string _problems;

    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        _textbookSection = string.IsNullOrWhiteSpace(textbookSection)
            ? throw new ArgumentException("Textbook section is required.", nameof(textbookSection))
            : textbookSection;

        _problems = string.IsNullOrWhiteSpace(problems)
            ? throw new ArgumentException("Problems are required.", nameof(problems))
            : problems;
    }

    public string GetHomeworkList() => $"Section {_textbookSection} Problems {_problems}";
}
