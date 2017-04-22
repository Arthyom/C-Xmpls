
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChecadorMaestria
{
    public class Asistencia
    {
        public string Asistencia_FechaEntrada;
        public string Asistencia_FechaSalida;

        public string Asistencia_HoraEntrada;
        public string Asistencia_HoraSalida;

        public Boolean Asistencia_Entrada;
        public Boolean Asistencia_Salida;

        public DateTime FEntrada;
        public DateTime FSalida;

        public TimeSpan DeltaTiempo;
        public int      IntervaloTiempo;

        public Asistencia(){}

        public Asistencia ( string Ent_FechaEnt, string Ent_HoraEnt, Boolean Ent_Entrada, Boolean Ent_Salida)
        {
            this.Asistencia_FechaEntrada = Ent_FechaEnt;
            this.Asistencia_HoraEntrada = Ent_HoraEnt;
            this.Asistencia_Entrada = Ent_Entrada;
            this.Asistencia_Salida = Ent_Salida ;
        }

        public Asistencia ( string Ent_FechaEnt, string Ent_FechaSld, string Ent_HoraEnt, string Ent_HoraSld, Boolean Ent_Entrada, Boolean Ent_Salida)
        {
            this.Asistencia_FechaEntrada = Ent_FechaEnt;
            this.Asistencia_FechaSalida = Ent_FechaSld;

            this.Asistencia_HoraEntrada = Ent_HoraEnt;
            this.Asistencia_HoraSalida = Ent_HoraSld;

            this.Asistencia_Entrada = Ent_Entrada;
            this.Asistencia_Salida = Ent_Salida;
        }
    }
}
