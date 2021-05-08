namespace ValleVerde.Vistas.Compras
{
    partial class DevolucionesVer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevolucionesVer));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radButSinCompra = new System.Windows.Forms.RadioButton();
            this.radButNin = new System.Windows.Forms.RadioButton();
            this.radButFec = new System.Windows.Forms.RadioButton();
            this.radButPro = new System.Windows.Forms.RadioButton();
            this.radButCom = new System.Windows.Forms.RadioButton();
            this.texBoxIdCom = new System.Windows.Forms.TextBox();
            this.labFecIni = new System.Windows.Forms.Label();
            this.labFecFin = new System.Windows.Forms.Label();
            this.datTimPicFecFin = new System.Windows.Forms.DateTimePicker();
            this.datTimPicFecIni = new System.Windows.Forms.DateTimePicker();
            this.labNumCom = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labPro = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labFecDev = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labTotDev = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDevoluciones = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.butSelPro = new ValleVerde.RoundedButton();
            this.butBusIdCom = new ValleVerde.RoundedButton();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevoluciones)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radButSinCompra);
            this.groupBox2.Controls.Add(this.butSelPro);
            this.groupBox2.Controls.Add(this.radButNin);
            this.groupBox2.Controls.Add(this.butBusIdCom);
            this.groupBox2.Controls.Add(this.radButFec);
            this.groupBox2.Controls.Add(this.radButPro);
            this.groupBox2.Controls.Add(this.radButCom);
            this.groupBox2.Controls.Add(this.texBoxIdCom);
            this.groupBox2.Controls.Add(this.labFecIni);
            this.groupBox2.Controls.Add(this.labFecFin);
            this.groupBox2.Controls.Add(this.datTimPicFecFin);
            this.groupBox2.Controls.Add(this.datTimPicFecIni);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.Location = new System.Drawing.Point(13, 6);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(559, 184);
            this.groupBox2.TabIndex = 94;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar por";
            // 
            // radButSinCompra
            // 
            this.radButSinCompra.AutoSize = true;
            this.radButSinCompra.Location = new System.Drawing.Point(14, 107);
            this.radButSinCompra.Margin = new System.Windows.Forms.Padding(2);
            this.radButSinCompra.Name = "radButSinCompra";
            this.radButSinCompra.Size = new System.Drawing.Size(107, 24);
            this.radButSinCompra.TabIndex = 126;
            this.radButSinCompra.Text = "Sin compra";
            this.radButSinCompra.UseVisualStyleBackColor = true;
            this.radButSinCompra.CheckedChanged += new System.EventHandler(this.radButSinCompra_CheckedChanged);
            // 
            // radButNin
            // 
            this.radButNin.AutoSize = true;
            this.radButNin.Checked = true;
            this.radButNin.Location = new System.Drawing.Point(14, 135);
            this.radButNin.Margin = new System.Windows.Forms.Padding(2);
            this.radButNin.Name = "radButNin";
            this.radButNin.Size = new System.Drawing.Size(86, 24);
            this.radButNin.TabIndex = 96;
            this.radButNin.TabStop = true;
            this.radButNin.Text = "Ninguno";
            this.radButNin.UseVisualStyleBackColor = true;
            this.radButNin.CheckedChanged += new System.EventHandler(this.radButNin_CheckedChanged);
            // 
            // radButFec
            // 
            this.radButFec.AutoSize = true;
            this.radButFec.Location = new System.Drawing.Point(14, 79);
            this.radButFec.Margin = new System.Windows.Forms.Padding(2);
            this.radButFec.Name = "radButFec";
            this.radButFec.Size = new System.Drawing.Size(72, 24);
            this.radButFec.TabIndex = 71;
            this.radButFec.Text = "Fecha";
            this.radButFec.UseVisualStyleBackColor = true;
            this.radButFec.CheckedChanged += new System.EventHandler(this.radButFec_CheckedChanged);
            // 
            // radButPro
            // 
            this.radButPro.AutoSize = true;
            this.radButPro.Location = new System.Drawing.Point(14, 50);
            this.radButPro.Margin = new System.Windows.Forms.Padding(2);
            this.radButPro.Name = "radButPro";
            this.radButPro.Size = new System.Drawing.Size(99, 24);
            this.radButPro.TabIndex = 70;
            this.radButPro.Text = "Proveedor";
            this.radButPro.UseVisualStyleBackColor = true;
            this.radButPro.CheckedChanged += new System.EventHandler(this.radButPro_CheckedChanged);
            // 
            // radButCom
            // 
            this.radButCom.AutoSize = true;
            this.radButCom.Location = new System.Drawing.Point(14, 22);
            this.radButCom.Margin = new System.Windows.Forms.Padding(2);
            this.radButCom.Name = "radButCom";
            this.radButCom.Size = new System.Drawing.Size(83, 24);
            this.radButCom.TabIndex = 69;
            this.radButCom.Text = "Compra";
            this.radButCom.UseVisualStyleBackColor = true;
            this.radButCom.CheckedChanged += new System.EventHandler(this.radButCom_CheckedChanged);
            // 
            // texBoxIdCom
            // 
            this.texBoxIdCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.texBoxIdCom.Location = new System.Drawing.Point(112, 21);
            this.texBoxIdCom.Margin = new System.Windows.Forms.Padding(2);
            this.texBoxIdCom.Name = "texBoxIdCom";
            this.texBoxIdCom.Size = new System.Drawing.Size(143, 26);
            this.texBoxIdCom.TabIndex = 63;
            // 
            // labFecIni
            // 
            this.labFecIni.AutoSize = true;
            this.labFecIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labFecIni.Location = new System.Drawing.Point(142, 79);
            this.labFecIni.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labFecIni.Name = "labFecIni";
            this.labFecIni.Size = new System.Drawing.Size(96, 20);
            this.labFecIni.TabIndex = 65;
            this.labFecIni.Text = "Fecha inicial";
            this.labFecIni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labFecFin
            // 
            this.labFecFin.AutoSize = true;
            this.labFecFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labFecFin.Location = new System.Drawing.Point(152, 109);
            this.labFecFin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labFecFin.Name = "labFecFin";
            this.labFecFin.Size = new System.Drawing.Size(87, 20);
            this.labFecFin.TabIndex = 66;
            this.labFecFin.Text = "Fecha final";
            this.labFecFin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datTimPicFecFin
            // 
            this.datTimPicFecFin.Enabled = false;
            this.datTimPicFecFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.datTimPicFecFin.Location = new System.Drawing.Point(242, 105);
            this.datTimPicFecFin.Margin = new System.Windows.Forms.Padding(2);
            this.datTimPicFecFin.Name = "datTimPicFecFin";
            this.datTimPicFecFin.Size = new System.Drawing.Size(290, 26);
            this.datTimPicFecFin.TabIndex = 68;
            // 
            // datTimPicFecIni
            // 
            this.datTimPicFecIni.Enabled = false;
            this.datTimPicFecIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.datTimPicFecIni.Location = new System.Drawing.Point(242, 75);
            this.datTimPicFecIni.Margin = new System.Windows.Forms.Padding(2);
            this.datTimPicFecIni.Name = "datTimPicFecIni";
            this.datTimPicFecIni.Size = new System.Drawing.Size(290, 26);
            this.datTimPicFecIni.TabIndex = 67;
            // 
            // labNumCom
            // 
            this.labNumCom.AutoSize = true;
            this.labNumCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labNumCom.Location = new System.Drawing.Point(197, 34);
            this.labNumCom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labNumCom.Name = "labNumCom";
            this.labNumCom.Size = new System.Drawing.Size(63, 20);
            this.labNumCom.TabIndex = 93;
            this.labNumCom.Text = "123456";
            this.labNumCom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(84, 34);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 20);
            this.label12.TabIndex = 92;
            this.label12.Text = "No. de compra:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labPro
            // 
            this.labPro.AutoSize = true;
            this.labPro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labPro.Location = new System.Drawing.Point(169, 59);
            this.labPro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labPro.Name = "labPro";
            this.labPro.Size = new System.Drawing.Size(112, 20);
            this.labPro.TabIndex = 89;
            this.labPro.Text = "Omar Robledo";
            this.labPro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(84, 59);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 20);
            this.label7.TabIndex = 88;
            this.label7.Text = "Proveedor:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labFecDev
            // 
            this.labFecDev.AutoSize = true;
            this.labFecDev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labFecDev.Location = new System.Drawing.Point(187, 80);
            this.labFecDev.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labFecDev.Name = "labFecDev";
            this.labFecDev.Size = new System.Drawing.Size(96, 20);
            this.labFecDev.TabIndex = 87;
            this.labFecDev.Text = "22 Oct 2019";
            this.labFecDev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 80);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 20);
            this.label5.TabIndex = 86;
            this.label5.Text = "Fecha de devolución:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labTotDev
            // 
            this.labTotDev.AutoSize = true;
            this.labTotDev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTotDev.ForeColor = System.Drawing.Color.DarkRed;
            this.labTotDev.Location = new System.Drawing.Point(206, 108);
            this.labTotDev.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labTotDev.Name = "labTotDev";
            this.labTotDev.Size = new System.Drawing.Size(80, 20);
            this.labTotDev.TabIndex = 85;
            this.labTotDev.Text = "$1,234.56";
            this.labTotDev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(98, 108);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(112, 20);
            this.label14.TabIndex = 84;
            this.label14.Text = "Total devuelto:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvCompras
            // 
            this.dgvCompras.AllowUserToAddRows = false;
            this.dgvCompras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCompras.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCompras.Location = new System.Drawing.Point(10, 194);
            this.dgvCompras.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.ReadOnly = true;
            this.dgvCompras.RowHeadersVisible = false;
            this.dgvCompras.RowHeadersWidth = 51;
            this.dgvCompras.RowTemplate.Height = 24;
            this.dgvCompras.Size = new System.Drawing.Size(255, 393);
            this.dgvCompras.TabIndex = 83;
            this.dgvCompras.SelectionChanged += new System.EventHandler(this.dgvCompras_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(98, 136);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 95;
            this.label1.Text = "Total devuelto:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvDevoluciones
            // 
            this.dgvDevoluciones.AllowUserToAddRows = false;
            this.dgvDevoluciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDevoluciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDevoluciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevoluciones.Location = new System.Drawing.Point(269, 194);
            this.dgvDevoluciones.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDevoluciones.Name = "dgvDevoluciones";
            this.dgvDevoluciones.ReadOnly = true;
            this.dgvDevoluciones.RowHeadersVisible = false;
            this.dgvDevoluciones.RowHeadersWidth = 51;
            this.dgvDevoluciones.RowTemplate.Height = 24;
            this.dgvDevoluciones.Size = new System.Drawing.Size(706, 393);
            this.dgvDevoluciones.TabIndex = 96;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.labTotDev);
            this.groupBox1.Controls.Add(this.labNumCom);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labFecDev);
            this.groupBox1.Controls.Add(this.labPro);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(577, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 182);
            this.groupBox1.TabIndex = 97;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalles de Devolucion";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.dgvDevoluciones);
            this.panel1.Controls.Add(this.dgvCompras);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(9, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 601);
            this.panel1.TabIndex = 98;
            // 
            // butSelPro
            // 
            this.butSelPro.BackColor = System.Drawing.Color.White;
            this.butSelPro.Enabled = false;
            this.butSelPro.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.butSelPro.FlatAppearance.BorderSize = 5;
            this.butSelPro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSelPro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butSelPro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.butSelPro.Location = new System.Drawing.Point(354, 14);
            this.butSelPro.Name = "butSelPro";
            this.butSelPro.Size = new System.Drawing.Size(188, 41);
            this.butSelPro.TabIndex = 125;
            this.butSelPro.Text = "Seleccionar proveedor...";
            this.butSelPro.UseVisualStyleBackColor = false;
            this.butSelPro.Click += new System.EventHandler(this.butSelPro_Click);
            // 
            // butBusIdCom
            // 
            this.butBusIdCom.BackColor = System.Drawing.Color.White;
            this.butBusIdCom.Enabled = false;
            this.butBusIdCom.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.butBusIdCom.FlatAppearance.BorderSize = 5;
            this.butBusIdCom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butBusIdCom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butBusIdCom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.butBusIdCom.Location = new System.Drawing.Point(277, 14);
            this.butBusIdCom.Name = "butBusIdCom";
            this.butBusIdCom.Size = new System.Drawing.Size(70, 41);
            this.butBusIdCom.TabIndex = 95;
            this.butBusIdCom.Text = "Buscar";
            this.butBusIdCom.UseVisualStyleBackColor = false;
            // 
            // DevolucionesVer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 617);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DevolucionesVer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver devoluciones";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevoluciones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radButFec;
        private System.Windows.Forms.RadioButton radButPro;
        private System.Windows.Forms.RadioButton radButCom;
        private System.Windows.Forms.TextBox texBoxIdCom;
        private System.Windows.Forms.Label labFecIni;
        private System.Windows.Forms.Label labFecFin;
        private System.Windows.Forms.DateTimePicker datTimPicFecFin;
        private System.Windows.Forms.DateTimePicker datTimPicFecIni;
        private System.Windows.Forms.Label labNumCom;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labPro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labFecDev;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labTotDev;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvCompras;
        private RoundedButton butBusIdCom;
        private System.Windows.Forms.RadioButton radButNin;
        private RoundedButton butSelPro;
        private System.Windows.Forms.DataGridView dgvDevoluciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radButSinCompra;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        //No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, comerciales, o cualquier otro fin, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
    }
}