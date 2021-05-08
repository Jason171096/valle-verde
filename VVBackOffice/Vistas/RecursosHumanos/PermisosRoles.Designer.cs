namespace ValleVerde.Vistas.RecursosHumanos
{
    partial class PermisosRoles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PermisosRoles));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.rolesComunes = new System.Windows.Forms.TabPage();
            this.cbDevolucionesVentasAcceder = new System.Windows.Forms.CheckBox();
            this.cbPedidoClienteAcceder = new System.Windows.Forms.CheckBox();
            this.cbVerificadorAcceder = new System.Windows.Forms.CheckBox();
            this.rolesBackOffice = new System.Windows.Forms.TabPage();
            this.cbInicciarSesionBackOffice = new System.Windows.Forms.CheckBox();
            this.cbProductosPendientesComprasAcceder = new System.Windows.Forms.CheckBox();
            this.cbCotizacionCompras = new System.Windows.Forms.CheckBox();
            this.cbEntradasSalidasProductoAcceder = new System.Windows.Forms.CheckBox();
            this.cbClavesAdicionalesAcceder = new System.Windows.Forms.CheckBox();
            this.cbModificarProducto = new System.Windows.Forms.CheckBox();
            this.cbPrecapturarProducto = new System.Windows.Forms.CheckBox();
            this.cbAltaProducto = new System.Windows.Forms.CheckBox();
            this.cbDevolucionesComprasAcceder = new System.Windows.Forms.CheckBox();
            this.cbRecibirAcceder = new System.Windows.Forms.CheckBox();
            this.cbKardexAcceder = new System.Windows.Forms.CheckBox();
            this.cbVerificarInventario = new System.Windows.Forms.CheckBox();
            this.cbPreescanearEtiquetas = new System.Windows.Forms.CheckBox();
            this.cbEtiquetasPendientesPegarAcceder = new System.Windows.Forms.CheckBox();
            this.rolesPtoVta = new System.Windows.Forms.TabPage();
            this.cbIniciarSesionPuntoVenta = new System.Windows.Forms.CheckBox();
            this.cbHacerCotizacionVenta = new System.Windows.Forms.CheckBox();
            this.cbEliminarProducto = new System.Windows.Forms.CheckBox();
            this.cbHacerDevolucion = new System.Windows.Forms.CheckBox();
            this.cbHacerCorte = new System.Windows.Forms.CheckBox();
            this.cbDesbloquearCaja = new System.Windows.Forms.CheckBox();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNomRol = new System.Windows.Forms.TextBox();
            this.btnCrearRol = new ValleVerde.RoundedButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGuardarCambios = new ValleVerde.RoundedButton();
            this.btnSalir = new ValleVerde.RoundedButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.rolesComunes.SuspendLayout();
            this.rolesBackOffice.SuspendLayout();
            this.rolesPtoVta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.rolesComunes);
            this.tabControl1.Controls.Add(this.rolesBackOffice);
            this.tabControl1.Controls.Add(this.rolesPtoVta);
            this.tabControl1.Location = new System.Drawing.Point(6, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(829, 544);
            this.tabControl1.TabIndex = 6;
            // 
            // rolesComunes
            // 
            this.rolesComunes.Controls.Add(this.cbDevolucionesVentasAcceder);
            this.rolesComunes.Controls.Add(this.cbPedidoClienteAcceder);
            this.rolesComunes.Controls.Add(this.cbVerificadorAcceder);
            this.rolesComunes.Location = new System.Drawing.Point(4, 25);
            this.rolesComunes.Name = "rolesComunes";
            this.rolesComunes.Padding = new System.Windows.Forms.Padding(3);
            this.rolesComunes.Size = new System.Drawing.Size(821, 515);
            this.rolesComunes.TabIndex = 0;
            this.rolesComunes.Text = "Permisos Comunes";
            this.rolesComunes.UseVisualStyleBackColor = true;
            // 
            // cbDevolucionesVentasAcceder
            // 
            this.cbDevolucionesVentasAcceder.AutoSize = true;
            this.cbDevolucionesVentasAcceder.Location = new System.Drawing.Point(45, 135);
            this.cbDevolucionesVentasAcceder.Name = "cbDevolucionesVentasAcceder";
            this.cbDevolucionesVentasAcceder.Size = new System.Drawing.Size(245, 21);
            this.cbDevolucionesVentasAcceder.TabIndex = 9;
            this.cbDevolucionesVentasAcceder.Text = "Acceso a Devoluciones de Ventas";
            this.cbDevolucionesVentasAcceder.UseVisualStyleBackColor = true;
            // 
            // cbPedidoClienteAcceder
            // 
            this.cbPedidoClienteAcceder.AutoSize = true;
            this.cbPedidoClienteAcceder.Location = new System.Drawing.Point(45, 90);
            this.cbPedidoClienteAcceder.Name = "cbPedidoClienteAcceder";
            this.cbPedidoClienteAcceder.Size = new System.Drawing.Size(210, 21);
            this.cbPedidoClienteAcceder.TabIndex = 8;
            this.cbPedidoClienteAcceder.Text = "Acceso a Pedidos de Cliente";
            this.cbPedidoClienteAcceder.UseVisualStyleBackColor = true;
            // 
            // cbVerificadorAcceder
            // 
            this.cbVerificadorAcceder.AutoSize = true;
            this.cbVerificadorAcceder.Location = new System.Drawing.Point(45, 45);
            this.cbVerificadorAcceder.Name = "cbVerificadorAcceder";
            this.cbVerificadorAcceder.Size = new System.Drawing.Size(163, 21);
            this.cbVerificadorAcceder.TabIndex = 7;
            this.cbVerificadorAcceder.Text = "Acceso al Verificador";
            this.cbVerificadorAcceder.UseVisualStyleBackColor = true;
            // 
            // rolesBackOffice
            // 
            this.rolesBackOffice.Controls.Add(this.cbInicciarSesionBackOffice);
            this.rolesBackOffice.Controls.Add(this.cbProductosPendientesComprasAcceder);
            this.rolesBackOffice.Controls.Add(this.cbCotizacionCompras);
            this.rolesBackOffice.Controls.Add(this.cbEntradasSalidasProductoAcceder);
            this.rolesBackOffice.Controls.Add(this.cbClavesAdicionalesAcceder);
            this.rolesBackOffice.Controls.Add(this.cbModificarProducto);
            this.rolesBackOffice.Controls.Add(this.cbPrecapturarProducto);
            this.rolesBackOffice.Controls.Add(this.cbAltaProducto);
            this.rolesBackOffice.Controls.Add(this.cbDevolucionesComprasAcceder);
            this.rolesBackOffice.Controls.Add(this.cbRecibirAcceder);
            this.rolesBackOffice.Controls.Add(this.cbKardexAcceder);
            this.rolesBackOffice.Controls.Add(this.cbVerificarInventario);
            this.rolesBackOffice.Controls.Add(this.cbPreescanearEtiquetas);
            this.rolesBackOffice.Controls.Add(this.cbEtiquetasPendientesPegarAcceder);
            this.rolesBackOffice.Location = new System.Drawing.Point(4, 25);
            this.rolesBackOffice.Name = "rolesBackOffice";
            this.rolesBackOffice.Padding = new System.Windows.Forms.Padding(3);
            this.rolesBackOffice.Size = new System.Drawing.Size(796, 515);
            this.rolesBackOffice.TabIndex = 1;
            this.rolesBackOffice.Text = "Permisos para Back Office";
            this.rolesBackOffice.UseVisualStyleBackColor = true;
            // 
            // cbInicciarSesionBackOffice
            // 
            this.cbInicciarSesionBackOffice.AutoSize = true;
            this.cbInicciarSesionBackOffice.Location = new System.Drawing.Point(400, 315);
            this.cbInicciarSesionBackOffice.Name = "cbInicciarSesionBackOffice";
            this.cbInicciarSesionBackOffice.Size = new System.Drawing.Size(281, 21);
            this.cbInicciarSesionBackOffice.TabIndex = 23;
            this.cbInicciarSesionBackOffice.Text = "Permiso de Iniciar Sesion al Back-Office";
            this.cbInicciarSesionBackOffice.UseVisualStyleBackColor = true;
            // 
            // cbProductosPendientesComprasAcceder
            // 
            this.cbProductosPendientesComprasAcceder.AutoSize = true;
            this.cbProductosPendientesComprasAcceder.Location = new System.Drawing.Point(45, 315);
            this.cbProductosPendientesComprasAcceder.Name = "cbProductosPendientesComprasAcceder";
            this.cbProductosPendientesComprasAcceder.Size = new System.Drawing.Size(311, 21);
            this.cbProductosPendientesComprasAcceder.TabIndex = 22;
            this.cbProductosPendientesComprasAcceder.Text = "Acceso a Productos Pendientes de Compras";
            this.cbProductosPendientesComprasAcceder.UseVisualStyleBackColor = true;
            // 
            // cbCotizacionCompras
            // 
            this.cbCotizacionCompras.AutoSize = true;
            this.cbCotizacionCompras.Location = new System.Drawing.Point(400, 270);
            this.cbCotizacionCompras.Name = "cbCotizacionCompras";
            this.cbCotizacionCompras.Size = new System.Drawing.Size(209, 21);
            this.cbCotizacionCompras.TabIndex = 21;
            this.cbCotizacionCompras.Text = "Permiso de Cotizar Compras";
            this.cbCotizacionCompras.UseVisualStyleBackColor = true;
            // 
            // cbEntradasSalidasProductoAcceder
            // 
            this.cbEntradasSalidasProductoAcceder.AutoSize = true;
            this.cbEntradasSalidasProductoAcceder.Location = new System.Drawing.Point(400, 225);
            this.cbEntradasSalidasProductoAcceder.Name = "cbEntradasSalidasProductoAcceder";
            this.cbEntradasSalidasProductoAcceder.Size = new System.Drawing.Size(298, 21);
            this.cbEntradasSalidasProductoAcceder.TabIndex = 19;
            this.cbEntradasSalidasProductoAcceder.Text = "Acceso a Entradas y Salidas de Productos";
            this.cbEntradasSalidasProductoAcceder.UseVisualStyleBackColor = true;
            // 
            // cbClavesAdicionalesAcceder
            // 
            this.cbClavesAdicionalesAcceder.AutoSize = true;
            this.cbClavesAdicionalesAcceder.Location = new System.Drawing.Point(400, 180);
            this.cbClavesAdicionalesAcceder.Name = "cbClavesAdicionalesAcceder";
            this.cbClavesAdicionalesAcceder.Size = new System.Drawing.Size(210, 21);
            this.cbClavesAdicionalesAcceder.TabIndex = 17;
            this.cbClavesAdicionalesAcceder.Text = "Acceso a Claves Adicionales";
            this.cbClavesAdicionalesAcceder.UseVisualStyleBackColor = true;
            // 
            // cbModificarProducto
            // 
            this.cbModificarProducto.AutoSize = true;
            this.cbModificarProducto.Location = new System.Drawing.Point(400, 135);
            this.cbModificarProducto.Name = "cbModificarProducto";
            this.cbModificarProducto.Size = new System.Drawing.Size(222, 21);
            this.cbModificarProducto.TabIndex = 15;
            this.cbModificarProducto.Text = "Permiso a Modificar Productos";
            this.cbModificarProducto.UseVisualStyleBackColor = true;
            // 
            // cbPrecapturarProducto
            // 
            this.cbPrecapturarProducto.AutoSize = true;
            this.cbPrecapturarProducto.Location = new System.Drawing.Point(400, 90);
            this.cbPrecapturarProducto.Name = "cbPrecapturarProducto";
            this.cbPrecapturarProducto.Size = new System.Drawing.Size(248, 21);
            this.cbPrecapturarProducto.TabIndex = 13;
            this.cbPrecapturarProducto.Text = "Permiso de Precapturar Productos";
            this.cbPrecapturarProducto.UseVisualStyleBackColor = true;
            // 
            // cbAltaProducto
            // 
            this.cbAltaProducto.AutoSize = true;
            this.cbAltaProducto.Location = new System.Drawing.Point(400, 45);
            this.cbAltaProducto.Name = "cbAltaProducto";
            this.cbAltaProducto.Size = new System.Drawing.Size(241, 21);
            this.cbAltaProducto.TabIndex = 11;
            this.cbAltaProducto.Text = "Permiso a dar Altas de Productos";
            this.cbAltaProducto.UseVisualStyleBackColor = true;
            // 
            // cbDevolucionesComprasAcceder
            // 
            this.cbDevolucionesComprasAcceder.AutoSize = true;
            this.cbDevolucionesComprasAcceder.Location = new System.Drawing.Point(45, 270);
            this.cbDevolucionesComprasAcceder.Name = "cbDevolucionesComprasAcceder";
            this.cbDevolucionesComprasAcceder.Size = new System.Drawing.Size(257, 21);
            this.cbDevolucionesComprasAcceder.TabIndex = 20;
            this.cbDevolucionesComprasAcceder.Text = "Acceso a Devoluciones de Compras";
            this.cbDevolucionesComprasAcceder.UseVisualStyleBackColor = true;
            // 
            // cbRecibirAcceder
            // 
            this.cbRecibirAcceder.AutoSize = true;
            this.cbRecibirAcceder.Location = new System.Drawing.Point(45, 225);
            this.cbRecibirAcceder.Name = "cbRecibirAcceder";
            this.cbRecibirAcceder.Size = new System.Drawing.Size(149, 21);
            this.cbRecibirAcceder.TabIndex = 18;
            this.cbRecibirAcceder.Text = "Permiso de Recibir";
            this.cbRecibirAcceder.UseVisualStyleBackColor = true;
            // 
            // cbKardexAcceder
            // 
            this.cbKardexAcceder.AutoSize = true;
            this.cbKardexAcceder.Location = new System.Drawing.Point(45, 180);
            this.cbKardexAcceder.Name = "cbKardexAcceder";
            this.cbKardexAcceder.Size = new System.Drawing.Size(139, 21);
            this.cbKardexAcceder.TabIndex = 16;
            this.cbKardexAcceder.Text = "Acceso al Kardex";
            this.cbKardexAcceder.UseVisualStyleBackColor = true;
            // 
            // cbVerificarInventario
            // 
            this.cbVerificarInventario.AutoSize = true;
            this.cbVerificarInventario.Location = new System.Drawing.Point(45, 135);
            this.cbVerificarInventario.Name = "cbVerificarInventario";
            this.cbVerificarInventario.Size = new System.Drawing.Size(230, 21);
            this.cbVerificarInventario.TabIndex = 14;
            this.cbVerificarInventario.Text = "Permiso de Verificar Inventarios";
            this.cbVerificarInventario.UseVisualStyleBackColor = true;
            // 
            // cbPreescanearEtiquetas
            // 
            this.cbPreescanearEtiquetas.AutoSize = true;
            this.cbPreescanearEtiquetas.Location = new System.Drawing.Point(45, 90);
            this.cbPreescanearEtiquetas.Name = "cbPreescanearEtiquetas";
            this.cbPreescanearEtiquetas.Size = new System.Drawing.Size(236, 21);
            this.cbPreescanearEtiquetas.TabIndex = 12;
            this.cbPreescanearEtiquetas.Text = "Acceso a Preescanear Etiquetas";
            this.cbPreescanearEtiquetas.UseVisualStyleBackColor = true;
            // 
            // cbEtiquetasPendientesPegarAcceder
            // 
            this.cbEtiquetasPendientesPegarAcceder.AutoSize = true;
            this.cbEtiquetasPendientesPegarAcceder.Location = new System.Drawing.Point(45, 45);
            this.cbEtiquetasPendientesPegarAcceder.Name = "cbEtiquetasPendientesPegarAcceder";
            this.cbEtiquetasPendientesPegarAcceder.Size = new System.Drawing.Size(280, 21);
            this.cbEtiquetasPendientesPegarAcceder.TabIndex = 10;
            this.cbEtiquetasPendientesPegarAcceder.Text = "Acceso a Etiquetas Pendientes a Pegar";
            this.cbEtiquetasPendientesPegarAcceder.UseVisualStyleBackColor = true;
            // 
            // rolesPtoVta
            // 
            this.rolesPtoVta.Controls.Add(this.cbIniciarSesionPuntoVenta);
            this.rolesPtoVta.Controls.Add(this.cbHacerCotizacionVenta);
            this.rolesPtoVta.Controls.Add(this.cbEliminarProducto);
            this.rolesPtoVta.Controls.Add(this.cbHacerDevolucion);
            this.rolesPtoVta.Controls.Add(this.cbHacerCorte);
            this.rolesPtoVta.Controls.Add(this.cbDesbloquearCaja);
            this.rolesPtoVta.Location = new System.Drawing.Point(4, 25);
            this.rolesPtoVta.Name = "rolesPtoVta";
            this.rolesPtoVta.Size = new System.Drawing.Size(796, 515);
            this.rolesPtoVta.TabIndex = 2;
            this.rolesPtoVta.Text = "Permisos para Punto de Venta";
            this.rolesPtoVta.UseVisualStyleBackColor = true;
            // 
            // cbIniciarSesionPuntoVenta
            // 
            this.cbIniciarSesionPuntoVenta.AutoSize = true;
            this.cbIniciarSesionPuntoVenta.Location = new System.Drawing.Point(400, 135);
            this.cbIniciarSesionPuntoVenta.Name = "cbIniciarSesionPuntoVenta";
            this.cbIniciarSesionPuntoVenta.Size = new System.Drawing.Size(306, 21);
            this.cbIniciarSesionPuntoVenta.TabIndex = 29;
            this.cbIniciarSesionPuntoVenta.Text = "Permiso de Iniciar Sesion al Punto de Venta";
            this.cbIniciarSesionPuntoVenta.UseVisualStyleBackColor = true;
            // 
            // cbHacerCotizacionVenta
            // 
            this.cbHacerCotizacionVenta.AutoSize = true;
            this.cbHacerCotizacionVenta.Location = new System.Drawing.Point(400, 90);
            this.cbHacerCotizacionVenta.Name = "cbHacerCotizacionVenta";
            this.cbHacerCotizacionVenta.Size = new System.Drawing.Size(197, 21);
            this.cbHacerCotizacionVenta.TabIndex = 27;
            this.cbHacerCotizacionVenta.Text = "Permiso de Cotizar Ventas";
            this.cbHacerCotizacionVenta.UseVisualStyleBackColor = true;
            // 
            // cbEliminarProducto
            // 
            this.cbEliminarProducto.AutoSize = true;
            this.cbEliminarProducto.Location = new System.Drawing.Point(400, 45);
            this.cbEliminarProducto.Name = "cbEliminarProducto";
            this.cbEliminarProducto.Size = new System.Drawing.Size(225, 21);
            this.cbEliminarProducto.TabIndex = 25;
            this.cbEliminarProducto.Text = "Permiso para Quitar Productos";
            this.cbEliminarProducto.UseVisualStyleBackColor = true;
            // 
            // cbHacerDevolucion
            // 
            this.cbHacerDevolucion.AutoSize = true;
            this.cbHacerDevolucion.Location = new System.Drawing.Point(45, 135);
            this.cbHacerDevolucion.Name = "cbHacerDevolucion";
            this.cbHacerDevolucion.Size = new System.Drawing.Size(245, 21);
            this.cbHacerDevolucion.TabIndex = 28;
            this.cbHacerDevolucion.Text = "Permiso para Hacer Devoluciones";
            this.cbHacerDevolucion.UseVisualStyleBackColor = true;
            // 
            // cbHacerCorte
            // 
            this.cbHacerCorte.AutoSize = true;
            this.cbHacerCorte.Location = new System.Drawing.Point(45, 90);
            this.cbHacerCorte.Name = "cbHacerCorte";
            this.cbHacerCorte.Size = new System.Drawing.Size(194, 21);
            this.cbHacerCorte.TabIndex = 26;
            this.cbHacerCorte.Text = "Permiso para Hacer Corte";
            this.cbHacerCorte.UseVisualStyleBackColor = true;
            // 
            // cbDesbloquearCaja
            // 
            this.cbDesbloquearCaja.AutoSize = true;
            this.cbDesbloquearCaja.Location = new System.Drawing.Point(45, 45);
            this.cbDesbloquearCaja.Name = "cbDesbloquearCaja";
            this.cbDesbloquearCaja.Size = new System.Drawing.Size(246, 21);
            this.cbDesbloquearCaja.TabIndex = 24;
            this.cbDesbloquearCaja.Text = "Permiso para Desbloquear la Caja";
            this.cbDesbloquearCaja.UseVisualStyleBackColor = true;
            // 
            // dgvRoles
            // 
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToDeleteRows = false;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Location = new System.Drawing.Point(11, 30);
            this.dgvRoles.MultiSelect = false;
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.ReadOnly = true;
            this.dgvRoles.RowHeadersVisible = false;
            this.dgvRoles.RowHeadersWidth = 51;
            this.dgvRoles.RowTemplate.Height = 24;
            this.dgvRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoles.Size = new System.Drawing.Size(315, 427);
            this.dgvRoles.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbNomRol);
            this.groupBox1.Controls.Add(this.btnCrearRol);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 166);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crear roles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 47;
            this.label1.Text = "Nombre del rol";
            // 
            // tbNomRol
            // 
            this.tbNomRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNomRol.Location = new System.Drawing.Point(11, 61);
            this.tbNomRol.Name = "tbNomRol";
            this.tbNomRol.Size = new System.Drawing.Size(361, 30);
            this.tbNomRol.TabIndex = 4;
            // 
            // btnCrearRol
            // 
            this.btnCrearRol.BackColor = System.Drawing.Color.White;
            this.btnCrearRol.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCrearRol.FlatAppearance.BorderSize = 5;
            this.btnCrearRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnCrearRol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrearRol.Location = new System.Drawing.Point(211, 108);
            this.btnCrearRol.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrearRol.Name = "btnCrearRol";
            this.btnCrearRol.Size = new System.Drawing.Size(172, 51);
            this.btnCrearRol.TabIndex = 5;
            this.btnCrearRol.Text = "Crear nuevo rol";
            this.btnCrearRol.UseVisualStyleBackColor = false;
            this.btnCrearRol.Click += new System.EventHandler(this.btnCrearRol_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Controls.Add(this.btnEditar);
            this.groupBox2.Controls.Add(this.dgvRoles);
            this.groupBox2.Location = new System.Drawing.Point(13, 193);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 468);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Roles existentes";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Image = global::ValleVerde.Properties.Resources.cancel_32;
            this.btnEliminar.Location = new System.Drawing.Point(332, 90);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(40, 40);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.Transparent;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEditar.Image = global::ValleVerde.Properties.Resources.editar_32;
            this.btnEditar.Location = new System.Drawing.Point(332, 40);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(40, 40);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.BackColor = System.Drawing.Color.White;
            this.btnGuardarCambios.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnGuardarCambios.FlatAppearance.BorderSize = 5;
            this.btnGuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCambios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnGuardarCambios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarCambios.Location = new System.Drawing.Point(888, 604);
            this.btnGuardarCambios.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(358, 56);
            this.btnGuardarCambios.TabIndex = 30;
            this.btnGuardarCambios.Text = "Guardar cambios este rol";
            this.btnGuardarCambios.UseVisualStyleBackColor = false;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnSalir.FlatAppearance.BorderSize = 5;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalir.Location = new System.Drawing.Point(717, 605);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(163, 56);
            this.btnSalir.TabIndex = 31;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tabControl1);
            this.groupBox3.Location = new System.Drawing.Point(409, 17);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(841, 576);
            this.groupBox3.TabIndex = 49;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Permisos";
            // 
            // PermisosRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSalir;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGuardarCambios);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PermisosRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Roles y permisos";
            this.tabControl1.ResumeLayout(false);
            this.rolesComunes.ResumeLayout(false);
            this.rolesComunes.PerformLayout();
            this.rolesBackOffice.ResumeLayout(false);
            this.rolesBackOffice.PerformLayout();
            this.rolesPtoVta.ResumeLayout(false);
            this.rolesPtoVta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage rolesComunes;
        private System.Windows.Forms.TabPage rolesBackOffice;
        private System.Windows.Forms.TabPage rolesPtoVta;
        private System.Windows.Forms.CheckBox cbDevolucionesVentasAcceder;
        private System.Windows.Forms.CheckBox cbPedidoClienteAcceder;
        private System.Windows.Forms.CheckBox cbVerificadorAcceder;
        private System.Windows.Forms.CheckBox cbInicciarSesionBackOffice;
        private System.Windows.Forms.CheckBox cbProductosPendientesComprasAcceder;
        private System.Windows.Forms.CheckBox cbCotizacionCompras;
        private System.Windows.Forms.CheckBox cbEntradasSalidasProductoAcceder;
        private System.Windows.Forms.CheckBox cbClavesAdicionalesAcceder;
        private System.Windows.Forms.CheckBox cbModificarProducto;
        private System.Windows.Forms.CheckBox cbPrecapturarProducto;
        private System.Windows.Forms.CheckBox cbAltaProducto;
        private System.Windows.Forms.CheckBox cbDevolucionesComprasAcceder;
        private System.Windows.Forms.CheckBox cbRecibirAcceder;
        private System.Windows.Forms.CheckBox cbKardexAcceder;
        private System.Windows.Forms.CheckBox cbVerificarInventario;
        private System.Windows.Forms.CheckBox cbPreescanearEtiquetas;
        private System.Windows.Forms.CheckBox cbEtiquetasPendientesPegarAcceder;
        private System.Windows.Forms.CheckBox cbIniciarSesionPuntoVenta;
        private System.Windows.Forms.CheckBox cbHacerCotizacionVenta;
        private System.Windows.Forms.CheckBox cbEliminarProducto;
        private System.Windows.Forms.CheckBox cbHacerDevolucion;
        private System.Windows.Forms.CheckBox cbHacerCorte;
        private System.Windows.Forms.CheckBox cbDesbloquearCaja;
        internal RoundedButton btnGuardarCambios;
        internal RoundedButton btnCrearRol;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNomRol;
        internal RoundedButton btnSalir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}