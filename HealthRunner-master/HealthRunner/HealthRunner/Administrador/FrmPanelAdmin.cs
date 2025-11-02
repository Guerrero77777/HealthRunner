using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthRunner.Administrador
{
    public partial class btnVolver : Form
    {
        public btnVolver()
        {
            InitializeComponent();
        }

        private void btnVerdetalle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mostrará el detalle del usuario seleccionado.", "Ver Detalle", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmRegistroAdmin frm = new FrmRegistroAdmin();
            frm.Show();
            this.Hide();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función para editar usuarios próximamente disponible.", "Editar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Deseas eliminar este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Usuario eliminado correctamente.", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos actualizados correctamente.", "Actualizar", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmInicio frmInicio = new FrmInicio();
            frmInicio.Show();
            this.Hide();
        }
    }
}
