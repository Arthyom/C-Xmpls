namespace BusquedaProfundidad
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radDerIn = new System.Windows.Forms.RadioButton();
            this.radIzqIn = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radDerFin = new System.Windows.Forms.RadioButton();
            this.radIzqFin = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.GTree = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GTree)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radDerIn);
            this.groupBox1.Controls.Add(this.radIzqIn);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(9, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estado Inicial";
            // 
            // radDerIn
            // 
            this.radDerIn.AutoSize = true;
            this.radDerIn.Location = new System.Drawing.Point(102, 47);
            this.radDerIn.Name = "radDerIn";
            this.radDerIn.Size = new System.Drawing.Size(66, 17);
            this.radDerIn.TabIndex = 2;
            this.radDerIn.TabStop = true;
            this.radDerIn.Text = "Derecho";
            this.radDerIn.UseVisualStyleBackColor = true;
            // 
            // radIzqIn
            // 
            this.radIzqIn.AutoSize = true;
            this.radIzqIn.Location = new System.Drawing.Point(10, 47);
            this.radIzqIn.Name = "radIzqIn";
            this.radIzqIn.Size = new System.Drawing.Size(68, 17);
            this.radIzqIn.TabIndex = 1;
            this.radIzqIn.TabStop = true;
            this.radIzqIn.Text = "Izquierdo";
            this.radIzqIn.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(431, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 60);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radDerFin);
            this.groupBox3.Controls.Add(this.radIzqFin);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Location = new System.Drawing.Point(198, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(183, 68);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Estado Final";
            // 
            // radDerFin
            // 
            this.radDerFin.AutoSize = true;
            this.radDerFin.Location = new System.Drawing.Point(102, 47);
            this.radDerFin.Name = "radDerFin";
            this.radDerFin.Size = new System.Drawing.Size(66, 17);
            this.radDerFin.TabIndex = 2;
            this.radDerFin.TabStop = true;
            this.radDerFin.Text = "Derecho";
            this.radDerFin.UseVisualStyleBackColor = true;
            // 
            // radIzqFin
            // 
            this.radIzqFin.AutoSize = true;
            this.radIzqFin.Location = new System.Drawing.Point(10, 47);
            this.radIzqFin.Name = "radIzqFin";
            this.radIzqFin.Size = new System.Drawing.Size(68, 17);
            this.radIzqFin.TabIndex = 1;
            this.radIzqFin.TabStop = true;
            this.radIzqFin.Text = "Izquierdo";
            this.radIzqFin.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(10, 20);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(158, 20);
            this.textBox2.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Location = new System.Drawing.Point(3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(757, 93);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Panel De Entrada";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(585, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 60);
            this.button2.TabIndex = 4;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GTree
            // 
            this.GTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GTree.Location = new System.Drawing.Point(3, 102);
            this.GTree.Name = "GTree";
            this.GTree.Size = new System.Drawing.Size(824, 235);
            this.GTree.TabIndex = 5;
            this.GTree.TabStop = false;
            this.GTree.Click += new System.EventHandler(this.GTree_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 339);
            this.Controls.Add(this.GTree);
            this.Controls.Add(this.groupBox4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GTree)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radDerIn;
        private System.Windows.Forms.RadioButton radIzqIn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radDerFin;
        private System.Windows.Forms.RadioButton radIzqFin;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox GTree;
    }
}

