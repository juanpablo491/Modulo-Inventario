using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public Usuario oUsuario { get; set; }
        public Proveedor oProveedor { get; set; }
        public string Nombre { get; set; }
        public decimal StockActuall { get; set; }
        public int MontoToltal { get; set; }
        public string FechaCreacion { get; set; }
        public Categoria IdCategoria { get; set; }
        public List<Detalle_Compra> oDetalleCompra { get; set; }
    }
}
