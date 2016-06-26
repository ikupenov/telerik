namespace SchoolClasses.School
{
    using Enumerations;
    using Contracts;

    public class Discipline : IComment
    {
        private DisciplineType discipline;
        private int numberOfLectures;
        private int numberOfExercises;

        public Discipline(DisciplineType discipline, int numberOfLectures, int numberOfExercises)
        {
            this.discipline = discipline;
            this.numberOfLectures = numberOfLectures;
            this.numberOfExercises = numberOfExercises;
        }

        public string GetInfo
        {
            get
            {
                return string.Format("{0} - Lectures: {1}, Exercises: {2}",
                    this.discipline, this.numberOfLectures, this.numberOfExercises);
            }
        }

        public string Comment { get; set; }
    }
}