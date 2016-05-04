namespace PruebasLibroCSharp
{
    partial class Form4
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
            this.lblMens = new System.Windows.Forms.Label();
            this.lblTecla = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.coloresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rojoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verdeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blancoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fuenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.negritaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.italicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subrayadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripFuenteFAct = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStripEditarSActl = new System.Windows.Forms.ToolStripMenuItem();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMens
            // 
            this.lblMens.AutoSize = true;
            this.lblMens.Location = new System.Drawing.Point(12, 33);
            this.lblMens.Name = "lblMens";
            this.lblMens.Size = new System.Drawing.Size(35, 13);
            this.lblMens.TabIndex = 0;
            this.lblMens.Text = "label1";
            this.lblMens.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTecla_MouseMove);
            // 
            // lblTecla
            // 
            this.lblTecla.Location = new System.Drawing.Point(12, 46);
            this.lblTecla.Name = "lblTecla";
            this.lblTecla.Size = new System.Drawing.Size(35, 13);
            this.lblTecla.TabIndex = 1;
            this.lblTecla.Text = "label2";
            this.lblTecla.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTecla_MouseMove);
            this.lblTecla.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tecleo_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 62);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(215, 133);
            this.textBox1.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coloresToolStripMenuItem,
            this.archivoToolStripMenuItem,
            this.editarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(484, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // coloresToolStripMenuItem
            // 
            this.coloresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rojoToolStripMenuItem,
            this.verdeToolStripMenuItem,
            this.blancoToolStripMenuItem});
            this.coloresToolStripMenuItem.Name = "coloresToolStripMenuItem";
            this.coloresToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.coloresToolStripMenuItem.Text = "&Colores";
            // 
            // rojoToolStripMenuItem
            // 
            this.rojoToolStripMenuItem.Name = "rojoToolStripMenuItem";
            this.rojoToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.rojoToolStripMenuItem.Text = "&Rojo";
            this.rojoToolStripMenuItem.Click += new System.EventHandler(this.rojoToolStripMenuItem_Click);
            // 
            // verdeToolStripMenuItem
            // 
            this.verdeToolStripMenuItem.Name = "verdeToolStripMenuItem";
            this.verdeToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.verdeToolStripMenuItem.Text = "&verde";
            this.verdeToolStripMenuItem.Click += new System.EventHandler(this.verdeToolStripMenuItem_Click);
            // 
            // blancoToolStripMenuItem
            // 
            this.blancoToolStripMenuItem.Name = "blancoToolStripMenuItem";
            this.blancoToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.blancoToolStripMenuItem.Text = "&Blanco";
            this.blancoToolStripMenuItem.Click += new System.EventHandler(this.blancoToolStripMenuItem_Click);
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aercaDeToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // aercaDeToolStripMenuItem
            // 
            this.aercaDeToolStripMenuItem.Name = "aercaDeToolStripMenuItem";
            this.aercaDeToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.aercaDeToolStripMenuItem.Text = "&Aerca de ...";
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fuenteToolStripMenuItem,
            this.MenuStripFuenteFAct,
            this.MenuStripEditarSActl});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // fuenteToolStripMenuItem
            // 
            this.fuenteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.negritaToolStripMenuItem,
            this.italicaToolStripMenuItem,
            this.subrayadoToolStripMenuItem});
            this.fuenteToolStripMenuItem.Name = "fuenteToolStripMenuItem";
            this.fuenteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.fuenteToolStripMenuItem.Text = "Fuente";
            // 
            // negritaToolStripMenuItem
            // 
            this.negritaToolStripMenuItem.Name = "negritaToolStripMenuItem";
            this.negritaToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.negritaToolStripMenuItem.Text = "&Negrita";
            this.negritaToolStripMenuItem.Click += new System.EventHandler(this.negritaToolStripMenuItem_Click);
            // 
            // italicaToolStripMenuItem
            // 
            this.italicaToolStripMenuItem.Name = "italicaToolStripMenuItem";
            this.italicaToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.italicaToolStripMenuItem.Text = "&Italica";
            this.italicaToolStripMenuItem.Click += new System.EventHandler(this.italicaToolStripMenuItem_Click);
            // 
            // subrayadoToolStripMenuItem
            // 
            this.subrayadoToolStripMenuItem.Name = "subrayadoToolStripMenuItem";
            this.subrayadoToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.subrayadoToolStripMenuItem.Text = "&subrayado";
            this.subrayadoToolStripMenuItem.Click += new System.EventHandler(this.subrayadoToolStripMenuItem_Click);
            // 
            // MenuStripFuenteFAct
            // 
            this.MenuStripFuenteFAct.Name = "MenuStripFuenteFAct";
            this.MenuStripFuenteFAct.Size = new System.Drawing.Size(144, 22);
            this.MenuStripFuenteFAct.Text = ":FunteActual;";
            // 
            // MenuStripEditarSActl
            // 
            this.MenuStripEditarSActl.Name = "MenuStripEditarSActl";
            this.MenuStripEditarSActl.Size = new System.Drawing.Size(144, 22);
            this.MenuStripEditarSActl.Text = ";sizeActual:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(231, 33);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 4;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker1.Location = new System.Drawing.Point(54, 36);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(165, 20);
            this.dateTimePicker1.TabIndex = 5;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 199);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblTecla);
            this.Controls.Add(this.lblMens);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMens;
        private System.Windows.Forms.Label lblTecla;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem coloresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rojoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verdeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blancoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aercaDeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fuenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negritaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem italicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subrayadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuStripFuenteFAct;
        private System.Windows.Forms.ToolStripMenuItem MenuStripEditarSActl;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}