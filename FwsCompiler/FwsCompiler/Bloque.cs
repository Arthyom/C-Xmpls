using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FwsCompiler
{
    public class Bloque : Shape
    {
        /// <propiedades>

        public Color        Bloque_ColorBloque;
        public string       Bloque_ClaseBloque;
        public string       Bloque_EtiquetaInterna;
        public Point        Bloque_Localizacion;
        public Size         Bloque_Dimenciones;
        public Rectangle    Bloque_FondoRectangulo;

        /// </propiedades>


        protected override Geometry DefiningGeometry
        {
            get
            {
                RectangleGeometry r = new RectangleGeometry();
                return r;
            }
        }

        public Bloque()
        {

        }

        public Bloque ( Color Creacion_Color, string Creacion_ClaseBloque, string Creacion_EtiquetaInt )
        {
            this.Bloque_ColorBloque = Creacion_Color;
            this.Bloque_ClaseBloque = Creacion_ClaseBloque;
            this.Bloque_EtiquetaInterna = Creacion_EtiquetaInt;

            this.Bloque_Localizacion = new Point(0, 0);
            this.Bloque_Dimenciones = new Size(100, 100);

            this.Bloque_FondoRectangulo = new Rectangle();
            
            this.Bloque_FondoRectangulo.Height = this.Bloque_Dimenciones.Height;
            this.Bloque_FondoRectangulo.Width = this.Bloque_Dimenciones.Width;

            this.Bloque_FondoRectangulo.Fill = new SolidColorBrush(this.Bloque_ColorBloque);
        } 

        public Rectangle RegresarRectangulo ()
        {

            return this.Bloque_FondoRectangulo;
            
        }

        


    }
}
