using System;
using System.Collections.Generic;

namespace Models.MomentoApp;

public partial class PublicationPicture
{
    public int Id { get; set; }

    public int IdPublication { get; set; }

    public byte[] Picture { get; set; } = null!;
}
