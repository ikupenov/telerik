namespace StudentsAndWorkers.Exceptions
{
    using System;

    public class WorkHoursOutOfRangeException : ApplicationException
    {
        public WorkHoursOutOfRangeException (string msg) : base(msg) { }

        public WorkHoursOutOfRangeException (string msg, Exception innerException) : base(msg, innerException) { }
    }
}
