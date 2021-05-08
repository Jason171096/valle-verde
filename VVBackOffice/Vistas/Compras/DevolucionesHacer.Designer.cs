namespace ValleVerde.Vistas.Compras
{
    partial class DevolucionesHacer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevolucionesHacer));
            this.tbCodBar = new System.Windows.Forms.TextBox();
            this.prod = new System.Windows.Forms.DataGridView();
            this.prov = new System.Windows.Forms.DataGridView();
            this.IDProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbProv = new System.Windows.Forms.ComboBox();
            this.lImpSal = new System.Windows.Forms.Label();
            this.bFin = new ValleVerde.RoundedButton();
            this.roundedButton1 = new ValleVerde.RoundedButton();
            this.can = new ValleVerde.RoundedButton();
            this.agrProv = new ValleVerde.RoundedButton();
            this.butSelProd = new ValleVerde.RoundedButton();
            this.butAgrPro = new ValleVerde.RoundedButton();
            this.bCon = new ValleVerde.RoundedButton();
            this.IDDevolucionCompraSaliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDevolucion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Motivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.prod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prov)).BeginInit();
            this.SuspendLayout();
            // 
            // tbCodBar
            // 
            this.tbCodBar.Enabled = false;
            this.tbCodBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbCodBar.Location = new System.Drawing.Point(918, 22);
            this.tbCodBar.Margin = new System.Windows.Forms.Padding(2);
            this.tbCodBar.Name = "tbCodBar";
            this.tbCodBar.Size = new System.Drawing.Size(219, 26);
            this.tbCodBar.TabIndex = 131;
            // 
            // prod
            // 
            this.prod.AllowUserToAddRows = false;
            this.prod.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.prod.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.prod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prod.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDDevolucionCompraSaliente,
            this.IDProducto,
            this.Cantidad,
            this.DescripcionProducto,
            this.Costo,
            this.TipoDevolucion,
            this.Motivo,
            this.Importe});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.prod.DefaultCellStyle = dataGridViewCellStyle2;
            this.prod.Location = new System.Drawing.Point(223, 89);
            this.prod.Margin = new System.Windows.Forms.Padding(2);
            this.prod.MultiSelect = false;
            this.prod.Name = "prod";
            this.prod.RowHeadersVisible = false;
            this.prod.RowHeadersWidth = 51;
            this.prod.RowTemplate.Height = 24;
            this.prod.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.prod.Size = new System.Drawing.Size(1116, 567);
            this.prod.TabIndex = 130;
            // 
            // prov
            // 
            this.prov.AllowUserToAddRows = false;
            this.prov.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.prov.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.prov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.prov.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDProveedor,
            this.Proveedor});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.prov.DefaultCellStyle = dataGridViewCellStyle4;
            this.prov.Location = new System.Drawing.Point(11, 89);
            this.prov.Margin = new System.Windows.Forms.Padding(2);
            this.prov.MultiSelect = false;
            this.prov.Name = "prov";
            this.prov.ReadOnly = true;
            this.prov.RowHeadersVisible = false;
            this.prov.RowHeadersWidth = 51;
            this.prov.RowTemplate.Height = 24;
            this.prov.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.prov.Size = new System.Drawing.Size(203, 567);
            this.prov.TabIndex = 129;
            // 
            // IDProveedor
            // 
            this.IDProveedor.HeaderText = "ID de proveedor";
            this.IDProveedor.MinimumWidth = 6;
            this.IDProveedor.Name = "IDProveedor";
            this.IDProveedor.ReadOnly = true;
            // 
            // Proveedor
            // 
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.ReadOnly = true;
            // 
            // cbProv
            // 
            this.cbProv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbProv.FormattingEnabled = true;
            this.cbProv.Location = new System.Drawing.Point(12, 20);
            this.cbProv.Name = "cbProv";
            this.cbProv.Size = new System.Drawing.Size(407, 28);
            this.cbProv.TabIndex = 135;
            // 
            // lImpSal
            // 
            this.lImpSal.AutoSize = true;
            this.lImpSal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lImpSal.Location = new System.Drawing.Point(818, 684);
            this.lImpSal.Name = "lImpSal";
            this.lImpSal.Size = new System.Drawing.Size(63, 20);
            this.lImpSal.TabIndex = 160;
            this.lImpSal.Text = "$00000";
            this.lImpSal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bFin
            // 
            this.bFin.BackColor = System.Drawing.Color.White;
            this.bFin.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.bFin.FlatAppearance.BorderSize = 5;
            this.bFin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.bFin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.bFin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bFin.Location = new System.Drawing.Point(1202, 671);
            this.bFin.Name = "bFin";
            this.bFin.Size = new System.Drawing.Size(136, 46);
            this.bFin.TabIndex = 161;
            this.bFin.Text = "Confirmar";
            this.bFin.UseVisualStyleBackColor = false;
            this.bFin.Click += new System.EventHandler(this.bFin_Click);
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.White;
            this.roundedButton1.Enabled = false;
            this.roundedButton1.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.roundedButton1.FlatAppearance.BorderSize = 5;
            this.roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.roundedButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.roundedButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roundedButton1.Location = new System.Drawing.Point(223, 671);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(106, 46);
            this.roundedButton1.TabIndex = 159;
            this.roundedButton1.Text = "Eliminar";
            this.roundedButton1.UseVisualStyleBackColor = false;
            // 
            // can
            // 
            this.can.BackColor = System.Drawing.Color.White;
            this.can.Enabled = false;
            this.can.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.can.FlatAppearance.BorderSize = 5;
            this.can.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.can.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.can.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.can.Image = global::ValleVerde.Properties.Resources.cancelar;
            this.can.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.can.Location = new System.Drawing.Point(12, 671);
            this.can.Name = "can";
            this.can.Size = new System.Drawing.Size(182, 46);
            this.can.TabIndex = 137;
            this.can.Text = "Cancelar devolución";
            this.can.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.can.UseVisualStyleBackColor = false;
            this.can.Click += new System.EventHandler(this.can_Click);
            // 
            // agrProv
            // 
            this.agrProv.BackColor = System.Drawing.Color.White;
            this.agrProv.Enabled = false;
            this.agrProv.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.agrProv.FlatAppearance.BorderSize = 5;
            this.agrProv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agrProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.agrProv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.agrProv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.agrProv.Location = new System.Drawing.Point(425, 12);
            this.agrProv.Name = "agrProv";
            this.agrProv.Size = new System.Drawing.Size(148, 46);
            this.agrProv.TabIndex = 136;
            this.agrProv.Text = "Agregar proveedor";
            this.agrProv.UseVisualStyleBackColor = false;
            this.agrProv.Click += new System.EventHandler(this.agrProv_Click);
            // 
            // butSelProd
            // 
            this.butSelProd.BackColor = System.Drawing.SystemColors.Control;
            this.butSelProd.Enabled = false;
            this.butSelProd.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.butSelProd.FlatAppearance.BorderSize = 5;
            this.butSelProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSelProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butSelProd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.butSelProd.Image = global::ValleVerde.Properties.Resources.lupa;
            this.butSelProd.Location = new System.Drawing.Point(1142, 12);
            this.butSelProd.Name = "butSelProd";
            this.butSelProd.Size = new System.Drawing.Size(43, 46);
            this.butSelProd.TabIndex = 133;
            this.butSelProd.UseVisualStyleBackColor = false;
            this.butSelProd.Click += new System.EventHandler(this.butSelProd_Click);
            // 
            // butAgrPro
            // 
            this.butAgrPro.BackColor = System.Drawing.Color.White;
            this.butAgrPro.Enabled = false;
            this.butAgrPro.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.butAgrPro.FlatAppearance.BorderSize = 5;
            this.butAgrPro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAgrPro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butAgrPro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.butAgrPro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAgrPro.Location = new System.Drawing.Point(1191, 12);
            this.butAgrPro.Name = "butAgrPro";
            this.butAgrPro.Size = new System.Drawing.Size(148, 46);
            this.butAgrPro.TabIndex = 132;
            this.butAgrPro.Text = "Agregar";
            this.butAgrPro.UseVisualStyleBackColor = false;
            this.butAgrPro.Click += new System.EventHandler(this.butAgrPro_Click);
            // 
            // bCon
            // 
            this.bCon.BackColor = System.Drawing.Color.White;
            this.bCon.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.bCon.FlatAppearance.BorderSize = 5;
            this.bCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.bCon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.bCon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCon.Location = new System.Drawing.Point(1060, 671);
            this.bCon.Name = "bCon";
            this.bCon.Size = new System.Drawing.Size(136, 46);
            this.bCon.TabIndex = 162;
            this.bCon.Text = "Continuar";
            this.bCon.UseVisualStyleBackColor = false;
            this.bCon.Visible = false;
            this.bCon.Click += new System.EventHandler(this.bCon_Click);
            // 
            // IDDevolucionCompraSaliente
            // 
            this.IDDevolucionCompraSaliente.HeaderText = "IDProductoDevolucionCompra";
            this.IDDevolucionCompraSaliente.Name = "IDDevolucionCompraSaliente";
            this.IDDevolucionCompraSaliente.ReadOnly = true;
            this.IDDevolucionCompraSaliente.Visible = false;
            // 
            // IDProducto
            // 
            this.IDProducto.HeaderText = "Código de barras";
            this.IDProducto.Name = "IDProducto";
            this.IDProducto.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // DescripcionProducto
            // 
            this.DescripcionProducto.HeaderText = "Descripcion";
            this.DescripcionProducto.Name = "DescripcionProducto";
            this.DescripcionProducto.ReadOnly = true;
            // 
            // Costo
            // 
            this.Costo.HeaderText = "Costo";
            this.Costo.Name = "Costo";
            this.Costo.ReadOnly = true;
            // 
            // TipoDevolucion
            // 
            this.TipoDevolucion.HeaderText = "Se cambiará por";
            this.TipoDevolucion.Name = "TipoDevolucion";
            this.TipoDevolucion.ReadOnly = true;
            // 
            // Motivo
            // 
            this.Motivo.HeaderText = "Motivo";
            this.Motivo.Name = "Motivo";
            // 
            // Importe
            // 
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            // 
            // DevolucionesHacer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.bCon);
            this.Controls.Add(this.bFin);
            this.Controls.Add(this.lImpSal);
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.can);
            this.Controls.Add(this.agrProv);
            this.Controls.Add(this.cbProv);
            this.Controls.Add(this.butSelProd);
            this.Controls.Add(this.butAgrPro);
            this.Controls.Add(this.tbCodBar);
            this.Controls.Add(this.prod);
            this.Controls.Add(this.prov);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DevolucionesHacer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hacer devolución";
            this.Load += new System.EventHandler(this.DevolucionesHacer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prov)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton butSelProd;
        private RoundedButton butAgrPro;
        private System.Windows.Forms.TextBox tbCodBar;
        private System.Windows.Forms.DataGridView prod;
        private System.Windows.Forms.DataGridView prov;
        private System.Windows.Forms.ComboBox cbProv;
        private RoundedButton agrProv;
        private RoundedButton can;
        private RoundedButton roundedButton1;
        private System.Windows.Forms.Label lImpSal;
        private RoundedButton bFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private RoundedButton bCon;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDDevolucionCompraSaliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDevolucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Motivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        //No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, comerciales, o cualquier otro fin, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
    }
}