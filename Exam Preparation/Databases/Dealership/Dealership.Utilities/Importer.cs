using System;
using System.Linq;

using Dealership.Utilities.Contracts;

namespace Dealership.Utilities
{
    public class Importer
    {
        public static void ImportAll()
        {
            AppDomain.CurrentDomain.GetAssemblies()
                 .SelectMany(a => a.DefinedTypes)
                 .Where(t => t.ImplementedInterfaces
                                 .Contains(typeof(IImporter)) &&
                             !t.IsAbstract &&
                             !t.IsInterface)
                 .Select(t => (IImporter)Activator.CreateInstance(t))
                 .OrderBy(i => i.Order)
                 .ToList()
                 .ForEach(i => i.Import());
        }
    }
}