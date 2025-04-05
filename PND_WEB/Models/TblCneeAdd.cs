using System;
using System.Collections.Generic;

namespace PND_WEB.Models;

public partial class TblCneeAdd
{
    public int Id { get; set; }

    public string? Adds { get; set; }

    public string? Place { get; set; }

    public string? PersonInCharge { get; set; }

    public string? Cnee { get; set; }

    public virtual TblCnee? CneeNavigation { get; set; }
}
