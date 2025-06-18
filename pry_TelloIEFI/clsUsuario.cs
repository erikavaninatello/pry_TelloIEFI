using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pry_TelloIEFI
{
    internal class clsUsuario
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public int IdRol { get; set; }
        public string NombreCompleto { get; set; }
        public string Tarea { get; set; }
        public DateTime Fecha { get; set; }
        public string HorarioInicio { get; set; }
        public string HorarioFin { get; set; }

        public string HoraIngreso { get; set; }
        public string HoraSalida { get; set; }
    }
}
