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
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {


           



        }

        private void doble( object sender, MouseButtonEventArgs e )
        {

        }

        public void moverSobre(object sender, MouseEventArgs e)
        {
            string c = new BloqueControl().GetType().FullName;
         
        }

        private void Btn_Compilar_Click(object sender, RoutedEventArgs e)
        {
           

            BloqueControl b1 = new BloqueControl( TipoBloques.Tipo_Bloque_Lineal, TextoInterno.Texto_Lineal_Abajo, new Point(100, 50), new Size(100, 50));
            BloqueControl b2 = new BloqueControl( TipoBloques.Tipo_Bloque_Ciclo_While, TextoInterno.Texto_Lineal_Izquierda, new Point(0, 0), new Size(100, 50));
            BloqueControl b3 = new BloqueControl( TipoBloques.Tipo_Bloque_Ciclo_For, TextoInterno.Texto_Lineal_Derecha, new Point(100, 150), new Size(100, 50));
            BloqueControl b4 = new BloqueControl( TipoBloques.Tipo_Bloque_Condicion, TextoInterno.Texto_Lineal_Arriba, new Point(100, 250), new Size(100, 50));

          
            


            this.CanvasPnlExc.Children.Add(b1.RegresarBloque());
            this.CanvasPnlExc.Children.Add(b2.RegresarBloque());
            this.CanvasPnlExc.Children.Add(b3.RegresarBloque());
            this.CanvasPnlExc.Children.Add(b4.RegresarBloque());
        }

        private void CanvasPnlExc_MouseMove(object sender, MouseEventArgs e)
        {
            if( e.LeftButton == MouseButtonState.Pressed )
            {

            }
        }
    }
}
