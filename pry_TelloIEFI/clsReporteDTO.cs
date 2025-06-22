using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pry_TelloIEFI
{
    public class clsReporteDTO
    {
        public string Usuario { get; set; }
        public string NombreCompleto { get; set; }
        public string HorarioInicio { get; set; }
        public string HorarioFin { get; set; }

        public DateTime? FechaIngreso { get; set; }
        public TimeSpan? HoraIngreso { get; set; }
        public TimeSpan? HoraSalida { get; set; }

        public DateTime? FechaTarea { get; set; }
        public string Tarea { get; set; }
        public string Lugar { get; set; }
        public string Comentario { get; set; }

        public bool Insumo { get; set; }
        public bool Estudio { get; set; }
        public bool Vacacion { get; set; }
        public bool Recibo { get; set; }
        public bool Salario { get; set; }
    }
}

