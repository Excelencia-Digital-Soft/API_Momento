using System;
using System.Collections.Generic;

namespace Models.MomentoApp;

public partial class Profile
{
    public int IdProfile { get; set; }

    public int IdUser { get; set; }

    public string Descript { get; set; } = null!;

    public bool Annulated { get; set; }
}
