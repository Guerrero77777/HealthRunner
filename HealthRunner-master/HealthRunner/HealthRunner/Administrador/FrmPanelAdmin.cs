using HealthRunner.Model;
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
        public FrmPanelAdmin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ActiveControl = null;

            // Asegura que los eventos estén conectados
            this.Load += new System.EventHandler(this.FrmPanelAdmin_Load);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
        }

        private void FrmPanelAdmin_Load(object sender, EventArgs e)
        {
            ConfigurarControles();
            CargarUsuarios();
        }

        private void ConfigurarControles()
        {
            // Habilita todos los botones
            btnBuscar.Enabled = true;
            btnVerdetalle.Enabled = true;
            btnAgregar.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
            btnActualizar.Enabled = true;
            btnVolver.Enabled = true;
            txtBuscar.Enabled = true;

            // Ajustes del DataGridView
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.ReadOnly = true;
        }

        private void CargarUsuarios(string filtro = "")
        {
            try
            {
                using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
                {
                    // Consulta: muestra todos los usuarios (incluyendo administradores)
                    string query = @"
                        SELECT 
                            u.NombreCompleto AS NOMBRE,
                            u.CorreoElectronico AS CORREO,
                            r.NombreRol AS ROL,
                            u.Genero AS GENERO,
                            u.Telefono AS TELEFONO
                        FROM Usuarios u
                        LEFT JOIN Roles r ON u.IdRol = r.IdRol";

                    // Si hay filtro, se aplica a nombre o correo
                    if (!string.IsNullOrEmpty(filtro))
                    {
                        query += " WHERE u.NombreCompleto LIKE @filtro OR u.CorreoElectronico LIKE @filtro";
                    }

                    SqlCommand cmd = new SqlCommand(query, cn);

                    if (!string.IsNullOrEmpty(filtro))
                    {
                        cmd.Parameters.AddWithValue("@filtro", $"%{filtro}%");
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Limpia antes de asignar para evitar duplicaciones
                    dgvUsuarios.DataSource = null;
                    dgvUsuarios.Rows.Clear();
                    dgvUsuarios.Columns.Clear();

                    dgvUsuarios.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los usuarios: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Búsqueda en tiempo real mientras el usuario escribe
            CargarUsuarios(txtBuscar.Text.Trim());
        }  
              
     

        private void btnVerdetalle_Click_1(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                string nombre = dgvUsuarios.SelectedRows[0].Cells["NOMBRE"].Value.ToString();
                string correo = dgvUsuarios.SelectedRows[0].Cells["CORREO"].Value.ToString();
                string rol = dgvUsuarios.SelectedRows[0].Cells["ROL"].Value.ToString();
                string genero = dgvUsuarios.SelectedRows[0].Cells["GENERO"].Value.ToString();
                string telefono = dgvUsuarios.SelectedRows[0].Cells["TELEFONO"].Value.ToString();

                string mensaje = $"👤 Nombre: {nombre}\n📧 Correo: {correo}\n🎯 Rol: {rol}\n⚧ Género: {genero}\n📞 Teléfono: {telefono}";
                MessageBox.Show(mensaje, "Detalles del Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para ver los detalles.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            FrmRegistroAdmin frm = new FrmRegistroAdmin();
            frm.Show();
            this.Hide();
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                string correo = dgvUsuarios.SelectedRows[0].Cells["CORREO"].Value.ToString();

                DialogResult result = MessageBox.Show($"¿Desea editar la información de {correo}?",
                                                      "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    FrmRegistroAdmin frm = new FrmRegistroAdmin();
                    frm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para editar.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                string correo = dgvUsuarios.SelectedRows[0].Cells["CORREO"].Value.ToString();

                DialogResult result = MessageBox.Show($"¿Desea eliminar al usuario {correo}?",
                                                      "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
                        {
                            string query = "DELETE FROM Usuarios WHERE CorreoElectronico = @correo";
                            SqlCommand cmd = new SqlCommand(query, cn);
                            cmd.Parameters.AddWithValue("@correo", correo);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Usuario eliminado correctamente.",
                                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarUsuarios();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar: {ex.Message}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para eliminar.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            CargarUsuarios();
            MessageBox.Show("Lista de usuarios actualizada correctamente.",
                            "HealthRunner", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea volver al inicio de sesión?",
                                                  "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                FrmInicio frm = new FrmInicio();
                frm.Show();
                this.Hide();
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();
            CargarUsuarios(filtro);
        }
    }
}