namespace ValleVerde.Vistas.Ventas
{
    partial class PromoProductoAdicional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PromoProductoAdicional));
            this.textAdicional = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.anadir = new ValleVerde.RoundedButton();
            this.aceptar = new ValleVerde.RoundedButton();
            this.buscar = new System.Windows.Forms.Button();
            this.textDescuento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textCantidad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAdicional = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdicional)).BeginInit();
            this.SuspendLayout();
            // 
            // textAdicional
            // 
            this.textAdicional.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAdicional.Location = new System.Drawing.Point(251, 32);
            this.textAdicional.Name = "textAdicional";
            this.textAdicional.Size = new System.Drawing.Size(340, 26);
            this.textAdicional.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Código producto adicional :";
            // 
            // anadir
            // 
            this.anadir.BackColor = System.Drawing.Color.White;
            this.anadir.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.anadir.FlatAppearance.BorderSize = 5;
            this.anadir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.anadir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.anadir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.anadir.Image = global::ValleVerde.Properties.Resources.mas24;
            this.anadir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.anadir.Location = new System.Drawing.Point(625, 101);
            this.anadir.Name = "anadir";
            this.anadir.Size = new System.Drawing.Size(92, 37);
            this.anadir.TabIndex = 4;
            this.anadir.Text = "Añadir";
            this.anadir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.anadir.UseVisualStyleBackColor = false;
            this.anadir.Click += new System.EventHandler(this.anadir_Click);
            // 
            // aceptar
            // 
            this.aceptar.BackColor = System.Drawing.Color.White;
            this.aceptar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.aceptar.FlatAppearance.BorderSize = 5;
            this.aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.aceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.aceptar.Image = global::ValleVerde.Properties.Resources.correcto;
            this.aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aceptar.Location = new System.Drawing.Point(644, 346);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(101, 41);
            this.aceptar.TabIndex = 5;
            this.aceptar.Text = "Aceptar";
            this.aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.aceptar.UseVisualStyleBackColor = false;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // buscar
            // 
            this.buscar.FlatAppearance.BorderSize = 0;
            this.buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscar.Image = global::ValleVerde.Properties.Resources.lupa24;
            this.buscar.Location = new System.Drawing.Point(613, 32);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(34, 29);
            this.buscar.TabIndex = 6;
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // textDescuento
            // 
            this.textDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDescuento.Location = new System.Drawing.Point(439, 106);
            this.textDescuento.Name = "textDescuento";
            this.textDescuento.Size = new System.Drawing.Size(132, 26);
            this.textDescuento.TabIndex = 8;
            this.textDescuento.Text = "100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(333, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Descuento:";
            // 
            // textCantidad
            // 
            this.textCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCantidad.Location = new System.Drawing.Point(161, 106);
            this.textCantidad.Name = "textCantidad";
            this.textCantidad.Size = new System.Drawing.Size(131, 26);
            this.textCantidad.TabIndex = 10;
            this.textCantidad.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cantidad:";
            // 
            // textNombre
            // 
            this.textNombre.Enabled = false;
            this.textNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNombre.Location = new System.Drawing.Point(161, 70);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(430, 26);
            this.textNombre.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Nombre:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(572, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "%";
            // 
            // descuento
            // 
            this.descuento.FillWeight = 59.03715F;
            this.descuento.HeaderText = "Descuento";
            this.descuento.Name = "descuento";
            // 
            // cantidad
            // 
            this.cantidad.FillWeight = 72.70445F;
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            // 
            // nombre
            // 
            this.nombre.FillWeight = 166.7355F;
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            // 
            // idProducto
            // 
            this.idProducto.FillWeight = 101.5228F;
            this.idProducto.HeaderText = "Código Producto";
            this.idProducto.Name = "idProducto";
            // 
            // dgvAdicional
            // 
            this.dgvAdicional.AllowUserToAddRows = false;
            this.dgvAdicional.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAdicional.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAdicional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdicional.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProducto,
            this.nombre,
            this.cantidad,
            this.descuento});
            this.dgvAdicional.Location = new System.Drawing.Point(53, 167);
            this.dgvAdicional.Name = "dgvAdicional";
            this.dgvAdicional.RowHeadersVisible = false;
            this.dgvAdicional.Size = new System.Drawing.Size(692, 160);
            this.dgvAdicional.TabIndex = 11;
            // 
            // PromoProductoAdicional
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 396);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvAdicional);
            this.Controls.Add(this.textCantidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textDescuento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.anadir);
            this.Controls.Add(this.textAdicional);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PromoProductoAdicional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Promoción Producto Adicional:";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdicional)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textAdicional;
        private System.Windows.Forms.Label label1;
        private RoundedButton anadir;
        private RoundedButton aceptar;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.TextBox textDescuento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProducto;
        private System.Windows.Forms.DataGridView dgvAdicional;
    }
}