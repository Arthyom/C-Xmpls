using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FwsCompiler
{
    /// <summary>
    /// Lógica de interacción para BloqueControl.xaml
    /// </summary>
    public partial class BloqueControl : UserControl
    {
        public const string Txt_MvArriba = "Mover arriba";
        public const string Txt_MvAbajo = "Mover abajo";
        public const string Txt_MvIzqrd = "Mover izquierda";
        public const string Txt_MvDrch = "Mover derecha";
        public const string Txt_Vacio = " "; 


        public Canvas       Blq_ContenedorPrincipal = new Canvas();
        public Label        Blq_EtiquetaInterna = new Label();
        public Rectangle    Blq_FormaExterna = new Rectangle();
        public Border       Blq_Borde = new Border();
        public TipoBloques  Blq_TipoBloque;
        public Point        PosActualGrid = new Point();

        public Boolean Seleccionado;

        public BloqueControl()
        {
            InitializeComponent();

          
        }

        private void ColorearBloque ( TipoBloques TipoEntrada)
        {
            switch (TipoEntrada)
            {
                case TipoBloques.Tipo_Bloque_Lineal: this.Blq_ContenedorPrincipal.Background = Brushes.Orange; break;
                  
                case TipoBloques.Tipo_Bloque_Ciclo_For: this.Blq_ContenedorPrincipal.Background = Brushes.Orange; break;

                case TipoBloques.Tipo_Bloque_Ciclo_While: this.Blq_ContenedorPrincipal.Background = Brushes.Blue; break;

                case TipoBloques.Tipo_Bloque_Switch:

                    OpenFileDialog c = new OpenFileDialog();
                    c.ShowDialog();
                    string ruta = c.FileName;

                    ImageBrush fondo = new ImageBrush();
                    fondo.ImageSource = new BitmapImage(new Uri(ruta));
                    this.Blq_ContenedorPrincipal.Background = fondo;
                    break;

            }
        }

        private void FijarTextoInterno ( TextoInterno TextoEntrada)
        {
            switch ( TextoEntrada)
            {
                case TextoInterno.Texto_Lineal_Abajo: this.Blq_EtiquetaInterna.Content = Txt_MvArriba; break;
                case TextoInterno.Texto_Lineal_Arriba: this.Blq_EtiquetaInterna.Content = Txt_MvAbajo; break;
                case TextoInterno.Texto_Lineal_Derecha: this.Blq_EtiquetaInterna.Content = Txt_MvDrch; break;
                case TextoInterno.Texto_Lineal_Izquierda: this.Blq_EtiquetaInterna.Content = Txt_MvIzqrd; break;
                case TextoInterno.Texto_Vacio: this.Blq_EtiquetaInterna.Content = Txt_Vacio; break;
            }
        }

        public BloqueControl ( TipoBloques Creacion_TipoBloque, TextoInterno Creacion_TextoEtiqueta, Point Creacion_PuntoOrigen, Size Creacion_Dims )
        {
            // definir el texto de la etiqueta de texto
            FijarTextoInterno( Creacion_TextoEtiqueta );
            this.Blq_TipoBloque = Creacion_TipoBloque;
            this.Blq_EtiquetaInterna.Width = Creacion_Dims.Width ;
            this.Blq_EtiquetaInterna.Height = Creacion_Dims.Height ;

            // posicionar y dimencionar el contenedro principal
            this.Blq_ContenedorPrincipal.Width = Creacion_Dims.Width;
            this.Blq_ContenedorPrincipal.Height = Creacion_Dims.Height;
            Canvas.SetTop(this.Blq_ContenedorPrincipal, Creacion_PuntoOrigen.Y);
            Canvas.SetLeft(this.Blq_ContenedorPrincipal, Creacion_PuntoOrigen.X);

            // poscicionar y dimencionar la forma del 
            this.Blq_FormaExterna.Height = Creacion_Dims.Height - 1;
            this.Blq_FormaExterna.Width = Creacion_Dims.Width - 1;
     

            // pintar el control del color adecuado 
            ColorearBloque(Creacion_TipoBloque);
           
            // generar la composicion de los controles 
            this.Blq_ContenedorPrincipal.Children.Add(this.Blq_FormaExterna);
            this.Blq_ContenedorPrincipal.Children.Add(Blq_EtiquetaInterna);
            
            // suscribirse a los eventos del raton
            this.Blq_ContenedorPrincipal.MouseDown += UserControl_MouseDown;
            this.Blq_ContenedorPrincipal.MouseMove += UserControl_MouseMove;
            this.Blq_ContenedorPrincipal.MouseUp += UserControl_MouseUp;
        }

        public Canvas RegresarBloque()
        {
            return this.Blq_ContenedorPrincipal;
            
        }

        public void RedondearBorde ( double radioBorde )
        {
            this.Blq_FormaExterna.RadiusX = radioBorde;
            this.Blq_FormaExterna.RadiusY = radioBorde;
        }

        // cuando se cargue la grilla principal
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        // cuando se le de clikc al control
        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Seleccionado = true;
            this.Blq_FormaExterna.Fill = Brushes.BlueViolet;

            Console.WriteLine("Precionado");

        }

        // cuando se mueva el control 
        private void UserControl_MouseMove(object sender, MouseEventArgs e)
        {
            if( this.Seleccionado)
            {
                this.PosActualGrid.X = e.GetPosition(this.Blq_ContenedorPrincipal).X;
                this.PosActualGrid.Y = e.GetPosition(this.Blq_ContenedorPrincipal).Y;

                this.Blq_FormaExterna.Fill = Brushes.Gold;
                Console.WriteLine("Moviendo sobre");
            }
        }

        // cuando se levante el rato
        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Seleccionado = false;
            this.Blq_FormaExterna.Fill = Brushes.Red;

            TranslateTransform Trans = new TranslateTransform(this.PosActualGrid.X, this.PosActualGrid.Y);

            this.Blq_ContenedorPrincipal.RenderTransform = Trans;


            Console.WriteLine("Levantado");
        }
    }
}
