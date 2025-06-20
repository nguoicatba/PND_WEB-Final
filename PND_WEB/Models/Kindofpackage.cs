﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;
[Table("KINDOFPACKAGES")]
public partial class Kindofpackage
{
    [Key]
    [Column("CODE", TypeName = "nvarchar")]
    [Required(ErrorMessage = "Mã không được để trống")]
    [MaxLength(20,ErrorMessage ="Độ dài không được quá 20")]
    public string Code { get; set; } = null!;

    [Column("Package_name")]
    [MaxLength(255)]
    [DisplayName("Package Name")]
    public string? PackageName { get; set; }

    [Column("Packages_description")]
    [MaxLength(255)]
    [DisplayName("Packages Description")]
    public string? PackagesDescription { get; set; }
}
