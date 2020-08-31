using Autofac;
using NonreciprocalFollowings.NonreciprocalFollowingsIdentifiers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NonreciprocalFollowings
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var builder = new ContainerBuilder();

            builder
                .RegisterType<NonreciprocalFollowingsIdentifier>()
                .As<INonreciprocalFollowingsIdentifier>()
                .SingleInstance();

            builder
                .RegisterType<MainViewModel>()
                .AsSelf()
                .SingleInstance();

            builder
                .RegisterType<MainWindow>()
                .AsSelf();

            this.container = builder.Build();

            this.container
                .Resolve<MainWindow>()
                .Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            this.container.Dispose();
        }
    }
}
