using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Diagnostics;
using Avalonia.Logging.Serilog;
using Avalonia.Themes.Default;
using Avalonia.Markup.Xaml;
using Serilog;
using AvaloniaRxDemo.ViewModels;
using AvaloniaRxDemo.Services;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Autofac.Extensions.DependencyInjection;

namespace AvaloniaRxDemo
{
    class App : Application
    {

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
            base.Initialize();
        }

        static void Main(string[] args)
        {
            InitializeLogging();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();


            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);

            // Services.
            containerBuilder.RegisterType<TodoItemsService>()
                .AsImplementedInterfaces()
                .SingleInstance();
            containerBuilder.RegisterType<UsersService>()
                .AsImplementedInterfaces()
                .SingleInstance();

            // View models.
            containerBuilder.RegisterType<MainWindowVm>();
            containerBuilder.RegisterType<TodoItemsListVm>();
            containerBuilder.RegisterType<CreateTodoItemVm>();
            containerBuilder.RegisterType<TodoItemsDetailsVm>();
            containerBuilder.RegisterType<StaticVm>();

            var container = containerBuilder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            ServiceLocator.Init(serviceProvider);

            AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .Start<MainWindow>(() => serviceProvider.GetService<MainWindowVm>());
        }

        public static void AttachDevTools(Window window)
        {
#if DEBUG
            DevTools.Attach(window);
#endif
        }

        private static void InitializeLogging()
        {
#if DEBUG
            SerilogLogger.Initialize(new LoggerConfiguration()
                .MinimumLevel.Warning()
                .WriteTo.Trace(outputTemplate: "{Area}: {Message}")
                .CreateLogger());
#endif
        }
    }
}
