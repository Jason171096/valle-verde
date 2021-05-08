namespace ValleVerde.Vistas.Configuracion
{
    partial class Sucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Sucursal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BotonEliminar = new ValleVerde.RoundedButton();
            this.botonAgregarProductos = new ValleVerde.RoundedButton();
            this.botonEditar = new ValleVerde.RoundedButton();
            this.botonAgregar = new ValleVerde.RoundedButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvSucursales = new System.Windows.Forms.DataGridView();
            this.BotonCancelar = new ValleVerde.RoundedButton();
            this.idSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipConexion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conexion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activo = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursales)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.LimeGreen;
            this.panel1.Controls.Add(this.BotonEliminar);
            this.panel1.Controls.Add(this.botonAgregarProductos);
            this.panel1.Controls.Add(this.botonEditar);
            this.panel1.Controls.Add(this.botonAgregar);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Name = "panel1";
            // 
            // BotonEliminar
            // 
            this.BotonEliminar.BackColor = System.Drawing.Color.White;
            this.BotonEliminar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.BotonEliminar.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.BotonEliminar, "BotonEliminar");
            this.BotonEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.BotonEliminar.Image = global::ValleVerde.Properties.Resources.Eliminar24;
            this.BotonEliminar.Name = "BotonEliminar";
            this.BotonEliminar.UseVisualStyleBackColor = false;
            this.BotonEliminar.Click += new System.EventHandler(this.BotonEliminar_Click);
            // 
            // botonAgregarProductos
            // 
            this.botonAgregarProductos.BackColor = System.Drawing.Color.White;
            this.botonAgregarProductos.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.botonAgregarProductos.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.botonAgregarProductos, "botonAgregarProductos");
            this.botonAgregarProductos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.botonAgregarProductos.Image = global::ValleVerde.Properties.Resources.bottle_24;
            this.botonAgregarProductos.Name = "botonAgregarProductos";
            this.botonAgregarProductos.UseVisualStyleBackColor = false;
            this.botonAgregarProductos.Click += new System.EventHandler(this.botonAgregarProductos_Click);
            // 
            // botonEditar
            // 
            this.botonEditar.BackColor = System.Drawing.Color.White;
            this.botonEditar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.botonEditar.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.botonEditar, "botonEditar");
            this.botonEditar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.botonEditar.Image = global::ValleVerde.Properties.Resources.modificar24;
            this.botonEditar.Name = "botonEditar";
            this.botonEditar.UseVisualStyleBackColor = false;
            this.botonEditar.Click += new System.EventHandler(this.botonEditar_Click);
            // 
            // botonAgregar
            // 
            this.botonAgregar.BackColor = System.Drawing.Color.White;
            this.botonAgregar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.botonAgregar.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.botonAgregar, "botonAgregar");
            this.botonAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.botonAgregar.Image = global::ValleVerde.Properties.Resources.mas241;
            this.botonAgregar.Name = "botonAgregar";
            this.botonAgregar.UseVisualStyleBackColor = false;
            this.botonAgregar.Click += new System.EventHandler(this.botonAgregar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ValleVerde.Properties.Resources.LOGO;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // dgvSucursales
            // 
            this.dgvSucursales.AllowUserToAddRows = false;
            resources.ApplyResources(this.dgvSucursales, "dgvSucursales");
            this.dgvSucursales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSucursales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idSucursal,
            this.nombreSucursal,
            this.direccion,
            this.ipConexion,
            this.conexion,
            this.fechaCreacion,
            this.activo});
            this.dgvSucursales.Name = "dgvSucursales";
            this.dgvSucursales.RowHeadersVisible = false;
            // 
            // BotonCancelar
            // 
            this.BotonCancelar.BackColor = System.Drawing.Color.White;
            this.BotonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BotonCancelar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.BotonCancelar.FlatAppearance.BorderSize = 5;
            resources.ApplyResources(this.BotonCancelar, "BotonCancelar");
            this.BotonCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.BotonCancelar.Image = global::ValleVerde.Properties.Resources.cancel_32;
            this.BotonCancelar.Name = "BotonCancelar";
            this.BotonCancelar.UseVisualStyleBackColor = false;
            this.BotonCancelar.Click += new System.EventHandler(this.BotonCancelar_Click);
            // 
            // idSucursal
            // 
            resources.ApplyResources(this.idSucursal, "idSucursal");
            this.idSucursal.Name = "idSucursal";
            // 
            // nombreSucursal
            // 
            resources.ApplyResources(this.nombreSucursal, "nombreSucursal");
            this.nombreSucursal.Name = "nombreSucursal";
            // 
            // direccion
            // 
            resources.ApplyResources(this.direccion, "direccion");
            this.direccion.Name = "direccion";
            // 
            // ipConexion
            // 
            resources.ApplyResources(this.ipConexion, "ipConexion");
            this.ipConexion.Name = "ipConexion";
            // 
            // conexion
            // 
            resources.ApplyResources(this.conexion, "conexion");
            this.conexion.Name = "conexion";
            // 
            // fechaCreacion
            // 
            this.fechaCreacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.NullValue = null;
            this.fechaCreacion.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.fechaCreacion, "fechaCreacion");
            this.fechaCreacion.Name = "fechaCreacion";
            // 
            // activo
            // 
            this.activo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.activo.DataPropertyName = "EstadoS";
            resources.ApplyResources(this.activo, "activo");
            this.activo.Name = "activo";
            this.activo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.activo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Sucursal
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BotonCancelar;
            this.Controls.Add(this.BotonCancelar);
            this.Controls.Add(this.dgvSucursales);
            this.Controls.Add(this.panel1);
            this.Name = "Sucursal";
            this.Load += new System.EventHandler(this.Sucursal_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private RoundedButton botonAgregarProductos;
        private RoundedButton botonEditar;
        private RoundedButton botonAgregar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvSucursales;
        private RoundedButton BotonEliminar;
        private RoundedButton BotonCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipConexion;
        private System.Windows.Forms.DataGridViewTextBoxColumn conexion;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCreacion;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activo;
    }
}