namespace WindowsFormsApp1.Vista
{
    partial class FrmReporteTop5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReporteTop5));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnImprimirTodos = new System.Windows.Forms.Button();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControlReportes = new System.Windows.Forms.TabControl();
            this.tabTop5 = new System.Windows.Forms.TabPage();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dtpFechaTop5 = new System.Windows.Forms.DateTimePicker();
            this.btnGenerarTop5 = new System.Windows.Forms.Button();
            this.btnImprimirTop5 = new System.Windows.Forms.Button();
            this.dgvTop5 = new System.Windows.Forms.DataGridView();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocumento = new System.Drawing.Printing.PrintDocument();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog3 = new System.Windows.Forms.PrintPreviewDialog();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.tabControlReportes.SuspendLayout();
            this.tabTop5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop5)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnImprimirTodos);
            this.tabPage2.Controls.Add(this.dgvReporte);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 610);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Todos con Detenciones ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnImprimirTodos
            // 
            this.btnImprimirTodos.Location = new System.Drawing.Point(634, 284);
            this.btnImprimirTodos.Name = "btnImprimirTodos";
            this.btnImprimirTodos.Size = new System.Drawing.Size(75, 41);
            this.btnImprimirTodos.TabIndex = 2;
            this.btnImprimirTodos.Text = "Imprimir";
            this.btnImprimirTodos.UseVisualStyleBackColor = true;
            this.btnImprimirTodos.Click += new System.EventHandler(this.btnImprimirTodos_Click);
            // 
            // dgvReporte
            // 
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(3, 0);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.RowHeadersWidth = 62;
            this.dgvReporte.RowTemplate.Height = 28;
            this.dgvReporte.Size = new System.Drawing.Size(567, 607);
            this.dgvReporte.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(606, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 81);
            this.button1.TabIndex = 0;
            this.button1.Text = "GenerarTodos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControlReportes
            // 
            this.tabControlReportes.Controls.Add(this.tabTop5);
            this.tabControlReportes.Controls.Add(this.tabPage2);
            this.tabControlReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlReportes.Location = new System.Drawing.Point(0, 0);
            this.tabControlReportes.Name = "tabControlReportes";
            this.tabControlReportes.SelectedIndex = 0;
            this.tabControlReportes.Size = new System.Drawing.Size(800, 643);
            this.tabControlReportes.TabIndex = 0;
            // 
            // tabTop5
            // 
            this.tabTop5.Controls.Add(this.btnVolver);
            this.tabTop5.Controls.Add(this.dtpFechaTop5);
            this.tabTop5.Controls.Add(this.btnGenerarTop5);
            this.tabTop5.Controls.Add(this.btnImprimirTop5);
            this.tabTop5.Controls.Add(this.dgvTop5);
            this.tabTop5.Location = new System.Drawing.Point(4, 29);
            this.tabTop5.Name = "tabTop5";
            this.tabTop5.Padding = new System.Windows.Forms.Padding(3);
            this.tabTop5.Size = new System.Drawing.Size(792, 610);
            this.tabTop5.TabIndex = 0;
            this.tabTop5.Text = "Top 5 Detenciones";
            this.tabTop5.UseVisualStyleBackColor = true;
            this.tabTop5.Click += new System.EventHandler(this.tabTop5_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(554, 383);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(137, 35);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dtpFechaTop5
            // 
            this.dtpFechaTop5.Location = new System.Drawing.Point(485, 94);
            this.dtpFechaTop5.Name = "dtpFechaTop5";
            this.dtpFechaTop5.Size = new System.Drawing.Size(301, 26);
            this.dtpFechaTop5.TabIndex = 7;
            // 
            // btnGenerarTop5
            // 
            this.btnGenerarTop5.Location = new System.Drawing.Point(554, 155);
            this.btnGenerarTop5.Name = "btnGenerarTop5";
            this.btnGenerarTop5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGenerarTop5.Size = new System.Drawing.Size(137, 33);
            this.btnGenerarTop5.TabIndex = 6;
            this.btnGenerarTop5.Text = "GenerarTop5";
            this.btnGenerarTop5.UseVisualStyleBackColor = true;
            this.btnGenerarTop5.Click += new System.EventHandler(this.btnGenerarTop5_Click);
            // 
            // btnImprimirTop5
            // 
            this.btnImprimirTop5.Location = new System.Drawing.Point(554, 244);
            this.btnImprimirTop5.Name = "btnImprimirTop5";
            this.btnImprimirTop5.Size = new System.Drawing.Size(137, 38);
            this.btnImprimirTop5.TabIndex = 3;
            this.btnImprimirTop5.Text = "Imprimir";
            this.btnImprimirTop5.UseVisualStyleBackColor = true;
            this.btnImprimirTop5.Click += new System.EventHandler(this.btnImprimirTop5_Click);
            // 
            // dgvTop5
            // 
            this.dgvTop5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTop5.Location = new System.Drawing.Point(-4, 0);
            this.dgvTop5.Name = "dgvTop5";
            this.dgvTop5.RowHeadersWidth = 62;
            this.dgvTop5.RowTemplate.Height = 28;
            this.dgvTop5.Size = new System.Drawing.Size(452, 453);
            this.dgvTop5.TabIndex = 2;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocumento
            // 
            this.printDocumento.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocumento_PrintPage_1);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog3
            // 
            this.printPreviewDialog3.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog3.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog3.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog3.Enabled = true;
            this.printPreviewDialog3.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog3.Icon")));
            this.printPreviewDialog3.Name = "printPreviewDialog3";
            this.printPreviewDialog3.Visible = false;
            this.printPreviewDialog3.Load += new System.EventHandler(this.printPreviewDialog3_Load);
            // 
            // FrmReporteTop5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 643);
            this.Controls.Add(this.tabControlReportes);
            this.Name = "FrmReporteTop5";
            this.Text = "FrmReporte";
            this.Load += new System.EventHandler(this.FrmReporteTop5_Load);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.tabControlReportes.ResumeLayout(false);
            this.tabTop5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControlReportes;
        private System.Windows.Forms.TabPage tabTop5;
        private System.Windows.Forms.Button btnImprimirTop5;
        private System.Windows.Forms.DataGridView dgvTop5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnImprimirTodos;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Button btnGenerarTop5;
        private System.Windows.Forms.DateTimePicker dtpFechaTop5;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocumento;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog3;
    }
}