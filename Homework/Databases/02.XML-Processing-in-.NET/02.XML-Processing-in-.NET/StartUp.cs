namespace XMLProcessing
{
    using System.Reflection;

    using Contracts;
    using Ninject;
    using Root;

    internal class StartUp
    {
        private static void Main()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            var logger = kernel.Get<ILogger>();
            var reader = kernel.Get<IReader>();
            var commandHandler = kernel.Get<ICommandHandler>();

            var engine = Engine.GetInstance();
            engine.Run(commandHandler, logger, reader);
        }
    }
}
