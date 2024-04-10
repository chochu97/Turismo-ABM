using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Entrada
    {
        public int id_entrada { get; set; }
        public int id_tipoturismo { get; set; }
        public int dni { get; set; }
        public double monto { get; set; }
        public DateTime fecha_registro { get; set; }
        public DateTime fecha_validez { get; set; }



    }
}
