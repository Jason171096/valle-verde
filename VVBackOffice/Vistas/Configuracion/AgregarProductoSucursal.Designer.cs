namespace ValleVerde.Vistas.Configuracion
{
    partial class AgregarProductoSucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarProductoSucursal));
            this.dgvProductoSuc = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProducto = new System.Windows.Forms.TextBox();
            this.botonProducto = new System.Windows.Forms.Button();
            this.cbMarca = new System.Windows.Forms.ComboBox();
            this.cbLinea = new System.Windows.Forms.ComboBox();
            this.cbProveedor = new System.Windows.Forms.ComboBox();
            this.cbFabricante = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.botonAgregar = new ValleVerde.RoundedButton();
            this.idProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.utilidadMatriz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.utilidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioSuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductoSuc)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductoSuc
            // 
            this.dgvProductoSuc.AllowUserToAddRows = false;
            this.dgvProductoSuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProductoSuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductoSuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductoSuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProducto,
            this.nombre,
            this.costo,
            this.utilidadMatriz,
            this.precioM,
            this.utilidad,
            this.precioSuc});
            this.dgvProductoSuc.Location = new System.Drawing.Point(12, 189);
            this.dgvProductoSuc.Name = "dgvProductoSuc";
            this.dgvProductoSuc.RowHeadersVisible = false;
            this.dgvProductoSuc.Size = new System.Drawing.Size(1160, 393);
            this.dgvProductoSuc.TabIndex = 0;
            this.dgvProductoSuc.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductoSuc_CellValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(277, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Producto";
            // 
            // textBoxProducto
            // 
            this.textBoxProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxProducto.Location = new System.Drawing.Point(384, 29);
            this.textBoxProducto.Name = "textBoxProducto";
            this.textBoxProducto.Size = new System.Drawing.Size(411, 27);
            this.textBoxProducto.TabIndex = 2;
            this.textBoxProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxProducto_KeyDown);
            // 
            // botonProducto
            // 
            this.botonProducto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.botonProducto.FlatAppearance.BorderSize = 0;
            this.botonProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonProducto.Image = global::ValleVerde.Properties.Resources.lupa;
            this.botonProducto.Location = new System.Drawing.Point(801, 25);
            this.botonProducto.Name = "botonProducto";
            this.botonProducto.Size = new System.Drawing.Size(37, 36);
            this.botonProducto.TabIndex = 3;
            this.botonProducto.UseVisualStyleBackColor = true;
            this.botonProducto.Click += new System.EventHandler(this.botonProducto_Click);
            // 
            // cbMarca
            // 
            this.cbMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMarca.FormattingEnabled = true;
            this.cbMarca.Location = new System.Drawing.Point(134, 120);
            this.cbMarca.Name = "cbMarca";
            this.cbMarca.Size = new System.Drawing.Size(196, 28);
            this.cbMarca.TabIndex = 4;
            this.cbMarca.SelectionChangeCommitted += new System.EventHandler(this.cbMarca_SelectionChangeCommitted);
            // 
            // cbLinea
            // 
            this.cbLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLinea.FormattingEnabled = true;
            this.cbLinea.Location = new System.Drawing.Point(371, 120);
            this.cbLinea.Name = "cbLinea";
            this.cbLinea.Size = new System.Drawing.Size(196, 28);
            this.cbLinea.TabIndex = 5;
            this.cbLinea.SelectionChangeCommitted += new System.EventHandler(this.cbLinea_SelectionChangeCommitted);
            // 
            // cbProveedor
            // 
            this.cbProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbProveedor.FormattingEnabled = true;
            this.cbProveedor.Location = new System.Drawing.Point(601, 120);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(196, 28);
            this.cbProveedor.TabIndex = 6;
            this.cbProveedor.SelectionChangeCommitted += new System.EventHandler(this.cbProveedor_SelectionChangeCommitted);
            // 
            // cbFabricante
            // 
            this.cbFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFabricante.FormattingEnabled = true;
            this.cbFabricante.Location = new System.Drawing.Point(833, 120);
            this.cbFabricante.Name = "cbFabricante";
            this.cbFabricante.Size = new System.Drawing.Size(196, 28);
            this.cbFabricante.TabIndex = 7;
            this.cbFabricante.SelectionChangeCommitted += new System.EventHandler(this.cbFabricante_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(207, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "Marca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(448, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 22);
            this.label3.TabIndex = 9;
            this.label3.Text = "Linea";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(652, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "Proveedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(885, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 22);
            this.label5.TabIndex = 11;
            this.label5.Text = "Fabricante";
            // 
            // botonAgregar
            // 
            this.botonAgregar.BackColor = System.Drawing.Color.White;
            this.botonAgregar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.botonAgregar.FlatAppearance.BorderSize = 5;
            this.botonAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.botonAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.botonAgregar.Location = new System.Drawing.Point(900, 601);
            this.botonAgregar.Name = "botonAgregar";
            this.botonAgregar.Size = new System.Drawing.Size(109, 38);
            this.botonAgregar.TabIndex = 12;
            this.botonAgregar.Text = "Agregar";
            this.botonAgregar.UseVisualStyleBackColor = false;
            this.botonAgregar.Click += new System.EventHandler(this.botonAgregar_Click);
            // 
            // idProducto
            // 
            this.idProducto.FillWeight = 106.0754F;
            this.idProducto.HeaderText = "Codigo";
            this.idProducto.Name = "idProducto";
            // 
            // nombre
            // 
            this.nombre.FillWeight = 249.4366F;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            // 
            // costo
            // 
            this.costo.HeaderText = "Costo";
            this.costo.Name = "costo";
            // 
            // utilidadMatriz
            // 
            this.utilidadMatriz.FillWeight = 55.26635F;
            this.utilidadMatriz.HeaderText = "Utilidad Matriz";
            this.utilidadMatriz.Name = "utilidadMatriz";
            // 
            // precioM
            // 
            this.precioM.FillWeight = 67.2735F;
            this.precioM.HeaderText = "Precio Matriz";
            this.precioM.Name = "precioM";
            // 
            // utilidad
            // 
            this.utilidad.FillWeight = 54.94302F;
            this.utilidad.HeaderText = "Utilidad Suc";
            this.utilidad.Name = "utilidad";
            // 
            // precioSuc
            // 
            this.precioSuc.FillWeight = 67.00507F;
            this.precioSuc.HeaderText = "Precio Suc";
            this.precioSuc.Name = "precioSuc";
            // 
            // AgregarProductoSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.botonAgregar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFabricante);
            this.Controls.Add(this.cbProveedor);
            this.Controls.Add(this.cbLinea);
            this.Controls.Add(this.cbMarca);
            this.Controls.Add(this.botonProducto);
            this.Controls.Add(this.textBoxProducto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvProductoSuc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AgregarProductoSucursal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Producto Sucursal";
            this.Load += new System.EventHandler(this.AgregarProductoSucursal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductoSuc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductoSuc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProducto;
        private System.Windows.Forms.Button botonProducto;
        private System.Windows.Forms.ComboBox cbMarca;
        private System.Windows.Forms.ComboBox cbLinea;
        private System.Windows.Forms.ComboBox cbProveedor;
        private System.Windows.Forms.ComboBox cbFabricante;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private RoundedButton botonAgregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn utilidadMatriz;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioM;
        private System.Windows.Forms.DataGridViewTextBoxColumn utilidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioSuc;
    }
}