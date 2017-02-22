namespace cargadorImagenes
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.rad = new System.Windows.Forms.TrackBar();
            this.bri = new System.Windows.Forms.TrackBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.MaxBar = new System.Windows.Forms.TrackBar();
            this.minBar = new System.Windows.Forms.TrackBar();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.pictureBox1.Location = new System.Drawing.Point(2, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(506, 454);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(191, 85);
            this.button1.TabIndex = 1;
            this.button1.Text = "Cargar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkRed;
            this.pictureBox2.Location = new System.Drawing.Point(569, 94);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(506, 454);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(199, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 86);
            this.button2.TabIndex = 4;
            this.button2.Text = "Iniciar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rad
            // 
            this.rad.LargeChange = 1;
            this.rad.Location = new System.Drawing.Point(560, 43);
            this.rad.Minimum = 1;
            this.rad.Name = "rad";
            this.rad.Size = new System.Drawing.Size(515, 45);
            this.rad.TabIndex = 5;
            this.rad.Value = 1;
            this.rad.Scroll += new System.EventHandler(this.rad_Scroll);
            // 
            // bri
            // 
            this.bri.LargeChange = 1;
            this.bri.Location = new System.Drawing.Point(518, 87);
            this.bri.Minimum = 1;
            this.bri.Name = "bri";
            this.bri.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.bri.Size = new System.Drawing.Size(45, 460);
            this.bri.TabIndex = 6;
            this.bri.Value = 1;
            this.bri.Scroll += new System.EventHandler(this.bri_Scroll);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(560, 554);
            this.trackBar1.Maximum = 255;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(527, 45);
            this.trackBar1.TabIndex = 7;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(353, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(73, 86);
            this.button3.TabIndex = 8;
            this.button3.Text = "Informacion";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(255, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 85);
            this.button4.TabIndex = 9;
            this.button4.Text = "Negra";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(432, 1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(76, 87);
            this.button5.TabIndex = 10;
            this.button5.Text = "Transformar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // MaxBar
            // 
            this.MaxBar.Location = new System.Drawing.Point(261, 553);
            this.MaxBar.Maximum = 255;
            this.MaxBar.Name = "MaxBar";
            this.MaxBar.Size = new System.Drawing.Size(247, 45);
            this.MaxBar.TabIndex = 11;
            // 
            // minBar
            // 
            this.minBar.Location = new System.Drawing.Point(2, 553);
            this.minBar.Maximum = 255;
            this.minBar.Name = "minBar";
            this.minBar.Size = new System.Drawing.Size(253, 45);
            this.minBar.TabIndex = 12;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(533, 1);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 13;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 590);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.minBar);
            this.Controls.Add(this.MaxBar);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.bri);
            this.Controls.Add(this.rad);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar rad;
        private System.Windows.Forms.TrackBar bri;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TrackBar MaxBar;
        private System.Windows.Forms.TrackBar minBar;
        private System.Windows.Forms.Button button6;
    }
}

