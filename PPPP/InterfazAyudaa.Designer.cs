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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InterfazAyudaa));
            this.btnRegresar = new PPPP.Resources.RJButton();
            this.p1 = new System.Windows.Forms.PictureBox();
            this.pb2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.p1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
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
            this.p1.Location = new System.Drawing.Point(195, 12);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(662, 381);
            this.p1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1.TabIndex = 1;
            this.p1.TabStop = false;
            // 
            // pb2
            // 
            this.pb2.Image = ((System.Drawing.Image)(resources.GetObject("pb2.Image")));
            this.pb2.Location = new System.Drawing.Point(195, 428);
            this.pb2.Name = "pb2";
            this.pb2.Size = new System.Drawing.Size(662, 370);
            this.pb2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb2.TabIndex = 3;
            this.pb2.TabStop = false;
            // 
            // InterfazAyudaa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1313, 870);
            this.Controls.Add(this.pb2);
            this.Controls.Add(this.p1);
            this.Controls.Add(this.btnRegresar);
            this.Name = "InterfazAyudaa";
            this.Text = "Ayuda";
            ((System.ComponentModel.ISupportInitialize)(this.p1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Resources.RJButton btnRegresar;
        private System.Windows.Forms.PictureBox p1;
        private System.Windows.Forms.PictureBox pb2;
    }
}