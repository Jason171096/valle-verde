namespace ValleVerde
{
    partial class AdministrarEntradasSalidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdministrarEntradasSalidas));
            this.dateFin = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dateinicio = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvEntradasSalidas = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.existenciaDespues = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label9 = new System.Windows.Forms.Label();
            this.labelproducto = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelCompra = new System.Windows.Forms.Label();
            this.labelVenta = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelDevolucion = new System.Windows.Forms.Label();
            this.toggleDevolucion = new ValleVerde.Toggle();
            this.buttonMostrar = new ValleVerde.RoundedButton();
            this.toggleFecha = new ValleVerde.Toggle();
            this.toggleCompra = new ValleVerde.Toggle();
            this.toggleVenta = new ValleVerde.Toggle();
            this.toggleProducto = new ValleVerde.Toggle();
            this.toggleEntrada = new ValleVerde.Toggle();
            this.toggleSalida = new ValleVerde.Toggle();
            this.toggleTodo1 = new ValleVerde.Toggle();
            this.botonPDF = new ValleVerde.RoundedButton();
            this.exportarExcel = new ValleVerde.RoundedButton();
            this.roundedButton5 = new ValleVerde.RoundedButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelCodigo = new System.Windows.Forms.Label();
            this.labelDescripcion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntradasSalidas)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateFin
            // 
            this.dateFin.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFin.Location = new System.Drawing.Point(188, 75);
            this.dateFin.Name = "dateFin";
            this.dateFin.Size = new System.Drawing.Size(355, 29);
            this.dateFin.TabIndex = 64;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(21, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 24);
            this.label11.TabIndex = 63;
            this.label11.Text = "Fecha de fin:";
            // 
            // dateinicio
            // 
            this.dateinicio.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateinicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateinicio.Location = new System.Drawing.Point(188, 35);
            this.dateinicio.Name = "dateinicio";
            this.dateinicio.Size = new System.Drawing.Size(355, 29);
            this.dateinicio.TabIndex = 62;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(21, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(161, 24);
            this.label10.TabIndex = 60;
            this.label10.Text = "Fecha de inicio:";
            // 
            // dgvEntradasSalidas
            // 
            this.dgvEntradasSalidas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEntradasSalidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEntradasSalidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntradasSalidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.codigo,
            this.descripcion,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn12,
            this.existenciaDespues,
            this.Column3,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column1});
            this.dgvEntradasSalidas.Location = new System.Drawing.Point(16, 292);
            this.dgvEntradasSalidas.Name = "dgvEntradasSalidas";
            this.dgvEntradasSalidas.RowHeadersVisible = false;
            this.dgvEntradasSalidas.Size = new System.Drawing.Size(1322, 397);
            this.dgvEntradasSalidas.TabIndex = 59;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 105.5693F;
            this.Column2.HeaderText = "Fecha";
            this.Column2.Name = "Column2";
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Codigo Producto";
            this.codigo.Name = "codigo";
            this.codigo.Visible = false;
            // 
            // descripcion
            // 
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.FillWeight = 75.58437F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Existencia antes";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.FillWeight = 76.90792F;
            this.dataGridViewTextBoxColumn12.HeaderText = "Piezas/ Ajustadas";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // existenciaDespues
            // 
            this.existenciaDespues.FillWeight = 77.66498F;
            this.existenciaDespues.HeaderText = "Existencia Despues";
            this.existenciaDespues.Name = "existenciaDespues";
            // 
            // Column3
            // 
            this.Column3.FillWeight = 107.2024F;
            this.Column3.HeaderText = "Concepto";
            this.Column3.Name = "Column3";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.FillWeight = 123.3458F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Folio Movimiento";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.FillWeight = 104.3572F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Almacen";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 123.3458F;
            this.Column1.HeaderText = "Usuario";
            this.Column1.Name = "Column1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(307, 24);
            this.label9.TabIndex = 58;
            this.label9.Text = "Resumen de entradas y salidas:";
            // 
            // labelproducto
            // 
            this.labelproducto.AutoSize = true;
            this.labelproducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelproducto.Location = new System.Drawing.Point(11, 46);
            this.labelproducto.Name = "labelproducto";
            this.labelproducto.Size = new System.Drawing.Size(421, 24);
            this.labelproducto.TabIndex = 68;
            this.labelproducto.Text = "Escribe  el codigo de un producto a buscar:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(15, 73);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(523, 29);
            this.txtBuscar.TabIndex = 66;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 82;
            this.label1.Text = "Todo";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(68, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 83;
            this.label2.Text = "Entradas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(187, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 84;
            this.label4.Text = "Salidas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(317, 266);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 20);
            this.label5.TabIndex = 85;
            this.label5.Text = "Producto(Kardex)";
            // 
            // labelCompra
            // 
            this.labelCompra.AutoSize = true;
            this.labelCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompra.Location = new System.Drawing.Point(511, 266);
            this.labelCompra.Name = "labelCompra";
            this.labelCompra.Size = new System.Drawing.Size(73, 20);
            this.labelCompra.TabIndex = 86;
            this.labelCompra.Text = "Compras";
            this.labelCompra.Visible = false;
            // 
            // labelVenta
            // 
            this.labelVenta.AutoSize = true;
            this.labelVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVenta.Location = new System.Drawing.Point(636, 266);
            this.labelVenta.Name = "labelVenta";
            this.labelVenta.Size = new System.Drawing.Size(60, 20);
            this.labelVenta.TabIndex = 87;
            this.labelVenta.Text = "Ventas";
            this.labelVenta.Visible = false;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::ValleVerde.Properties.Resources.lupa;
            this.button1.Location = new System.Drawing.Point(556, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(43, 34);
            this.button1.TabIndex = 88;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(161, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 90;
            this.label3.Text = "Fecha";
            this.label3.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dateFin);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dateinicio);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(765, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(582, 116);
            this.groupBox1.TabIndex = 91;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buscar por Fecha:";
            // 
            // labelDevolucion
            // 
            this.labelDevolucion.AutoSize = true;
            this.labelDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDevolucion.Location = new System.Drawing.Point(761, 266);
            this.labelDevolucion.Name = "labelDevolucion";
            this.labelDevolucion.Size = new System.Drawing.Size(87, 20);
            this.labelDevolucion.TabIndex = 93;
            this.labelDevolucion.Text = "Devolución";
            this.labelDevolucion.Visible = false;
            // 
            // toggleDevolucion
            // 
            this.toggleDevolucion.BorderColor = System.Drawing.Color.LightGray;
            this.toggleDevolucion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleDevolucion.ForeColor = System.Drawing.Color.White;
            this.toggleDevolucion.IsOn = false;
            this.toggleDevolucion.Location = new System.Drawing.Point(719, 266);
            this.toggleDevolucion.Name = "toggleDevolucion";
            this.toggleDevolucion.OffColor = System.Drawing.Color.Red;
            this.toggleDevolucion.OffText = "OFF";
            this.toggleDevolucion.OnColor = System.Drawing.Color.LightGreen;
            this.toggleDevolucion.OnText = "ON";
            this.toggleDevolucion.Size = new System.Drawing.Size(36, 20);
            this.toggleDevolucion.TabIndex = 92;
            this.toggleDevolucion.Text = "toggle1";
            this.toggleDevolucion.TextEnabled = true;
            this.toggleDevolucion.Visible = false;
            // 
            // buttonMostrar
            // 
            this.buttonMostrar.BackColor = System.Drawing.Color.White;
            this.buttonMostrar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonMostrar.FlatAppearance.BorderSize = 5;
            this.buttonMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMostrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonMostrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.buttonMostrar.Location = new System.Drawing.Point(527, 121);
            this.buttonMostrar.Name = "buttonMostrar";
            this.buttonMostrar.Size = new System.Drawing.Size(119, 47);
            this.buttonMostrar.TabIndex = 61;
            this.buttonMostrar.Text = "Mostrar";
            this.buttonMostrar.UseVisualStyleBackColor = false;
            this.buttonMostrar.Click += new System.EventHandler(this.buttonMostrar_Click);
            // 
            // toggleFecha
            // 
            this.toggleFecha.BorderColor = System.Drawing.Color.LightGray;
            this.toggleFecha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleFecha.Enabled = false;
            this.toggleFecha.ForeColor = System.Drawing.Color.White;
            this.toggleFecha.IsOn = false;
            this.toggleFecha.Location = new System.Drawing.Point(119, 240);
            this.toggleFecha.Name = "toggleFecha";
            this.toggleFecha.OffColor = System.Drawing.Color.Red;
            this.toggleFecha.OffText = "OFF";
            this.toggleFecha.OnColor = System.Drawing.Color.LightGreen;
            this.toggleFecha.OnText = "ON";
            this.toggleFecha.Size = new System.Drawing.Size(36, 20);
            this.toggleFecha.TabIndex = 89;
            this.toggleFecha.Text = "toggle1";
            this.toggleFecha.TextEnabled = true;
            this.toggleFecha.Visible = false;
            this.toggleFecha.SliderValueChanged += new ValleVerde.Toggle.SliderChangedEventHandler(this.toggleFecha_SliderValueChanged);
            // 
            // toggleCompra
            // 
            this.toggleCompra.BorderColor = System.Drawing.Color.LightGray;
            this.toggleCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleCompra.ForeColor = System.Drawing.Color.White;
            this.toggleCompra.IsOn = false;
            this.toggleCompra.Location = new System.Drawing.Point(474, 266);
            this.toggleCompra.Name = "toggleCompra";
            this.toggleCompra.OffColor = System.Drawing.Color.Red;
            this.toggleCompra.OffText = "OFF";
            this.toggleCompra.OnColor = System.Drawing.Color.LightGreen;
            this.toggleCompra.OnText = "ON";
            this.toggleCompra.Size = new System.Drawing.Size(36, 20);
            this.toggleCompra.TabIndex = 81;
            this.toggleCompra.Text = "toggleCompra";
            this.toggleCompra.TextEnabled = true;
            this.toggleCompra.Visible = false;
            this.toggleCompra.SliderValueChanged += new ValleVerde.Toggle.SliderChangedEventHandler(this.toggleCompra_SliderValueChanged);
            // 
            // toggleVenta
            // 
            this.toggleVenta.BorderColor = System.Drawing.Color.LightGray;
            this.toggleVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleVenta.ForeColor = System.Drawing.Color.White;
            this.toggleVenta.IsOn = false;
            this.toggleVenta.Location = new System.Drawing.Point(594, 266);
            this.toggleVenta.Name = "toggleVenta";
            this.toggleVenta.OffColor = System.Drawing.Color.Red;
            this.toggleVenta.OffText = "OFF";
            this.toggleVenta.OnColor = System.Drawing.Color.LightGreen;
            this.toggleVenta.OnText = "ON";
            this.toggleVenta.Size = new System.Drawing.Size(36, 20);
            this.toggleVenta.TabIndex = 80;
            this.toggleVenta.Text = "toggleVenta";
            this.toggleVenta.TextEnabled = true;
            this.toggleVenta.Visible = false;
            this.toggleVenta.SliderValueChanged += new ValleVerde.Toggle.SliderChangedEventHandler(this.toggleVenta_SliderValueChanged);
            // 
            // toggleProducto
            // 
            this.toggleProducto.BorderColor = System.Drawing.Color.LightGray;
            this.toggleProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleProducto.ForeColor = System.Drawing.Color.White;
            this.toggleProducto.IsOn = false;
            this.toggleProducto.Location = new System.Drawing.Point(275, 266);
            this.toggleProducto.Name = "toggleProducto";
            this.toggleProducto.OffColor = System.Drawing.Color.Red;
            this.toggleProducto.OffText = "OFF";
            this.toggleProducto.OnColor = System.Drawing.Color.LightGreen;
            this.toggleProducto.OnText = "ON";
            this.toggleProducto.Size = new System.Drawing.Size(36, 20);
            this.toggleProducto.TabIndex = 79;
            this.toggleProducto.Text = "toggle4";
            this.toggleProducto.TextEnabled = true;
            this.toggleProducto.SliderValueChanged += new ValleVerde.Toggle.SliderChangedEventHandler(this.toggleProducto_SliderValueChanged);
            // 
            // toggleEntrada
            // 
            this.toggleEntrada.BorderColor = System.Drawing.Color.LightGray;
            this.toggleEntrada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleEntrada.ForeColor = System.Drawing.Color.White;
            this.toggleEntrada.IsOn = true;
            this.toggleEntrada.Location = new System.Drawing.Point(26, 266);
            this.toggleEntrada.Name = "toggleEntrada";
            this.toggleEntrada.OffColor = System.Drawing.Color.Red;
            this.toggleEntrada.OffText = "OFF";
            this.toggleEntrada.OnColor = System.Drawing.Color.LightGreen;
            this.toggleEntrada.OnText = "ON";
            this.toggleEntrada.Size = new System.Drawing.Size(36, 20);
            this.toggleEntrada.TabIndex = 78;
            this.toggleEntrada.Text = "toggleEntrada";
            this.toggleEntrada.TextEnabled = true;
            this.toggleEntrada.SliderValueChanged += new ValleVerde.Toggle.SliderChangedEventHandler(this.toggleEntrada_SliderValueChanged);
            // 
            // toggleSalida
            // 
            this.toggleSalida.BorderColor = System.Drawing.Color.LightGray;
            this.toggleSalida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleSalida.ForeColor = System.Drawing.Color.White;
            this.toggleSalida.IsOn = true;
            this.toggleSalida.Location = new System.Drawing.Point(145, 266);
            this.toggleSalida.Name = "toggleSalida";
            this.toggleSalida.OffColor = System.Drawing.Color.Red;
            this.toggleSalida.OffText = "OFF";
            this.toggleSalida.OnColor = System.Drawing.Color.LightGreen;
            this.toggleSalida.OnText = "ON";
            this.toggleSalida.Size = new System.Drawing.Size(36, 20);
            this.toggleSalida.TabIndex = 77;
            this.toggleSalida.Text = "toggleSalida";
            this.toggleSalida.TextEnabled = true;
            this.toggleSalida.SliderValueChanged += new ValleVerde.Toggle.SliderChangedEventHandler(this.toggleSalida_SliderValueChanged);
            // 
            // toggleTodo1
            // 
            this.toggleTodo1.BorderColor = System.Drawing.Color.LightGray;
            this.toggleTodo1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleTodo1.Enabled = false;
            this.toggleTodo1.ForeColor = System.Drawing.Color.White;
            this.toggleTodo1.IsOn = true;
            this.toggleTodo1.Location = new System.Drawing.Point(26, 240);
            this.toggleTodo1.Name = "toggleTodo1";
            this.toggleTodo1.OffColor = System.Drawing.Color.Red;
            this.toggleTodo1.OffText = "OFF";
            this.toggleTodo1.OnColor = System.Drawing.Color.LightGreen;
            this.toggleTodo1.OnText = "ON";
            this.toggleTodo1.Size = new System.Drawing.Size(36, 20);
            this.toggleTodo1.TabIndex = 76;
            this.toggleTodo1.Text = "toggleTodo";
            this.toggleTodo1.TextEnabled = true;
            this.toggleTodo1.Visible = false;
            this.toggleTodo1.SliderValueChanged += new ValleVerde.Toggle.SliderChangedEventHandler(this.toggleTodo_SliderValueChanged);
            // 
            // botonPDF
            // 
            this.botonPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botonPDF.BackColor = System.Drawing.Color.White;
            this.botonPDF.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.botonPDF.FlatAppearance.BorderSize = 5;
            this.botonPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botonPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botonPDF.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.botonPDF.Image = global::ValleVerde.Properties.Resources.pdf24;
            this.botonPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonPDF.Location = new System.Drawing.Point(1215, 240);
            this.botonPDF.Name = "botonPDF";
            this.botonPDF.Size = new System.Drawing.Size(124, 46);
            this.botonPDF.TabIndex = 75;
            this.botonPDF.Text = "PDF";
            this.botonPDF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.botonPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.botonPDF.UseVisualStyleBackColor = false;
            this.botonPDF.Click += new System.EventHandler(this.botonPDF_Click);
            // 
            // exportarExcel
            // 
            this.exportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportarExcel.BackColor = System.Drawing.Color.White;
            this.exportarExcel.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.exportarExcel.FlatAppearance.BorderSize = 5;
            this.exportarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportarExcel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.exportarExcel.Image = global::ValleVerde.Properties.Resources.excel24;
            this.exportarExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportarExcel.Location = new System.Drawing.Point(1084, 240);
            this.exportarExcel.Name = "exportarExcel";
            this.exportarExcel.Size = new System.Drawing.Size(124, 46);
            this.exportarExcel.TabIndex = 74;
            this.exportarExcel.Text = "Excel";
            this.exportarExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exportarExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.exportarExcel.UseVisualStyleBackColor = false;
            this.exportarExcel.Click += new System.EventHandler(this.exportarExcel_Click);
            // 
            // roundedButton5
            // 
            this.roundedButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedButton5.BackColor = System.Drawing.Color.White;
            this.roundedButton5.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.roundedButton5.FlatAppearance.BorderSize = 5;
            this.roundedButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.roundedButton5.Image = global::ValleVerde.Properties.Resources.imprimir24;
            this.roundedButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roundedButton5.Location = new System.Drawing.Point(954, 240);
            this.roundedButton5.Name = "roundedButton5";
            this.roundedButton5.Size = new System.Drawing.Size(124, 46);
            this.roundedButton5.TabIndex = 73;
            this.roundedButton5.Text = "Imprimir";
            this.roundedButton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roundedButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.roundedButton5.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 22);
            this.label6.TabIndex = 94;
            this.label6.Text = "Codigo Producto:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 22);
            this.label7.TabIndex = 95;
            this.label7.Text = "Descripcion:";
            // 
            // labelCodigo
            // 
            this.labelCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCodigo.Location = new System.Drawing.Point(167, 128);
            this.labelCodigo.Name = "labelCodigo";
            this.labelCodigo.Size = new System.Drawing.Size(342, 22);
            this.labelCodigo.TabIndex = 96;
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescripcion.Location = new System.Drawing.Point(126, 171);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(397, 52);
            this.labelDescripcion.TabIndex = 97;
            // 
            // AdministrarEntradasSalidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 701);
            this.Controls.Add(this.labelDescripcion);
            this.Controls.Add(this.labelCodigo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelDevolucion);
            this.Controls.Add(this.toggleDevolucion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonMostrar);
            this.Controls.Add(this.toggleFecha);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelVenta);
            this.Controls.Add(this.labelCompra);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toggleCompra);
            this.Controls.Add(this.toggleVenta);
            this.Controls.Add(this.toggleProducto);
            this.Controls.Add(this.toggleEntrada);
            this.Controls.Add(this.toggleSalida);
            this.Controls.Add(this.toggleTodo1);
            this.Controls.Add(this.botonPDF);
            this.Controls.Add(this.exportarExcel);
            this.Controls.Add(this.roundedButton5);
            this.Controls.Add(this.labelproducto);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dgvEntradasSalidas);
            this.Controls.Add(this.label9);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdministrarEntradasSalidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrar Entradas y Salidas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntradasSalidas)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateFin;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateinicio;
        private RoundedButton buttonMostrar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvEntradasSalidas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelproducto;
        private System.Windows.Forms.TextBox txtBuscar;
        private RoundedButton botonPDF;
        private RoundedButton exportarExcel;
        private RoundedButton roundedButton5;
        private Toggle toggleTodo1;
        private Toggle toggleSalida;
        private Toggle toggleEntrada;
        private Toggle toggleProducto;
        private Toggle toggleVenta;
        private Toggle toggleCompra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelCompra;
        private System.Windows.Forms.Label labelVenta;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private Toggle toggleFecha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelDevolucion;
        private Toggle toggleDevolucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn existenciaDespues;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelCodigo;
        private System.Windows.Forms.Label labelDescripcion;
    }
}