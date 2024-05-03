using System;
using System.Collections.Generic;

namespace Models.MomentoApp;

public partial class ProfilePicture
{
    public int IdPp { get; set; }

    public int IdProfile { get; set; }

    public string FileName { get; set; } = null!;

    public string FileFormat { get; set; } = null!;

    public byte[] FileCod { get; set; } = null!;
}
