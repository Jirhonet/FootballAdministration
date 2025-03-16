namespace FootballAdministration.Models.Interfaces;

public interface IEntity
{
    /// <summary>
    /// Id of the entity, as defined in the database
    /// </summary>
    public int Id { get; set; }
}