namespace HealthRunner
{
    partial class FrmPerfilUsuario
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
            this.tblMain = new System.Windows.Forms.TableLayoutPanel();
            this.tblTop = new System.Windows.Forms.TableLayoutPanel();
            this.picFotoPerfil = new System.Windows.Forms.PictureBox();
            this.grpDatosPersonales = new System.Windows.Forms.GroupBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtGenero = new System.Windows.Forms.TextBox();
            this.txtFechaNacimiento = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblGenero = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtMetas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNivel = new System.Windows.Forms.TextBox();
            this.lblNivel = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPerfilPersonal = new System.Windows.Forms.Label();
            this.grpEstadistica = new System.Windows.Forms.GroupBox();
            this.tblEstadistica = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFrecuencias = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCalorias = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblKilometros = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPaos = new System.Windows.Forms.Label();
            this.lblPasos = new System.Windows.Forms.Label();
            this.grpProgreso = new System.Windows.Forms.GroupBox();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.flowInsignias = new System.Windows.Forms.FlowLayoutPanel();
            this.picOro = new System.Windows.Forms.PictureBox();
            this.picPlata = new System.Windows.Forms.PictureBox();
            this.picBronce = new System.Windows.Forms.PictureBox();
            this.lblProgreso = new System.Windows.Forms.Label();
            this.progressExperiencia = new System.Windows.Forms.ProgressBar();
            this.lblNivelActual = new System.Windows.Forms.Label();
            this.tblMain.SuspendLayout();
            this.tblTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFotoPerfil)).BeginInit();
            this.grpDatosPersonales.SuspendLayout();
            this.grpEstadistica.SuspendLayout();
            this.tblEstadistica.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpProgreso.SuspendLayout();
            this.flowInsignias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBronce)).BeginInit();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.tblTop, 0, 0);
            this.tblMain.Controls.Add(this.grpEstadistica, 0, 1);
            this.tblMain.Controls.Add(this.grpProgreso, 0, 2);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 3;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblMain.Size = new System.Drawing.Size(800, 545);
            this.tblMain.TabIndex = 0;
            // 
            // tblTop
            // 
            this.tblTop.ColumnCount = 2;
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tblTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblTop.Controls.Add(this.picFotoPerfil, 0, 0);
            this.tblTop.Controls.Add(this.grpDatosPersonales, 1, 0);
            this.tblTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTop.Location = new System.Drawing.Point(3, 3);
            this.tblTop.Name = "tblTop";
            this.tblTop.RowCount = 1;
            this.tblTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblTop.Size = new System.Drawing.Size(794, 184);
            this.tblTop.TabIndex = 0;
            // 
            // picFotoPerfil
            // 
            this.picFotoPerfil.Image = global::HealthRunner.Properties.Resources.avata;
            this.picFotoPerfil.Location = new System.Drawing.Point(3, 3);
            this.picFotoPerfil.Name = "picFotoPerfil";
            this.picFotoPerfil.Size = new System.Drawing.Size(150, 145);
            this.picFotoPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFotoPerfil.TabIndex = 0;
            this.picFotoPerfil.TabStop = false;
            // 
            // grpDatosPersonales
            // 
            this.grpDatosPersonales.Controls.Add(this.txtTelefono);
            this.grpDatosPersonales.Controls.Add(this.txtGenero);
            this.grpDatosPersonales.Controls.Add(this.txtFechaNacimiento);
            this.grpDatosPersonales.Controls.Add(this.lblTelefono);
            this.grpDatosPersonales.Controls.Add(this.lblGenero);
            this.grpDatosPersonales.Controls.Add(this.lblFecha);
            this.grpDatosPersonales.Controls.Add(this.txtMetas);
            this.grpDatosPersonales.Controls.Add(this.label2);
            this.grpDatosPersonales.Controls.Add(this.txtNivel);
            this.grpDatosPersonales.Controls.Add(this.lblNivel);
            this.grpDatosPersonales.Controls.Add(this.txtCorreo);
            this.grpDatosPersonales.Controls.Add(this.lblCorreo);
            this.grpDatosPersonales.Controls.Add(this.txtNombre);
            this.grpDatosPersonales.Controls.Add(this.lblNombre);
            this.grpDatosPersonales.Controls.Add(this.lblPerfilPersonal);
            this.grpDatosPersonales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDatosPersonales.Location = new System.Drawing.Point(183, 3);
            this.grpDatosPersonales.Name = "grpDatosPersonales";
            this.grpDatosPersonales.Size = new System.Drawing.Size(608, 178);
            this.grpDatosPersonales.TabIndex = 1;
            this.grpDatosPersonales.TabStop = false;
            this.grpDatosPersonales.Text = " Perfil Personal";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(376, 90);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(197, 23);
            this.txtTelefono.TabIndex = 17;
            // 
            // txtGenero
            // 
            this.txtGenero.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGenero.Location = new System.Drawing.Point(376, 60);
            this.txtGenero.Name = "txtGenero";
            this.txtGenero.ReadOnly = true;
            this.txtGenero.Size = new System.Drawing.Size(197, 23);
            this.txtGenero.TabIndex = 16;
            // 
            // txtFechaNacimiento
            // 
            this.txtFechaNacimiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaNacimiento.Location = new System.Drawing.Point(376, 31);
            this.txtFechaNacimiento.Name = "txtFechaNacimiento";
            this.txtFechaNacimiento.ReadOnly = true;
            this.txtFechaNacimiento.Size = new System.Drawing.Size(197, 23);
            this.txtFechaNacimiento.TabIndex = 15;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(294, 89);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(65, 17);
            this.lblTelefono.TabIndex = 14;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // lblGenero
            // 
            this.lblGenero.AutoSize = true;
            this.lblGenero.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenero.Location = new System.Drawing.Point(294, 60);
            this.lblGenero.Name = "lblGenero";
            this.lblGenero.Size = new System.Drawing.Size(55, 17);
            this.lblGenero.TabIndex = 13;
            this.lblGenero.Text = "Género:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(294, 31);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(76, 17);
            this.lblFecha.TabIndex = 12;
            this.lblFecha.Text = "Fecha Nac:";
            // 
            // txtMetas
            // 
            this.txtMetas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMetas.Location = new System.Drawing.Point(73, 119);
            this.txtMetas.Name = "txtMetas";
            this.txtMetas.ReadOnly = true;
            this.txtMetas.Size = new System.Drawing.Size(197, 23);
            this.txtMetas.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Metas:";
            // 
            // txtNivel
            // 
            this.txtNivel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNivel.Location = new System.Drawing.Point(73, 89);
            this.txtNivel.Name = "txtNivel";
            this.txtNivel.ReadOnly = true;
            this.txtNivel.Size = new System.Drawing.Size(197, 23);
            this.txtNivel.TabIndex = 9;
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivel.Location = new System.Drawing.Point(6, 90);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(44, 17);
            this.lblNivel.TabIndex = 8;
            this.lblNivel.Text = "Nivel:";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.Location = new System.Drawing.Point(73, 59);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.ReadOnly = true;
            this.txtCorreo.Size = new System.Drawing.Size(197, 23);
            this.txtCorreo.TabIndex = 7;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.Location = new System.Drawing.Point(6, 60);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(51, 17);
            this.lblCorreo.TabIndex = 6;
            this.lblCorreo.Text = "Correo:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(73, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(197, 23);
            this.txtNombre.TabIndex = 5;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(6, 31);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(61, 17);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblPerfilPersonal
            // 
            this.lblPerfilPersonal.AutoSize = true;
            this.lblPerfilPersonal.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerfilPersonal.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lblPerfilPersonal.Location = new System.Drawing.Point(221, 3);
            this.lblPerfilPersonal.Name = "lblPerfilPersonal";
            this.lblPerfilPersonal.Size = new System.Drawing.Size(98, 17);
            this.lblPerfilPersonal.TabIndex = 3;
            this.lblPerfilPersonal.Text = "Perfil Personal";
            // 
            // grpEstadistica
            // 
            this.grpEstadistica.Controls.Add(this.tblEstadistica);
            this.grpEstadistica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEstadistica.Location = new System.Drawing.Point(3, 193);
            this.grpEstadistica.Name = "grpEstadistica";
            this.grpEstadistica.Size = new System.Drawing.Size(794, 130);
            this.grpEstadistica.TabIndex = 1;
            this.grpEstadistica.TabStop = false;
            this.grpEstadistica.Text = "Estadisitica de Salud y Rendimiento";
            // 
            // tblEstadistica
            // 
            this.tblEstadistica.ColumnCount = 4;
            this.tblEstadistica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblEstadistica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblEstadistica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblEstadistica.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblEstadistica.Controls.Add(this.panel4, 3, 0);
            this.tblEstadistica.Controls.Add(this.panel3, 2, 0);
            this.tblEstadistica.Controls.Add(this.panel2, 1, 0);
            this.tblEstadistica.Controls.Add(this.panel1, 0, 0);
            this.tblEstadistica.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblEstadistica.Location = new System.Drawing.Point(3, 16);
            this.tblEstadistica.Name = "tblEstadistica";
            this.tblEstadistica.RowCount = 1;
            this.tblEstadistica.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblEstadistica.Size = new System.Drawing.Size(788, 111);
            this.tblEstadistica.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.lblFrecuencias);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(601, 10);
            this.panel4.Margin = new System.Windows.Forms.Padding(10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(177, 91);
            this.panel4.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 30);
            this.label6.TabIndex = 1;
            // 
            // lblFrecuencias
            // 
            this.lblFrecuencias.AutoSize = true;
            this.lblFrecuencias.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFrecuencias.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrecuencias.Location = new System.Drawing.Point(0, 0);
            this.lblFrecuencias.MaximumSize = new System.Drawing.Size(0, 25);
            this.lblFrecuencias.Name = "lblFrecuencias";
            this.lblFrecuencias.Size = new System.Drawing.Size(72, 17);
            this.lblFrecuencias.TabIndex = 0;
            this.lblFrecuencias.Text = "Frecuencia";
            this.lblFrecuencias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lblCalorias);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(404, 10);
            this.panel3.Margin = new System.Windows.Forms.Padding(10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(177, 91);
            this.panel3.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 30);
            this.label4.TabIndex = 1;
            // 
            // lblCalorias
            // 
            this.lblCalorias.AutoSize = true;
            this.lblCalorias.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCalorias.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalorias.Location = new System.Drawing.Point(0, 0);
            this.lblCalorias.MaximumSize = new System.Drawing.Size(0, 25);
            this.lblCalorias.Name = "lblCalorias";
            this.lblCalorias.Size = new System.Drawing.Size(55, 17);
            this.lblCalorias.TabIndex = 0;
            this.lblCalorias.Text = "Calorias";
            this.lblCalorias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblKilometros);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(207, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(177, 91);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 30);
            this.label1.TabIndex = 1;
            // 
            // lblKilometros
            // 
            this.lblKilometros.AutoSize = true;
            this.lblKilometros.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKilometros.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKilometros.Location = new System.Drawing.Point(0, 0);
            this.lblKilometros.MaximumSize = new System.Drawing.Size(0, 25);
            this.lblKilometros.Name = "lblKilometros";
            this.lblKilometros.Size = new System.Drawing.Size(73, 17);
            this.lblKilometros.TabIndex = 0;
            this.lblKilometros.Text = "Kilometros";
            this.lblKilometros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblPaos);
            this.panel1.Controls.Add(this.lblPasos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(177, 91);
            this.panel1.TabIndex = 0;
            // 
            // lblPaos
            // 
            this.lblPaos.AutoSize = true;
            this.lblPaos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPaos.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaos.Location = new System.Drawing.Point(0, 17);
            this.lblPaos.Name = "lblPaos";
            this.lblPaos.Size = new System.Drawing.Size(0, 30);
            this.lblPaos.TabIndex = 1;
            // 
            // lblPasos
            // 
            this.lblPasos.AutoSize = true;
            this.lblPasos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPasos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasos.Location = new System.Drawing.Point(0, 0);
            this.lblPasos.MaximumSize = new System.Drawing.Size(0, 25);
            this.lblPasos.Name = "lblPasos";
            this.lblPasos.Size = new System.Drawing.Size(43, 17);
            this.lblPasos.TabIndex = 0;
            this.lblPasos.Text = "Pasos";
            this.lblPasos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpProgreso
            // 
            this.grpProgreso.Controls.Add(this.btnCerrarSesion);
            this.grpProgreso.Controls.Add(this.btnHistorial);
            this.grpProgreso.Controls.Add(this.btnActualizar);
            this.grpProgreso.Controls.Add(this.flowInsignias);
            this.grpProgreso.Controls.Add(this.lblProgreso);
            this.grpProgreso.Controls.Add(this.progressExperiencia);
            this.grpProgreso.Controls.Add(this.lblNivelActual);
            this.grpProgreso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProgreso.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpProgreso.Location = new System.Drawing.Point(3, 329);
            this.grpProgreso.Name = "grpProgreso";
            this.grpProgreso.Padding = new System.Windows.Forms.Padding(10);
            this.grpProgreso.Size = new System.Drawing.Size(794, 213);
            this.grpProgreso.TabIndex = 2;
            this.grpProgreso.TabStop = false;
            this.grpProgreso.Text = "Progreso y Logros";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCerrarSesion.Location = new System.Drawing.Point(642, 164);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(130, 36);
            this.btnCerrarSesion.TabIndex = 6;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnHistorial
            // 
            this.btnHistorial.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorial.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btnHistorial.Location = new System.Drawing.Point(454, 164);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(130, 36);
            this.btnHistorial.TabIndex = 5;
            this.btnHistorial.Text = "Ver Historial";
            this.btnHistorial.UseVisualStyleBackColor = true;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.btnActualizar.Location = new System.Drawing.Point(275, 164);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(130, 36);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar datos";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // flowInsignias
            // 
            this.flowInsignias.Controls.Add(this.picOro);
            this.flowInsignias.Controls.Add(this.picPlata);
            this.flowInsignias.Controls.Add(this.picBronce);
            this.flowInsignias.Location = new System.Drawing.Point(13, 124);
            this.flowInsignias.Name = "flowInsignias";
            this.flowInsignias.Padding = new System.Windows.Forms.Padding(5);
            this.flowInsignias.Size = new System.Drawing.Size(227, 80);
            this.flowInsignias.TabIndex = 3;
            // 
            // picOro
            // 
            this.picOro.Location = new System.Drawing.Point(8, 8);
            this.picOro.Name = "picOro";
            this.picOro.Size = new System.Drawing.Size(64, 64);
            this.picOro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOro.TabIndex = 0;
            this.picOro.TabStop = false;
            // 
            // picPlata
            // 
            this.picPlata.Location = new System.Drawing.Point(78, 8);
            this.picPlata.Name = "picPlata";
            this.picPlata.Size = new System.Drawing.Size(64, 64);
            this.picPlata.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPlata.TabIndex = 1;
            this.picPlata.TabStop = false;
            // 
            // picBronce
            // 
            this.picBronce.Location = new System.Drawing.Point(148, 8);
            this.picBronce.Name = "picBronce";
            this.picBronce.Size = new System.Drawing.Size(64, 64);
            this.picBronce.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBronce.TabIndex = 2;
            this.picBronce.TabStop = false;
            // 
            // lblProgreso
            // 
            this.lblProgreso.AutoSize = true;
            this.lblProgreso.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgreso.Location = new System.Drawing.Point(13, 97);
            this.lblProgreso.Name = "lblProgreso";
            this.lblProgreso.Size = new System.Drawing.Size(104, 21);
            this.lblProgreso.TabIndex = 2;
            this.lblProgreso.Text = "Progreso: 40";
            this.lblProgreso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressExperiencia
            // 
            this.progressExperiencia.Location = new System.Drawing.Point(17, 56);
            this.progressExperiencia.Name = "progressExperiencia";
            this.progressExperiencia.Size = new System.Drawing.Size(400, 25);
            this.progressExperiencia.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressExperiencia.TabIndex = 1;
            this.progressExperiencia.Value = 40;
            // 
            // lblNivelActual
            // 
            this.lblNivelActual.AutoSize = true;
            this.lblNivelActual.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivelActual.Location = new System.Drawing.Point(13, 32);
            this.lblNivelActual.Name = "lblNivelActual";
            this.lblNivelActual.Size = new System.Drawing.Size(121, 21);
            this.lblNivelActual.TabIndex = 0;
            this.lblNivelActual.Text = "Nivel Actual: 1";
            this.lblNivelActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmPerfilUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 545);
            this.Controls.Add(this.tblMain);
            this.Name = "FrmPerfilUsuario";
            this.Text = "HealthRunner Perfil Usuario";
            this.tblMain.ResumeLayout(false);
            this.tblTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFotoPerfil)).EndInit();
            this.grpDatosPersonales.ResumeLayout(false);
            this.grpDatosPersonales.PerformLayout();
            this.grpEstadistica.ResumeLayout(false);
            this.tblEstadistica.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpProgreso.ResumeLayout(false);
            this.grpProgreso.PerformLayout();
            this.flowInsignias.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picOro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPlata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBronce)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblMain;
        private System.Windows.Forms.TableLayoutPanel tblTop;
        private System.Windows.Forms.PictureBox picFotoPerfil;
        private System.Windows.Forms.GroupBox grpDatosPersonales;
        private System.Windows.Forms.Label lblPerfilPersonal;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtMetas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNivel;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtGenero;
        private System.Windows.Forms.TextBox txtFechaNacimiento;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblGenero;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.GroupBox grpEstadistica;
        private System.Windows.Forms.TableLayoutPanel tblEstadistica;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPasos;
        private System.Windows.Forms.Label lblPaos;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFrecuencias;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCalorias;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblKilometros;
        private System.Windows.Forms.GroupBox grpProgreso;
        private System.Windows.Forms.Label lblNivelActual;
        private System.Windows.Forms.Label lblProgreso;
        private System.Windows.Forms.ProgressBar progressExperiencia;
        private System.Windows.Forms.FlowLayoutPanel flowInsignias;
        private System.Windows.Forms.PictureBox picOro;
        private System.Windows.Forms.PictureBox picPlata;
        private System.Windows.Forms.PictureBox picBronce;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnActualizar;
    }
}