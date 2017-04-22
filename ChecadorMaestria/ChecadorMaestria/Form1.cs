using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChecadorMaestria
{
    public partial class Form1 : Form
    {
        public Dictionary<int, EstudianteMaestria> EstudiantesMaestria;
        public Utilidades Herramientas = new Utilidades();

        public Form1()
        {
            InitializeComponent();
        }

        // agregar los estudiantes al control para visualizarlos
        public void CargarAlumnos ( TreeView Destino )
        {
            // cargar total de asistencias
            foreach (EstudianteMaestria est in EstudiantesMaestria.Values)
            {
                Destino.Nodes.Add(est.Est_Id.ToString(),"[ "+ est.Est_Id + " ]   "+ est.Est_Nombre);
                Destino.Nodes[est.Est_Id.ToString()].Nodes.Add("Asistencias Totales [ " + est.Asst_Total.Count + " ]");
                foreach (Asistencia a in est.Asst_Total)
                    Destino.Nodes[est.Est_Id.ToString()].Nodes[0].Nodes.Add(a.Asistencia_FechaEntrada + "    " + a.Asistencia_HoraEntrada + "    " +Convert.ToInt32( a.Asistencia_Entrada) ); 
            }

            // cargar asistencias agrupadas
            foreach (EstudianteMaestria est in EstudiantesMaestria.Values)
            {
               // Destino.Nodes.Add(est.Est_Id.ToString(), est.Est_Nombre);
                Destino.Nodes[est.Est_Id.ToString()].Nodes.Add("Asistencias Agrupadas [ " + est.Asst_Agrupada.Count + " ]");
                foreach (Asistencia a in est.Asst_Agrupada)
                    Destino.Nodes[est.Est_Id.ToString()].Nodes[1].Nodes.Add(a.Asistencia_FechaEntrada + "    " + a.Asistencia_HoraEntrada + "    " + a.Asistencia_HoraSalida +"    "+ Convert.ToInt32(a.Asistencia_Salida));
            }

            // cargar asistencias validas
            foreach (EstudianteMaestria est in EstudiantesMaestria.Values)
            {
                // Destino.Nodes.Add(est.Est_Id.ToString(), est.Est_Nombre);
                Destino.Nodes[est.Est_Id.ToString()].Nodes.Add("Asistencias Validas [ " + est.Asst_Valida.Count + " ]");
                foreach (Asistencia a in est.Asst_Valida)
                    Destino.Nodes[est.Est_Id.ToString()].Nodes[2].Nodes.Add(a.Asistencia_FechaEntrada + "    " + a.Asistencia_HoraEntrada + "    " + a.Asistencia_HoraSalida + "    " + Convert.ToInt32(a.Asistencia_Salida));
            }


        }

        

        public void GraficarAsistenciaAlumno ( EstudianteMaestria est)
        {

        }

        public void CargarDatos( string ruta )
        {
            EstudiantesMaestria = EstudianteMaestria.ProcesarClaves(ruta);
            EstudianteMaestria.ProcesarRegistros(ruta, EstudiantesMaestria);
            EstudianteMaestria.AgruparFechas(EstudiantesMaestria);
            EstudianteMaestria.ValidadAsistencia(EstudiantesMaestria);
            EstudianteMaestria.ProcesarFechas(EstudiantesMaestria, EstudianteMaestria.Lista_Valid);
            EstudianteMaestria.GraficarTodosEn(EstudiantesMaestria, EstudianteMaestria.Lista_Valid, chart1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inicarGrafico();
            string ruta = this.Herramientas.ConseguirUltimoArchivo();
            CargarDatos(ruta);
            // EstudianteMaestria.GraficarEstEn(EstudiantesMaestria[101], EstudianteMaestria.Lista_Valid, chart1 );
            CargarAlumnos( this.Arbol_VistaEstudiantes );
        }

        private void Arbol_VistaEstudiantes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                string clave = e.Node.Text;
                string[] Clave = clave.Split(' ');
                int Id = Convert.ToInt32(Clave[1]);

                if (chart1.Series.Count == 0)
                    EstudianteMaestria.GraficarEstEn(EstudiantesMaestria[Id], EstudianteMaestria.Lista_Valid, chart1);
                else
                {
                    chart1.Series.Clear();
                    EstudianteMaestria.GraficarEstEn(EstudiantesMaestria[Id], EstudianteMaestria.Lista_Valid, chart1);
                }
            }
            catch( Exception ex)
            {
                ;
            }
          
        }

        private void Opt_Nuevo_Click(object sender, EventArgs e)
        {
          if(  this.Herramientas.CargarArchivo() )
            {
                BorrarEstado();
                inicarGrafico();
                CargarDatos(Herramientas.RutaArchivoActual);
                CargarAlumnos(this.Arbol_VistaEstudiantes);
            }
        }

        public void BorrarEstado()
        {
            Arbol_VistaEstudiantes.Nodes.Clear();
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();

        }

        public void inicarGrafico()
        {
            chart1.ChartAreas.Add("A1");
        }

        private void Opt_Ultimo_Click(object sender, EventArgs e)
        {
            BorrarEstado();
            inicarGrafico();
            CargarDatos(Herramientas.ConseguirUltimoArchivo());
            CargarAlumnos(this.Arbol_VistaEstudiantes);
        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BorrarEstado();
            inicarGrafico();
            CargarDatos(Herramientas.ConseguirUltimoArchivo());
            CargarAlumnos(this.Arbol_VistaEstudiantes);
        }
    }
}
