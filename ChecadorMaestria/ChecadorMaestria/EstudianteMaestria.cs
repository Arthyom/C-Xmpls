using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChecadorMaestria
{
   public class EstudianteMaestria
    {
        public const int IndxId = 1;
        public const int IndxNmb = 0;
        public const int IndxFch = 2;
        public const int IndxActv = 3;
        public const int Tabulador = 09;

        public const int Lista_Total = 1;
        public const int Lista_Agrpd = 2;
        public const int Lista_Valid = 3;

        public string   Est_Nombre;
        public int      Est_Id;
        public Boolean  Est_Activo;
        public string   Est_Carrera;

        public List<Asistencia> Asst_Total;
        public List<Asistencia> Asst_Agrupada;
        public List<Asistencia> Asst_Valida;

        public EstudianteMaestria() { }

        public EstudianteMaestria ( string Ent_Nombre, int Ent_Id )
        {
            this.Est_Nombre = Ent_Nombre;
            this.Est_Id = Ent_Id;

            this.Est_Activo = true;
            Asst_Total = new List<Asistencia>();
            Asst_Agrupada = new List<Asistencia>();
            Asst_Valida = new List<Asistencia>();
            Est_Carrera = "";
        }

        // agregar datos a las listas de asistencia
        public static void                               ProcesarRegistros ( string RutaArchivo, Dictionary<int,EstudianteMaestria> Estudiante)
        {
            StreamReader Lector = new StreamReader(RutaArchivo);
            Lector.ReadLine();
            char tabulador = (char) 09;
            // C:\Users\frodo\Documents\Visual Studio 2015\Projects\ChecadorMaestria\CHECADOR MAESTRIA.txt

            // conseguir registros 
            while ( !Lector.EndOfStream )
            {
                string Linea = Lector.ReadLine();
                if (Linea != "" && Linea != " " && Linea != "\t\t\t")
                {
                    string[] Lsg = Linea.Split(tabulador);
                    int claveTemporal = Convert.ToInt32(Lsg[IndxId]);
                    string FechaHora = Lsg[IndxFch];
                    string Fecha = FechaHora.Split(' ')[0];
                    string Hora = FechaHora.Split(' ')[1];
                    
                    Boolean Active = Convert.ToBoolean( Convert.ToInt32(Lsg[IndxActv]));

                    // verificar si el estudiante ya esta en el hash 
                    if (Estudiante.ContainsKey(claveTemporal))
                    {
                        // agregar una nueva asistencia a sus reistros 
                        Asistencia nuevaAsistencia = new Asistencia(Fecha, Hora, Active, false);
                        Estudiante[claveTemporal].Asst_Total.Add(nuevaAsistencia);
                    }
                }
            }

            Lector.Close();
        }

        // crear un hash para almacenar los estudiantes y sus asistencias
        public static Dictionary<int,EstudianteMaestria> ProcesarClaves    ( string Ent_RutaArchivo )
        {
            // instanciar objetos
            Dictionary<int, EstudianteMaestria> DictEstudiantes = new Dictionary<int, EstudianteMaestria>();

            // conseguir registros 
            StreamReader Lector = new StreamReader(Ent_RutaArchivo);
            Lector.ReadLine();
            Lector.ReadLine();
            char tab = (char)Tabulador;
            while ( !Lector.EndOfStream )
            {
                string Linea = Lector.ReadLine();
                if ( Linea != "" && Linea != " " && Linea != "\t\t\t")
                {

                    string[] LineaSegmentada = Linea.Split(tab);
                    int claveTemporal = Convert.ToInt32(LineaSegmentada[IndxId]);
                    string nombreEstdnt = LineaSegmentada[IndxNmb];
                    string si = Lector.ReadLine();

                    // verificar si existe la clave en el hash 
                    if (!DictEstudiantes.ContainsKey(claveTemporal))
                    {

                        // crear un nuevo estudiante de maestria
                        EstudianteMaestria est = new EstudianteMaestria(nombreEstdnt, claveTemporal);
                        DictEstudiantes.Add(claveTemporal, est);
                    }
                }     
            }

            // cerrar el escritor 
            Lector.Close();
            return DictEstudiantes;
        }

        // agrupar las fechas en 1 sola
        public static void                               AgruparFechas     ( Dictionary<int,EstudianteMaestria> Estudaintes )
        {
            foreach( EstudianteMaestria est in Estudaintes.Values )
            {
                // unir las fechas identicas en un solo nodo de la lista agrupada
                Asistencia Anterior = est.Asst_Total[0];

                for( int i = 1; i < est.Asst_Total.Count; i ++)
                {
                    Asistencia Actual = est.Asst_Total[i];
                    if ( Anterior.Asistencia_FechaEntrada == Actual.Asistencia_FechaEntrada )
                    {
                        est.Asst_Agrupada.Add( new Asistencia( Anterior.Asistencia_FechaEntrada ,Actual.Asistencia_FechaEntrada,
                            Anterior.Asistencia_HoraEntrada, Actual.Asistencia_HoraEntrada, Anterior.Asistencia_Entrada, Actual.Asistencia_Entrada ) );
                    }
                    Anterior = Actual;
                }
            }
        }

        public static void                               ValidadAsistencia ( Dictionary<int, EstudianteMaestria> Estudiantes ) 
        {
            foreach( EstudianteMaestria est in Estudiantes.Values)           
                foreach( Asistencia a in est.Asst_Agrupada)
                    if (a.Asistencia_Salida)
                        est.Asst_Valida.Add(new Asistencia(a.Asistencia_FechaEntrada, a.Asistencia_FechaSalida, a.Asistencia_HoraEntrada, a.Asistencia_HoraSalida,
                            a.Asistencia_Entrada, a.Asistencia_Salida));       
        }

        public static void                               ProcesarFechas    ( Dictionary<int, EstudianteMaestria> Estudiantes, int TipoLista )
        {
            foreach (EstudianteMaestria est in Estudiantes.Values)
            {
                string s = est.Est_Nombre;


                List<Asistencia> Lgen = EstudianteMaestria.SeleccionarLista(est, TipoLista);
                foreach (Asistencia a in Lgen)
                {
                    int Intervalo = 0;
                    string[] FechaEntrada = a.Asistencia_FechaEntrada.Split('/');
                    string[] FechaSalida = a.Asistencia_FechaSalida.Split('/');

                    string[] HoraEntrada = a.Asistencia_HoraEntrada.Split(':');
                    string[] HoraSalida = a.Asistencia_HoraSalida.Split(':');

                    DateTime Fentrada = new DateTime(Convert.ToInt32(FechaEntrada[2]), Convert.ToInt32(FechaEntrada[1]), Convert.ToInt32(FechaEntrada[0]),
                        Convert.ToInt32(HoraEntrada[0]), Convert.ToInt32(HoraEntrada[1]), 00);

                    DateTime FSalida = new DateTime(Convert.ToInt32(FechaSalida[2]), Convert.ToInt32(FechaSalida[1]), Convert.ToInt32(FechaSalida[0]),
                        Convert.ToInt32(HoraSalida[0]), Convert.ToInt32(HoraSalida[1]), 00);

                    TimeSpan DeltaTiempo = FSalida - Fentrada;
                    Intervalo = DeltaTiempo.Hours;

                    a.FEntrada = Fentrada;
                    a.FSalida = FSalida;
                    a.DeltaTiempo = DeltaTiempo;
                    a.IntervaloTiempo = Intervalo;
                }
            }
        }

        public static List<Asistencia>                   SeleccionarLista  ( EstudianteMaestria est, int TipoLista)
        {
            switch( TipoLista)
            {
                case 1: return est.Asst_Total;
                case 2: return est.Asst_Agrupada;
                case 3: return est.Asst_Valida;

                default: return null;
            }
        }

        public static void                               GraficarTodosEn   ( Dictionary<int, EstudianteMaestria> Estudiantes, int TipoLista, Chart Destino)
        {
            foreach (EstudianteMaestria est in Estudiantes.Values)
            {
                string s = est.Est_Nombre;
                Destino.Series.Add(s);
                Destino.Series[s].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                int Intervalo = 0;

                List<Asistencia> Lgen = EstudianteMaestria.SeleccionarLista(est, TipoLista);
                foreach (Asistencia a in Lgen) 
                    Intervalo += a.IntervaloTiempo;
                
                Destino.Series[s].Points.AddY(Intervalo);
            }
        }

        public static void                               GraficarEstEn     ( EstudianteMaestria Estudiente, int TipoLista, Chart Destino)
        {
            string s = Estudiente.Est_Nombre;
            Destino.Series.Add(s);
            Destino.Series[s].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            List<Asistencia> Lgen = EstudianteMaestria.SeleccionarLista(Estudiente, TipoLista);
            foreach (Asistencia a in Lgen)
            {
                Destino.Series[s].Points.AddY(a.IntervaloTiempo);
                Destino.Series[s].AxisLabel = a.Asistencia_FechaSalida;
            }
        }
    }
}
