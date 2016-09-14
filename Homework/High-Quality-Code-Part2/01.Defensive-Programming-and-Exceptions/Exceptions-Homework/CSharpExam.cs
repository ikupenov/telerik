using Exceptions_Homework.Exceptions;

public class CSharpExam : Exam
{
    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < 0)
            {
                throw new InvalidScoreException("Score cannot be a negative integer!");
            }

            if (value > 100)
            {
                throw new InvalidScoreException("Score cannot be greater than 100!");
            }

            this.score = value;
        }
    }


    public override ExamResult Check()
    {
        var examResult = new ExamResult(this.Score, 0, 100, "Exam results calculated by score");

        return examResult;
    }
}