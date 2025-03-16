using System;

namespace FootballAdministration.Models.Views 
{
    public class MemberView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public TeamView Team { get; set; }
        
        public string FullName
            => string.IsNullOrEmpty(MiddleName)
                ? $"{FirstName} {LastName}"
                : $"{FirstName} {MiddleName} {LastName}";
    }
}

