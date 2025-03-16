using CommunityToolkit.Mvvm.DependencyInjection;
using FootballAdministration.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace FootballAdministration.Pages
{
    public sealed partial class PlanningPage : Page
    {
        public PlanningPage()
        {
            InitializeComponent();

            DataContext = Ioc.Default.GetRequiredService<PlanningViewModel>();
        }

        public PlanningViewModel ViewModel => (PlanningViewModel)DataContext;

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ViewModel.OnViewLoaded();
        }
    }
}
