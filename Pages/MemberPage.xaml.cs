using CommunityToolkit.Mvvm.DependencyInjection;
using FootballAdministration.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace FootballAdministration.Pages
{
    public sealed partial class MemberPage : Page
    {
        public MemberPage()
        {
            InitializeComponent();

            DataContext = Ioc.Default.GetRequiredService<MemberViewModel>();
        }

        public MemberViewModel ViewModel => (MemberViewModel)DataContext;

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ViewModel.OnViewLoaded();
        }
    }
}
