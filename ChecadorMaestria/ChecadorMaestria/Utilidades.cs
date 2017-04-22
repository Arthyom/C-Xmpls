using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ChecadorMaestria
{
    public class Utilidades
    {
        public string RutaArchivoActual;
        string RutaArchivoUltimo;
        string RutaArchivoRecnts;

        StreamWriter EscritorRecientes;
        StreamWriter EscritorUltimo;

        public Utilidades()
        {
            this.RutaArchivoRecnts = ".recnts.txt";
            this.RutaArchivoUltimo = ".lasts.txt";

            // crear archivos de rutas recientes si es que no existen ya
            if ( !Directory.Exists(this.RutaArchivoRecnts))
                EscritorRecientes = new StreamWriter(RutaArchivoRecnts,true);

            if ( !Directory.Exists(this.RutaArchivoUltimo))
                EscritorUltimo = new StreamWriter(RutaArchivoUltimo,true);
        }

        public Boolean CargarArchivo()
        {
            OpenFileDialog d = new OpenFileDialog();
            if( d.ShowDialog() == DialogResult.OK)
            {
                // crear archivos de rutas recientes si es que no existen ya
                if (!Directory.Exists(this.RutaArchivoRecnts))
                    EscritorRecientes = new StreamWriter(RutaArchivoRecnts, true);

                if (!Directory.Exists(this.RutaArchivoUltimo))
                    EscritorUltimo = new StreamWriter(RutaArchivoUltimo);

                this.RutaArchivoActual = d.FileName;

                // agregar la ruta del archivo actual a los recientes
                EscritorRecientes.WriteLine(RutaArchivoActual);

                // agregar la ruta al archivo ultimo
                EscritorUltimo.WriteLine(RutaArchivoActual);

                EscritorUltimo.Close();
                EscritorRecientes.Close();

                return true;
            }

            return false;
        }

        public string ConseguirUltimoArchivo()
        {
            EscritorUltimo.Close();
            EscritorRecientes.Close();

            // leer el contenido del archivo ultimo, es decir la ultima ruta usada
            StreamReader lector = new StreamReader(this.RutaArchivoUltimo);

            string r = lector.ReadLine();

            lector.Close();

            return @r;
        }

        




    }
}
