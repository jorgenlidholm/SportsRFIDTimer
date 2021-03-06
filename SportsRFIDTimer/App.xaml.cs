﻿using System;
using System.Configuration;
using System.Data.Entity;
using System.Windows;
using Griffin.Container;
using Griffin.Decoupled;
using Griffin.Logging;
using OneTrueError.Reporting;
using OneTrueError.Reporting.Submitters;
using SportsRFIDTimer.BusinessLogic.DomainHandlers.Users;
using SportsRFIDTimer.Domain.User;
using SportsRFIDTimer.Repository;
using SportsRFIDTimer.Domain;
using SportsRFIDTimer.Repository.Dto;
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
            // DbContext configs
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SportsRfidTimerContext>());

            ConfigureOneTrueError();
            var logFile = ConfigurationManager.AppSettings["Application.Logging.FileName"];
            SimpleLogManager.Instance.AddFile(logFile ?? "logfile.log");
            SimpleLogManager.Instance.GetLogger(typeof (App)).Info("Registrering components");

            DomainManager.Container = ConfigureGriffinContainer();
            DomainManager.Container.DispatchEvents();
            DomainManager.Container.DispatchCommands();
            LogManager.Assign(new DomainLogManager());


            InitializeComponent();

            var repo = new UserRepository();
            repo.Save(new User("Jörgen Lidholm", 11){Email = "jorgen.lidholm@gmail.com", Meta = "GasGas EC 300", TagId = "EnTag"});
            repo.Save(new User("Jonas Larsson", 34) { Email = "zyberspy@hotmail.com", Meta = "Husaberg FE 350", TagId = "EnAnnanTag" });
            var user = repo.Find("Jörgen");
            var user2 = repo.Find("EC");
            LogManager.GetLogger<App>().Info("User: " + user);
            LogManager.GetLogger<App>().Info("User: " + user);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
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

        private void ConfigureOneTrueError()
        {
            OneTrue.Configuration.AddSubmitter(
                new ReportToOneTrueError(
                    "7d7d00a8-5c1f-4bb2-88c3-1b987ca3613a",
                    "5bc3237a-6e50-46ab-a160-17c23035d646"
                    ));
            OneTrue.Configuration.AskUserForDetails = true;
            OneTrue.Configuration.AskUserForPermission = true;
            OneTrue.Configuration.CatchConsoleExceptions();
            //OneTrue.Configuration.CatchWinFormsExeptions();
            //OneTrueError.Reporting.WinForms.WinFormsErrorReporter.Activate();
        }

    }
}
