using System;

namespace FootballAdministration.Models.Views 
{
    public class TeamView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TrainerView Trainer { get; set; }
    }
}

