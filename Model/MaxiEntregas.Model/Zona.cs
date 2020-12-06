using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxiEntregas.Model
{
    public class Zona
    {
        public Int16 idZona { get; set; }
        public string nombreZona { get; set; }
        public string municipio { get; set; }
        public Boolean estado { get; set; }
        public decimal valorCobro { get; set; }
        
    }
}
