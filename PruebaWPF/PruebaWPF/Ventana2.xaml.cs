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
using System.Windows.Shapes;

namespace PruebaWPF
{
    /// <summary>
    /// Interaction logic for Ventana2.xaml
    /// </summary>
    public partial class Ventana2 : Window
    {

        /************************************************************************************/
        /*                     metodos graficos para el raton                               */
        /************************************************************************************/
        private void CambiarCursorCruz()
        {
            Cursor CursorNuevo = Cursors.Cross;
            Mouse.OverrideCursor = CursorNuevo;
        }



        public Ventana2()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // cambiar de color los botones
            
        }

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            // cambiar el tipo de cursor 
            this.CambiarCursorCruz();

        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            /* crear un rectangulo */
            Rectangle r1 = new Rectangle();
            r1.Name = "r1";
            r1.Width = 200;
            r1.Height = 300;
            r1.Fill = new SolidColorBrush(Color.FromRgb(0,0,0));
            r1.Stroke = Brushes.Blue;
            r1.StrokeThickness = 3;
            this.LnsDibujo.Children.Add(r1);
            


        }

        // comenzar la manípulacion de la las formas 
        private void Window_ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            e.ManipulationContainer = this;
            e.Handled = true;
        }

        // manipular el rectangulo, el evento delta se llama cuando se mueve el dedo por un dispositivo tactil o se levanta el dedo
        private void Window_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            Rectangle Rget = e.OriginalSource as Rectangle;
            Matrix RgetMatrix = ((MatrixTransform)Rget.RenderTransform).Matrix;

            /// rotar el rectangulo de creacion 
            RgetMatrix.RotateAt(e.DeltaManipulation.Rotation, e.ManipulationOrigin.X, e.ManipulationOrigin.Y);

            /// redimencionar el rectangulo
            RgetMatrix.ScaleAt(e.DeltaManipulation.Scale.X, e.DeltaManipulation.Scale.Y, e.ManipulationOrigin.X, e.ManipulationOrigin.Y);

            // mover el rectangulo
            RgetMatrix.Translate(e.DeltaManipulation.Translation.X, e.DeltaManipulation.Translation.Y);

            // aplicar los cambios al rectangulo
            Rget.RenderTransform = new MatrixTransform(RgetMatrix);

            Rect contenedor = new Rect( ( (FrameworkElement)e.ManipulationContainer).RenderSize );
            Rect formsLado = Rget.RenderTransform.TransformBounds(new Rect(Rget.RenderSize));

        }

        private void Window_ManipulationInertiaStarting(object sender, ManipulationInertiaStartingEventArgs e)
        {
            // desaceleracion para la traslacion
            e.TranslationBehavior.DesiredDeceleration = 10.0 * 96.0 / (1000.0 * 1000.0);

            // desaceleracion para la expansion
            e.ExpansionBehavior.DesiredDeceleration = 0.1 * 96 / (1000.0 * 1000.0); ;

            // desaceleracion para la rotacion
            e.RotationBehavior.DesiredDeceleration = 720 / (1000.0 * 1000.0);

            e.Handled = true;
        }
    }
}
