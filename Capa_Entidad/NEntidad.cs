using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class NEntidad
    {
        private string nombre;
        private string apellido;
        private string telefono;
        private string cedula;
        private string fecha;
        private int id;
        private decimal monto;
        private string interes;
        private string tiempo;
        private string deudad;
        private decimal cuota;
        private DateTime fecha_inicio;
        private DateTime fecha_final;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public int Id { get => id; set => id = value; }
        public string Interes { get => interes; set => interes = value; }
        public string Tiempo { get => tiempo; set => tiempo = value; }
        public string Deudad { get => deudad; set => deudad = value; }
        public decimal Cuota { get => cuota; set => cuota = value; }
        public decimal Monto { get => monto; set => monto = value; }
        public DateTime Fecha_inicio { get => fecha_inicio; set => fecha_inicio = value; }
        public DateTime Fecha_final { get => fecha_final; set => fecha_final = value; }
    }
}
