using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            cmbGenero.SelectedIndex = -1;
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

            if (cmbGenero.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el género.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGenero.Focus();
                return;
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