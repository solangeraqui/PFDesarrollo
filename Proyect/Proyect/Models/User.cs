using System;
using System.Collections.Generic;

namespace Proyect.Models
{
    public partial class User
    {
        public uint Id { get; set; }
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
