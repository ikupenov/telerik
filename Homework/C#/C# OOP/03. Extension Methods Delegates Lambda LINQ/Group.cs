namespace Homework
{
    public class Group
    {
        public Group(string groupNumber, string department)
        {
            this.GroupNumber = groupNumber;
            this.DepartmentName = department;
        }

        public string GroupNumber { get;  }

        public string DepartmentName { get; }
    }
}
