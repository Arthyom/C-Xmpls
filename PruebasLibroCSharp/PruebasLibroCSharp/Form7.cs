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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        // fijar elementos del listview 
        private void Form7_Load(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.CheckBoxes = true;

            ColumnHeader c1 = new ColumnHeader("Esta es la C1");

            listView1.Columns.Add("c1");
            listView1.Columns.Add("c2");

            ListViewItem it = new ListViewItem();

          

            listView1.Items.Add("Elemento 2");
            listView1.Items.Add("Elemento 3");
            listView1.Items.Add("Elemento 4");


            listView1.Items[1].SubItems.Add("Elemento 1");
        }

        // agregar 
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Add(textBox1.Text);

        }

        // eliminar seleccionado
        private void button2_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection i = listView1.SelectedIndices;

            foreach (int indx in i)
                listView1.Items.RemoveAt(indx);
        }

        // eliminar checados 
        private void button3_Click(object sender, EventArgs e)
        {
            ListView.CheckedListViewItemCollection ch = listView1.CheckedItems;
            foreach (ListViewItem lst in ch)
                listView1.Items.Remove(lst);

        }
    }
}
