using Microsoft.UI.Xaml.Controls;

namespace FootballAdministration.Controls.Base
{
    public sealed partial class ContentDialogContent : UserControl
    {
        public ContentDialogContent()
        {
            InitializeComponent();
        }

        public void SetText(string dialogText)
        {
            text.Text = dialogText;
        }
    }
}
