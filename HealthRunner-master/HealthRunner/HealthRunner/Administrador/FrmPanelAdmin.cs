using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthRunner.Administrador
{
    public partial class FrmPanelAdmin : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=HealthRunnerDB;Integrated Security=True";

        public FrmPanelAdmin()
        {
            InitializeComponent();
        }

        private void FrmPanelAdmin_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        // 🔹 Cargar lista de usuarios en el DataGridView
        private void CargarUsuarios()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT u.IdUsuario, u.NombreCompleto AS NOMBRE, 
                               u.CorreoElectronico AS CORREO,
                               r.NombreRol AS ROL,
                               u.Genero AS GÉNERO,
                               u.Telefono AS TELÉFONO
                        FROM Usuarios u
                        INNER JOIN Roles r ON u.IdRol = r.IdRol";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvUsuarios.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerdetalle_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario primero.", "HealthRunner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nombre = dgvUsuarios.SelectedRows[0].Cells["NOMBRE"].Value.ToString();
            string correo = dgvUsuarios.SelectedRows[0].Cells["CORREO"].Value.ToString();
            string rol = dgvUsuarios.SelectedRows[0].Cells["ROL"].Value.ToString();
            string genero = dgvUsuarios.SelectedRows[0].Cells["GÉNERO"].Value.ToString();
            string telefono = dgvUsuarios.SelectedRows[0].Cells["TELÉFONO"].Value.ToString();

            MessageBox.Show($"👤 Nombre: {nombre}\n📧 Correo: {correo}\n🎭 Rol: {rol}\n⚧ Género: {genero}\n📱 Teléfono: {telefono}",
                            "Detalle del usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmRegistroAdmin frm = new FrmRegistroAdmin();
            frm.Show();
            this.Hide();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario para editar.", "HealthRunner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["IdUsuario"].Value);
            string nuevoTelefono = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nuevo número de teléfono:", "Editar Usuario");

            if (string.IsNullOrWhiteSpace(nuevoTelefono)) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Usuarios SET Telefono = @telefono WHERE IdUsuario = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@telefono", nuevoTelefono);
                    cmd.Parameters.AddWithValue("@id", idUsuario);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("✅ Usuario actualizado correctamente.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar usuario:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un usuario para eliminar.", "HealthRunner", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("¿Deseas eliminar este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["IdUsuario"].Value);

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Usuarios WHERE IdUsuario = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", idUsuario);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("🗑️ Usuario eliminado correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar usuario:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
            MessageBox.Show("🔄 Datos actualizados correctamente.", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FrmInicio frmInicio = new FrmInicio();
            frmInicio.Show();
            this.Hide();
        }

        private void FrmPanelAdmin_Load_1(object sender, EventArgs e)
        {

        }
    }
}