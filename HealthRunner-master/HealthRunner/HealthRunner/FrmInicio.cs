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

            // Configura los placeholders
            SetPlaceholder(txtCorreo, "Ingrese su correo");
            SetPlaceholder(txtPassword, "Ingrese su contraseña");

            // Desactiva el foco automático en el primer TextBox
            this.Shown += FrmInicio_Shown;
            this.Load += FrmInicio_Load;
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            // Asegura que no se seleccione nada en el diseño inicial
            this.ActiveControl = null;
        }

        private void FrmInicio_Shown(object sender, EventArgs e)
        {
            // Truco seguro: quitar el foco del control activo después de cargar
            BeginInvoke((Action)(() =>
            {
                this.ActiveControl = null; // fuerza que ningún control tenga foco
            }));
        }

        private void SetPlaceholder(TextBox txt, string placeholder)
        {
            txt.Text = placeholder;
            txt.ForeColor = Color.Gray;

            // Cuando entra al cuadro
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

            // Cuando sale del cuadro
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

            // Si es contraseña, inicialmente no oculta el texto
            if (txt == txtPassword)
                txt.UseSystemPasswordChar = false;
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(txtCorreo.Text) || txtCorreo.Text == "Ingrese su correo")
            {
                MessageBox.Show("Por favor ingrese su correo electrónico.", "HealthRunner", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text == "Ingrese su contraseña")
            {
                MessageBox.Show("Por favor ingrese su contraseña.", "HealthRunner", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=HealthRunnerDB;Integrated Security=True"))
                {
                    conn.Open();

                    string query = @"
                        SELECT u.IdUsuario, u.CorreoElectronico, r.NombreRol 
                        FROM Usuarios u
                        INNER JOIN Roles r ON u.IdRol = r.IdRol
                        WHERE u.CorreoElectronico = @correo AND u.PasswordHash = @password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            string rol = reader["NombreRol"].ToString();
                            int idUsuario = Convert.ToInt32(reader["IdUsuario"]);

                            reader.Close();
                            RegistrarLogAcceso(idUsuario, true);

                            MessageBox.Show("Inicio de sesión exitoso ✅", "HealthRunner", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Redirigir según el rol
                            if (rol == "Administrador")
                            {
                                FrmPanelAdmin frm = new FrmPanelAdmin();
                                frm.Show();
                                this.Hide();
                            }
                            else if (rol == "UsuarioFinal")
                            {
                                FrmPerfilUsuario frm = new FrmPerfilUsuario();
                                frm.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            reader.Close();
                            RegistrarLogAcceso(0, false);

                            MessageBox.Show("Correo o contraseña incorrectos.", "HealthRunner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistrarLogAcceso(int idUsuario, bool exitoso)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=HealthRunnerDB;Integrated Security=True"))
                {
                    conn.Open();
                    string insertLog = @"INSERT INTO LogsAcceso (IdUsuario, FechaIntento, Exitoso, IP)
                                         VALUES (@idUsuario, GETDATE(), @exitoso, HOST_NAME())";

                    using (SqlCommand cmd = new SqlCommand(insertLog, conn))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario == 0 ? DBNull.Value : idUsuario);
                        cmd.Parameters.AddWithValue("@exitoso", exitoso ? 1 : 0);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // Evita que un fallo en log interrumpa el flujo del login
            }
        }

        private void btnRegistrar_Click_1(object sender, EventArgs e)
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
                using (SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=HealthRunnerDB;Integrated Security=True"))
                {
                    conn.Open();
                    MessageBox.Show("✅ Conexión exitosa con SQL Server", "Prueba", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error de conexión: " + ex.Message, "Prueba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

