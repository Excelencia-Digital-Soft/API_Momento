using System;
using System.Collections.Generic;

namespace Models.MomentoApp;

public partial class ProfilesAudit
{
    public int Id { get; set; }

    public int IdProfile { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ModifDate { get; set; }

    public DateTime AnnulDate { get; set; }

    public int AnnulUser { get; set; }
}
