using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebasLibroCSharp
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        // establecer elementos en los controles 
        private void Form5_Load(object sender, EventArgs e)
        {
            // agregar elementos a los listbox 
            listBox1.Items.Add("Elemento 1");
            listBox1.Items.Add("Elemento 2");
            listBox1.Items.Add("Elemento 3");

            // agregar elementos al checkbox
            checkedListBox1.Items.Add("Elemento 1");
            checkedListBox1.Items.Add("Elemento 2");
            checkedListBox1.Items.Add("Elemento 3");

        }

        // desplegar el elemento seleccionado
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int indice = listBox1.SelectedIndex;
            MessageBox.Show( listBox1.SelectedIndex.ToString() );
            MessageBox.Show(listBox1.SelectedItem.ToString() );

        }

        // elementos seleccionados en el check
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = checkedListBox1.SelectedIndex;
            MessageBox.Show( checkedListBox1.SelectedIndex.ToString());
            MessageBox.Show( checkedListBox1.SelectedItem.ToString());

        }
    }
}
