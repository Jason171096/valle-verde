namespace ValleVerde.Vistas.Compras
{
    partial class ElegirProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ElegirProveedores));
            this.datGriVieProd = new System.Windows.Forms.DataGridView();
            this.butCon = new ValleVerde.RoundedButton();
            this.IDCotizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDClaveAdicional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Encargar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datGriVieProd)).BeginInit();
            this.SuspendLayout();
            // 
            // datGriVieProd
            // 
            this.datGriVieProd.AllowUserToAddRows = false;
            this.datGriVieProd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datGriVieProd.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datGriVieProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGriVieProd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDCotizacion,
            this.IDClaveAdicional,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.PrecioProveedor,
            this.Encargar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datGriVieProd.DefaultCellStyle = dataGridViewCellStyle2;
            this.datGriVieProd.Location = new System.Drawing.Point(11, 11);
            this.datGriVieProd.Margin = new System.Windows.Forms.Padding(2);
            this.datGriVieProd.MultiSelect = false;
            this.datGriVieProd.Name = "datGriVieProd";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datGriVieProd.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.datGriVieProd.RowHeadersVisible = false;
            this.datGriVieProd.RowHeadersWidth = 51;
            this.datGriVieProd.RowTemplate.Height = 24;
            this.datGriVieProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datGriVieProd.Size = new System.Drawing.Size(989, 512);
            this.datGriVieProd.TabIndex = 132;
            // 
            // butCon
            // 
            this.butCon.BackColor = System.Drawing.Color.White;
            this.butCon.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.butCon.FlatAppearance.BorderSize = 5;
            this.butCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butCon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.butCon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCon.Location = new System.Drawing.Point(871, 528);
            this.butCon.Name = "butCon";
            this.butCon.Size = new System.Drawing.Size(128, 46);
            this.butCon.TabIndex = 133;
            this.butCon.Text = "Continuar";
            this.butCon.UseVisualStyleBackColor = false;
            this.butCon.Click += new System.EventHandler(this.butCon_Click);
            // 
            // IDCotizacion
            // 
            this.IDCotizacion.HeaderText = "IDCotizacion";
            this.IDCotizacion.Name = "IDCotizacion";
            this.IDCotizacion.ReadOnly = true;
            // 
            // IDClaveAdicional
            // 
            this.IDClaveAdicional.HeaderText = "IDClaveAdicional";
            this.IDClaveAdicional.Name = "IDClaveAdicional";
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
            // PrecioProveedor
            // 
            this.PrecioProveedor.HeaderText = "Precio por proveedor";
            this.PrecioProveedor.MinimumWidth = 6;
            this.PrecioProveedor.Name = "PrecioProveedor";
            this.PrecioProveedor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Encargar
            // 
            this.Encargar.HeaderText = "Encargar";
            this.Encargar.Name = "Encargar";
            this.Encargar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Encargar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ElegirProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 586);
            this.Controls.Add(this.butCon);
            this.Controls.Add(this.datGriVieProd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ElegirProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elegir proveedores";
            this.Load += new System.EventHandler(this.ElegirProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datGriVieProd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView datGriVieProd;
        private RoundedButton butCon;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCotizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDClaveAdicional;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioProveedor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Encargar;
    }
}