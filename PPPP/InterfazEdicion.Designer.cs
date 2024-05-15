namespace PPPP
{
    partial class InterfazEdicion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnPrevisualizacion = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnResoluciones = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.x5X7 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SelectImg = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRecortar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Registro = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.NCopias = new System.Windows.Forms.NumericUpDown();
            this.PanelPre = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Acercar = new System.Windows.Forms.Button();
            this.Alejar = new System.Windows.Forms.Button();
            this.LRegistro = new System.Windows.Forms.ListBox();
            this.Agregar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.pbRecortar = new System.Windows.Forms.PictureBox();
            this.pnResoluciones.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NCopias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRecortar)).BeginInit();
            this.SuspendLayout();
            // 
            // pnPrevisualizacion
            // 
            this.pnPrevisualizacion.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnPrevisualizacion.Location = new System.Drawing.Point(229, 47);
            this.pnPrevisualizacion.Name = "pnPrevisualizacion";
            this.pnPrevisualizacion.Size = new System.Drawing.Size(445, 356);
            this.pnPrevisualizacion.TabIndex = 0;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(46, 617);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(482, 79);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(46, 518);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(482, 62);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Barra de herramientas";
            // 
            // pnResoluciones
            // 
            this.pnResoluciones.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnResoluciones.Controls.Add(this.button10);
            this.pnResoluciones.Controls.Add(this.button9);
            this.pnResoluciones.Controls.Add(this.x5X7);
            this.pnResoluciones.Location = new System.Drawing.Point(103, 215);
            this.pnResoluciones.Name = "pnResoluciones";
            this.pnResoluciones.Size = new System.Drawing.Size(107, 87);
            this.pnResoluciones.TabIndex = 4;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(0, 58);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(107, 23);
            this.button10.TabIndex = 14;
            this.button10.Text = "TamañoInfantil";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.inInf);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(0, 29);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(104, 23);
            this.button9.TabIndex = 12;
            this.button9.Text = "4X6";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.in4x6);
            // 
            // x5X7
            // 
            this.x5X7.Location = new System.Drawing.Point(0, 0);
            this.x5X7.Name = "x5X7";
            this.x5X7.Size = new System.Drawing.Size(104, 23);
            this.x5X7.TabIndex = 11;
            this.x5X7.Text = "5X7";
            this.x5X7.UseVisualStyleBackColor = true;
            this.x5X7.Click += new System.EventHandler(this.in5x7);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SelectImg);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnRecortar);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.Registro);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Location = new System.Drawing.Point(12, 115);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(85, 257);
            this.panel2.TabIndex = 5;
            // 
            // SelectImg
            // 
            this.SelectImg.Location = new System.Drawing.Point(0, 184);
            this.SelectImg.Name = "SelectImg";
            this.SelectImg.Size = new System.Drawing.Size(85, 40);
            this.SelectImg.TabIndex = 9;
            this.SelectImg.Text = "Seleccionar Imgen";
            this.SelectImg.UseVisualStyleBackColor = true;
            this.SelectImg.Click += new System.EventHandler(this.SelectImg_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "Ajustar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRecortar
            // 
            this.btnRecortar.Location = new System.Drawing.Point(0, 36);
            this.btnRecortar.Name = "btnRecortar";
            this.btnRecortar.Size = new System.Drawing.Size(85, 40);
            this.btnRecortar.TabIndex = 7;
            this.btnRecortar.Text = "Recortar";
            this.btnRecortar.UseVisualStyleBackColor = true;
            this.btnRecortar.Click += new System.EventHandler(this.btnRecortar_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 73);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 40);
            this.button3.TabIndex = 7;
            this.button3.Text = "Ajustar y Recortar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 110);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 40);
            this.button4.TabIndex = 8;
            this.button4.Text = "Resolucion de imgen";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Registro
            // 
            this.Registro.Location = new System.Drawing.Point(0, 147);
            this.Registro.Name = "Registro";
            this.Registro.Size = new System.Drawing.Size(85, 40);
            this.Registro.TabIndex = 9;
            this.Registro.Text = "Registro";
            this.Registro.UseVisualStyleBackColor = true;
            this.Registro.Click += new System.EventHandler(this.Registro_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(0, 219);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(85, 75);
            this.button7.TabIndex = 9;
            this.button7.Text = "AtoAjustarImgH";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "\"Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp\"";
            // 
            // NCopias
            // 
            this.NCopias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NCopias.Location = new System.Drawing.Point(615, 411);
            this.NCopias.Name = "NCopias";
            this.NCopias.Size = new System.Drawing.Size(59, 26);
            this.NCopias.TabIndex = 8;
            this.NCopias.ValueChanged += new System.EventHandler(this.NCopias_ValueChanged);
            // 
            // PanelPre
            // 
            this.PanelPre.AutoScroll = true;
            this.PanelPre.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PanelPre.Location = new System.Drawing.Point(709, 47);
            this.PanelPre.Name = "PanelPre";
            this.PanelPre.Size = new System.Drawing.Size(638, 152);
            this.PanelPre.TabIndex = 9;
            this.PanelPre.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelPre_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(469, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Numero de Copias";
            // 
            // Acercar
            // 
            this.Acercar.BackgroundImage = global::PPPP.Properties.Resources.boton_para_acercar__1_;
            this.Acercar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Acercar.Location = new System.Drawing.Point(1019, 626);
            this.Acercar.Name = "Acercar";
            this.Acercar.Size = new System.Drawing.Size(70, 70);
            this.Acercar.TabIndex = 7;
            this.Acercar.UseVisualStyleBackColor = true;
            this.Acercar.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // Alejar
            // 
            this.Alejar.BackgroundImage = global::PPPP.Properties.Resources.lupa_con_signo_menos__2_;
            this.Alejar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Alejar.Location = new System.Drawing.Point(908, 626);
            this.Alejar.Name = "Alejar";
            this.Alejar.Size = new System.Drawing.Size(70, 70);
            this.Alejar.TabIndex = 6;
            this.Alejar.UseVisualStyleBackColor = true;
            this.Alejar.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // LRegistro
            // 
            this.LRegistro.FormattingEnabled = true;
            this.LRegistro.Location = new System.Drawing.Point(103, 448);
            this.LRegistro.Name = "LRegistro";
            this.LRegistro.Size = new System.Drawing.Size(343, 69);
            this.LRegistro.TabIndex = 11;
            this.LRegistro.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Agregar
            // 
            this.Agregar.Location = new System.Drawing.Point(114, 386);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(96, 23);
            this.Agregar.TabIndex = 13;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = true;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.Location = new System.Drawing.Point(229, 408);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(188, 31);
            this.btnAplicar.TabIndex = 14;
            this.btnAplicar.Text = "Aplicar recorte";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.button2_Click);
            // 
            // pbRecortar
            // 
            this.pbRecortar.Location = new System.Drawing.Point(739, 244);
            this.pbRecortar.Name = "pbRecortar";
            this.pbRecortar.Size = new System.Drawing.Size(445, 356);
            this.pbRecortar.TabIndex = 15;
            this.pbRecortar.TabStop = false;
            this.pbRecortar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbRecortar_MouseDown);
            this.pbRecortar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbRecortar_MouseUp);
            // 
            // InterfazEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1359, 749);
            this.Controls.Add(this.pbRecortar);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.Agregar);
            this.Controls.Add(this.LRegistro);
            this.Controls.Add(this.PanelPre);
            this.Controls.Add(this.Acercar);
            this.Controls.Add(this.Alejar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NCopias);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnResoluciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pnPrevisualizacion);
            this.Name = "InterfazEdicion";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnResoluciones.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NCopias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRecortar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnPrevisualizacion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnResoluciones;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnRecortar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SelectImg;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button Registro;
        private System.Windows.Forms.Button button7;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Alejar;
        private System.Windows.Forms.Button Acercar;
        private System.Windows.Forms.NumericUpDown NCopias;
        private System.Windows.Forms.Panel PanelPre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button x5X7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ListBox LRegistro;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.PictureBox pbRecortar;
    }
}

