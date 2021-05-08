namespace ValleVerde
{
    partial class RegistrarEntrada
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarEntrada));
            this.comboconcepto = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textObservacion = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboAlmacen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textPrecio = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textdescripcion = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxProducto = new System.Windows.Forms.PictureBox();
            this.textCantidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textExistencia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvEntrada = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.textProducto = new System.Windows.Forms.TextBox();
            this.buttonAgregar = new ValleVerde.RoundedButton();
            this.buttonCancelar = new ValleVerde.RoundedButton();
            this.buttonRegiatrar = new ValleVerde.RoundedButton();
            this.comboAlmacenAntes = new System.Windows.Forms.ComboBox();
            this.labelAlmacenAntes = new System.Windows.Forms.Label();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.almacenAntes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quitar = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntrada)).BeginInit();
            this.SuspendLayout();
            // 
            // comboconcepto
            // 
            this.comboconcepto.CausesValidation = false;
            this.comboconcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboconcepto.FormattingEnabled = true;
            this.comboconcepto.Location = new System.Drawing.Point(273, 267);
            this.comboconcepto.Name = "comboconcepto";
            this.comboconcepto.Size = new System.Drawing.Size(270, 32);
            this.comboconcepto.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(55, 270);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "Concepto de entrada:";
            // 
            // textObservacion
            // 
            this.textObservacion.Location = new System.Drawing.Point(273, 305);
            this.textObservacion.Name = "textObservacion";
            this.textObservacion.Size = new System.Drawing.Size(424, 81);
            this.textObservacion.TabIndex = 18;
            this.textObservacion.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(111, 305);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Observaciones:";
            // 
            // comboAlmacen
            // 
            this.comboAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboAlmacen.FormattingEnabled = true;
            this.comboAlmacen.Location = new System.Drawing.Point(223, 220);
            this.comboAlmacen.Name = "comboAlmacen";
            this.comboAlmacen.Size = new System.Drawing.Size(204, 32);
            this.comboAlmacen.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "Almacen de Destino:";
            // 
            // textPrecio
            // 
            this.textPrecio.Enabled = false;
            this.textPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPrecio.Location = new System.Drawing.Point(628, 130);
            this.textPrecio.Name = "textPrecio";
            this.textPrecio.Size = new System.Drawing.Size(120, 29);
            this.textPrecio.TabIndex = 66;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(546, 132);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 24);
            this.label18.TabIndex = 65;
            this.label18.Text = "Precio:";
            // 
            // textdescripcion
            // 
            this.textdescripcion.Enabled = false;
            this.textdescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textdescripcion.Location = new System.Drawing.Point(361, 90);
            this.textdescripcion.Name = "textdescripcion";
            this.textdescripcion.Size = new System.Drawing.Size(387, 29);
            this.textdescripcion.TabIndex = 63;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(228, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 24);
            this.label7.TabIndex = 62;
            this.label7.Text = "Descripcion:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBoxProducto);
            this.panel1.Location = new System.Drawing.Point(67, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(115, 104);
            this.panel1.TabIndex = 61;
            // 
            // pictureBoxProducto
            // 
            this.pictureBoxProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxProducto.Image = global::ValleVerde.Properties.Resources.producto_placeholder200;
            this.pictureBoxProducto.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxProducto.Name = "pictureBoxProducto";
            this.pictureBoxProducto.Size = new System.Drawing.Size(107, 96);
            this.pictureBoxProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxProducto.TabIndex = 0;
            this.pictureBoxProducto.TabStop = false;
            // 
            // textCantidad
            // 
            this.textCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCantidad.Location = new System.Drawing.Point(402, 168);
            this.textCantidad.Name = "textCantidad";
            this.textCantidad.Size = new System.Drawing.Size(128, 29);
            this.textCantidad.TabIndex = 60;
            this.textCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCantidad_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(197, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(204, 24);
            this.label6.TabIndex = 59;
            this.label6.Text = "Cantidad de entrada:";
            // 
            // textExistencia
            // 
            this.textExistencia.Enabled = false;
            this.textExistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textExistencia.Location = new System.Drawing.Point(402, 129);
            this.textExistencia.Name = "textExistencia";
            this.textExistencia.Size = new System.Drawing.Size(128, 29);
            this.textExistencia.TabIndex = 58;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(188, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 24);
            this.label5.TabIndex = 57;
            this.label5.Text = "Existencia en destino:";
            // 
            // dgvEntrada
            // 
            this.dgvEntrada.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEntrada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntrada.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Descripcion,
            this.Column7,
            this.Column8,
            this.dataGridViewTextBoxColumn8,
            this.idAlmacen,
            this.concepto,
            this.observacion,
            this.almacenAntes,
            this.quitar});
            this.dgvEntrada.Location = new System.Drawing.Point(8, 434);
            this.dgvEntrada.Name = "dgvEntrada";
            this.dgvEntrada.RowHeadersVisible = false;
            this.dgvEntrada.Size = new System.Drawing.Size(797, 215);
            this.dgvEntrada.TabIndex = 56;
            this.dgvEntrada.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEntrada_CellContentDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 24);
            this.label3.TabIndex = 55;
            this.label3.Text = "Resumen de entrada:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(60, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(525, 24);
            this.label10.TabIndex = 72;
            this.label10.Text = "Introduce o escanea un codigo de barras del producto:";
            // 
            // button9
            // 
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Image = global::ValleVerde.Properties.Resources.lupa;
            this.button9.Location = new System.Drawing.Point(594, 39);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(29, 29);
            this.button9.TabIndex = 71;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // textProducto
            // 
            this.textProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textProducto.Location = new System.Drawing.Point(63, 39);
            this.textProducto.Name = "textProducto";
            this.textProducto.Size = new System.Drawing.Size(523, 29);
            this.textProducto.TabIndex = 1;
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAgregar.BackColor = System.Drawing.Color.White;
            this.buttonAgregar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonAgregar.FlatAppearance.BorderSize = 5;
            this.buttonAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.buttonAgregar.Location = new System.Drawing.Point(689, 392);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(94, 36);
            this.buttonAgregar.TabIndex = 74;
            this.buttonAgregar.Text = "Agregar";
            this.buttonAgregar.UseVisualStyleBackColor = false;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelar.BackColor = System.Drawing.Color.White;
            this.buttonCancelar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonCancelar.FlatAppearance.BorderSize = 5;
            this.buttonCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.buttonCancelar.Location = new System.Drawing.Point(605, 655);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(94, 36);
            this.buttonCancelar.TabIndex = 73;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = false;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // buttonRegiatrar
            // 
            this.buttonRegiatrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRegiatrar.BackColor = System.Drawing.Color.White;
            this.buttonRegiatrar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonRegiatrar.FlatAppearance.BorderSize = 5;
            this.buttonRegiatrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegiatrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonRegiatrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.buttonRegiatrar.Location = new System.Drawing.Point(708, 655);
            this.buttonRegiatrar.Name = "buttonRegiatrar";
            this.buttonRegiatrar.Size = new System.Drawing.Size(94, 36);
            this.buttonRegiatrar.TabIndex = 64;
            this.buttonRegiatrar.Text = "Registrar";
            this.buttonRegiatrar.UseVisualStyleBackColor = false;
            this.buttonRegiatrar.Click += new System.EventHandler(this.buttonRegiatrar_Click);
            // 
            // comboAlmacenAntes
            // 
            this.comboAlmacenAntes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboAlmacenAntes.FormattingEnabled = true;
            this.comboAlmacenAntes.Location = new System.Drawing.Point(611, 220);
            this.comboAlmacenAntes.Name = "comboAlmacenAntes";
            this.comboAlmacenAntes.Size = new System.Drawing.Size(191, 32);
            this.comboAlmacenAntes.TabIndex = 76;
            // 
            // labelAlmacenAntes
            // 
            this.labelAlmacenAntes.AutoSize = true;
            this.labelAlmacenAntes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAlmacenAntes.Location = new System.Drawing.Point(448, 223);
            this.labelAlmacenAntes.Name = "labelAlmacenAntes";
            this.labelAlmacenAntes.Size = new System.Drawing.Size(157, 24);
            this.labelAlmacenAntes.TabIndex = 75;
            this.labelAlmacenAntes.Text = "Almacen Antes:";
            // 
            // Column5
            // 
            this.Column5.FillWeight = 143.1472F;
            this.Column5.HeaderText = "Codigo Producto";
            this.Column5.Name = "Column5";
            // 
            // Descripcion
            // 
            this.Descripcion.FillWeight = 178.2689F;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            // 
            // Column7
            // 
            this.Column7.FillWeight = 77.15607F;
            this.Column7.HeaderText = "Almcacen Destino";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.FillWeight = 76.97382F;
            this.Column8.HeaderText = "Existencia Destino";
            this.Column8.Name = "Column8";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.FillWeight = 77.05122F;
            this.dataGridViewTextBoxColumn8.HeaderText = "Piezas ajustadas";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // idAlmacen
            // 
            this.idAlmacen.HeaderText = "IDAlmacen";
            this.idAlmacen.Name = "idAlmacen";
            this.idAlmacen.Visible = false;
            // 
            // concepto
            // 
            this.concepto.HeaderText = "Concepto";
            this.concepto.Name = "concepto";
            this.concepto.Visible = false;
            // 
            // observacion
            // 
            this.observacion.HeaderText = "Observaciones";
            this.observacion.Name = "observacion";
            this.observacion.Visible = false;
            // 
            // almacenAntes
            // 
            this.almacenAntes.HeaderText = "AlmacenAntes";
            this.almacenAntes.Name = "almacenAntes";
            this.almacenAntes.Visible = false;
            // 
            // quitar
            // 
            this.quitar.FillWeight = 47.40282F;
            this.quitar.HeaderText = "Quitar";
            this.quitar.Image = global::ValleVerde.Properties.Resources.darBajaUsuario1;
            this.quitar.Name = "quitar";
            this.quitar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.quitar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // RegistrarEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 698);
            this.Controls.Add(this.comboAlmacenAntes);
            this.Controls.Add(this.labelAlmacenAntes);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.textProducto);
            this.Controls.Add(this.textPrecio);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.buttonRegiatrar);
            this.Controls.Add(this.textdescripcion);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textCantidad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textExistencia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvEntrada);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboAlmacen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textObservacion);
            this.Controls.Add(this.comboconcepto);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistrarEntrada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Entrada";
            this.Load += new System.EventHandler(this.RegistrarEntrada_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntrada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboconcepto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox textObservacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboAlmacen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPrecio;
        private System.Windows.Forms.Label label18;
        private RoundedButton buttonRegiatrar;
        private System.Windows.Forms.TextBox textdescripcion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxProducto;
        private System.Windows.Forms.TextBox textCantidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textExistencia;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvEntrada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textProducto;
        private RoundedButton buttonCancelar;
        private RoundedButton buttonAgregar;
        private System.Windows.Forms.ComboBox comboAlmacenAntes;
        private System.Windows.Forms.Label labelAlmacenAntes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn idAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn almacenAntes;
        private System.Windows.Forms.DataGridViewImageColumn quitar;
    }
}