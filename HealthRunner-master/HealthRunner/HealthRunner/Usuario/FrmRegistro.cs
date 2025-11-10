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
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();

            SetPlaceholder(txtNombre, "Ingrese su nombre completo");
            SetPlaceholder(txtCorreo, "Ingrese su correo electrónico");
            SetPlaceholder(txtPassword, "Cree una contraseña");
            SetPlaceholder(txtConfirmar, "Confirme su contraseña");
            SetPlaceholder(txtTelefono, "Ingrese su número telefónico");

            cmbNivel.Items.Clear();
            cmbNivel.Items.Add("Seleccione su nivel de actividad");
            cmbNivel.Items.Add("Principiante");
            cmbNivel.Items.Add("Intermedio");
            cmbNivel.Items.Add("Avanzado");
            cmbNivel.SelectedIndex = 0;

            cmbGenero.Items.Clear();
            cmbGenero.Items.Add("Seleccione su género");
            cmbGenero.Items.Add("Masculino");
            cmbGenero.Items.Add("Femenino");
            cmbGenero.Items.Add("Otro");
            cmbGenero.SelectedIndex = 0;

            this.Shown += FrmInicio_Shown;
        }

        private void FrmRegistro_Load(object sender, EventArgs e)
        {
            SetPlaceholder(txtNombre, "Ingrese su nombre completo");
            SetPlaceholder(txtCorreo, "Ingrese su correo electrónico");
            SetPlaceholder(txtPassword, "Cree una contraseña");
            SetPlaceholder(txtConfirmar, "Confirme su contraseña");
            SetPlaceholder(txtTelefono, "Ingrese su número telefónico");
        }

        private void FrmInicio_Shown(object sender, EventArgs e)
        {
            BeginInvoke((Action)(() => { this.ActiveControl = null; }));
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

                    if (txt.Name.Contains("Password"))
                        txt.UseSystemPasswordChar = true;
                }
            };

            txt.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;

                    if (txt.Name.Contains("Password"))
                        txt.UseSystemPasswordChar = false;
                }
            };

            if (txt.Name.Contains("Password"))
                txt.UseSystemPasswordChar = false;
        }

        private void LimpiarControles(Control contenedor)
        {
            foreach (Control ctrl in contenedor.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.Clear();
                    txt.ForeColor = Color.Gray;
                }
                else if (ctrl is ComboBox cmb)
                {
                    if (cmb.Items.Count > 0)
                        cmb.SelectedIndex = 0;
                }
                else if (ctrl is CheckBox chk)
                {
                    chk.Checked = false;
                }
                else if (ctrl is DateTimePicker dtp)
                {
                    dtp.Value = DateTime.Now;
                }

                if (ctrl.HasChildren)
                    LimpiarControles(ctrl);
            }
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            LimpiarControles(this);

            SetPlaceholder(txtNombre, "Ingrese su nombre completo");
            SetPlaceholder(txtCorreo, "Ingrese su correo electrónico");
            SetPlaceholder(txtPassword, "Cree una contraseña");
            SetPlaceholder(txtConfirmar, "Confirme su contraseña");
            SetPlaceholder(txtTelefono, "Ingrese su número telefónico");

            MessageBox.Show("Campos limpiados correctamente.",
                            "HealthRunner",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnVolver_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Desea volver al inicio de sesión?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FrmInicio frmInicio = new FrmInicio();
                frmInicio.Show();
                this.Hide();
            }
        }

        private void btnRegistrar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtNombre.Text == "Ingrese su nombre completo")
            {
                MessageBox.Show("Debe ingresar su nombre completo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text) || txtCorreo.Text == "Ingrese su correo electrónico")
            {
                MessageBox.Show("Debe ingresar su correo electrónico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbNivel.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar su nivel de actividad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbGenero.SelectedIndex == 0)
            {
                MessageBox.Show("Debe seleccionar su género.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text) || txtTelefono.Text == "Ingrese su número telefónico")
            {
                MessageBox.Show("Debe ingresar su número telefónico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtCorreo.Text.Contains("@") || !txtCorreo.Text.Contains("."))
            {
                MessageBox.Show("El correo electrónico no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text == "Cree una contraseña" || txtConfirmar.Text == "Confirme su contraseña")
            {
                MessageBox.Show("Debe ingresar y confirmar la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text != txtConfirmar.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text.Length < 8 ||
                !txtPassword.Text.Any(char.IsUpper) ||
                !txtPassword.Text.Any(char.IsDigit))
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres, una letra mayúscula y un número.",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtTelefono.Text.All(char.IsDigit))
            {
                MessageBox.Show("El número telefónico solo debe contener dígitos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dateTimeFecha.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser futura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection cn = ConexionDB.Instancia.ObtenerConexion())
                {
                    string query = @"INSERT INTO Usuarios
                                    (NombreCompleto, CorreoElectronico, Contrasena, 
                                     FechaNacimiento, NivelActividad, Genero, Telefono, IdRol)
                                     VALUES (@nombre, @correo, @pass,  @fecha, @nivel, @genero, @tel, 2)";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                        cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                      //  cmd.Parameters.AddWithValue("@confirma", txtConfirmar.Text);
                        cmd.Parameters.AddWithValue("@fecha", dateTimeFecha.Value);
                        cmd.Parameters.AddWithValue("@nivel", cmbNivel.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@genero", cmbGenero.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@tel", txtTelefono.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Usuario registrado correctamente ✅",
                                    "HealthRunner",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlRegistro_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}