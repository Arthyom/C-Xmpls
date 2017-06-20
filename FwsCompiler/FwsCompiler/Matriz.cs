using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FwsCompiler
{
    public class Matriz
    {
        public      Grid Mtrz_ContPrimario;
        public      char [,] Mtrz_MatrizCartrs;
        public      Size Dims;
        public      char Mtrz_SimboloActuante = 'X';
        public      char Mtrz_SimboloVacio;

        public  Matriz( Size Ent_Dims, char Ent_SimAct)
        {
            // crear una nueva matriz de chars 
            this.Mtrz_MatrizCartrs = new char[(int)Ent_Dims.Width, (int)Ent_Dims.Height];


            // crear un grid que represente a la matriz 
            this.Mtrz_ContPrimario = new Grid();
            
            for( int i = 0; i < Ent_Dims.Height; i ++ )
            {
                ColumnDefinition cn = new ColumnDefinition();
                this.Mtrz_ContPrimario.ColumnDefinitions.Add(cn);
            }

            for (int i = 0; i < Ent_Dims.Width; i++)
            {
                RowDefinition rn = new RowDefinition();
                this.Mtrz_ContPrimario.RowDefinitions.Add(rn);
            }

            this.Mtrz_MatrizCartrs[0, 0] = Mtrz_SimboloActuante;
           // this.Mtrz_ContPrimario.ShowGridLines = true;
            this.Mtrz_ContPrimario.Height = 200;
            this.Mtrz_ContPrimario.Width = 200;

            this.Mtrz_ContPrimario.ShowGridLines = true;


        }

        public Grid RegresarContenedor ()
        {
            
            this.Mtrz_ContPrimario.Background = Brushes.Red;
            
            Label l = new Label();

            TextBlock t = new TextBlock();
            t.Text = this.Mtrz_SimboloActuante.ToString();
            t.FontSize = 20;
            t.FontWeight = FontWeights.Bold;

            t.Foreground = Brushes.Red;
            l.Content = t;

            l.Background = Brushes.Blue;
            Grid.SetColumn(l, 0);
            Grid.SetColumn(l, 0);
            this.Mtrz_ContPrimario.Children.Add(l);
            return this.Mtrz_ContPrimario;
        }

        public void MoverActuante ( char [,] Ent_Matriz )
        {
            for (int i = 0; i < this.Dims.Height; i++)
                for (int j = 0; j < this.Dims.Width; j++)
                    this.Mtrz_MatrizCartrs[i, j] = Ent_Matriz[j, i];
        }

        public void BorrarMatriz ()
        {
            for( int i = 0; i < this.Dims.Height; i ++ )
                for ( int j = 0; j < this.Dims.Width; j ++ )
                    this.Mtrz_MatrizCartrs[i, j] = this.Mtrz_SimboloVacio;
            
        }

        public void BorrarGrid()
        {
            for (int i = 0; i < this.Dims.Height; i++)
            {
                for (int j = 0; j < this.Dims.Width; j++)
                {
                    Grid.SetRow(null, i);
                    Grid.SetColumn(null, j);
                }
            }

        }

        public void MapearGrid( int i, int j )
        {
            // copiar los caracteres de la matriz de chars, en el grid
        }

    }
}
