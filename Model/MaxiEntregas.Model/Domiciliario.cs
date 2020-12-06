using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiEntregas.Model
{
    public class Domiciliario
    {
        public Int16 idDomiciliario { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string tipoDoc { get; set; }
        public int nroDoc { get; set; }
        public string direccion { get; set; }
        public Boolean estado { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
    }
}
