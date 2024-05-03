using System;
using System.Collections.Generic;

namespace Models.MomentoApp;

public partial class User
{
    public int IdUser { get; set; }

    public string Username { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string NameFull { get; set; } = null!;

    public string Cuil { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public bool MailVerification { get; set; }

    public int IdRole { get; set; }
    
    public DateTime BirthDate { get; set; }

    public string Description { get; set; } = null!;

    public bool Annulated { get; set; }
}
