using System;

using Exceptions_Homework.Exceptions;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0 || minGrade < 0 || maxGrade < 0)
        {
            throw new InvalidGradeException("Grades cannot be less than zero!");
        }

        if (maxGrade < minGrade)
        {
            throw new InvalidGradeException("The max grade cannot be less than the min grade!");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        private set
        {
            if (value < 0)
            {
                throw new InvalidGradeException("Grade cannot be less than zero!");
            }

            this.grade = value;
        }
    }


    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }

        private set
        {
            if (value < 0)
            {
                throw new InvalidGradeException("MinGrade cannot be less than zero!");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }

        private set
        {
            if (value < 0)
            {
                throw new InvalidGradeException("MaxGrade cannot be less than zero!");
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }

        private set
        {
            if (value == null || value == "")
            {
                throw new ArgumentNullException("Comments cannot be null or empty!");
            }

            this.comments = value;
        }
    }
}