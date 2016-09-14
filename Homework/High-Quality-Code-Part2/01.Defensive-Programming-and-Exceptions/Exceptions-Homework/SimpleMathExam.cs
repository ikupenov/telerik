using System;

public class SimpleMathExam : Exam
{
    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Problems solved cannot be less than 0!");
            }

            if (value > 10)
            {
                throw new ArgumentOutOfRangeException("Problems solved cannot be more than the total problems count!");
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        switch (ProblemsSolved)
        {
            case 0: return new ExamResult(2, 2, 6, "Bad result: nothing done.");
            case 1: return new ExamResult(4, 2, 6, "Average result: nothing done.");
            case 2: return new ExamResult(6, 2, 6, "Average result: nothing done.");

            case 3:
            case 4:
            case 5:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                throw new NotImplementedException();

            default: return new ExamResult(0, 0, 0, "Invalid number of problems solved!");
        }
    }
}