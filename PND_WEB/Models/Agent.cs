using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class Agent
{
    [Key]
    public string Code { get; set; } = null!;

    public string? AgentName { get; set; }

    public string? AgentNamekd { get; set; }

    public string? AgentAdd { get; set; }

    public string? Note { get; set; }

    public virtual ICollection<AgentAction> AgentActions { get; set; } = new List<AgentAction>();

    public virtual ICollection<TblJob> TblJobs { get; set; } = new List<TblJob>();
}
