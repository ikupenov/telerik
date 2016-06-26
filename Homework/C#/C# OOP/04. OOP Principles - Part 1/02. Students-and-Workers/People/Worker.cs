namespace StudentsAndWorkers.People
{
    using Constants;
    using Exceptions;

    public class Worker : Human
    {
        private decimal weekSalary;
        private int workingHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, int workingHoursPerDay) : base(firstName, lastName)
        {
            this.weekSalary = weekSalary;
            this.workingHoursPerDay = workingHoursPerDay;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            private set
            {
                if (this.weekSalary < GlobalConstants.WorkerMinSalary || this.weekSalary > GlobalConstants.WorkerMaxSalary)
                {
                    throw new SalaryOutOfRangeException("Salary can't be lower than $1000 and more than $10.000");
                }

                WeekSalary = this.weekSalary;
            }
        }

        public int WorkingHoursPerDay
        {
            get
            {
                return this.workingHoursPerDay;
            }

            private set
            {
                if (this.workingHoursPerDay < GlobalConstants.MinWorkingHoursPerDay)
                {
                    throw new WorkHoursOutOfRangeException("Invalid Input");
                }
                else if (this.workingHoursPerDay > GlobalConstants.MaxWorkingHoursPerDay)
                {
                    throw new WorkHoursOutOfRangeException("Working Hours Can't Be More Than Eight");
                }

                WeekSalary = this.weekSalary;
            }
        }

        public decimal HourlyWage
        {
            get
            {
                return MoneyPerHour();
            }

            private set
            {
                HourlyWage = MoneyPerHour();
            }
        }

        public decimal MoneyPerHour()
        {
            decimal dailyEarnings = this.weekSalary / GlobalConstants.TotalDaysInWeek;

            decimal earnedPerHour = dailyEarnings / this.workingHoursPerDay;

            return earnedPerHour;
        }
    }
}
