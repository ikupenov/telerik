using Dealership.CommandHandlers;
using Dealership.CommandHandlers.Base;
using Dealership.Engine;
using Dealership.Factories;
using Dealership.IO;

using Ninject;
using Ninject.Modules;

namespace Dealership.Configurations
{
    public class DealershipModule : NinjectModule
    {
        private const string AddCommentHandlerName = "AddCommentHandler";
        private const string AddVehicleHandlerName = "AddVehicleHandler";
        private const string LogInUserHandlerName = "LogInUserHandler";
        private const string LogOutUserHandlerName = "LogOutUserHandler";
        private const string RegisterUserHandlerName = "RegisterUserHandler";
        private const string RemoveCommentHandlerName = "RemoveCommentHandler";
        private const string RemoveVehicleHandlerName = "RemoveVehicleHandler";
        private const string ShowUsersHandlerName = "ShowUsersHandler";
        private const string ShowVehiclesHandlerName = "ShowVehiclesHandler";

        public override void Load()
        {
            Bind<IEngine>().To<DealershipEngine>().InSingletonScope();
            Bind<IDataProvider>().To<DataProvider>().InSingletonScope();

            Bind<IReader>().To<ConsoleReader>().InSingletonScope();
            Bind<IWriter>().To<ConsoleWriter>().InSingletonScope();

            Bind<IDealershipFactory>().To<DealershipFactory>().InSingletonScope();

            Bind<ICommandManager>().To<CommandManager>().InSingletonScope();

            Bind<ICommandHandler>().To<AddCommentHandler>().Named(AddCommentHandlerName);
            Bind<ICommandHandler>().To<AddVehicleHandler>().Named(AddVehicleHandlerName);
            Bind<ICommandHandler>().To<LogInUserHandler>().Named(LogInUserHandlerName);
            Bind<ICommandHandler>().To<LogOutUserHandler>().Named(LogOutUserHandlerName);
            Bind<ICommandHandler>().To<RegisterUserHandler>().Named(RegisterUserHandlerName);
            Bind<ICommandHandler>().To<RemoveCommentHandler>().Named(RemoveCommentHandlerName);
            Bind<ICommandHandler>().To<RemoveVehicleHandler>().Named(RemoveVehicleHandlerName);
            Bind<ICommandHandler>().To<ShowUsersHandler>().Named(ShowUsersHandlerName);
            Bind<ICommandHandler>().To<ShowVehiclesHandler>().Named(ShowVehiclesHandlerName);

            Bind<ICommandHandler>()
                .ToMethod(x =>
                {
                    ICommandHandler addCommentHandler = Kernel.Get<ICommandHandler>(AddCommentHandlerName);
                    ICommandHandler addVehicleHandler = Kernel.Get<ICommandHandler>(AddVehicleHandlerName);
                    ICommandHandler logInUserHandler = Kernel.Get<ICommandHandler>(LogInUserHandlerName);
                    ICommandHandler logOutUserHandler = Kernel.Get<ICommandHandler>(LogOutUserHandlerName);
                    ICommandHandler registerUserHandler = Kernel.Get<ICommandHandler>(RegisterUserHandlerName);
                    ICommandHandler removeCommentHandler = Kernel.Get<ICommandHandler>(RemoveCommentHandlerName);
                    ICommandHandler removeVehicleHandler = Kernel.Get<ICommandHandler>(RemoveVehicleHandlerName);
                    ICommandHandler showUsersHandler = Kernel.Get<ICommandHandler>(ShowUsersHandlerName);
                    ICommandHandler showVehiclesHandler = Kernel.Get<ICommandHandler>(ShowVehiclesHandlerName);

                    addCommentHandler.SetCommandHandlerSuccessor(addVehicleHandler);
                    addVehicleHandler.SetCommandHandlerSuccessor(logInUserHandler);
                    logInUserHandler.SetCommandHandlerSuccessor(logOutUserHandler);
                    logOutUserHandler.SetCommandHandlerSuccessor(registerUserHandler);
                    registerUserHandler.SetCommandHandlerSuccessor(removeCommentHandler);
                    removeCommentHandler.SetCommandHandlerSuccessor(removeVehicleHandler);
                    removeVehicleHandler.SetCommandHandlerSuccessor(showUsersHandler);
                    showUsersHandler.SetCommandHandlerSuccessor(showVehiclesHandler);

                    return addCommentHandler;
                })
                .WhenInjectedInto<ICommandManager>();
        }
    }
}