using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Detalle_Compra
    {
        public int IdDetalleCompra { get; set; }
        public Producto oProducto { get; set; }
        public int PrecioCompra { get; set; }
        public int PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public int MontoTotal { get; set; }
        public string FechaCreacion { get; set; }

    }
}
