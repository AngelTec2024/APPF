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
            this.btnRecortar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
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
            this.pbRecortar2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbRecortar2_MouseDown);
            this.pbRecortar2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbRecortar2_MouseUp);
            // 
            // btnRecortar
            // 
            this.btnRecortar.Location = new System.Drawing.Point(76, 63);
            this.btnRecortar.Name = "btnRecortar";
            this.btnRecortar.Size = new System.Drawing.Size(75, 23);
            this.btnRecortar.TabIndex = 1;
            this.btnRecortar.Text = "button1";
            this.btnRecortar.UseVisualStyleBackColor = true;
            this.btnRecortar.Click += new System.EventHandler(this.btnRecortar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(76, 148);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(75, 23);
            this.btnRegresar.TabIndex = 2;
            this.btnRegresar.Text = "button2";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // Recorte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1101, 697);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnRecortar);
            this.Controls.Add(this.pbRecortar2);
            this.Name = "Recorte";
            this.Text = "Recorte";
            ((System.ComponentModel.ISupportInitialize)(this.pbRecortar2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRecortar2;
        private System.Windows.Forms.Button btnRecortar;
        private System.Windows.Forms.Button btnRegresar;
    }
}