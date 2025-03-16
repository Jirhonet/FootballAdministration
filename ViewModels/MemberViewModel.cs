using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using FootballAdministration.Controls;
using FootballAdministration.Models.Entities;
using FootballAdministration.Models.Views;
using FootballAdministration.Services;
using FootballAdministration.Services.Base;
using FootballAdministration.ViewModels.Base;
using Microsoft.UI.Xaml.Controls;

namespace FootballAdministration.ViewModels
{
    public partial class MemberViewModel : ViewModelBase
    {
        private readonly MemberService service;

        private ObservableCollection<MemberView> _members;
        private MemberView _selectedMember;

        public MemberViewModel(DialogService dialogService = null, MemberService service = null)
            : base(dialogService)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));

            AddCommand = new AsyncRelayCommand(AddAsync);
            EditCommand = new AsyncRelayCommand(EditAsync);
            DeleteCommand = new AsyncRelayCommand(DeleteAsync);
        }

        #region Properties
        public ICommand AddCommand
        {
            get;
            private init;
        }

        public ICommand EditCommand
        {
            get;
            private init;
        }

        public ICommand DeleteCommand
        {
            get;
            private init;
        }

        public ObservableCollection<MemberView> Members
        {
            get => _members;
            set => SetProperty(ref _members, value);
        }

        public MemberView SelectedMember
        {
            get => _selectedMember;
            set => SetProperty(ref _selectedMember, value);
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
                await ShowError(ex);
            }
        }

        public async Task AddMemberAsync(Member member, CancellationToken ct = default)
        {
            await service.AddMemberAsync(member, ct);
        }

        public async Task UpdateMemberAsync(Member member, CancellationToken ct = default)
        {
            await service.UpdateMemberAsync(member, ct);
        }

        public async Task DeleteMemberAsync(int id, CancellationToken ct = default)
        {
            await service.DeleteMemberAsync(id, ct);
        }

        private async Task AddAsync(CancellationToken ct = default)
        {
            try
            {
                MemberDialog dialog = new MemberDialog();
                ContentDialogResult result = await DialogService.ShowDialogAsync(dialog);

                if (result == ContentDialogResult.Primary)
                {
                    dialog.Validate();
                    await AddMemberAsync(dialog.Member, ct);
                    await LoadMembersAsync();
                }
            }
            catch (Exception ex)
            {
                await ShowError(ex);
            }
        }

        private async Task EditAsync(CancellationToken ct = default)
        {
            try
            {
                Member member = await service.GetMemberAsync(SelectedMember.Id, ct);

                MemberDialog dialog = new MemberDialog();
                dialog.Member = member;
                ContentDialogResult result = await DialogService.ShowDialogAsync(dialog);

                if (result == ContentDialogResult.Primary)
                {
                    dialog.Validate();
                    await UpdateMemberAsync(dialog.Member, ct);
                    await LoadMembersAsync();
                }
            }
            catch (Exception ex)
            {
                await ShowError(ex);
            }
        }

        private async Task DeleteAsync(CancellationToken ct = default)
        {
            try
            {
                ContentDialogResult result = await DialogService.ShowDialogAsync("Delete", $"Are you sure you want to delete member '{SelectedMember.FullName}'?", "Yes", "No");

                if (result == ContentDialogResult.Primary)
                {
                    await DeleteMemberAsync(SelectedMember.Id, ct);
                    await LoadMembersAsync();
                }
            }
            catch (Exception ex)
            {
                await ShowError(ex);
            }
        }
    }
}
