using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiEntregas.Model
{
    public class Proveedor
    {
        public Int16 idProveedor { get; set; }
        public string razonSocial { get; set; }
        public string nit { get; set; }
        public string nombreContacto { get; set; }
        public string tipoDocContacto { get; set; }
        public string nroDocContacto { get; set; }
        public string emailContacto { get; set; }
        public string direccion { get; set; }
        public string telefonoFijo { get; set; }
        public string celular { get; set; }
        public Boolean estado { get; set; }
    }
}
