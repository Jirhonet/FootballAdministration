using System;

namespace FootballAdministration.Models.Interfaces;

public interface IPlanningItem
{
    public int FieldId { get; set; }
    
    public DateTimeOffset StartDateTime { get; set; }
    
    public DateTimeOffset EndDateTime { get; set; }
}