using System;
using System.Collections.Generic;

namespace Models.MomentoApp;

public partial class Publication
{
    public int IdPublication { get; set; }

    public int IdUser { get; set; }

    public int IdTarget { get; set; }

    public int IdVisib { get; set; }

    public bool Annulated { get; set; }
}
