namespace ValleVerde.Vistas.Compras
{
    partial class ComprasSugeridas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComprasSugeridas));
            this.datGriVieProv = new System.Windows.Forms.DataGridView();
            this.IDCotizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datGriVieProd = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labSub = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.labImp = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.labTot = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.butConGenPed = new ValleVerde.RoundedButton();
            this.butDes = new ValleVerde.RoundedButton();
            this.CodigoBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDClaveAdicional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadPiezas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExistenciaActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datGriVieProv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datGriVieProd)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // datGriVieProv
            // 
            this.datGriVieProv.AllowUserToAddRows = false;
            this.datGriVieProv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datGriVieProv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datGriVieProv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGriVieProv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDCotizacion,
            this.IdProveedor,
            this.Proveedor});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datGriVieProv.DefaultCellStyle = dataGridViewCellStyle2;
            this.datGriVieProv.Location = new System.Drawing.Point(9, 10);
            this.datGriVieProv.Margin = new System.Windows.Forms.Padding(2);
            this.datGriVieProv.MultiSelect = false;
            this.datGriVieProv.Name = "datGriVieProv";
            this.datGriVieProv.ReadOnly = true;
            this.datGriVieProv.RowHeadersVisible = false;
            this.datGriVieProv.RowHeadersWidth = 51;
            this.datGriVieProv.RowTemplate.Height = 24;
            this.datGriVieProv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datGriVieProv.Size = new System.Drawing.Size(90, 566);
            this.datGriVieProv.TabIndex = 2;
            // 
            // IDCotizacion
            // 
            this.IDCotizacion.HeaderText = "ID de cotizacion";
            this.IDCotizacion.Name = "IDCotizacion";
            this.IDCotizacion.ReadOnly = true;
            this.IDCotizacion.Visible = false;
            // 
            // IdProveedor
            // 
            this.IdProveedor.HeaderText = "ID Proveedor";
            this.IdProveedor.Name = "IdProveedor";
            this.IdProveedor.ReadOnly = true;
            this.IdProveedor.Visible = false;
            // 
            // Proveedor
            // 
            this.Proveedor.FillWeight = 32.08556F;
            this.Proveedor.HeaderText = "Proveedor";
            this.Proveedor.MinimumWidth = 6;
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.ReadOnly = true;
            // 
            // datGriVieProd
            // 
            this.datGriVieProd.AllowUserToAddRows = false;
            this.datGriVieProd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datGriVieProd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.datGriVieProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGriVieProd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoBarras,
            this.IDClaveAdicional,
            this.CantidadPiezas,
            this.Descripcion,
            this.PrecioUnitario,
            this.ExistenciaActual});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datGriVieProd.DefaultCellStyle = dataGridViewCellStyle4;
            this.datGriVieProd.Location = new System.Drawing.Point(113, 11);
            this.datGriVieProd.Margin = new System.Windows.Forms.Padding(2);
            this.datGriVieProd.MultiSelect = false;
            this.datGriVieProd.Name = "datGriVieProd";
            this.datGriVieProd.RowHeadersVisible = false;
            this.datGriVieProd.RowHeadersWidth = 51;
            this.datGriVieProd.RowTemplate.Height = 24;
            this.datGriVieProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datGriVieProd.Size = new System.Drawing.Size(889, 510);
            this.datGriVieProd.TabIndex = 71;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labSub);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.labImp);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.labTot);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.Location = new System.Drawing.Point(474, 526);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(528, 50);
            this.groupBox2.TabIndex = 141;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Estimación";
            // 
            // labSub
            // 
            this.labSub.AutoSize = true;
            this.labSub.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSub.ForeColor = System.Drawing.Color.DarkRed;
            this.labSub.Location = new System.Drawing.Point(124, 22);
            this.labSub.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labSub.Name = "labSub";
            this.labSub.Size = new System.Drawing.Size(90, 20);
            this.labSub.TabIndex = 128;
            this.labSub.Text = "$99999999";
            this.labSub.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(60, 22);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 20);
            this.label15.TabIndex = 127;
            this.label15.Text = "Subtotal:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labImp
            // 
            this.labImp.AutoSize = true;
            this.labImp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labImp.ForeColor = System.Drawing.Color.DarkRed;
            this.labImp.Location = new System.Drawing.Point(296, 22);
            this.labImp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labImp.Name = "labImp";
            this.labImp.Size = new System.Drawing.Size(90, 20);
            this.labImp.TabIndex = 126;
            this.labImp.Text = "$99999999";
            this.labImp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(218, 22);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 20);
            this.label18.TabIndex = 125;
            this.label18.Text = "Impuestos:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labTot
            // 
            this.labTot.AutoSize = true;
            this.labTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTot.ForeColor = System.Drawing.Color.DarkRed;
            this.labTot.Location = new System.Drawing.Point(433, 22);
            this.labTot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labTot.Name = "labTot";
            this.labTot.Size = new System.Drawing.Size(90, 20);
            this.labTot.TabIndex = 124;
            this.labTot.Text = "$99999999";
            this.labTot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(390, 22);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 20);
            this.label21.TabIndex = 123;
            this.label21.Text = "Total:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // butConGenPed
            // 
            this.butConGenPed.BackColor = System.Drawing.Color.White;
            this.butConGenPed.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.butConGenPed.FlatAppearance.BorderSize = 5;
            this.butConGenPed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butConGenPed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butConGenPed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.butConGenPed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butConGenPed.Location = new System.Drawing.Point(223, 530);
            this.butConGenPed.Name = "butConGenPed";
            this.butConGenPed.Size = new System.Drawing.Size(204, 46);
            this.butConGenPed.TabIndex = 100;
            this.butConGenPed.Text = "Confirmar y generar pedido";
            this.butConGenPed.UseVisualStyleBackColor = false;
            this.butConGenPed.Click += new System.EventHandler(this.butConGenPed_Click);
            // 
            // butDes
            // 
            this.butDes.BackColor = System.Drawing.Color.White;
            this.butDes.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.butDes.FlatAppearance.BorderSize = 5;
            this.butDes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butDes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.butDes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butDes.Location = new System.Drawing.Point(113, 530);
            this.butDes.Name = "butDes";
            this.butDes.Size = new System.Drawing.Size(104, 46);
            this.butDes.TabIndex = 99;
            this.butDes.Text = "Descartar";
            this.butDes.UseVisualStyleBackColor = false;
            this.butDes.Click += new System.EventHandler(this.butDes_Click);
            // 
            // CodigoBarras
            // 
            this.CodigoBarras.HeaderText = "Código de barras";
            this.CodigoBarras.Name = "CodigoBarras";
            // 
            // IDClaveAdicional
            // 
            this.IDClaveAdicional.HeaderText = "IDClaveAdicional";
            this.IDClaveAdicional.Name = "IDClaveAdicional";
            this.IDClaveAdicional.Visible = false;
            // 
            // CantidadPiezas
            // 
            this.CantidadPiezas.HeaderText = "Unidades a pedir";
            this.CantidadPiezas.MinimumWidth = 6;
            this.CantidadPiezas.Name = "CantidadPiezas";
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // PrecioUnitario
            // 
            this.PrecioUnitario.HeaderText = "Costo unitario";
            this.PrecioUnitario.MinimumWidth = 6;
            this.PrecioUnitario.Name = "PrecioUnitario";
            this.PrecioUnitario.ReadOnly = true;
            // 
            // ExistenciaActual
            // 
            this.ExistenciaActual.HeaderText = "Existencia actual";
            this.ExistenciaActual.MinimumWidth = 6;
            this.ExistenciaActual.Name = "ExistenciaActual";
            this.ExistenciaActual.ReadOnly = true;
            // 
            // ComprasSugeridas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 586);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.butConGenPed);
            this.Controls.Add(this.butDes);
            this.Controls.Add(this.datGriVieProd);
            this.Controls.Add(this.datGriVieProv);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ComprasSugeridas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mejores precios";
            this.Load += new System.EventHandler(this.ComprasSugeridas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datGriVieProv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datGriVieProd)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datGriVieProv;
        private System.Windows.Forms.DataGridView datGriVieProd;
        private RoundedButton butDes;
        private RoundedButton butConGenPed;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labSub;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labImp;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label labTot;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDClaveAdicional;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadPiezas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExistenciaActual;
        //No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, comerciales, o cualquier otro fin, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
    }
}