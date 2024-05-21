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
            this.button4 = new System.Windows.Forms.Button();
            this.Registro = new System.Windows.Forms.Button();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Guardar = new PPPP.Resources.RJButton();
            this.AgregarImg = new PPPP.Resources.RJButton();
            this.rjButton1 = new PPPP.Resources.RJButton();
            this.Resolucion = new PPPP.Resources.RJButton();
            this.rjButton2 = new PPPP.Resources.RJButton();
            this.rjButton3 = new PPPP.Resources.RJButton();
            this.rjButton4 = new PPPP.Resources.RJButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnResoluciones.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NCopias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRecortar)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnPrevisualizacion
            // 
            this.pnPrevisualizacion.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnPrevisualizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnPrevisualizacion.Location = new System.Drawing.Point(229, 47);
            this.pnPrevisualizacion.Name = "pnPrevisualizacion";
            this.pnPrevisualizacion.Size = new System.Drawing.Size(445, 356);
            this.pnPrevisualizacion.TabIndex = 0;
            this.pnPrevisualizacion.Paint += new System.Windows.Forms.PaintEventHandler(this.pnPrevisualizacion_Paint);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnGuardar.Location = new System.Drawing.Point(259, 577);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(352, 48);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(629, 681);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(352, 41);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(62)))), ((int)(((byte)(59)))));
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Barra de herramientas";
            // 
            // pnResoluciones
            // 
            this.pnResoluciones.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnResoluciones.Controls.Add(this.x5X7);
            this.pnResoluciones.Controls.Add(this.button10);
            this.pnResoluciones.Controls.Add(this.button9);
            this.pnResoluciones.Location = new System.Drawing.Point(155, 136);
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
            this.x5X7.Location = new System.Drawing.Point(0, 3);
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
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.Registro);
            this.panel2.Location = new System.Drawing.Point(679, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(85, 187);
            this.panel2.TabIndex = 5;
            // 
            // SelectImg
            // 
            this.SelectImg.Location = new System.Drawing.Point(0, 158);
            this.SelectImg.Name = "SelectImg";
            this.SelectImg.Size = new System.Drawing.Size(85, 40);
            this.SelectImg.TabIndex = 9;
            this.SelectImg.Text = "Seleccionar Imgen";
            this.SelectImg.UseVisualStyleBackColor = true;
            this.SelectImg.Click += new System.EventHandler(this.SelectImg_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "Restablecer Imagen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRecortar
            // 
            this.btnRecortar.Location = new System.Drawing.Point(0, 46);
            this.btnRecortar.Name = "btnRecortar";
            this.btnRecortar.Size = new System.Drawing.Size(85, 40);
            this.btnRecortar.TabIndex = 7;
            this.btnRecortar.Text = "Recortar";
            this.btnRecortar.UseVisualStyleBackColor = true;
            this.btnRecortar.Click += new System.EventHandler(this.btnRecortar_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 84);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 40);
            this.button4.TabIndex = 8;
            this.button4.Text = "Resolucion de imgen";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Registro
            // 
            this.Registro.Location = new System.Drawing.Point(0, 121);
            this.Registro.Name = "Registro";
            this.Registro.Size = new System.Drawing.Size(85, 40);
            this.Registro.TabIndex = 9;
            this.Registro.Text = "Registro";
            this.Registro.UseVisualStyleBackColor = true;
            this.Registro.Click += new System.EventHandler(this.Registro_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "\"Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp\"";
            // 
            // NCopias
            // 
            this.NCopias.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NCopias.Location = new System.Drawing.Point(588, 418);
            this.NCopias.Name = "NCopias";
            this.NCopias.Size = new System.Drawing.Size(59, 26);
            this.NCopias.TabIndex = 8;
            this.NCopias.ValueChanged += new System.EventHandler(this.NCopias_ValueChanged);
            // 
            // PanelPre
            // 
            this.PanelPre.AutoScroll = true;
            this.PanelPre.BackColor = System.Drawing.SystemColors.ControlLight;
            this.PanelPre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelPre.Location = new System.Drawing.Point(709, 47);
            this.PanelPre.Name = "PanelPre";
            this.PanelPre.Size = new System.Drawing.Size(745, 525);
            this.PanelPre.TabIndex = 9;
            this.PanelPre.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelPre_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(426, 427);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Numero de Copias";
            // 
            // Acercar
            // 
            this.Acercar.BackgroundImage = global::PPPP.Properties.Resources.boton_para_acercar__1_;
            this.Acercar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Acercar.Location = new System.Drawing.Point(1117, 592);
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
            this.Alejar.Location = new System.Drawing.Point(1022, 592);
            this.Alejar.Name = "Alejar";
            this.Alejar.Size = new System.Drawing.Size(70, 70);
            this.Alejar.TabIndex = 6;
            this.Alejar.UseVisualStyleBackColor = true;
            this.Alejar.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // LRegistro
            // 
            this.LRegistro.FormattingEnabled = true;
            this.LRegistro.Location = new System.Drawing.Point(14, 355);
            this.LRegistro.Name = "LRegistro";
            this.LRegistro.Size = new System.Drawing.Size(211, 381);
            this.LRegistro.TabIndex = 11;
            this.LRegistro.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Agregar
            // 
            this.Agregar.Location = new System.Drawing.Point(272, 460);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(96, 23);
            this.Agregar.TabIndex = 13;
            this.Agregar.Text = "Agregar Imagen";
            this.Agregar.UseVisualStyleBackColor = true;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicar.Location = new System.Drawing.Point(708, 611);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(188, 31);
            this.btnAplicar.TabIndex = 14;
            this.btnAplicar.Text = "Aplicar recorte";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.button2_Click);
            // 
            // pbRecortar
            // 
            this.pbRecortar.Location = new System.Drawing.Point(3, 666);
            this.pbRecortar.Name = "pbRecortar";
            this.pbRecortar.Size = new System.Drawing.Size(222, 189);
            this.pbRecortar.TabIndex = 15;
            this.pbRecortar.TabStop = false;
            this.pbRecortar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbRecortar_MouseDown);
            this.pbRecortar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbRecortar_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LRegistro);
            this.panel1.Controls.Add(this.pnResoluciones);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.Agregar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.rjButton1);
            this.panel1.Controls.Add(this.btnAplicar);
            this.panel1.Controls.Add(this.AgregarImg);
            this.panel1.Controls.Add(this.pbRecortar);
            this.panel1.Controls.Add(this.Guardar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Alejar);
            this.panel1.Controls.Add(this.Acercar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 749);
            this.panel1.TabIndex = 16;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Guardar
            // 
            this.Guardar.BackColor = System.Drawing.Color.Transparent;
            this.Guardar.BackgroundColor = System.Drawing.Color.Transparent;
            this.Guardar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(181)))), ((int)(((byte)(160)))));
            this.Guardar.BorderRadius = 8;
            this.Guardar.BorderSize = 2;
            this.Guardar.FlatAppearance.BorderSize = 0;
            this.Guardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(125)))), ((int)(((byte)(126)))));
            this.Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Guardar.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Guardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(181)))), ((int)(((byte)(160)))));
            this.Guardar.Location = new System.Drawing.Point(259, 496);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(352, 75);
            this.Guardar.TabIndex = 0;
            this.Guardar.Text = "Guardar";
            this.Guardar.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(181)))), ((int)(((byte)(160)))));
            this.Guardar.UseMnemonic = false;
            this.Guardar.UseVisualStyleBackColor = false;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // AgregarImg
            // 
            this.AgregarImg.BackColor = System.Drawing.Color.Transparent;
            this.AgregarImg.BackgroundColor = System.Drawing.Color.Transparent;
            this.AgregarImg.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.AgregarImg.BorderRadius = 8;
            this.AgregarImg.BorderSize = 1;
            this.AgregarImg.FlatAppearance.BorderSize = 0;
            this.AgregarImg.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(54)))), ((int)(((byte)(73)))));
            this.AgregarImg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(218)))), ((int)(((byte)(191)))));
            this.AgregarImg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AgregarImg.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarImg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.AgregarImg.Location = new System.Drawing.Point(259, 419);
            this.AgregarImg.Name = "AgregarImg";
            this.AgregarImg.Size = new System.Drawing.Size(142, 35);
            this.AgregarImg.TabIndex = 16;
            this.AgregarImg.Text = "Agregar Imagen";
            this.AgregarImg.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(117)))), ((int)(((byte)(117)))));
            this.AgregarImg.UseMnemonic = false;
            this.AgregarImg.UseVisualStyleBackColor = false;
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.Transparent;
            this.rjButton1.BackgroundColor = System.Drawing.Color.Transparent;
            this.rjButton1.BorderColor = System.Drawing.Color.Maroon;
            this.rjButton1.BorderRadius = 8;
            this.rjButton1.BorderSize = 2;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.rjButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton1.ForeColor = System.Drawing.Color.Maroon;
            this.rjButton1.Location = new System.Drawing.Point(259, 631);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(352, 75);
            this.rjButton1.TabIndex = 17;
            this.rjButton1.Text = "Salir";
            this.rjButton1.TextColor = System.Drawing.Color.Maroon;
            this.rjButton1.UseMnemonic = false;
            this.rjButton1.UseVisualStyleBackColor = false;
            // 
            // Resolucion
            // 
            this.Resolucion.BackColor = System.Drawing.Color.Transparent;
            this.Resolucion.BackgroundColor = System.Drawing.Color.Transparent;
            this.Resolucion.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(62)))), ((int)(((byte)(59)))));
            this.Resolucion.BorderRadius = 8;
            this.Resolucion.BorderSize = 1;
            this.Resolucion.FlatAppearance.BorderSize = 0;
            this.Resolucion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
            this.Resolucion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.Resolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Resolucion.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Resolucion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(62)))), ((int)(((byte)(59)))));
            this.Resolucion.Location = new System.Drawing.Point(6, 11);
            this.Resolucion.Name = "Resolucion";
            this.Resolucion.Size = new System.Drawing.Size(121, 64);
            this.Resolucion.TabIndex = 18;
            this.Resolucion.Text = "Seleccionar Imagen";
            this.Resolucion.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(62)))), ((int)(((byte)(59)))));
            this.Resolucion.UseMnemonic = false;
            this.Resolucion.UseVisualStyleBackColor = false;
            // 
            // rjButton2
            // 
            this.rjButton2.BackColor = System.Drawing.Color.Transparent;
            this.rjButton2.BackgroundColor = System.Drawing.Color.Transparent;
            this.rjButton2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(62)))), ((int)(((byte)(59)))));
            this.rjButton2.BorderRadius = 8;
            this.rjButton2.BorderSize = 1;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
            this.rjButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(62)))), ((int)(((byte)(59)))));
            this.rjButton2.Location = new System.Drawing.Point(6, 81);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(121, 64);
            this.rjButton2.TabIndex = 19;
            this.rjButton2.Text = "Resolucion De Imagen";
            this.rjButton2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(62)))), ((int)(((byte)(59)))));
            this.rjButton2.UseMnemonic = false;
            this.rjButton2.UseVisualStyleBackColor = false;
            // 
            // rjButton3
            // 
            this.rjButton3.BackColor = System.Drawing.Color.Transparent;
            this.rjButton3.BackgroundColor = System.Drawing.Color.Transparent;
            this.rjButton3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(62)))), ((int)(((byte)(59)))));
            this.rjButton3.BorderRadius = 8;
            this.rjButton3.BorderSize = 1;
            this.rjButton3.FlatAppearance.BorderSize = 0;
            this.rjButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
            this.rjButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.rjButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton3.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(62)))), ((int)(((byte)(59)))));
            this.rjButton3.Location = new System.Drawing.Point(6, 221);
            this.rjButton3.Name = "rjButton3";
            this.rjButton3.Size = new System.Drawing.Size(121, 64);
            this.rjButton3.TabIndex = 20;
            this.rjButton3.Text = "Registro";
            this.rjButton3.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(62)))), ((int)(((byte)(59)))));
            this.rjButton3.UseMnemonic = false;
            this.rjButton3.UseVisualStyleBackColor = false;
            // 
            // rjButton4
            // 
            this.rjButton4.BackColor = System.Drawing.Color.Transparent;
            this.rjButton4.BackgroundColor = System.Drawing.Color.Transparent;
            this.rjButton4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(62)))), ((int)(((byte)(59)))));
            this.rjButton4.BorderRadius = 8;
            this.rjButton4.BorderSize = 1;
            this.rjButton4.FlatAppearance.BorderSize = 0;
            this.rjButton4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RosyBrown;
            this.rjButton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(200)))), ((int)(((byte)(180)))));
            this.rjButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton4.Font = new System.Drawing.Font("Yu Gothic UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjButton4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(62)))), ((int)(((byte)(59)))));
            this.rjButton4.Location = new System.Drawing.Point(6, 151);
            this.rjButton4.Name = "rjButton4";
            this.rjButton4.Size = new System.Drawing.Size(121, 64);
            this.rjButton4.TabIndex = 21;
            this.rjButton4.Text = "Recortar";
            this.rjButton4.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(62)))), ((int)(((byte)(59)))));
            this.rjButton4.UseMnemonic = false;
            this.rjButton4.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.Resolucion);
            this.panel3.Controls.Add(this.rjButton3);
            this.panel3.Controls.Add(this.rjButton4);
            this.panel3.Controls.Add(this.rjButton2);
            this.panel3.Location = new System.Drawing.Point(16, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(136, 294);
            this.panel3.TabIndex = 22;
            // 
            // InterfazEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.PanelPre);
            this.Controls.Add(this.NCopias);
            this.Controls.Add(this.pnPrevisualizacion);
            this.Controls.Add(this.panel1);
            this.Name = "InterfazEdicion";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnResoluciones.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NCopias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRecortar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnPrevisualizacion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnResoluciones;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRecortar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SelectImg;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button Registro;
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
        private System.Windows.Forms.Panel panel1;
        private Resources.RJButton Guardar;
        private Resources.RJButton AgregarImg;
        private Resources.RJButton rjButton1;
        private Resources.RJButton Resolucion;
        private System.Windows.Forms.Panel panel3;
        private Resources.RJButton rjButton4;
        private Resources.RJButton rjButton3;
        private Resources.RJButton rjButton2;
    }
}

