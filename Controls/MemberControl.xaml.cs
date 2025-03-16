using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using FootballAdministration.Models.Views;

namespace FootballAdministration.Controls
{
    public sealed partial class MemberControl : UserControl
    {
        public static readonly DependencyProperty MemberProperty =
            DependencyProperty.Register(nameof(Member), typeof(MemberView), typeof(MemberControl),
                new PropertyMetadata(null, OnMemberChanged));

        public MemberView Member
        {
            get => (MemberView)GetValue(MemberProperty);
            set => SetValue(MemberProperty, value);
        }

        public MemberControl()
        {
            InitializeComponent();
        }

        private static void OnMemberChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is MemberControl control)
            {
                control.UpdateMemberInfo();
            }
        }

        private void UpdateMemberInfo()
        {
            if (Member == null)
            {
                NameTextBlock.Text = string.Empty;
                EmailTextBlock.Text = string.Empty;
                DateOfBirthTextBlock.Text = string.Empty;
                TeamTextBlock.Text = string.Empty;
                return;
            }

            NameTextBlock.Text = Member.FullName;
            EmailTextBlock.Text = Member.Email;
            DateOfBirthTextBlock.Text = $"Born: {Member.DateOfBirth:d}";
            TeamTextBlock.Text = Member.Team?.Name ?? "No Team";
        }
    }
}