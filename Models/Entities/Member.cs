using System;
using FootballAdministration.Models.Interfaces;

namespace FootballAdministration.Models.Entities;

public class Member : IEntity
{
    /// <inheritdoc />
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int? TeamId { get; set; }
    public bool IsActive { get; set; }
}