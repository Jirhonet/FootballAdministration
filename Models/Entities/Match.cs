using System;
using FootballAdministration.Models.Interfaces;

namespace FootballAdministration.Models.Entities;

public class Match : IEntity, IPlanningItem
{
    /// <inheritdoc />
    public int Id { get; set; }
    
    public int TeamId { get; set; }
    
    public int OpponentId { get; set; }
    
    public int FieldId { get; set; }
    
    public DateTimeOffset StartDateTime { get; set; }
    
    public DateTimeOffset EndDateTime { get; set; }

    public int? ScoreTeam { get; set; }
    
    public int ScoreOpponent { get; set; }
}