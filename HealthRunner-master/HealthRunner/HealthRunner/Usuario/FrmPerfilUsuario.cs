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
            ConfigurarMetas();
            LimpiarInsignias();
        }

        private void CargarDatosDesdeBD()
        {
            try
            {
                using (SqlConnection conn = ConexionDB.Instancia.ObtenerConexion())
                {
                    string query = @"
                        SELECT NombreCompleto, CorreoElectronico, Genero, Telefono, FechaNacimiento, NivelActividad
                        FROM Usuarios
                        WHERE IdUsuario = @idUsuario";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNombre.Text = reader["NombreCompleto"].ToString();
                                txtCorreo.Text = reader["CorreoElectronico"].ToString();
                                cmbGenero.Text = reader["Genero"].ToString();
                                txtTelefono.Text = reader["Telefono"].ToString();

                                if (reader["FechaNacimiento"] != DBNull.Value)
                                    dateTimeFecha.Value = Convert.ToDateTime(reader["FechaNacimiento"]);

                                txtNivel.Text = reader["NivelActividad"] != DBNull.Value ? reader["NivelActividad"].ToString() : "Principiante";
                                lblNivelActual.Text = $"Nivel actual: {txtNivel.Text}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del usuario: {ex.Message}", "HealthRunner", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarMetas()
        {
            cmbMetas.Items.Clear();
            cmbMetas.Items.Add("Caminar más de 10.000 pasos diarios");
            cmbMetas.Items.Add("Correr 5 km semanales");
            cmbMetas.Items.Add("Quemar 500 calorías diarias");
            cmbMetas.Items.Add("Mantener ritmo cardíaco estable");
            cmbMetas.Items.Add("Aumentar 2 km de distancia semanal");
            cmbMetas.Items.Add("Completar 3 sesiones de fuerza por semana");

            if (cmbMetas.Items.Count > 0)
                cmbMetas.SelectedIndex = 0;
        }

        private void LimpiarInsignias()
        {
            picOro.Visible = false;
            picPlata.Visible = false;
            picBronce.Visible = false;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtPasos.Text) ||
                    string.IsNullOrWhiteSpace(txtKilometros.Text) ||
                    string.IsNullOrWhiteSpace(txtCalorias.Text) ||
                    string.IsNullOrWhiteSpace(txtFrecuencia.Text))
                {
                    MessageBox.Show("Por favor completa todos los campos numéricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtPasos.Text, out int pasos) ||
                    !double.TryParse(txtKilometros.Text, out double km) ||
                    !int.TryParse(txtCalorias.Text, out int calorias) ||
                    !int.TryParse(txtFrecuencia.Text, out int frecuencia))
                {
                    MessageBox.Show("Por favor ingresa valores numéricos válidos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Regla 10: Límites de seguridad
                if (pasos > 20000 || km > 15 || calorias > 1200 || frecuencia > 150)
                {
                    MessageBox.Show("⚠️ Evita el sobreesfuerzo para cuidar tu salud.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double progreso = CalcularProgreso(pasos, km, calorias, frecuencia);
                string nivelAnterior = txtNivel.Text?.Trim() ?? "Principiante";
                string nivelCalculado = NivelPorProgreso(progreso);

                txtNivel.Text = nivelCalculado;
                lblNivelActual.Text = $"Nivel actual: {txtNivel.Text}";

                if (!string.Equals(nivelCalculado, nivelAnterior, StringComparison.OrdinalIgnoreCase))
                {
                    bool actualizado = ActualizarNivelUsuario(idUsuario, nivelCalculado);
                    if (actualizado)
                    {
                        MessageBox.Show($"Tu nivel ha cambiado a: {nivelCalculado}", "Nivel actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                string piAsignada = EvaluarMostrarInsignia(pasos, km, calorias, frecuencia);

                (int contOro, int contPlata, int contBronce) = ObtenerContadores(idUsuario);
                if (piAsignada == "Oro") contOro++;
                else if (piAsignada == "Plata") contPlata++;
                else if (piAsignada == "Bronce") contBronce++;

                bool guardado = GuardarEstadistica(pasos, km, calorias, frecuencia, contOro, contPlata, contBronce, txtNivel.Text);

                if (guardado)
                {
                    MessageBox.Show("Datos guardados correctamente en la base de datos.", "HealthRunner", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al guardar la estadística.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "HealthRunner", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double CalcularProgreso(int pasos, double km, int calorias, int frecuencia)
        {
            const double refPasos = 10000.0;
            const double refKm = 7.0;
            const double refCal = 500.0;
            const double refFreq = 90.0;

            double pctPasos = Math.Min(100.0, pasos / refPasos * 100.0);
            double pctKm = Math.Min(100.0, km / refKm * 100.0);
            double pctCal = Math.Min(100.0, calorias / refCal * 100.0);
            double pctFreq = Math.Min(100.0, (frecuencia / refFreq) * 100.0);

            double progreso = (pctPasos + pctKm + pctCal + pctFreq) / 4.0;
            int progresoEntero = (int)Math.Round(Math.Max(0, Math.Min(100, progreso)));

            try { progressExperiencia.Value = progresoEntero; } catch { progressExperiencia.Value = Math.Max(0, Math.Min(100, progresoEntero)); }
            lblProgreso.Text = $"Progreso: {progresoEntero}%";

            string nivelCalculado = NivelPorProgreso(progresoEntero);
            txtNivel.Text = nivelCalculado;
            lblNivelActual.Text = $"Nivel actual: {nivelCalculado}";

            return progresoEntero;
        }

        private string NivelPorProgreso(double progreso)
        {
            if (progreso >= 95.0) return "Avanzado";
            if (progreso >= 70.0) return "Intermedio";
            return "Principiante";
        }

        private string EvaluarMostrarInsignia(int pasos, double km, int calorias, int frecuencia)
        {
            LimpiarInsignias();

            // Regla 1: ORO
            if (pasos >= 9000 && pasos <= 10000 && km >= 6 && km <= 15 && calorias >= 450 && calorias <= 750 && frecuencia >= 80 && frecuencia <= 100)
            {
                picOro.Visible = true;
                MessageBox.Show("🥇 Excelente — Insignia ORO otorgada.", "Insignia Oro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "Oro";
            }

            // Regla 2: PLATA
            if (pasos >= 7000 && pasos <= 8999 && km >= 4 && km <= 5 && calorias >= 300 && calorias <= 349 && frecuencia >= 70 && frecuencia <= 79)
            {
                picPlata.Visible = true;
                MessageBox.Show("🥈 Muy bien — Insignia PLATA otorgada.", "Insignia Plata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "Plata";
            }

            // Regla 3: BRONCE
            if (pasos >= 4000 && pasos <= 6999 && km >= 1 && km <= 3 && calorias < 259 && frecuencia < 60)
            {
                picBronce.Visible = true;
                MessageBox.Show("🥉 Buen esfuerzo — Insignia BRONCE otorgada.", "Insignia Bronce", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "Bronce";
            }

            // Regla 4: Sin insignia
            if (pasos < 4000 && calorias < 150)
            {
                MessageBox.Show("💪 No te rindas, cada paso cuenta.", "Motivación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "Ninguna";
            }

            // Regla 5: Frecuencia Alta
            if (frecuencia > 120)
            {
                MessageBox.Show("⚠️ ¡Cuidado! No te sobreesfuerces.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return "Ninguna";
            }

            // Regla 6: Desempeño saludable
            if (km >= 10 && calorias >= 900)
            {
                MessageBox.Show("🏆 Excelente desempeño, mantén el ritmo saludable.", "Desempeño Saludable", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "Oro";
            }

            return "Ninguna";
        }

        private (int contOro, int contPlata, int contBronce) ObtenerContadores(int idUsuario)
        {
            int oro = 0, plata = 0, bronce = 0;

            try
            {
                using (SqlConnection conn = ConexionDB.Instancia.ObtenerConexion())
                {
                    string query = @"
                        SELECT TOP 1
                            ISNULL(ContadorOro, 0) AS ContadorOro,
                            ISNULL(ContadorPlata, 0) AS ContadorPlata,
                            ISNULL(ContadorBronce, 0) AS ContadorBronce
                        FROM EstadisticasSalud
                        WHERE IdUsuario = @id
                        ORDER BY FechaRegistro DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idUsuario);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                oro = Convert.ToInt32(reader["ContadorOro"]);
                                plata = Convert.ToInt32(reader["ContadorPlata"]);
                                bronce = Convert.ToInt32(reader["ContadorBronce"]);
                            }
                        }
                    }
                }
            }
            catch { }

            return (oro, plata, bronce);
        }

        private bool GuardarEstadistica(int pasos, double km, int calorias, int frecuencia, int contOro, int contPlata, int contBronce, string nivel)
        {
            try
            {
                using (SqlConnection conn = ConexionDB.Instancia.ObtenerConexion())
                {
                    string insert = @"
                        INSERT INTO EstadisticasSalud
                        (IdUsuario, Pasos, Kilometros, Calorias, FrecuenciaCardiaca, FechaRegistro, ContadorOro, ContadorPlata, ContadorBronce, Nivel)
                        VALUES
                        (@idUsuario, @pasos, @km, @calorias, @frecuencia, GETDATE(), @oro, @plata, @bronce, @nivel)";

                    using (SqlCommand cmd = new SqlCommand(insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@pasos", pasos);
                        cmd.Parameters.AddWithValue("@km", km);
                        cmd.Parameters.AddWithValue("@calorias", calorias);
                        cmd.Parameters.AddWithValue("@frecuencia", frecuencia);
                        cmd.Parameters.AddWithValue("@oro", contOro);
                        cmd.Parameters.AddWithValue("@plata", contPlata);
                        cmd.Parameters.AddWithValue("@bronce", contBronce);
                        cmd.Parameters.AddWithValue("@nivel", nivel ?? (object)DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar estadística: {ex.Message}", "HealthRunner", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool ActualizarNivelUsuario(int idUsuario, string nuevoNivel)
        {
            try
            {
                using (SqlConnection conn = ConexionDB.Instancia.ObtenerConexion())
                {
                    string update = "UPDATE Usuarios SET NivelActividad = @nivel WHERE IdUsuario = @id";
                    using (SqlCommand cmd = new SqlCommand(update, conn))
                    {
                        cmd.Parameters.AddWithValue("@nivel", nuevoNivel);
                        cmd.Parameters.AddWithValue("@id", idUsuario);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
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