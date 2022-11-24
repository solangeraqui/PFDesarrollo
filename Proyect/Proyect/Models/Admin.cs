using System;
using System.Collections.Generic;

namespace Proyect.Models
{
    public partial class Admin
    {
        public int IdAdmin { get; set; }
        public string Nombre { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
