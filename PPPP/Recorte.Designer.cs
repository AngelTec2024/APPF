namespace PPPP
{
    partial class Recorte
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
            this.pbRecortar2 = new System.Windows.Forms.PictureBox();
            this.Recortar = new PPPP.Resources.RJButton();
            this.Aceptar = new PPPP.Resources.RJButton();
            this.rjButton1 = new PPPP.Resources.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbRecortar2)).BeginInit();
            this.SuspendLayout();
            // 
            // pbRecortar2
            // 
            this.pbRecortar2.Location = new System.Drawing.Point(396, 27);
            this.pbRecortar2.Name = "pbRecortar2";
            this.pbRecortar2.Size = new System.Drawing.Size(172, 240);
            this.pbRecortar2.TabIndex = 0;
            this.pbRecortar2.TabStop = false;
            this.pbRecortar2.Click += new System.EventHandler(this.pbRecortar2_Click);
            this.pbRecortar2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbRecortar2_MouseDown);
            this.pbRecortar2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbRecortar2_MouseUp);
            // 
            // Recortar
            // 
            this.Recortar.BackColor = System.Drawing.Color.Transparent;
            this.Recortar.BackgroundColor = System.Drawing.Color.Transparent;
            this.Recortar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Recortar.BorderRadius = 10;
            this.Recortar.BorderSize = 2;
            this.Recortar.FlatAppearance.BorderSize = 0;
            this.Recortar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Recortar.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.Recortar.Location = new System.Drawing.Point(12, 122);
            this.Recortar.Name = "Recortar";
            this.Recortar.Size = new System.Drawing.Size(150, 40);
            this.Recortar.TabIndex = 3;
            this.Recortar.Text = "Recortar";
            this.Recortar.TextColor = System.Drawing.Color.PaleVioletRed;
            this.Recortar.UseVisualStyleBackColor = false;
            this.Recortar.Click += new System.EventHandler(this.Recortar_Click);
            // 
            // Aceptar
            // 
            this.Aceptar.BackColor = System.Drawing.Color.Transparent;
            this.Aceptar.BackgroundColor = System.Drawing.Color.Transparent;
            this.Aceptar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Aceptar.BorderRadius = 10;
            this.Aceptar.BorderSize = 2;
            this.Aceptar.FlatAppearance.BorderSize = 0;
            this.Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Aceptar.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.Aceptar.Location = new System.Drawing.Point(12, 207);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(150, 40);
            this.Aceptar.TabIndex = 4;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.TextColor = System.Drawing.Color.PaleVioletRed;
            this.Aceptar.UseVisualStyleBackColor = false;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.Transparent;
            this.rjButton1.BackgroundColor = System.Drawing.Color.Transparent;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 10;
            this.rjButton1.BorderSize = 2;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.Location = new System.Drawing.Point(12, 39);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(150, 40);
            this.rjButton1.TabIndex = 5;
            this.rjButton1.Text = "Desasher";
            this.rjButton1.TextColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.UseVisualStyleBackColor = false;
            // 
            // Recorte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1101, 697);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.Recortar);
            this.Controls.Add(this.pbRecortar2);
            this.Name = "Recorte";
            this.Text = "Recorte";
            ((System.ComponentModel.ISupportInitialize)(this.pbRecortar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRecortar2;
        private Resources.RJButton Recortar;
        private Resources.RJButton Aceptar;
        private Resources.RJButton rjButton1;
    }
}