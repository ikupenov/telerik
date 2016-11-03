using System;
using System.Collections.Generic;

using Console.Data;

namespace Company.Utilities.DataGenerators.Contracts
{
    public interface IProjectGenerator
    {
        IEnumerable<Project> GetProjects(int count, DateTime minDate, DateTime maxDate);
    }
}