using FootballAdministration.Controls.Base;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;

namespace FootballAdministration.Services.Base
{
    public class DialogService
    {
        private readonly MainWindow window;
        private Page page => window.Page;
        private XamlRoot xamlRoot => page.XamlRoot;
        
        public DialogService()
        {
            window = App.Window as MainWindow;
        }

        public async Task<ContentDialogResult> ShowDialogAsync(string title, string text, string primary)
        {
            ContentDialogContent content = new ContentDialogContent();
            content.SetText(text);
            ContentDialog dialog = new ContentDialog();
            dialog.Content = content;
            dialog.XamlRoot = xamlRoot;
            dialog.Title = title;
            dialog.PrimaryButtonText = primary;
            return await dialog.ShowAsync();
        }

        public async Task<ContentDialogResult> ShowDialogAsync(string title, string text, string primary, string secondary)
        {
            ContentDialogContent content = new ContentDialogContent();
            content.SetText(text);
            ContentDialog dialog = new ContentDialog();
            dialog.Content = content;
            dialog.XamlRoot = xamlRoot;
            dialog.Title = title;
            dialog.PrimaryButtonText = primary;
            dialog.SecondaryButtonText = secondary;
            return await dialog.ShowAsync();
        }
    }
}
