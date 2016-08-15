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
using System.IO;

namespace PruebaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Boton2_Click(object sender, RoutedEventArgs e)
        {
            // el Xaml es la vista,  el modelo es el codigo, pero que es en si, la vista de modelo 

            for ( int i = 100; 10 < i;  i -- )
            {
                this.Opacity -= i;
      
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // mstrar un nuevo formulario 

            Window2 f2 = new Window2();
            f2.Show();
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            // crear un rectangulo
            Rectangle r = new Rectangle();

            SolidColorBrush c = new SolidColorBrush();
            c.Color = Color.FromRgb(2, 3, 4);

            r.Fill = c;
            r.Height = 200;
            r.Width = 100;
            r.Stroke = Brushes.CadetBlue;

            this.g2.Children.Add(r);

           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.button1.Content = "Rectangulo";
            this.button.Content = "Linea";
            this.button.Background = Brushes.CadetBlue;
            this.button1_Copy.Content = "Circulo";

            this.g2.Background = new SolidColorBrush( Color.FromArgb(4,4,4,0) );

            this.BtnForm2.Background = new SolidColorBrush(Color.FromRgb(1,2,3));

            
           
            // cambiar el color del canvas
            



        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            // dibujar una linea
            MessageBox.Show("Dibujando Linea");
            Line Linea1 = new Line();
            Linea1.Stroke = System.Windows.Media.Brushes.Azure;
            Linea1.X1 = 1; Linea1.Y1 = 1;
            Linea1.X2 = 100; Linea1.Y2 = 40;
            Linea1.HorizontalAlignment = HorizontalAlignment.Right;
           // Linea1.VerticalAlignment = VerticalAlignment.Center;
           // Linea1.HorizontalAlignment = HorizontalAlignment.Left;
            Linea1.StrokeThickness = 10;
           

            g2.Children.Add(Linea1);



        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            // crear una elipse
            Ellipse E1 = new Ellipse();

            // crear brocha para pintar elipse
            SolidColorBrush brocha = new SolidColorBrush();
            brocha.Color = Color.FromRgb(3, 4, 2);

            // pintar la elipse
            E1.Fill = brocha;
            E1.StrokeThickness = 3;
            E1.Stroke = Brushes.Salmon;
            E1.Width = 100;
            E1.Height = 100;

            this.g2.Children.Add(E1);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            // crear un triangulo
            PointCollection p = new PointCollection();
            p.Add(new Point(2, 2));
            p.Add(new Point(60, 34));
            p.Add(new Point(300, 300));

            Polygon pol = new Polygon();
            pol.Points = p;

            pol.Fill = Brushes.Red;
            pol.Stroke = Brushes.Cyan;
            pol.Width = 100;
            pol.Height = 34;
            pol.Stretch = Stretch.UniformToFill;

            this.g2.Children.Add(pol);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            // ir al formulario 2 
            Ventana2 V2 = new Ventana2();
            V2.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            
            this.Close();
            V2.Title = " Esta es la ventana 2";
            V2.Show();
        }
    }
}
