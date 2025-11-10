using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HealthRunner.Administrador
{
    public partial class FrmRegistroAdmin : Form
    {
        // 🔹 Agregar cadena de conexión (ajusta el Data Source si tu servidor es distinto)
        string cadenaConexion = "Data Source=GUERRERO;Initial Catalog=HealthRunnerDB;Integrated Security=True;TrustServerCertificate=True";

        public FrmRegistroAdmin()
        {
            InitializeComponent();

            cmbGenero.Items.Clear();
            cmbGenero.Items.Add("Seleccione su género");
            cmbGenero.Items.Add("Masculino");
            cmbGenero.Items.Add("Femenino");
            cmbGenero.Items.Add("Otro");
            cmbGenero.SelectedIndex = 0;
        }

        private void FrmRegistroAdmin_Load(object sender, EventArgs e)
        {
            txtRol.Text = "Administrador";
            txtRol.ReadOnly = true;
            txtRol.ForeColor = Color.DarkGreen;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ActiveControl = null;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtPassword.Clear();
            txtConfirmar.Clear();
            txtTelefono.Clear();
            cmbGenero.SelectedIndex = 0;
            dateTimeFecha.Value = DateTime.Now;
            this.ActiveControl = null;
        }

        private bool EsCorreoValido(string correo)
        {
            return Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe ingresar el nombre completo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text) || !EsCorreoValido(txtCorreo.Text))
            {
                MessageBox.Show("Ingrese un correo electrónico válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmar.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text) || !Regex.IsMatch(txtTelefono.Text, @"^\d+$"))
            {
                MessageBox.Show("Ingrese un número de teléfono válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            if (cmbGenero.SelectedIndex == -1 || cmbGenero.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione el género.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGenero.Focus();
                return;
            }

            // Inserción en la tabla Usuarios usando los nombres reales de columnas
            try
            {
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string query = @"
                        INSERT INTO Usuarios
                        (NombreCompleto, CorreoElectronico, Contrasena, FechaNacimiento, Genero, Telefono, IdRol)
                        VALUES
                        (@NombreCompleto, @CorreoElectronico, @Contrasena, @FechaNacimiento, @Genero, @Telefono, 1)";

                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@NombreCompleto", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@CorreoElectronico", txtCorreo.Text.Trim());
                        cmd.Parameters.AddWithValue("@Contrasena", txtPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@FechaNacimiento", dateTimeFecha.Value.Date);
                        cmd.Parameters.AddWithValue("@Genero", cmbGenero.Text);
                        cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }

                string mensaje = $"Administrador registrado exitosamente.\n\n" +
                                 $"👤 Nombre: {txtNombre.Text}\n" +
                                 $"📧 Correo: {txtCorreo.Text}\n" +
                                 $"📞 Teléfono: {txtTelefono.Text}\n" +
                                 $"⚧ Género: {cmbGenero.Text}\n" +
                                 $"🎯 Rol: {txtRol.Text}\n" +
                                 $"📅 Fecha Nacimiento: {dateTimeFecha.Value.ToShortDateString()}";

                MessageBox.Show(mensaje, "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Error SQL al registrar el administrador:\n{sqlEx.Message}", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el administrador:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            MessageBox.Show("Campos limpiados correctamente.", "HealthRunner", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea volver al inicio de sesión?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FrmInicio frmInicio = new FrmInicio();
                frmInicio.Show();
                this.Hide();
            }
        }
    }
}