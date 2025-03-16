using System;
using CommunityToolkit.Mvvm.DependencyInjection;
using FootballAdministration.Repositories;
using FootballAdministration.Services;
using FootballAdministration.Services.Base;
using FootballAdministration.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

namespace FootballAdministration
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Services = ConfigureServices();

            Ioc.Default.ConfigureServices(Services);
        }

        #region Properties
        public IServiceProvider Services { get; }

        public static Window Window
        {
            get;
            private set;
        }
        #endregion

        private static IServiceProvider ConfigureServices()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddScoped<DialogService>();

            services.AddScoped<MatchService>();
            services.AddScoped<MemberService>();
            services.AddScoped<TrainingService>();

            services.AddScoped<DbContext>();

            services.AddScoped<MatchRepository>();
            services.AddScoped<MemberRepository>();
            services.AddScoped<TrainingRepository>();

            services.AddTransient<MemberViewModel>();
            services.AddTransient<PlanningViewModel>();

            return services.BuildServiceProvider();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Window = new MainWindow();
            Window.Activate();
        }
    }
}
