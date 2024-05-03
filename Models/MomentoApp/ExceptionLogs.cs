using System;
using System.Collections.Generic;

namespace Models.MomentoApp;

public partial class ExceptionLogs
{
    public int IdException { get; set; }

    public int IdUser { get; set; }

    public DateTime CreationDate { get; set; }

    public string Controller { get; set; } = null!;

    public string Action { get; set; } = null!;

    public string Parameter { get; set; } = null!;

    public string ExceptionMsg { get; set; } = null!;

    public bool Result { get; set; }
}
