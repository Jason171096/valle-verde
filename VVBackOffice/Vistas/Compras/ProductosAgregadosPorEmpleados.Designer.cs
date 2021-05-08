namespace ValleVerde.Vistas.Compras
{
    partial class ProductosAgregadosPorEmpleados
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.aut = new ValleVerde.RoundedButton();
            this.IDProductoEsperaCotizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadCajas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadesPorCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadUnidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionUnidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasCubrir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EnBaseA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Agregar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDProductoEsperaCotizacion,
            this.CodigoBarras,
            this.Descripcion,
            this.CantidadCajas,
            this.UnidadesPorCaja,
            this.CantidadUnidades,
            this.DescripcionUnidad,
            this.Cantidad,
            this.DiasCubrir,
            this.EnBaseA,
            this.Usuario,
            this.NombreUsuario,
            this.Fecha,
            this.Agregar});
            this.dgv.Location = new System.Drawing.Point(12, 12);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(1326, 657);
            this.dgv.TabIndex = 0;
            // 
            // aut
            // 
            this.aut.BackColor = System.Drawing.Color.White;
            this.aut.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.aut.FlatAppearance.BorderSize = 5;
            this.aut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.aut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.aut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aut.Location = new System.Drawing.Point(1223, 675);
            this.aut.Name = "aut";
            this.aut.Size = new System.Drawing.Size(115, 42);
            this.aut.TabIndex = 136;
            this.aut.Text = "Autorizar";
            this.aut.UseVisualStyleBackColor = false;
            this.aut.Click += new System.EventHandler(this.aut_Click);
            // 
            // IDProductoEsperaCotizacion
            // 
            this.IDProductoEsperaCotizacion.HeaderText = "IDProductoEsperaCotizacion";
            this.IDProductoEsperaCotizacion.Name = "IDProductoEsperaCotizacion";
            this.IDProductoEsperaCotizacion.ReadOnly = true;
            this.IDProductoEsperaCotizacion.Visible = false;
            // 
            // CodigoBarras
            // 
            this.CodigoBarras.HeaderText = "Código de barras";
            this.CodigoBarras.Name = "CodigoBarras";
            this.CodigoBarras.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // CantidadCajas
            // 
            this.CantidadCajas.HeaderText = "Cantidad de cajas";
            this.CantidadCajas.Name = "CantidadCajas";
            this.CantidadCajas.ReadOnly = true;
            this.CantidadCajas.Visible = false;
            // 
            // UnidadesPorCaja
            // 
            this.UnidadesPorCaja.HeaderText = "Unidades por caja";
            this.UnidadesPorCaja.Name = "UnidadesPorCaja";
            this.UnidadesPorCaja.ReadOnly = true;
            this.UnidadesPorCaja.Visible = false;
            // 
            // CantidadUnidades
            // 
            this.CantidadUnidades.HeaderText = "CantidadDeUnidades";
            this.CantidadUnidades.Name = "CantidadUnidades";
            this.CantidadUnidades.ReadOnly = true;
            this.CantidadUnidades.Visible = false;
            // 
            // DescripcionUnidad
            // 
            this.DescripcionUnidad.HeaderText = "Descripcion de unidad";
            this.DescripcionUnidad.Name = "DescripcionUnidad";
            this.DescripcionUnidad.ReadOnly = true;
            this.DescripcionUnidad.Visible = false;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // DiasCubrir
            // 
            this.DiasCubrir.HeaderText = "Días a cubrir";
            this.DiasCubrir.Name = "DiasCubrir";
            this.DiasCubrir.ReadOnly = true;
            // 
            // EnBaseA
            // 
            this.EnBaseA.HeaderText = "En base a";
            this.EnBaseA.Name = "EnBaseA";
            this.EnBaseA.ReadOnly = true;
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Visible = false;
            // 
            // NombreUsuario
            // 
            this.NombreUsuario.HeaderText = "Usuario";
            this.NombreUsuario.Name = "NombreUsuario";
            this.NombreUsuario.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Agregar
            // 
            this.Agregar.HeaderText = "Agregar";
            this.Agregar.Name = "Agregar";
            this.Agregar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Agregar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ProductosAgregadosPorEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.aut);
            this.Controls.Add(this.dgv);
            this.Name = "ProductosAgregadosPorEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos agregados por empleados";
            this.Load += new System.EventHandler(this.ProductosAgregadosPorEmpleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private RoundedButton aut;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProductoEsperaCotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadCajas;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadesPorCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadUnidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionUnidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasCubrir;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnBaseA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Agregar;
        //No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, comerciales, o cualquier otro fin, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
    }
}