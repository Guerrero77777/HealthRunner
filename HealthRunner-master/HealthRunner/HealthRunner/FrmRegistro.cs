using HealthRunner.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            // Establecer los placeholders iniciales
            SetPlaceholder(txtNombre, "Ingrese su nombre completo");
            SetPlaceholder(txtCorreo, "Ingrese su correo electrónico");
            SetPlaceholder(txtPassword, "Cree una contraseña");
            SetPlaceholder(txtConfirmar, "Confirme su contraseña");
            SetPlaceholder(txtTelefono, "Ingrese su número telefónico");

            // 🔹 Cargar niveles de actividad
            cmbNivel.Items.Clear();
            cmbNivel.Items.Add("Seleccione su nivel de actividad");
            cmbNivel.Items.Add("Principiante");
            cmbNivel.Items.Add("Intermedio");
            cmbNivel.Items.Add("Avanzado");
            cmbNivel.SelectedIndex = 0;

            // 🔹 Cargar géneros
            cmbGenero.Items.Clear();
            cmbGenero.Items.Add("Seleccione su género");
            cmbGenero.Items.Add("Masculino");
            cmbGenero.Items.Add("Femenino");
            cmbGenero.Items.Add("Otro");
            cmbGenero.SelectedIndex = 0;

            this.Shown += FrmInicio_Shown;  // Quita el foco al cargar
        }

        private void FrmRegistro_Load(object sender, EventArgs e)
        {
            // Reestablecer placeholders por seguridad
            SetPlaceholder(txtNombre, "Ingrese su nombre completo");
            SetPlaceholder(txtCorreo, "Ingrese su correo electrónico");
            SetPlaceholder(txtPassword, "Cree una contraseña");
            SetPlaceholder(txtConfirmar, "Confirme su contraseña");
            SetPlaceholder(txtTelefono, "Ingrese su número telefónico");
        }

        private void FrmInicio_Shown(object sender, EventArgs e)
        {
            BeginInvoke((Action)(() =>
            {
                this.ActiveControl = null;
            }));
        }

        // 🔹 Método para limpiar los campos
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    txt.Clear();
                    txt.ForeColor = Color.Black;
                }
                else if (ctrl is ComboBox cmb)
                {
                    cmb.SelectedIndex = 0;
                }
            }

            MessageBox.Show("Campos limpiados correctamente.",
                            "HealthRunner",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        // 🔹 Botón para volver al inicio
        private void btnVolver_Click(object sender, EventArgs e)
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

        // 🔹 Método para placeholders
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

        // 🔹 Botón Registrar
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Validaciones
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

            // Crear objeto Usuario (POO)
            Usuario nuevoUsuario = new Usuario()
            {
                NombreCompleto = txtNombre.Text,
                Correo = txtCorreo.Text,
                FechaNacimiento = dateTimeFecha.Value,
                NivelActividad = cmbNivel.SelectedItem.ToString(),
                Genero = cmbGenero.SelectedItem.ToString(),
                Telefono = txtTelefono.Text,
                Contrasena = txtPassword.Text
            };

            // Confirmación visual
            MessageBox.Show($"Usuario {nuevoUsuario.NombreCompleto} registrado correctamente.",
                            "HealthRunner", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // TODO: Agregar persistencia en base de datos con UsuarioRepository
        }
    }
}
