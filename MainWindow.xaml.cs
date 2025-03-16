using System.Collections.ObjectModel;
using FootballAdministration.Models.Sidebar;
using FootballAdministration.Pages;
using FootballAdministration.Utils.Sidebar;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace FootballAdministration
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeSidebar();

            framePage.Navigate(typeof(MainPage), framePage);
        }

        #region Properties
        public ObservableCollection<SidebarCategory> Sidebar
        {
            get;
            private set;
        }

        public Page Page
            => framePage.Content as Page;
        #endregion

        private void InitializeSidebar()
        {
            Sidebar = SidebarBuilder.CreateSidebar()
                .AddItem("Administration", "\uE713", i =>
                {
                    i.AddItem("Teams", "\uE902", typeof(MainPage));
                    i.AddItem("Trainers", "\uECA7", typeof(MainPage));
                    i.AddItem("Fields", "\uE707", typeof(MainPage));
                    i.AddItem("Opponents", "\uE8F8", typeof(MainPage));
                })
                .AddItem("Members", "\uE77B", i =>
                {
                    i.AddItem("Members", "\uE77B", typeof(MemberPage));
                    i.AddItem("Teams", "\uE902", typeof(MainPage));
                    i.AddItem("Payments", "\uEC0B", typeof(MainPage));
                })
                .AddItem("Planning", "\uE787", typeof(PlanningPage))
                .Build();

        }

        private void OnSelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs e)
        {
            if (e.SelectedItem is not SidebarCategory item || item.Page == null)
                return;

            framePage.Navigate(item.Page);
        }
    }
}
