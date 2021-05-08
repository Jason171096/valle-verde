namespace ValleVerde.Vistas.Ventas
{
    partial class ProductoPromo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductoPromo));
            this.buscar = new System.Windows.Forms.Button();
            this.textProducto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboMarca = new System.Windows.Forms.ComboBox();
            this.comboFabricante = new System.Windows.Forms.ComboBox();
            this.comboLinea = new System.Windows.Forms.ComboBox();
            this.comboProveedor = new System.Windows.Forms.ComboBox();
            this.eliminaProducto = new System.Windows.Forms.Button();
            this.eliminaMarca = new System.Windows.Forms.Button();
            this.eliminaLinea = new System.Windows.Forms.Button();
            this.eliminaFabricante = new System.Windows.Forms.Button();
            this.eliminaProveedor = new System.Windows.Forms.Button();
            this.dgvMarca = new System.Windows.Forms.DataGridView();
            this.dgvLinea = new System.Windows.Forms.DataGridView();
            this.dgvFabricante = new System.Windows.Forms.DataGridView();
            this.dgvProveedor = new System.Windows.Forms.DataGridView();
            this.dgvProducto = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aceptar = new ValleVerde.RoundedButton();
            this.toggleProvvedor = new ValleVerde.Toggle();
            this.toggleLinea = new ValleVerde.Toggle();
            this.toggleMarca = new ValleVerde.Toggle();
            this.toggleFabricante = new ValleVerde.Toggle();
            this.toggleProducto = new ValleVerde.Toggle();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFabricante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // buscar
            // 
            this.buscar.FlatAppearance.BorderSize = 0;
            this.buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buscar.Image = global::ValleVerde.Properties.Resources.lupa24;
            this.buscar.Location = new System.Drawing.Point(613, 25);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(34, 29);
            this.buscar.TabIndex = 9;
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // textProducto
            // 
            this.textProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textProducto.Location = new System.Drawing.Point(282, 25);
            this.textProducto.Name = "textProducto";
            this.textProducto.Size = new System.Drawing.Size(315, 26);
            this.textProducto.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(142, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Código producto :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Producto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 337);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Fabricante";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Marca";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Linea";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 450);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "Proveedor";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(208, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "Marca:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(208, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Linea:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(171, 337);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Fabricante:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(175, 445);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Proveedor:";
            // 
            // comboMarca
            // 
            this.comboMarca.Enabled = false;
            this.comboMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboMarca.FormattingEnabled = true;
            this.comboMarca.Location = new System.Drawing.Point(271, 128);
            this.comboMarca.Name = "comboMarca";
            this.comboMarca.Size = new System.Drawing.Size(298, 28);
            this.comboMarca.TabIndex = 22;
            this.comboMarca.SelectedIndexChanged += new System.EventHandler(this.comboMarca_SelectedIndexChanged);
            // 
            // comboFabricante
            // 
            this.comboFabricante.Enabled = false;
            this.comboFabricante.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFabricante.FormattingEnabled = true;
            this.comboFabricante.Location = new System.Drawing.Point(271, 334);
            this.comboFabricante.Name = "comboFabricante";
            this.comboFabricante.Size = new System.Drawing.Size(298, 28);
            this.comboFabricante.TabIndex = 23;
            this.comboFabricante.SelectedIndexChanged += new System.EventHandler(this.comboFabricante_SelectedIndexChanged);
            // 
            // comboLinea
            // 
            this.comboLinea.Enabled = false;
            this.comboLinea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLinea.FormattingEnabled = true;
            this.comboLinea.Location = new System.Drawing.Point(271, 230);
            this.comboLinea.Name = "comboLinea";
            this.comboLinea.Size = new System.Drawing.Size(298, 28);
            this.comboLinea.TabIndex = 23;
            this.comboLinea.SelectedIndexChanged += new System.EventHandler(this.comboLinea_SelectedIndexChanged);
            // 
            // comboProveedor
            // 
            this.comboProveedor.Enabled = false;
            this.comboProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboProveedor.FormattingEnabled = true;
            this.comboProveedor.Location = new System.Drawing.Point(271, 442);
            this.comboProveedor.Name = "comboProveedor";
            this.comboProveedor.Size = new System.Drawing.Size(298, 28);
            this.comboProveedor.TabIndex = 24;
            this.comboProveedor.SelectedIndexChanged += new System.EventHandler(this.comboProveedor_SelectedIndexChanged);
            // 
            // eliminaProducto
            // 
            this.eliminaProducto.FlatAppearance.BorderSize = 0;
            this.eliminaProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eliminaProducto.Image = global::ValleVerde.Properties.Resources.menos22;
            this.eliminaProducto.Location = new System.Drawing.Point(579, 71);
            this.eliminaProducto.Name = "eliminaProducto";
            this.eliminaProducto.Size = new System.Drawing.Size(35, 30);
            this.eliminaProducto.TabIndex = 31;
            this.eliminaProducto.UseVisualStyleBackColor = true;
            this.eliminaProducto.Click += new System.EventHandler(this.eliminaProducto_Click);
            // 
            // eliminaMarca
            // 
            this.eliminaMarca.FlatAppearance.BorderSize = 0;
            this.eliminaMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eliminaMarca.Image = global::ValleVerde.Properties.Resources.menos22;
            this.eliminaMarca.Location = new System.Drawing.Point(579, 175);
            this.eliminaMarca.Name = "eliminaMarca";
            this.eliminaMarca.Size = new System.Drawing.Size(35, 30);
            this.eliminaMarca.TabIndex = 32;
            this.eliminaMarca.UseVisualStyleBackColor = true;
            this.eliminaMarca.Click += new System.EventHandler(this.eliminaMarca_Click);
            // 
            // eliminaLinea
            // 
            this.eliminaLinea.FlatAppearance.BorderSize = 0;
            this.eliminaLinea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eliminaLinea.Image = global::ValleVerde.Properties.Resources.menos22;
            this.eliminaLinea.Location = new System.Drawing.Point(581, 276);
            this.eliminaLinea.Name = "eliminaLinea";
            this.eliminaLinea.Size = new System.Drawing.Size(35, 30);
            this.eliminaLinea.TabIndex = 33;
            this.eliminaLinea.UseVisualStyleBackColor = true;
            this.eliminaLinea.Click += new System.EventHandler(this.eliminaLinea_Click);
            // 
            // eliminaFabricante
            // 
            this.eliminaFabricante.FlatAppearance.BorderSize = 0;
            this.eliminaFabricante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eliminaFabricante.Image = global::ValleVerde.Properties.Resources.menos22;
            this.eliminaFabricante.Location = new System.Drawing.Point(581, 382);
            this.eliminaFabricante.Name = "eliminaFabricante";
            this.eliminaFabricante.Size = new System.Drawing.Size(35, 30);
            this.eliminaFabricante.TabIndex = 34;
            this.eliminaFabricante.UseVisualStyleBackColor = true;
            this.eliminaFabricante.Click += new System.EventHandler(this.eliminaFabricante_Click);
            // 
            // eliminaProveedor
            // 
            this.eliminaProveedor.FlatAppearance.BorderSize = 0;
            this.eliminaProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eliminaProveedor.Image = global::ValleVerde.Properties.Resources.menos22;
            this.eliminaProveedor.Location = new System.Drawing.Point(581, 495);
            this.eliminaProveedor.Name = "eliminaProveedor";
            this.eliminaProveedor.Size = new System.Drawing.Size(35, 30);
            this.eliminaProveedor.TabIndex = 35;
            this.eliminaProveedor.UseVisualStyleBackColor = true;
            this.eliminaProveedor.Click += new System.EventHandler(this.eliminaProveedor_Click);
            // 
            // dgvMarca
            // 
            this.dgvMarca.AllowUserToAddRows = false;
            this.dgvMarca.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMarca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarca.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.nombre});
            this.dgvMarca.Location = new System.Drawing.Point(212, 162);
            this.dgvMarca.Name = "dgvMarca";
            this.dgvMarca.RowHeadersVisible = false;
            this.dgvMarca.Size = new System.Drawing.Size(357, 62);
            this.dgvMarca.TabIndex = 36;
            // 
            // dgvLinea
            // 
            this.dgvLinea.AllowUserToAddRows = false;
            this.dgvLinea.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLinea.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLinea.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvLinea.Location = new System.Drawing.Point(212, 264);
            this.dgvLinea.Name = "dgvLinea";
            this.dgvLinea.RowHeadersVisible = false;
            this.dgvLinea.Size = new System.Drawing.Size(357, 62);
            this.dgvLinea.TabIndex = 37;
            // 
            // dgvFabricante
            // 
            this.dgvFabricante.AllowUserToAddRows = false;
            this.dgvFabricante.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFabricante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFabricante.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvFabricante.Location = new System.Drawing.Point(212, 374);
            this.dgvFabricante.Name = "dgvFabricante";
            this.dgvFabricante.RowHeadersVisible = false;
            this.dgvFabricante.Size = new System.Drawing.Size(357, 62);
            this.dgvFabricante.TabIndex = 38;
            // 
            // dgvProveedor
            // 
            this.dgvProveedor.AllowUserToAddRows = false;
            this.dgvProveedor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dgvProveedor.Location = new System.Drawing.Point(212, 476);
            this.dgvProveedor.Name = "dgvProveedor";
            this.dgvProveedor.RowHeadersVisible = false;
            this.dgvProveedor.Size = new System.Drawing.Size(357, 62);
            this.dgvProveedor.TabIndex = 39;
            // 
            // dgvProducto
            // 
            this.dgvProducto.AllowUserToAddRows = false;
            this.dgvProducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.dgvProducto.Location = new System.Drawing.Point(212, 57);
            this.dgvProducto.Name = "dgvProducto";
            this.dgvProducto.RowHeadersVisible = false;
            this.dgvProducto.Size = new System.Drawing.Size(357, 62);
            this.dgvProducto.TabIndex = 40;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Código";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // codigo
            // 
            this.codigo.HeaderText = "Código";
            this.codigo.Name = "codigo";
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Código";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Código";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
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
            this.aceptar.Location = new System.Drawing.Point(545, 541);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(102, 37);
            this.aceptar.TabIndex = 25;
            this.aceptar.Text = "Aceptar";
            this.aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.aceptar.UseVisualStyleBackColor = false;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // toggleProvvedor
            // 
            this.toggleProvvedor.BorderColor = System.Drawing.Color.LightGray;
            this.toggleProvvedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleProvvedor.ForeColor = System.Drawing.Color.White;
            this.toggleProvvedor.IsOn = false;
            this.toggleProvvedor.Location = new System.Drawing.Point(93, 450);
            this.toggleProvvedor.Name = "toggleProvvedor";
            this.toggleProvvedor.OffColor = System.Drawing.Color.Red;
            this.toggleProvvedor.OffText = "OFF";
            this.toggleProvvedor.OnColor = System.Drawing.Color.LightGreen;
            this.toggleProvvedor.OnText = "ON";
            this.toggleProvvedor.Size = new System.Drawing.Size(38, 21);
            this.toggleProvvedor.TabIndex = 16;
            this.toggleProvvedor.Text = "toggle5";
            this.toggleProvvedor.TextEnabled = true;
            this.toggleProvvedor.SliderValueChanged += new ValleVerde.Toggle.SliderChangedEventHandler(this.toggleProvvedor_SliderValueChanged);
            // 
            // toggleLinea
            // 
            this.toggleLinea.BorderColor = System.Drawing.Color.LightGray;
            this.toggleLinea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleLinea.ForeColor = System.Drawing.Color.White;
            this.toggleLinea.IsOn = false;
            this.toggleLinea.Location = new System.Drawing.Point(93, 233);
            this.toggleLinea.Name = "toggleLinea";
            this.toggleLinea.OffColor = System.Drawing.Color.Red;
            this.toggleLinea.OffText = "OFF";
            this.toggleLinea.OnColor = System.Drawing.Color.LightGreen;
            this.toggleLinea.OnText = "ON";
            this.toggleLinea.Size = new System.Drawing.Size(38, 21);
            this.toggleLinea.TabIndex = 14;
            this.toggleLinea.Text = "toggle4";
            this.toggleLinea.TextEnabled = true;
            this.toggleLinea.SliderValueChanged += new ValleVerde.Toggle.SliderChangedEventHandler(this.toggleLinea_SliderValueChanged);
            // 
            // toggleMarca
            // 
            this.toggleMarca.BorderColor = System.Drawing.Color.LightGray;
            this.toggleMarca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleMarca.ForeColor = System.Drawing.Color.White;
            this.toggleMarca.IsOn = false;
            this.toggleMarca.Location = new System.Drawing.Point(93, 130);
            this.toggleMarca.Name = "toggleMarca";
            this.toggleMarca.OffColor = System.Drawing.Color.Red;
            this.toggleMarca.OffText = "OFF";
            this.toggleMarca.OnColor = System.Drawing.Color.LightGreen;
            this.toggleMarca.OnText = "ON";
            this.toggleMarca.Size = new System.Drawing.Size(38, 21);
            this.toggleMarca.TabIndex = 12;
            this.toggleMarca.Text = "toggle2";
            this.toggleMarca.TextEnabled = true;
            this.toggleMarca.SliderValueChanged += new ValleVerde.Toggle.SliderChangedEventHandler(this.toggleMarca_SliderValueChanged);
            // 
            // toggleFabricante
            // 
            this.toggleFabricante.BorderColor = System.Drawing.Color.LightGray;
            this.toggleFabricante.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleFabricante.ForeColor = System.Drawing.Color.White;
            this.toggleFabricante.IsOn = false;
            this.toggleFabricante.Location = new System.Drawing.Point(93, 337);
            this.toggleFabricante.Name = "toggleFabricante";
            this.toggleFabricante.OffColor = System.Drawing.Color.Red;
            this.toggleFabricante.OffText = "OFF";
            this.toggleFabricante.OnColor = System.Drawing.Color.LightGreen;
            this.toggleFabricante.OnText = "ON";
            this.toggleFabricante.Size = new System.Drawing.Size(42, 23);
            this.toggleFabricante.TabIndex = 12;
            this.toggleFabricante.Text = "toggle2";
            this.toggleFabricante.TextEnabled = true;
            this.toggleFabricante.SliderValueChanged += new ValleVerde.Toggle.SliderChangedEventHandler(this.toggleFabricante_SliderValueChanged);
            // 
            // toggleProducto
            // 
            this.toggleProducto.BorderColor = System.Drawing.Color.LightGray;
            this.toggleProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleProducto.ForeColor = System.Drawing.Color.White;
            this.toggleProducto.IsOn = true;
            this.toggleProducto.Location = new System.Drawing.Point(92, 27);
            this.toggleProducto.Name = "toggleProducto";
            this.toggleProducto.OffColor = System.Drawing.Color.Red;
            this.toggleProducto.OffText = "OFF";
            this.toggleProducto.OnColor = System.Drawing.Color.LightGreen;
            this.toggleProducto.OnText = "ON";
            this.toggleProducto.Size = new System.Drawing.Size(38, 21);
            this.toggleProducto.TabIndex = 10;
            this.toggleProducto.Text = "toggle1";
            this.toggleProducto.TextEnabled = true;
            this.toggleProducto.SliderValueChanged += new ValleVerde.Toggle.SliderChangedEventHandler(this.toggleProducto_SliderValueChanged);
            // 
            // ProductoPromo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 590);
            this.Controls.Add(this.dgvProducto);
            this.Controls.Add(this.dgvProveedor);
            this.Controls.Add(this.dgvFabricante);
            this.Controls.Add(this.dgvLinea);
            this.Controls.Add(this.dgvMarca);
            this.Controls.Add(this.eliminaProveedor);
            this.Controls.Add(this.eliminaFabricante);
            this.Controls.Add(this.eliminaLinea);
            this.Controls.Add(this.eliminaMarca);
            this.Controls.Add(this.eliminaProducto);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.comboProveedor);
            this.Controls.Add(this.comboLinea);
            this.Controls.Add(this.comboFabricante);
            this.Controls.Add(this.comboMarca);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.toggleProvvedor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.toggleLinea);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.toggleMarca);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toggleFabricante);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toggleProducto);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.textProducto);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductoPromo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Añadir Promoción a";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLinea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFabricante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.TextBox textProducto;
        private System.Windows.Forms.Label label1;
        private Toggle toggleProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Toggle toggleFabricante;
        private Toggle toggleMarca;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private Toggle toggleLinea;
        private System.Windows.Forms.Label label6;
        private Toggle toggleProvvedor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboMarca;
        private System.Windows.Forms.ComboBox comboFabricante;
        private System.Windows.Forms.ComboBox comboLinea;
        private System.Windows.Forms.ComboBox comboProveedor;
        private RoundedButton aceptar;
        private System.Windows.Forms.Button eliminaProducto;
        private System.Windows.Forms.Button eliminaMarca;
        private System.Windows.Forms.Button eliminaLinea;
        private System.Windows.Forms.Button eliminaFabricante;
        private System.Windows.Forms.Button eliminaProveedor;
        private System.Windows.Forms.DataGridView dgvMarca;
        private System.Windows.Forms.DataGridView dgvLinea;
        private System.Windows.Forms.DataGridView dgvFabricante;
        private System.Windows.Forms.DataGridView dgvProveedor;
        private System.Windows.Forms.DataGridView dgvProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}