using System;
using System.Collections.Generic;

namespace Models.MomentoApp;

public partial class CommentSub
{
    public int IdSubComment { get; set; }

    public int IdComment { get; set; }

    public int IdUser { get; set; }

    public string Message { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public bool Annulated { get; set; }
}
