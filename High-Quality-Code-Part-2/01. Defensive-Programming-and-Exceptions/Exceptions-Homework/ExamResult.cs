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
            throw new ArgumentOutOfRangeException("Grade can't be less than zero!");
        }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentException();
        }
        if (string.IsNullOrEmpty(comments))
        {
            throw new ArgumentNullException();
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
