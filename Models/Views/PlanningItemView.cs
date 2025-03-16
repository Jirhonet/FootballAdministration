using FootballAdministration.Enums;
using System;

namespace FootballAdministration.Models.Views
{
    public class PlanningItemView
    {
        public string FieldName { get; set; }
        public string Title { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset StopDateTime { get; set; }
        public PlanningItemType Type { get; set; }
    }
}
