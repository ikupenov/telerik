namespace XMLProcessing.Root
{
    using Contracts;
    using Ninject.Modules;
    using UI;

    public sealed class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<ConsoleLogger>();
            Bind<IReader>().To<ConsoleReader>();
            Bind<ICommandHandler>().To<CommandHandler>();
        }
    }
}