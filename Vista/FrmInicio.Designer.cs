namespace WindowsFormsApp1.Vista
{
    partial class FrmInicio
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
            this.btnGestion = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGestion
            // 
            this.btnGestion.Location = new System.Drawing.Point(257, 100);
            this.btnGestion.Name = "btnGestion";
            this.btnGestion.Size = new System.Drawing.Size(276, 67);
            this.btnGestion.TabIndex = 0;
            this.btnGestion.Text = "Gestion";
            this.btnGestion.UseVisualStyleBackColor = true;
            this.btnGestion.Click += new System.EventHandler(this.btnGestion_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(257, 277);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(276, 72);
            this.btnReportes.TabIndex = 1;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(815, 484);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnGestion);
            this.Name = "FrmInicio";
            this.Text = "FrmInicio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGestion;
        private System.Windows.Forms.Button btnReportes;
    }
}