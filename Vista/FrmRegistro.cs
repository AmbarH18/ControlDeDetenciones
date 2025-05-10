using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Conexiones;

namespace WindowsFormsApp1
{
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
        }
        private void CargarEstudiantes()
        {
            try
            {
                using (var conn = Conexion.Conectar())
               
                {
                    string query = "SELECT id_estudiante, nombre FROM estudiante";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cboEstudiante.DataSource = dt;
                    cboEstudiante.DisplayMember = "nombre";
                    cboEstudiante.ValueMember = "id_estudiante";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estudiantes: " + ex.Message);
            }
        }

        private void CargarDetenciones()
        {
            try
            {
                using (var conn = Conexion.Conectar())
                {
                    string query = "SELECT id_detencion, motivo FROM detenciones";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboDetencion.DataSource = dt;
                    cboDetencion.DisplayMember = "motivo";       
                    cboDetencion.ValueMember = "id_detencion";   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detenciones: " + ex.Message);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = Conexion.Conectar())
                {
                    MySqlCommand cmd = new MySqlCommand("Registro", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_fecha", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("p_estudiante", cboEstudiante.SelectedValue);
                    cmd.Parameters.AddWithValue("p_detencion", cboDetencion.SelectedValue);
                    cmd.Parameters.AddWithValue("p_usuario", "Ambar");

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("¡Registrado con éxito!");


                    CargarData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message);
            }
        }
       

        private void FrmRegistro_Load(object sender, EventArgs e)
        {
            CargarData();
            CargarEstudiantes();
            CargarDetenciones();

        }
        private void CargarData()
        {

            string sql = @"SELECT 
                                e.id_estudiante, 
                                e.nombre, 
                                c.Nivel, 
                                c.Descripcion, 
                                IFNULL(rd.id_registro, 0) AS id_registro,
                                IFNULL(d.motivo, '') AS motivo,
                                IFNULL(d.tipo, '') AS tipo,
                                IFNULL(rd.fecha, '') AS fecha,
                                IFNULL(rd.usuario, '') AS usuario
                            FROM estudiante e
                            INNER JOIN curso c ON e.id_curso = c.Id_Curso
                            INNER JOIN registro_detencion rd ON rd.id_estudiante = e.id_estudiante
                            INNER JOIN detenciones d ON d.id_detencion = rd.id_detencion;";

            using (var conn = Conexion.Conectar())
            {
                try
                {

                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CargarData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = Conexion.Conectar())
                {
                    MySqlCommand cmd = new MySqlCommand("ConsultarDetencionesPorEstudiante", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_id_estudiante", cboEstudiante.SelectedValue);

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ninguna retenciones.");
                            dataGridView1.DataSource = null;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        private void btnVolverEstudiante_Click(object sender, EventArgs e)
        {
            FrmEstudiante frmEstudiante = new FrmEstudiante();
            frmEstudiante.Show();
            this.Hide();
        }
    }
}
