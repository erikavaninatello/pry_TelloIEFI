using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pry_TelloIEFI
{
    public class clsTarea
    {
        public string Descripcion { get; set; }
        public string Lugar { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Comentario { get; set; }
        public bool Insumo { get; set; }
        public bool Estudio { get; set; }
        public bool Vacacion { get; set; }
        public bool Recibo { get; set; }
        public bool Salario { get; set; }

    }
}
