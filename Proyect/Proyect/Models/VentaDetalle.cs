using System;
using System.Collections.Generic;

namespace Proyect.Models
{
    public partial class VentaDetalle
    {
        public int IdVentadetalle { get; set; }
        public int VentaId { get; set; }
        public int Cantidad { get; set; }
        public int? IdProducto { get; set; }
        public int PrecioVenta { get; set; }
    }
}
