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
            /*listBox1.Items.Add("Elemento 1");
            listBox1.Items.Add("Elemento 2");
            listBox1.Items.Add("Elemento 3");

            // agregar elementos al checkbox
            checkedListBox1.Items.Add("Elemento 1");
            checkedListBox1.Items.Add("Elemento 2");
            checkedListBox1.Items.Add("Elemento 3");*/

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
            /*
            int indice = checkedListBox1.SelectedIndex;
            MessageBox.Show( checkedListBox1.SelectedIndex.ToString());
            MessageBox.Show( checkedListBox1.SelectedItem.ToString());*/

        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add( textBox2.Text );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add(textBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            int IndiceSelect = checkedListBox1.SelectedIndex;
            checkedListBox1.Items.RemoveAt(IndiceSelect);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int IndiceSelect = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(IndiceSelect);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            int IndxSelect = checkedListBox1.SelectedIndex;
            string elemento = checkedListBox1.SelectedItem.ToString();

            checkedListBox1.Items.RemoveAt(IndxSelect);
            checkedListBox1.Items.Insert(IndxSelect - 1, elemento);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int IndxSelect = checkedListBox1.SelectedIndex;
            string elemento = checkedListBox1.SelectedItem.ToString();

            checkedListBox1.Items.RemoveAt(IndxSelect);
            checkedListBox1.Items.Insert(IndxSelect + 1, elemento);
        }

        private void button10_Click(object sender, EventArgs e)
        {
           CheckedListBox.CheckedItemCollection  s = checkedListBox1.CheckedItems;

            foreach (string es in s)
                listBox1.Items.Add(es);

        }
    }
}
