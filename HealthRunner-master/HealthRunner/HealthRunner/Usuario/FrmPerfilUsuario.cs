using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HealthRunner.Models;

namespace HealthRunner
{
    public partial class FrmPerfilUsuario : Form
    {
        private Usuario usuarioActual;

        public FrmPerfilUsuario()
        {
            InitializeComponent();
        }

        public FrmPerfilUsuario(Usuario usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;

            CargarDatosUsuario();
            CargarEstadisticas();
            ActualizarProgreso();
        }

        private void CargarDatosUsuario()
        {
            txtNombre.Text = usuarioActual.NombreCompleto;
            txtCorreo.Text = usuarioActual.Correo;
            txtNivel.Text = usuarioActual.NivelActividad;
            txtGenero.Text = usuarioActual.Genero;
            txtTelefono.Text = usuarioActual.Telefono;
            txtFechaNacimiento.Text = usuarioActual.FechaNacimiento.ToShortDateString();
        }

        private void CargarEstadisticas()
        {
            lblPasos.Text = usuarioActual.Pasos.ToString("N0");
            lblKilometros.Text = usuarioActual.Kilometros.ToString("0.00");
            lblCalorias.Text = usuarioActual.Calorias.ToString("N0");
            lblFrecuencias.Text = usuarioActual.FrecuenciaCardiaca.ToString();
        }

        private void ActualizarProgreso()
        {
            progressExperiencia.Value = usuarioActual.Experiencia;
            lblNivelActual.Text = $"Nivel actual: {usuarioActual.NivelActual}";
            lblProgreso.Text = $"Progreso: {usuarioActual.Experiencia}%";

            flowInsignias.Controls.Clear();

            if (usuarioActual.Experiencia >= 100)
            {
                PictureBox medallaOro = CrearMedalla(Color.Gold);
                flowInsignias.Controls.Add(medallaOro);
            }
            else if (usuarioActual.Experiencia >= 60)
            {
                PictureBox medallaPlata = CrearMedalla(Color.Silver);
                flowInsignias.Controls.Add(medallaPlata);
            }
            else if (usuarioActual.Experiencia >= 30)
            {
                PictureBox medallaBronce = CrearMedalla(Color.SaddleBrown);
                flowInsignias.Controls.Add(medallaBronce);
            }
        }

        private PictureBox CrearMedalla(Color color)
        {
            PictureBox pic = new PictureBox();
            pic.BackColor = color;
            pic.Size = new Size(64, 64);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Margin = new Padding(10, 5, 10, 5);
            return pic;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            usuarioActual.Pasos += 500;
            usuarioActual.Kilometros += 0.5;
            usuarioActual.Calorias += 30;
            usuarioActual.FrecuenciaCardiaca = 75 + new Random().Next(0, 10);
            usuarioActual.Experiencia = Math.Min(usuarioActual.Experiencia + 10, 100);

            CargarEstadisticas();
            ActualizarProgreso();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Historial de actividad en desarrollo.", "HealthRunner");
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea cerrar sesión?", "Salir", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                FrmInicio frmInicio = new FrmInicio();
                frmInicio.Show();
                this.Close();
            }
        }
    }
    
}
