using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Names.Services.NavigateService;
using Names.Services.ThemeService;
using Names.ViewModels;
using Names.Views;
using System.Windows;

namespace Names
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;
        public static IServiceProvider ServiceProvider { get; private set; } = null!;

        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSingleton<IThemeService, ThemeService>();
                    services.AddSingleton<INavigationService, NavigationService>();

                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<HomeView>();
                    services.AddSingleton<OrderListView>();
                    services.AddSingleton<OrderDetailView>();
                    services.AddSingleton<HomeViewModel>();
                    services.AddSingleton<MainWindowViewModel>();
                    services.AddSingleton<OrderDetailViewModel>();
                    services.AddSingleton<OrderListViewModel>();
                })
                .Build();
            InitializeComponent();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            ServiceProvider = _host.Services;
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            var mainWindowViewModel = _host.Services.GetRequiredService<MainWindowViewModel>();
            //var homeView = _host.Services.GetRequiredService<HomeView>();
            //var homeViewModel = _host.Services.GetRequiredService<HomeViewModel>();
            //homeView.DataContext = homeViewModel;
            mainWindow.DataContext = mainWindowViewModel;

            mainWindow.Show();

            var navigationService = _host.Services.GetRequiredService<INavigationService>();
            navigationService.NavigateTo<HomeViewModel>("main");
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            if (_host != null)
            {
                await _host.StopAsync();
                _host.Dispose();
            }
            base.OnExit(e);
        }
    }
}
