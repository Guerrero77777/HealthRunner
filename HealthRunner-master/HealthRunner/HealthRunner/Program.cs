using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthRunner
{
    /// <summary>
    /// Clase principal del proyecto HealthRunner.
    /// Es el punto de entrada de la aplicación.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Método Main: inicia la ejecución de la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Configuración básica de la aplicación
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Manejo global de errores (buena práctica)
            try
            {
                // 🔹 Inicia la aplicación mostrando el formulario principal
                Application.Run(new FrmInicio());
            }
            catch (Exception ex)
            {
                // Captura cualquier error crítico al iniciar
                MessageBox.Show(
                    "Ocurrió un error al iniciar la aplicación:\n" + ex.Message,
                    "Error Crítico",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}