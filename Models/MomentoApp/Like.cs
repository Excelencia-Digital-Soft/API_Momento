using System;
using System.Collections.Generic;

namespace Models.MomentoApp;

public partial class Like
{
    public int Id { get; set; }

    public int IdPublication { get; set; }

    public int IdUser { get; set; }
}
