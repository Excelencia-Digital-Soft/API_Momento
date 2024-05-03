using System;
using System.Collections.Generic;

namespace Models.MomentoApp;

public partial class UserPicture
{
    public int IdUp { get; set; }

    public int IdUser { get; set; }

    public string FileName { get; set; } = null!;

    public string FileFormat { get; set; } = null!;

    public byte[] FileCod { get; set; } = null!;
}
