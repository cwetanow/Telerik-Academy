using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0)
        {
            throw new ArgumentOutOfRangeException($"Grade can\'t be less than zero!");
        }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException($"Minimal grade can\'t be less than zero!");
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("Max grade can't be less than min grade!");
        }
        if (string.IsNullOrEmpty(comments))
        {
            throw new ArgumentNullException($"Comments can\'t be null or empty!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
