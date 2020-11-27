using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiEntregas.Model
{
    public class Producto
    {
        public Int16 idProducto { get; set; }
        public string nombreProducto { get; set; }
        public string dimensiones { get; set; }
        public string unidadEmpaque { get; set; }
        public decimal precio { get; set; }
    }
}
