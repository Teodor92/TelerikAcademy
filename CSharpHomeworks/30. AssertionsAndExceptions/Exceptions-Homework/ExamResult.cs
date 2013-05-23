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
            throw new ArgumentOutOfRangeException("Grade must NOT be negative!");
        }

        if (minGrade < 0)
        {
            throw new ArgumentOutOfRangeException("minGrade must not be negative!");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("maxGrade should not be less the minGrade!");
        }

        if (comments == null || comments == string.Empty)
        {
            throw new ArgumentNullException("Comments are mandatory!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
