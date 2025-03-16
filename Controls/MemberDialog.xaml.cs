using System;
using FootballAdministration.Models.Entities;
using Microsoft.UI.Xaml.Controls;

namespace FootballAdministration.Controls
{
    public sealed partial class MemberDialog : ContentDialog
    {
        public MemberDialog()
        {
            InitializeComponent();
        }

        #region Properties
        public Member Member
        {
            get;
            set;
        } = new Member();
        #endregion

        public bool Validate()
        {
            if (string.IsNullOrWhiteSpace(Member.FirstName) ||
                string.IsNullOrWhiteSpace(Member.LastName) ||
                Member.DateOfBirth == default ||
                string.IsNullOrWhiteSpace(Member.Email) ||
                string.IsNullOrWhiteSpace(Member.Password))
            {
                throw new InvalidOperationException("Please fill in all required fields.");
            }

            return true;
        }
    }
}

