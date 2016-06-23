namespace StudentsAndWorkers.Exceptions
{
    using System;

    public class SalaryOutOfRangeException : ApplicationException
    {
        public SalaryOutOfRangeException(string msg) : base(msg) { }

        public SalaryOutOfRangeException(string msg, Exception innerException) : base(msg, innerException) { }
    }
}
