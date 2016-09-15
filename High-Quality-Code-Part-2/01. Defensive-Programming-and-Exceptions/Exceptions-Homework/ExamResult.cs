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
            throw new ArgumentOutOfRangeException();
        }
        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (maxGrade <= minGrade)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (comments == null || comments == "")
        {
            throw new ArgumentOutOfRangeException();
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
