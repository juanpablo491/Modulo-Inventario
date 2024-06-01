using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public int PrecioCompra { get; set; }
        public int PrecioVenta { get; set; }
        public bool Estado { get; set; }
        public List<Detalle_Venta> OdetalleVenta { get; set; }
        public string FechaCreacion { get; set; }
    }
}
