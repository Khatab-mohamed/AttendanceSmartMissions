﻿namespace AMS.Domain.Entities;

public class Incident  : Base
{
    [Required]
    public string Title { get; set; }

    public string Description { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid LocationId { get; set; }
    public Location Location { get; set; }

    public Guid TypeId { get; set; }

    [ForeignKey("TypeId")] 
    public virtual IncidentType IncidentType { get; set; }

}