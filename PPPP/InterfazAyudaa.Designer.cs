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
            this.btnRegresar = new PPPP.Resources.RJButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAtras = new PPPP.Resources.RJButton();
            this.btnAdelante = new PPPP.Resources.RJButton();
            this.txtDescripcion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.Transparent;
            this.btnRegresar.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnRegresar.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRegresar.BorderRadius = 8;
            this.btnRegresar.BorderSize = 2;
            this.btnRegresar.FlatAppearance.BorderSize = 0;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnRegresar.ForeColor = System.Drawing.Color.Black;
            this.btnRegresar.Location = new System.Drawing.Point(387, 474);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(229, 47);
            this.btnRegresar.TabIndex = 0;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.TextColor = System.Drawing.Color.Black;
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(608, 400);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.Transparent;
            this.btnAtras.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAtras.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAtras.BorderRadius = 8;
            this.btnAtras.BorderSize = 2;
            this.btnAtras.FlatAppearance.BorderSize = 0;
            this.btnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtras.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAtras.Location = new System.Drawing.Point(12, 472);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(113, 47);
            this.btnAtras.TabIndex = 5;
            this.btnAtras.Text = "Anterior";
            this.btnAtras.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAtras.UseVisualStyleBackColor = false;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // btnAdelante
            // 
            this.btnAdelante.BackColor = System.Drawing.Color.Transparent;
            this.btnAdelante.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAdelante.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAdelante.BorderRadius = 8;
            this.btnAdelante.BorderSize = 2;
            this.btnAdelante.FlatAppearance.BorderSize = 0;
            this.btnAdelante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdelante.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdelante.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAdelante.Location = new System.Drawing.Point(179, 473);
            this.btnAdelante.Name = "btnAdelante";
            this.btnAdelante.Size = new System.Drawing.Size(113, 47);
            this.btnAdelante.TabIndex = 6;
            this.btnAdelante.Text = "Siguiente";
            this.btnAdelante.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAdelante.UseVisualStyleBackColor = false;
            this.btnAdelante.Click += new System.EventHandler(this.btnAdelante_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.AutoSize = true;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(12, 33);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(66, 24);
            this.txtDescripcion.TabIndex = 8;
            this.txtDescripcion.Text = "label2";
            // 
            // InterfazAyudaa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(628, 533);
            this.ControlBox = false;
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnAdelante);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRegresar);
            this.Name = "InterfazAyudaa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayuda";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InterfazAyudaa_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Resources.RJButton btnRegresar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Resources.RJButton btnAtras;
        private Resources.RJButton btnAdelante;
        private System.Windows.Forms.Label txtDescripcion;
    }
}