using System;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Conexiones;

namespace WindowsFormsApp1.Vista
{
    public partial class FrmReporteTop5 : Form
    {
        public FrmReporteTop5()
        {
            InitializeComponent();
        }

        private void btnGenerarTop5_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFechaTop5.Value;

            string consulta = @"
                                SELECT e.nombre AS 'Nombre del Estudiante', COUNT(r.id_detencion) AS 'Cantidad de Detenciones'
                                FROM registro_detencion r
                                inner JOIN estudiante e ON e.id_estudiante = r.id_estudiante
                                WHERE DATE(r.fecha) = @fecha
                                GROUP BY e.id_estudiante
                                ORDER BY COUNT(r.id_detencion) DESC
                                LIMIT 5;
                                    ";

            using (var conn = Conexion.Conectar())
            {
                try
                {



                    MySqlCommand cmd = new MySqlCommand(consulta, conn);
                    cmd.Parameters.AddWithValue("@fecha", fecha.ToString("yyyy-MM-dd"));

                    MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);


                    dgvTop5.DataSource = tabla;


                    if (tabla.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay datos para esa fecha.");
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al consultar: " + ex.Message);
                }
            }
        }

        private void dtpFechaTop5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmReporteTop5_Load(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmInicio frm = new FrmInicio();
            frm.ShowDialog();
            this.Close();
        }

        private void tabTop5_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimirTop5_Click(object sender, EventArgs e)

        {
            printDocumento.DocumentName = "Reporte Top 5";
            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = printDocumento;
            preview.ShowDialog();
        }


        private void printDocumento_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int margenIzquierdo = 60;
            int margenSuperior = 100;
            int anchoColumna = 300;
            int altoFila = 50;

            Font fuenteTitulo = new Font("Arial", 20, FontStyle.Bold);
            Font fuenteCabecera = new Font("Arial", 14, FontStyle.Bold);
            Font fuenteDatos = new Font("Arial", 13);

           
            string titulo = "Top 5 Estudiantes con Más Detenciones";
            SizeF sizeTitulo = e.Graphics.MeasureString(titulo, fuenteTitulo);
            float xTitulo = (e.PageBounds.Width - sizeTitulo.Width) / 2;
            e.Graphics.DrawString(titulo, fuenteTitulo, Brushes.Black, xTitulo, 40);

            int x = margenIzquierdo;
            int y = margenSuperior;

          
            for (int i = 0; i < dgvTop5.Columns.Count; i++)
            {
                e.Graphics.FillRectangle(Brushes.LightGray, x + i * anchoColumna, y, anchoColumna, altoFila);
                e.Graphics.DrawRectangle(Pens.Black, x + i * anchoColumna, y, anchoColumna, altoFila);
                e.Graphics.DrawString(dgvTop5.Columns[i].HeaderText, fuenteCabecera, Brushes.Black, x + i * anchoColumna + 10, y + 15);
            }

            y += altoFila;

         
            for (int i = 0; i < dgvTop5.Rows.Count; i++)
            {
                for (int j = 0; j < dgvTop5.Columns.Count; j++)
                {
                    if (dgvTop5.Rows[i].Cells[j].Value != null)
                    {
                        e.Graphics.DrawRectangle(Pens.Black, x + j * anchoColumna, y, anchoColumna, altoFila);
                        e.Graphics.DrawString(dgvTop5.Rows[i].Cells[j].Value.ToString(), fuenteDatos, Brushes.Black, x + j * anchoColumna + 10, y + 15);
                    }
                }

                y += altoFila;

                if (y > e.MarginBounds.Bottom - altoFila)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query =  @"SELECT e.Nombre, COUNT(r.id_detencion) AS 'Cantidad'
                            FROM registro_detencion r
                            INNER JOIN Estudiante e
                            ON r.id_estudiante = e.id_estudiante
                            GROUP BY e.id_estudiante
                            ORDER BY COUNT(r.id_detencion) DESC";


            using (var conn = Conexion.Conectar())
            {

                DataTable dt = new DataTable();
                using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                {
                    da.Fill(dt);
                }


                dgvReporte.DataSource = dt;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int x = 50;
            int y = 100;
            int anchoColumna = 200;
            int altoFila = 30;

            Font fuenteTitulo = new Font("Arial", 16, FontStyle.Bold);
            Font fuenteCeldas = new Font("Arial", 12);

            e.Graphics.DrawString("Reporte de Detenciones", fuenteTitulo, Brushes.Black, x, 40);

            
            for (int i = 0; i < dgvReporte.Columns.Count; i++)
            {
                e.Graphics.FillRectangle(Brushes.LightGray, x + i * anchoColumna, y, anchoColumna, altoFila);
                e.Graphics.DrawRectangle(Pens.Black, x + i * anchoColumna, y, anchoColumna, altoFila);
                e.Graphics.DrawString(dgvReporte.Columns[i].HeaderText, fuenteCeldas, Brushes.Black, x + i * anchoColumna + 5, y + 5);
            }

            y += altoFila;

           
            for (int i = 0; i < dgvReporte.Rows.Count; i++)
            {
                for (int j = 0; j < dgvReporte.Columns.Count; j++)
                {
                    if (dgvReporte.Rows[i].Cells[j].Value != null)
                    {
                        e.Graphics.DrawRectangle(Pens.Black, x + j * anchoColumna, y, anchoColumna, altoFila);
                        e.Graphics.DrawString(dgvReporte.Rows[i].Cells[j].Value.ToString(), fuenteCeldas, Brushes.Black, x + j * anchoColumna + 5, y + 5);
                    }
                }

                y += altoFila;

                
                if (y > e.MarginBounds.Bottom - altoFila)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            e.HasMorePages = false;
        }
        

        private void printPreviewDialog3_Load(object sender, EventArgs e)
        {

        }

        private void btnImprimirTodos_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }

}



