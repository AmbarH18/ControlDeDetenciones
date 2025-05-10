using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Conexiones;
using WindowsFormsApp1.Vista;

namespace WindowsFormsApp1
{
    public partial class FrmEstudiante : Form
    {
        private readonly string connectionString = "server=localhost;database=SchoolBD;uid=root;pwd=;";

        public FrmEstudiante()
        {
            InitializeComponent();
        }
        private void FrmEstudiante_Load(object sender, EventArgs e)
        {
            CargarEstudiante();
        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtMatricula.Text) ||
                string.IsNullOrWhiteSpace(txtEdad.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtUID.Text) ||
                string.IsNullOrWhiteSpace(txtcurso.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            if (!int.TryParse(txtEdad.Text, out int edad))
            {
                MessageBox.Show("Edad inválida.");
                return;
            }

            try
            {
                using (var conn = Conexion.Conectar())
                {
                    using (MySqlCommand cmd = new MySqlCommand("RegistrarEstudiante", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("p_matricula", txtMatricula.Text);
                        cmd.Parameters.AddWithValue("p_edad", edad);
                        cmd.Parameters.AddWithValue("p_telefono", txtTelefono.Text);
                        cmd.Parameters.AddWithValue("p_uid", txtUID.Text);
                        cmd.Parameters.AddWithValue("p_curso", txtcurso.Text);

                        cmd.ExecuteNonQuery(); 
                        MessageBox.Show("¡Estudiante registrado exitosamente!");
                    }
                }

                CargarEstudiante();
            }
            catch (MySqlException sqlEx)
            {
                MessageBox.Show("Error de MySQL: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general: " + ex.Message);
            }


        }

        private void CargarEstudiante()
        {
            try
            {
                using (var conn = Conexion.Conectar())
                {
                    using (MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM Estudiante", conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estudiantes: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdEstudiante.Text))
            {
                MessageBox.Show("Por favor ingresa un ID de estudiante.");
                return;
            }

            try
            {
                using (var conn = Conexion.Conectar())
                {
                    using (MySqlCommand cmd = new MySqlCommand("ActualizarEstudiante", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("p_id", Convert.ToInt32(txtIdEstudiante.Text));
                        cmd.Parameters.AddWithValue("p_nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("p_matricula", txtMatricula.Text);
                        cmd.Parameters.AddWithValue("p_edad", Convert.ToInt32(txtEdad.Text));
                        cmd.Parameters.AddWithValue("p_telefono", txtTelefono.Text);
                        cmd.Parameters.AddWithValue("p_uid", txtUID.Text);
                        cmd.Parameters.AddWithValue("p_curso", txtcurso.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("¡Estudiante actualizado correctamente!");
                    }
                }

                CargarEstudiante();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdEstudiante.Text) && string.IsNullOrEmpty(txtMatricula.Text))
            {
                MessageBox.Show("Por favor, ingrese el ID o la matrícula del estudiante.");
                return;
            }

            try
            {
                using (var conn = Conexion.Conectar())
                {
                    string procedimiento = !string.IsNullOrEmpty(txtIdEstudiante.Text)
                        ? "ConsultarEstudiante"
                        : "ConsultarEstudiantePorMatricula";

                    using (MySqlCommand cmd = new MySqlCommand(procedimiento, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (!string.IsNullOrEmpty(txtIdEstudiante.Text))
                        {
                            cmd.Parameters.AddWithValue("p_id_estudiante", Convert.ToInt32(txtIdEstudiante.Text));
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("p_matricula", txtMatricula.Text);
                        }

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
                                MessageBox.Show("No se encontró ningún estudiante.");
                                dataGridView1.DataSource = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtIdEstudiante.Clear();
            txtNombre.Clear();
            txtMatricula.Clear();
            txtEdad.Clear();
            txtTelefono.Clear();
            txtUID.Clear();
            txtcurso.Clear();
            dataGridView1.DataSource = null;
        }
        private void EstiloTablaEstudiantes()
        {
            dataGridView1.Columns["id_estudiante"].HeaderText = "ID";
            dataGridView1.Columns["nombre"].HeaderText = "Nombre";
            dataGridView1.Columns["apellido"].HeaderText = "Apellido";
            dataGridView1.Columns["curso"].HeaderText = "Curso";
            dataGridView1.Columns["email"].HeaderText = "Email";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
        }

        private void btnIrADetencion_Click(object sender, EventArgs e)
        {
            FrmDetencion frm = new FrmDetencion(0); 
            frm.Show();
            this.Hide();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRegistro frmRegistro = new FrmRegistro();
            frmRegistro.Show();
            this.Hide();
        }

    }
}