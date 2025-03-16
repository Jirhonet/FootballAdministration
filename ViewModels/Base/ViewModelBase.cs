using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using FootballAdministration.Services.Base;
using Microsoft.UI.Xaml.Controls;

namespace FootballAdministration.ViewModels.Base
{
    public partial class ViewModelBase : ObservableObject
    {
        private readonly DialogService dialogService;

        protected ViewModelBase(DialogService dialogService)
        {
            this.dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        }

        #region Properties
        public DialogService DialogService
            => dialogService;
        #endregion

        public virtual void OnViewLoaded()
        {
            //
        }

        protected Task<ContentDialogResult> ShowError(Exception ex)
        {
            return DialogService.ShowDialogAsync("Error", ex.Message, "OK");
        }
    }
}
