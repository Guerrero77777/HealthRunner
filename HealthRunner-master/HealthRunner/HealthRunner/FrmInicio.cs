using HealthRunner.Administrador;
using HealthRunner.Model;
using HealthRunner.Models;
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

namespace HealthRunner
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();

            SetPlaceholder(txtCorreo, "Ingrese su correo electrónico");
            SetPlaceholder(txtPassword, "Ingrese su contraseña");

            this.Shown += FrmInicio_Shown;
            this.Load += FrmInicio_Load;
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void FrmInicio_Shown(object sender, EventArgs e)
        {
            BeginInvoke((Action)(() => this.ActiveControl = null));
        }

        private void SetPlaceholder(TextBox txt, string placeholder)
        {
            txt.Text = placeholder;
            txt.ForeColor = Color.Gray;

            txt.Enter += (sender, e) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                    if (txt == txtPassword)
                        txt.UseSystemPasswordChar = true;
                }
            };

            txt.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                    if (txt == txtPassword)
                        txt.UseSystemPasswordChar = false;
                }
            };

            if (txt == txtPassword)
                txt.UseSystemPasswordChar = false;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCorreo.Text) || txtCorreo.Text == "Ingrese su correo electrónico")
            {
                MessageBox.Show("Por favor, ingrese su correo electrónico.", "HealthRunner", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text == "Ingrese su contraseña")
            {
                MessageBox.Show("Por favor, ingrese su contraseña.", "HealthRunner", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = ConexionDB.Instancia.ObtenerConexion())
                {
                    string query = @"
                        SELECT TOP 1 
                            u.IdUsuario, 
                            u.NombreCompleto, 
                            u.CorreoElectronico, 
                            u.Contrasena, 
                            u.FechaNacimiento,
                            u.Genero, 
                            u.Telefono,
                            r.NombreRol
                        FROM Usuarios u
                        INNER JOIN Roles r ON u.IdRol = r.IdRol
                        WHERE u.CorreoElectronico = @correo AND u.Contrasena = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int idUsuario = Convert.ToInt32(reader["IdUsuario"]);
                                string rol = reader["NombreRol"].ToString();

                                RegistrarLogAcceso(idUsuario, true);

                                MessageBox.Show("Inicio de sesión exitoso ✅", "HealthRunner", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (rol == "Administrador")
                                {
                                    FrmPanelAdmin frmAdmin = new FrmPanelAdmin();
                                    frmAdmin.Show();
                                    this.Hide();
                                }
                                else if (rol == "UsuarioFinal")
                                {
                                    FrmPerfilUsuario frmPerfil = new FrmPerfilUsuario(idUsuario);
                                    frmPerfil.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                RegistrarLogAcceso(0, false);
                                MessageBox.Show("Correo o contraseña incorrectos.", "HealthRunner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistrarLogAcceso(int idUsuario, bool exitoso)
        {
            try
            {
                using (SqlConnection conn = ConexionDB.Instancia.ObtenerConexion())
                {
                    string insertLog = @"INSERT INTO LogsAcceso (IdUsuario, FechaIntento, Exitoso, IP)
                                         VALUES (@idUsuario, GETDATE(), @exitoso, HOST_NAME())";

                    using (SqlCommand cmd = new SqlCommand(insertLog, conn))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario == 0 ? DBNull.Value : (object)idUsuario);
                        cmd.Parameters.AddWithValue("@exitoso", exitoso ? 1 : 0);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // Ignorar error en log para no afectar login
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            FrmRegistro frmRegistro = new FrmRegistro();
            frmRegistro.Show();
            this.Hide();
        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            FrmRegistroAdmin frmAdmin = new FrmRegistroAdmin();
            frmAdmin.Show();
            this.Hide();
        }

        private void btnConexionDB_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = ConexionDB.Instancia.ObtenerConexion())
                {
                    MessageBox.Show("✅ Conexión exitosa con SQL Server",
                                    "HealthRunner",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error de conexión: {ex.Message}",
                                "HealthRunner",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}