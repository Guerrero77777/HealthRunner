namespace HealthRunner.Administrador
{
    partial class FrmPanelAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlRegistro = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnVerdetalle = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CORREO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GÉNERO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TELÉFONO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.pictureBoxRunner = new System.Windows.Forms.PictureBox();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.pnlRegistro.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRunner)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRegistro
            // 
            this.pnlRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRegistro.Controls.Add(this.panel1);
            this.pnlRegistro.Controls.Add(this.dgvUsuarios);
            this.pnlRegistro.Controls.Add(this.btnBuscar);
            this.pnlRegistro.Controls.Add(this.txtBuscar);
            this.pnlRegistro.Location = new System.Drawing.Point(217, 71);
            this.pnlRegistro.Name = "pnlRegistro";
            this.pnlRegistro.Size = new System.Drawing.Size(802, 386);
            this.pnlRegistro.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAtras);
            this.panel1.Controls.Add(this.btnActualizar);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.btnVerdetalle);
            this.panel1.Location = new System.Drawing.Point(594, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 295);
            this.panel1.TabIndex = 3;
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.LightGray;
            this.btnAtras.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.ForeColor = System.Drawing.Color.White;
            this.btnAtras.Location = new System.Drawing.Point(16, 217);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(130, 35);
            this.btnAtras.TabIndex = 7;
            this.btnAtras.Text = "Volver";
            this.btnAtras.UseVisualStyleBackColor = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(16, 176);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(130, 35);
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.RosyBrown;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(16, 135);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(130, 35);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(16, 94);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(130, 35);
            this.btnEditar.TabIndex = 4;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(16, 53);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(130, 35);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnVerdetalle
            // 
            this.btnVerdetalle.BackColor = System.Drawing.Color.SeaGreen;
            this.btnVerdetalle.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerdetalle.ForeColor = System.Drawing.Color.White;
            this.btnVerdetalle.Location = new System.Drawing.Point(16, 12);
            this.btnVerdetalle.Name = "btnVerdetalle";
            this.btnVerdetalle.Size = new System.Drawing.Size(130, 35);
            this.btnVerdetalle.TabIndex = 2;
            this.btnVerdetalle.Text = "Ver Detalle";
            this.btnVerdetalle.UseVisualStyleBackColor = false;
            this.btnVerdetalle.Click += new System.EventHandler(this.btnVerdetalle_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.BackgroundColor = System.Drawing.Color.MintCream;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NOMBRE,
            this.CORREO,
            this.ROL,
            this.GÉNERO,
            this.TELÉFONO});
            this.dgvUsuarios.Location = new System.Drawing.Point(12, 72);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(538, 295);
            this.dgvUsuarios.TabIndex = 2;
            // 
            // NOMBRE
            // 
            this.NOMBRE.HeaderText = "NOMBRE";
            this.NOMBRE.Name = "NOMBRE";
            // 
            // CORREO
            // 
            this.CORREO.HeaderText = "CORREO";
            this.CORREO.Name = "CORREO";
            // 
            // ROL
            // 
            this.ROL.HeaderText = "ROL";
            this.ROL.Name = "ROL";
            // 
            // GÉNERO
            // 
            this.GÉNERO.HeaderText = "GÉNERO";
            this.GÉNERO.Name = "GÉNERO";
            // 
            // TELÉFONO
            // 
            this.TELÉFONO.HeaderText = "TELÉFONO";
            this.TELÉFONO.Name = "TELÉFONO";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(457, 31);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(93, 35);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(12, 31);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(391, 25);
            this.txtBuscar.TabIndex = 0;
            // 
            // pictureBoxRunner
            // 
            this.pictureBoxRunner.Image = global::HealthRunner.Properties.Resources.Registro;
            this.pictureBoxRunner.Location = new System.Drawing.Point(1046, 117);
            this.pictureBoxRunner.Name = "pictureBoxRunner";
            this.pictureBoxRunner.Size = new System.Drawing.Size(211, 255);
            this.pictureBoxRunner.TabIndex = 17;
            this.pictureBoxRunner.TabStop = false;
            // 
            // lblRegistro
            // 
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.Font = new System.Drawing.Font("Segoe UI", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblRegistro.Location = new System.Drawing.Point(366, 20);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(319, 37);
            this.lblRegistro.TabIndex = 16;
            this.lblRegistro.Text = "Panel de Administrador";
            // 
            // FrmPanelAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1445, 799);
            this.Controls.Add(this.pnlRegistro);
            this.Controls.Add(this.pictureBoxRunner);
            this.Controls.Add(this.lblRegistro);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPanelAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmPanelAdmin";
            this.Load += new System.EventHandler(this.FrmPanelAdmin_Load_1);
            this.pnlRegistro.ResumeLayout(false);
            this.pnlRegistro.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRunner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlRegistro;
        private System.Windows.Forms.PictureBox pictureBoxRunner;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CORREO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROL;
        private System.Windows.Forms.DataGridViewTextBoxColumn GÉNERO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TELÉFONO;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnVerdetalle;
    }
}