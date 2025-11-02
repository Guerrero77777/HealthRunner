using HealthRunner.Administrador;
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
            //  Truco seguro: quitar el foco del control activo después de cargar
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
            // Verificar campos vacíos
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

            // Simulación de usuario (más adelante se reemplaza por BD)
            string correoDemo = "prueba@gmail.com";
            string passDemo = "G12345678";

            if (txtCorreo.Text == correoDemo && txtPassword.Text == passDemo)
            {
                MessageBox.Show("¡Inicio de sesión exitoso! Bienvenido a HealthRunner 💪", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmPerfilUsuario frmPerfil = new FrmPerfilUsuario();
                frmPerfil.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos.\nVerifique sus datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}



