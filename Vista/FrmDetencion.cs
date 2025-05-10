using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Conexiones;

namespace WindowsFormsApp1
{
    public partial class FrmDetencion : Form
    {


        private int _idEstudianteSeleccionado;

        public FrmDetencion(int idEstudiante) 
        {
            InitializeComponent();
            _idEstudianteSeleccionado = idEstudiante;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmDetencion_Load(object sender, EventArgs e)
        {
            ComboTipo.Items.AddRange(new string[] { "Leve", "Grave" });
            comboEstado.Items.AddRange(new string[] { "Abierta", "Cerrada" });
            CargarDetenciones();

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            try
            {
                using (var conn = Conexion.Conectar())
                {
                    MySqlCommand cmd = new MySqlCommand("RegistrarDetencion", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_fecha", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("p_motivo", txtMotivo.Text);
                    cmd.Parameters.AddWithValue("p_tipo", ComboTipo.Text);
                    cmd.Parameters.AddWithValue("p_estado", comboEstado.Text);

                    cmd.Parameters.AddWithValue("p_id_estudiante", _idEstudianteSeleccionado);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("¡Detención registrada con éxito!");

                    CargarDetenciones();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message);
            }
        }

        private void CargarDetenciones()
        {
            try
            {
                using (var conn = Conexion.Conectar())
                {
                    MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM Detenciones", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar detenciones: " + ex.Message);
            }
        }

       
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = Conexion.Conectar())
                {
                    MySqlCommand cmd = new MySqlCommand("ActualizarDetencion", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("p_id_detencion", Convert.ToInt32(txtIdDetencion.Text));
                    cmd.Parameters.AddWithValue("p_fecha", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("p_motivo", txtMotivo.Text);
                    cmd.Parameters.AddWithValue("p_tipo", ComboTipo.Text);
                    cmd.Parameters.AddWithValue("p_estado", comboEstado.Text);
                    cmd.Parameters.AddWithValue("p_id_estudiante", _idEstudianteSeleccionado); 

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("¡Detención actualizada con éxito!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {


                using (var conn = new MySqlConnection("server=localhost;database=SchoolBD;uid=root;pwd=;"))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("ConsultarDetencion", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (!string.IsNullOrEmpty(txtIdDetencion.Text))
                        {
                            cmd.Parameters.AddWithValue("p_id_detencion", Convert.ToInt32(txtIdDetencion.Text));
                        }


                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dt;

                                DataRow row = dt.Rows[0];
                                dateTimePicker1.Value = Convert.ToDateTime(row["fecha"]);
                                txtMotivo.Text = row["motivo"].ToString();
                                ComboTipo.Text = row["tipo"].ToString();
                                comboEstado.Text = row["estado"].ToString();


                            }
                            else
                            {
                                MessageBox.Show("No se encontraron detenciones.");
                                dataGridView1.DataSource = null;
                            }
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Los IDs deben ser números válidos.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error de base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}");
            }
        }



        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtIdDetencion.Clear();
            txtMotivo.Clear();
            ComboTipo.SelectedIndex = -1;
            comboEstado.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Today;
            dataGridView1.DataSource = null;
        }

        private void btnVolverEstudiante_Click(object sender, EventArgs e)
        {
            FrmEstudiante frmEstudiante = new FrmEstudiante();
            frmEstudiante.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
    }
}

