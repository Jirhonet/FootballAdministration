using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FootballAdministration.Models.Views;
using FootballAdministration.Services;
using FootballAdministration.Services.Base;
using FootballAdministration.ViewModels.Base;

namespace FootballAdministration.ViewModels
{
    public partial class MemberViewModel : ViewModelBase
    {
        private readonly MemberService service;

        private ObservableCollection<MemberView> _members;

        public MemberViewModel(DialogService dialogService = null, MemberService service = null)
            : base(dialogService)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        #region Properties
        public ObservableCollection<MemberView> Members
        {
            get => _members;
            set => SetProperty(ref _members, value);
        }
        #endregion

        public override async void OnViewLoaded()
        {
            base.OnViewLoaded();
            await LoadMembersAsync();
        }

        private async Task LoadMembersAsync()
        {
            try
            {
                var membersList = await service.GetMembersAsync();
                Members = new ObservableCollection<MemberView>(membersList);
            }
            catch (Exception ex)
            {
                await DialogService.ShowDialogAsync("Error Loading Members", ex.Message, "OK");
            }
        }
    }
}
