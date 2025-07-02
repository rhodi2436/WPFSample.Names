using Microsoft.Extensions.DependencyInjection;
using Names.Services.NavigateService;
using System.Windows;

namespace Names.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RegisterRouteOutlet();
        }

        private void RegisterRouteOutlet()
        {
            var navigationService = App.ServiceProvider.GetRequiredService<INavigationService>();

            navigationService.RegisterOutlet(MainRegion);
            navigationService.RegisterOutlet(SubmainRegion);
        }
    }
}