using System.Configuration;
using System.Windows;
using Griffin.Container;
using Griffin.Decoupled;
using Griffin.Logging;
using SportsRFIDTimer.BusinessLogic.DomainHandlers.Users;
using SportsRFIDTimer.Repository;
using SportsRFIDTimer.Domain;
using SportsRFIDTimer.ViewModels;

namespace SportsRFIDTimer
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            var logFile = ConfigurationManager.AppSettings["Application.Logging.FileName"];
            SimpleLogManager.Instance.AddFile(logFile ?? "logfile.log");
            SimpleLogManager.Instance.GetLogger(typeof (App)).Info("Registrering components");

            DomainManager.Container = ConfigureGriffinContainer();
            DomainManager.Container.DispatchEvents();
            DomainManager.Container.DispatchCommands();
            LogManager.Assign(new DomainLogManager());


            InitializeComponent();

        }

        private Container ConfigureGriffinContainer()
        {
            var registrar = new ContainerRegistrar();

            // Repositories
            registrar.RegisterConcrete<RaceMemoryRepository>(Lifetime.Singleton);
            registrar.RegisterConcrete<UserMemoryRepository>(Lifetime.Singleton);
            registrar.RegisterConcrete<ResultMemoryRepository>(Lifetime.Singleton);
            registrar.RegisterConcrete<ApplicationStateMemoryRepository>(Lifetime.Singleton);            
            
            registrar.RegisterComponents(Lifetime.Default, typeof(RfidTagRegistrationHandler).Assembly);
            registrar.RegisterComponents(Lifetime.Singleton, typeof(DebugUserControlViewModel).Assembly);
            
            return registrar.Build();
        }
    }
}
