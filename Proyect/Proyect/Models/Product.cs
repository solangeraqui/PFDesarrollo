using System;
using System.Collections.Generic;

namespace Proyect.Models
{
    public partial class Product
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}
