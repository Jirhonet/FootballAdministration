using System;
using FootballAdministration.Models.Interfaces;

namespace FootballAdministration.Models.Entities;

public class Training : IEntity, IPlanningItem
{
    /// <inheritdoc />
    public int Id { get; set; }
    
    public int TeamId { get; set; }
    
    public int FieldId { get; set; }
    
    public DateTimeOffset StartDateTime { get; set; }
    
    public DateTimeOffset EndDateTime { get; set; }
}