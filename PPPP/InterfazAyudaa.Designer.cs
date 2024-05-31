namespace PPPP
{
    partial class InterfazAyudaa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be 
        /// 
        /// d; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InterfazAyudaa));
            this.btnRegresar = new PPPP.Resources.RJButton();
            this.p1 = new System.Windows.Forms.PictureBox();
            this.pb2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAtras = new PPPP.Resources.RJButton();
            this.btnAdelante = new PPPP.Resources.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Transparent;
            this.btnRegresar.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnRegresar.BorderColor = System.Drawing.Color.Magenta;
            this.btnRegresar.BorderRadius = 8;
            this.btnRegresar.BorderSize = 2;
            this.btnRegresar.FlatAppearance.BorderSize = 0;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.ForeColor = System.Drawing.Color.Black;
            this.btnRegresar.Location = new System.Drawing.Point(952, 708);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(234, 53);
            this.btnRegresar.TabIndex = 0;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.TextColor = System.Drawing.Color.Black;
            this.btnRegresar.UseVisualStyleBackColor = false;
            // 
            // p1
            // 
            this.p1.Image = ((System.Drawing.Image)(resources.GetObject("p1.Image")));
            this.p1.Location = new System.Drawing.Point(210, 41);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(414, 327);
            this.p1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1.TabIndex = 1;
            this.p1.TabStop = false;
            // 
            // pb2
            // 
            this.pb2.Image = ((System.Drawing.Image)(resources.GetObject("pb2.Image")));
            this.pb2.Location = new System.Drawing.Point(215, 411);
            this.pb2.Name = "pb2";
            this.pb2.Size = new System.Drawing.Size(409, 200);
            this.pb2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb2.TabIndex = 3;
            this.pb2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(755, 78);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(353, 348);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAtras.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAtras.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAtras.BorderRadius = 0;
            this.btnAtras.BorderSize = 0;
            this.btnAtras.FlatAppearance.BorderSize = 0;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.ForeColor = System.Drawing.Color.White;
            this.btnAtras.Location = new System.Drawing.Point(755, 446);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(84, 40);
            this.btnAtras.TabIndex = 5;
            this.btnAtras.Text = "Anterior";
            this.btnAtras.TextColor = System.Drawing.Color.White;
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnAdelante
            // 
            this.btnAdelante.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAdelante.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnAdelante.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAdelante.BorderRadius = 0;
            this.btnAdelante.BorderSize = 0;
            this.btnAdelante.FlatAppearance.BorderSize = 0;
            this.btnAdelante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdelante.ForeColor = System.Drawing.Color.White;
            this.btnAdelante.Location = new System.Drawing.Point(1024, 446);
            this.btnAdelante.Name = "btnAdelante";
            this.btnAdelante.Size = new System.Drawing.Size(84, 40);
            this.btnAdelante.TabIndex = 6;
            this.btnAdelante.Text = "Siguiente";
            this.btnAdelante.TextColor = System.Drawing.Color.White;
            this.btnAdelante.UseVisualStyleBackColor = false;
            this.btnAdelante.Click += new System.EventHandler(this.btnAdelante_Click);
            // 
            // InterfazAyudaa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1313, 749);
            this.Controls.Add(this.btnAdelante);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pb2);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.btnRegresar);
            this.Name = "InterfazAyudaa";
            this.Text = "Ayuda";
            this.Load += new System.EventHandler(this.InterfazAyudaa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.p1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Resources.RJButton btnRegresar;
        private System.Windows.Forms.PictureBox p1;
        private System.Windows.Forms.PictureBox pb2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Resources.RJButton btnAtras;
        private Resources.RJButton btnAdelante;
    }
}