using System;
using System.Collections.Generic;

namespace Models.MomentoApp;

public partial class UserAudit
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public DateTime Creationdate { get; set; }

    public DateTime ModifDate { get; set; }

    public DateTime AnnulDate { get; set; }

    public int AnnulUser { get; set; }
}
