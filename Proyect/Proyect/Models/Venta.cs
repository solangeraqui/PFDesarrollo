using System;
using System.Collections.Generic;

namespace Proyect.Models
{
    public partial class Venta
    {
        public int IdVenta { get; set; }
        public int Price { get; set; }
        public DateOnly? Date { get; set; }
    }
}
