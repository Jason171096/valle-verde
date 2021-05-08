namespace ValleVerde.Vistas
{
    partial class GenerarPedido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerarPedido));
            this.datGriVieProv = new System.Windows.Forms.DataGridView();
            this.IDCotizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdProv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datGriVieProd = new System.Windows.Forms.DataGridView();
            this.butBusMejPre = new ValleVerde.RoundedButton();
            this.butRecCarLisExc = new ValleVerde.RoundedButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EsCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadesPorCaja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datGriVieProv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datGriVieProd)).BeginInit();
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
            this.IdProv,
            this.Nombre});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datGriVieProv.DefaultCellStyle = dataGridViewCellStyle2;
            this.datGriVieProv.Location = new System.Drawing.Point(12, 11);
            this.datGriVieProv.Margin = new System.Windows.Forms.Padding(2);
            this.datGriVieProv.MultiSelect = false;
            this.datGriVieProv.Name = "datGriVieProv";
            this.datGriVieProv.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datGriVieProv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.datGriVieProv.RowHeadersVisible = false;
            this.datGriVieProv.RowHeadersWidth = 51;
            this.datGriVieProv.RowTemplate.Height = 24;
            this.datGriVieProv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datGriVieProv.Size = new System.Drawing.Size(176, 645);
            this.datGriVieProv.TabIndex = 133;
            // 
            // IDCotizacion
            // 
            this.IDCotizacion.HeaderText = "ID de cotizacion";
            this.IDCotizacion.Name = "IDCotizacion";
            this.IDCotizacion.ReadOnly = true;
            this.IDCotizacion.Visible = false;
            // 
            // IdProv
            // 
            this.IdProv.HeaderText = "ID de proveedor";
            this.IdProv.Name = "IdProv";
            this.IdProv.ReadOnly = true;
            this.IdProv.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Proveedor";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // datGriVieProd
            // 
            this.datGriVieProd.AllowUserToAddRows = false;
            this.datGriVieProd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datGriVieProd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.datGriVieProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGriVieProd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.CostoUnitario,
            this.EsCaja,
            this.UnidadesPorCaja,
            this.Unidad});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datGriVieProd.DefaultCellStyle = dataGridViewCellStyle5;
            this.datGriVieProd.Location = new System.Drawing.Point(205, 11);
            this.datGriVieProd.Margin = new System.Windows.Forms.Padding(2);
            this.datGriVieProd.MultiSelect = false;
            this.datGriVieProd.Name = "datGriVieProd";
            this.datGriVieProd.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datGriVieProd.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.datGriVieProd.RowHeadersVisible = false;
            this.datGriVieProd.RowHeadersWidth = 51;
            this.datGriVieProd.RowTemplate.Height = 24;
            this.datGriVieProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datGriVieProd.Size = new System.Drawing.Size(1134, 645);
            this.datGriVieProd.TabIndex = 131;
            // 
            // butBusMejPre
            // 
            this.butBusMejPre.BackColor = System.Drawing.Color.White;
            this.butBusMejPre.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.butBusMejPre.FlatAppearance.BorderSize = 5;
            this.butBusMejPre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butBusMejPre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butBusMejPre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.butBusMejPre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butBusMejPre.Location = new System.Drawing.Point(1158, 671);
            this.butBusMejPre.Name = "butBusMejPre";
            this.butBusMejPre.Size = new System.Drawing.Size(180, 46);
            this.butBusMejPre.TabIndex = 134;
            this.butBusMejPre.Text = "Buscar mejores precios";
            this.butBusMejPre.UseVisualStyleBackColor = false;
            this.butBusMejPre.Click += new System.EventHandler(this.butBusMejPre_Click);
            // 
            // butRecCarLisExc
            // 
            this.butRecCarLisExc.BackColor = System.Drawing.Color.White;
            this.butRecCarLisExc.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.butRecCarLisExc.FlatAppearance.BorderSize = 5;
            this.butRecCarLisExc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butRecCarLisExc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butRecCarLisExc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.butRecCarLisExc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butRecCarLisExc.Location = new System.Drawing.Point(12, 671);
            this.butRecCarLisExc.Name = "butRecCarLisExc";
            this.butRecCarLisExc.Size = new System.Drawing.Size(181, 46);
            this.butRecCarLisExc.TabIndex = 132;
            this.butRecCarLisExc.Text = "Cargar listas de Excel";
            this.butRecCarLisExc.UseVisualStyleBackColor = false;
            this.butRecCarLisExc.Click += new System.EventHandler(this.butRecCarLisExc_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Código de barras";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // CostoUnitario
            // 
            this.CostoUnitario.HeaderText = "Costo unitario";
            this.CostoUnitario.MinimumWidth = 6;
            this.CostoUnitario.Name = "CostoUnitario";
            this.CostoUnitario.ReadOnly = true;
            // 
            // EsCaja
            // 
            this.EsCaja.HeaderText = "EsCaja";
            this.EsCaja.Name = "EsCaja";
            this.EsCaja.ReadOnly = true;
            this.EsCaja.Visible = false;
            // 
            // UnidadesPorCaja
            // 
            this.UnidadesPorCaja.HeaderText = "UnidadesPorCaja";
            this.UnidadesPorCaja.Name = "UnidadesPorCaja";
            this.UnidadesPorCaja.ReadOnly = true;
            this.UnidadesPorCaja.Visible = false;
            // 
            // Unidad
            // 
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.ReadOnly = true;
            this.Unidad.Visible = false;
            // 
            // GenerarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.datGriVieProv);
            this.Controls.Add(this.datGriVieProd);
            this.Controls.Add(this.butBusMejPre);
            this.Controls.Add(this.butRecCarLisExc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GenerarPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recibir cotización";
            this.Load += new System.EventHandler(this.GenerarPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datGriVieProv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datGriVieProd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datGriVieProv;
        private System.Windows.Forms.DataGridView datGriVieProd;
        private RoundedButton butBusMejPre;
        private RoundedButton butRecCarLisExc;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn EsCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadesPorCaja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        //No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, comerciales, o cualquier otro fin, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
    }
}