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
using HealthRunner.Model;

namespace HealthRunner
{
    public partial class FrmPerfilUsuario : Form
    {
        private int idUsuario;

        public FrmPerfilUsuario(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;

            CargarDatosDesdeBD();
            ConfigurarMetas();    // ahora cmbMetas contiene metas (no niveles)
            LimpiarInsignias();
            // Si ya hay valores, evaluar al cargar
            try
            {
                if (!string.IsNullOrWhiteSpace(txtPasos.Text) &&
                    !string.IsNullOrWhiteSpace(txtKilometros.Text) &&
                    !string.IsNullOrWhiteSpace(txtCalorias.Text) &&
                    !string.IsNullOrWhiteSpace(txtFrecuencia.Text))
                {
                    EvaluarInsignias(
                        int.Parse(txtPasos.Text),
                        double.Parse(txtKilometros.Text),
                        int.Parse(txtCalorias.Text),
                        int.Parse(txtFrecuencia.Text)
                    );
                }
            }
            catch { /* Ignorar parseo inicial */ }
        }

        // 🔹 Carga los datos del usuario desde SQL Server
        private void CargarDatosDesdeBD()
        {
            try
            {
                using (SqlConnection conn = ConexionDB.Instancia.ObtenerConexion())
                {
                    string query = @"
                        SELECT 
                            NombreCompleto,
                            CorreoElectronico,
                            Genero,
                            Telefono,
                            FechaNacimiento,
                            NivelActividad
                        FROM Usuarios
                        WHERE IdUsuario = @idUsuario";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            txtNombre.Text = reader["NombreCompleto"].ToString();
                            txtCorreo.Text = reader["CorreoElectronico"].ToString();
                            cmbGenero.Text = reader["Genero"].ToString();
                            txtTelefono.Text = reader["Telefono"].ToString();
                            dateTimeFecha.Value = Convert.ToDateTime(reader["FechaNacimiento"]);

                            // Importante: Nivel se coloca en txtNivel (no en cmbMetas)
                            if (reader["NivelActividad"] != DBNull.Value)
                                txtNivel.Text = reader["NivelActividad"].ToString();
                            else
                                txtNivel.Text = "Principiante";
                        }
                        reader.Close();
                    }

                    ConexionDB.Instancia.CerrarConexion(conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del usuario: {ex.Message}",
                                "HealthRunner",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        // 🔹 Configurar metas (ComboBox) — aquí van las metas amigables
        private void ConfigurarMetas()
        {
            cmbMetas.Items.Clear();
            cmbMetas.Items.Add("Caminar más de 10.000 pasos diarios");
            cmbMetas.Items.Add("Correr 5 km semanales");
            cmbMetas.Items.Add("Quemar 500 calorías diarias");
            cmbMetas.Items.Add("Mantener ritmo cardíaco estable");
            cmbMetas.Items.Add("Aumentar 2 km de distancia semanal");
            cmbMetas.Items.Add("Completar 3 sesiones de fuerza por semana");

            // Selección por defecto (si quieres dejar la primera)
            if (cmbMetas.Items.Count > 0)
                cmbMetas.SelectedIndex = 0;
        }

        // 🔹 Limpia las insignias al iniciar
        private void LimpiarInsignias()
        {
            picOro.Visible = false;
            picPlata.Visible = false;
            picBronce.Visible = false;
        }

        // 🔹 Botón Actualizar (el usuario ingresa manualmente los valores)
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                int pasos = int.Parse(txtPasos.Text);
                double km = double.Parse(txtKilometros.Text);
                int calorias = int.Parse(txtCalorias.Text);
                int frecuencia = int.Parse(txtFrecuencia.Text);

                ActualizarProgreso(pasos, km, calorias);
                EvaluarInsignias(pasos, km, calorias, frecuencia);

                MessageBox.Show("Datos actualizados correctamente y evaluación de insignia completada.",
                                "HealthRunner",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Por favor ingresa valores numéricos válidos en todos los campos.",
                                "Error de validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        // 🔹 Actualiza el progress bar y etiquetas según valores
        private void ActualizarProgreso(int pasos, double km, int calorias)
        {
            // Calcular "experiencia" a partir de proporciones (normalizar)
            int expPasos = (int)(Math.Min(pasos, 10000) / 10000.0 * 100);
            int expKm = (int)(Math.Min(km, 10.0) / 10.0 * 100);
            int expCal = (int)(Math.Min(calorias, 1000) / 1000.0 * 100);

            // Promedio simple
            int experiencia = (expPasos + expKm + expCal) / 3;
            experiencia = Math.Max(0, Math.Min(100, experiencia));

            // Actualizar controles visuales (asegura rango del ProgressBar)
            try
            {
                progressExperiencia.Value = experiencia;
            }
            catch { progressExperiencia.Value = Math.Max(0, Math.Min(100, experiencia)); }

            lblProgreso.Text = $"Progreso: {experiencia}%";
            lblNivelActual.Text = $"Nivel actual: {txtNivel.Text}";
        }

        // 🔹 Evalúa las condiciones según el nivel (txtNivel) y los valores ingresados
        private void EvaluarInsignias(int pasos, double km, int calorias, int frecuencia)
        {
            LimpiarInsignias();

            // Usa txtNivel (valor que viene de BD o que el admin establezca)
            string nivel = txtNivel.Text?.Trim();
            if (string.IsNullOrEmpty(nivel))
                nivel = "Principiante";

            // 🥉 PRINCIPIANTE - condiciones más suaves
            if (nivel.Equals("Principiante", StringComparison.OrdinalIgnoreCase))
            {
                if (pasos >= 3000 && km >= 1.0 && calorias >= 150 && frecuencia >= 60)
                {
                    picBronce.Visible = true;
                }
            }
            // 🥈 INTERMEDIO - condiciones medias
            else if (nivel.Equals("Intermedio", StringComparison.OrdinalIgnoreCase))
            {
                if (pasos >= 7000 && km >= 4.0 && calorias >= 350 && frecuencia >= 70)
                {
                    picPlata.Visible = true;
                }
            }
            // 🥇 AVANZADO - condiciones altas
            else if (nivel.Equals("Avanzado", StringComparison.OrdinalIgnoreCase))
            {
                if (pasos >= 10000 && km >= 7.0 && calorias >= 500 && frecuencia >= 75)
                {
                    picOro.Visible = true;
                }
            }

            // Si ninguna insignia se activó, muestra mensaje de progreso en lblNivelActual
            if (!picBronce.Visible && !picPlata.Visible && !picOro.Visible)
            {
                lblNivelActual.Text = $"Nivel actual: En progreso ({nivel})";
            }
            else
            {
                lblNivelActual.Text = $"Nivel actual: {nivel}";
            }
        }

        // 🔹 Botón Historial
        private void btnHistorial_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Historial de actividad en desarrollo.", "HealthRunner");
        }

        // 🔹 Botón Cerrar Sesión
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