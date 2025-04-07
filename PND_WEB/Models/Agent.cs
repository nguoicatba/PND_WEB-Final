using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;

[Table("AGENT")]
public partial class Agent
{
    [Key]
    [Column("CODE")]
    [MaxLength(20)]
    public string Code { get; set; } = null!;

    [Column("Agent_name"),DisplayName("Agent Name")]
    [MaxLength(1000)]
    public string? AgentName { get; set; }

    [Column("Agent_namekd")]
    [MaxLength(1000)]
    public string? AgentNamekd { get; set; }

    [Column("Agent_add"),DisplayName("Agent address")]
    [MaxLength(255)]
    public string? AgentAdd { get; set; }

    [Column("Note")]
    public string? Note { get; set; }

    public virtual ICollection<AgentAction> AgentActions { get; set; } = new List<AgentAction>();

    public virtual ICollection<TblJob> TblJobs { get; set; } = new List<TblJob>();
}
