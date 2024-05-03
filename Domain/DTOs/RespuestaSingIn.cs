using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class RespuestaSingIn
    {
        public string Token { get; set; }

        public int IdUser { get; set; }

        public string Username { get; set; } = null!;

        public string NameFull { get; set; } = null!;

        public string Cuil { get; set; } = null!;

        public string Mail { get; set; } = null!;

        public int IdRole { get; set; }

        public DateTime BirthDate { get; set; }

        public int Age { get; set; }

        public byte[] UserPhoto { get; set; } = null;

        public string FormatPhoto { get; set;} = null!;

    }
}
