using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;

[Table("CARRIER_ACTION")]
public partial class CarrierAction
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("CODE")]
    [MaxLength(20)]
    public string? Code { get; set; }

    [Column("Person_in_charge")]
    [MaxLength(255)]
    public string? PersonInCharge { get; set; }

    [Column("Phone_number")]
    [MaxLength(30)]
    public string? PhoneNumber { get; set; }

    [Column("Email")]
    [MaxLength(100)]
    public string? Email { get; set; }

    [Column("LCC_Fee")]
    [MaxLength(255)]
    public string? LccFee { get; set; }

    [Column("Note")]
    [MaxLength(1000)]
    public string? Note { get; set; }

    [ForeignKey("Code")]
    public virtual Carrier? CodeNavigation { get; set; }
}
