using System.Reflection;
using Dealership.Engine;

using Ninject;

namespace Dealership
{
    public class Startup
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            IEngine engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
