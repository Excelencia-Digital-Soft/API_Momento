using System;
using System.Collections.Generic;

namespace Models.MomentoApp;

public partial class PublicationText
{
    public int Id { get; set; }

    public int IdPublication { get; set; }

    public string Text { get; set; } = null!;
}
