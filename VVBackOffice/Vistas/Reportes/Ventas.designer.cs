namespace ValleVerde
{
    partial class ReportesVentas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportesVentas));
            this.lblSinVentas = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnNinguno = new System.Windows.Forms.RadioButton();
            this.rbtnFiltrar = new ValleVerde.RoundedButton();
            this.cboxCajaEmpleado = new System.Windows.Forms.ComboBox();
            this.rbtnEmpleado = new System.Windows.Forms.RadioButton();
            this.rbtnCaja = new System.Windows.Forms.RadioButton();
            this.lblTotalVendido = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboxCYear = new System.Windows.Forms.ComboBox();
            this.cboxMesYear = new System.Windows.Forms.ComboBox();
            this.rbtnFecha = new System.Windows.Forms.RadioButton();
            this.rbtnYear = new System.Windows.Forms.RadioButton();
            this.rbtnMes = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dtFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSinVentas
            // 
            this.lblSinVentas.AutoSize = true;
            this.lblSinVentas.BackColor = System.Drawing.Color.Transparent;
            this.lblSinVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinVentas.Location = new System.Drawing.Point(201, 330);
            this.lblSinVentas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSinVentas.Name = "lblSinVentas";
            this.lblSinVentas.Size = new System.Drawing.Size(655, 108);
            this.lblSinVentas.TabIndex = 96;
            this.lblSinVentas.Text = "No hay ventas";
            this.lblSinVentas.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.ForestGreen;
            this.label5.Location = new System.Drawing.Point(319, 620);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 29);
            this.label5.TabIndex = 95;
            this.label5.Text = "$0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(173, 620);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 29);
            this.label6.TabIndex = 94;
            this.label6.Text = "Ganancias:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnNinguno);
            this.groupBox2.Controls.Add(this.rbtnFiltrar);
            this.groupBox2.Controls.Add(this.cboxCajaEmpleado);
            this.groupBox2.Controls.Add(this.rbtnEmpleado);
            this.groupBox2.Controls.Add(this.rbtnCaja);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.Location = new System.Drawing.Point(562, 25);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(475, 129);
            this.groupBox2.TabIndex = 93;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtrar por";
            // 
            // rbtnNinguno
            // 
            this.rbtnNinguno.AutoSize = true;
            this.rbtnNinguno.Location = new System.Drawing.Point(14, 79);
            this.rbtnNinguno.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnNinguno.Name = "rbtnNinguno";
            this.rbtnNinguno.Size = new System.Drawing.Size(86, 24);
            this.rbtnNinguno.TabIndex = 84;
            this.rbtnNinguno.TabStop = true;
            this.rbtnNinguno.Text = "Ninguno";
            this.rbtnNinguno.UseVisualStyleBackColor = true;
            this.rbtnNinguno.CheckedChanged += new System.EventHandler(this.rbtnNinguno_CheckedChanged);
            // 
            // rbtnFiltrar
            // 
            this.rbtnFiltrar.BackColor = System.Drawing.Color.White;
            this.rbtnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.rbtnFiltrar.FlatAppearance.BorderSize = 5;
            this.rbtnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rbtnFiltrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.rbtnFiltrar.Location = new System.Drawing.Point(370, 37);
            this.rbtnFiltrar.Name = "rbtnFiltrar";
            this.rbtnFiltrar.Size = new System.Drawing.Size(100, 46);
            this.rbtnFiltrar.TabIndex = 83;
            this.rbtnFiltrar.Text = "Filtrar";
            this.rbtnFiltrar.UseVisualStyleBackColor = false;
            this.rbtnFiltrar.Click += new System.EventHandler(this.rbtnFiltrar_Click);
            // 
            // cboxCajaEmpleado
            // 
            this.cboxCajaEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCajaEmpleado.FormattingEnabled = true;
            this.cboxCajaEmpleado.Location = new System.Drawing.Point(109, 47);
            this.cboxCajaEmpleado.Margin = new System.Windows.Forms.Padding(2);
            this.cboxCajaEmpleado.Name = "cboxCajaEmpleado";
            this.cboxCajaEmpleado.Size = new System.Drawing.Size(249, 28);
            this.cboxCajaEmpleado.TabIndex = 73;
            // 
            // rbtnEmpleado
            // 
            this.rbtnEmpleado.AutoSize = true;
            this.rbtnEmpleado.Location = new System.Drawing.Point(14, 50);
            this.rbtnEmpleado.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnEmpleado.Name = "rbtnEmpleado";
            this.rbtnEmpleado.Size = new System.Drawing.Size(99, 24);
            this.rbtnEmpleado.TabIndex = 70;
            this.rbtnEmpleado.TabStop = true;
            this.rbtnEmpleado.Text = "Empleado";
            this.rbtnEmpleado.UseVisualStyleBackColor = true;
            this.rbtnEmpleado.CheckedChanged += new System.EventHandler(this.rbtnEmpleado_CheckedChanged);
            // 
            // rbtnCaja
            // 
            this.rbtnCaja.AutoSize = true;
            this.rbtnCaja.Location = new System.Drawing.Point(14, 22);
            this.rbtnCaja.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnCaja.Name = "rbtnCaja";
            this.rbtnCaja.Size = new System.Drawing.Size(59, 24);
            this.rbtnCaja.TabIndex = 69;
            this.rbtnCaja.TabStop = true;
            this.rbtnCaja.Text = "Caja";
            this.rbtnCaja.UseVisualStyleBackColor = true;
            this.rbtnCaja.CheckedChanged += new System.EventHandler(this.rbtnCaja_CheckedChanged);
            // 
            // lblTotalVendido
            // 
            this.lblTotalVendido.AutoSize = true;
            this.lblTotalVendido.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVendido.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalVendido.Location = new System.Drawing.Point(755, 620);
            this.lblTotalVendido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalVendido.Name = "lblTotalVendido";
            this.lblTotalVendido.Size = new System.Drawing.Size(41, 29);
            this.lblTotalVendido.TabIndex = 92;
            this.lblTotalVendido.Text = "$0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(571, 620);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 29);
            this.label1.TabIndex = 91;
            this.label1.Text = "Total vendido:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboxCYear);
            this.groupBox1.Controls.Add(this.cboxMesYear);
            this.groupBox1.Controls.Add(this.rbtnFecha);
            this.groupBox1.Controls.Add(this.rbtnYear);
            this.groupBox1.Controls.Add(this.rbtnMes);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtFechaFinal);
            this.groupBox1.Controls.Add(this.dtFechaInicial);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(11, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(514, 129);
            this.groupBox1.TabIndex = 90;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ver por";
            // 
            // cboxCYear
            // 
            this.cboxCYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCYear.FormattingEnabled = true;
            this.cboxCYear.Location = new System.Drawing.Point(410, 23);
            this.cboxCYear.Margin = new System.Windows.Forms.Padding(2);
            this.cboxCYear.Name = "cboxCYear";
            this.cboxCYear.Size = new System.Drawing.Size(88, 28);
            this.cboxCYear.TabIndex = 73;
            // 
            // cboxMesYear
            // 
            this.cboxMesYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxMesYear.FormattingEnabled = true;
            this.cboxMesYear.Location = new System.Drawing.Point(116, 23);
            this.cboxMesYear.Margin = new System.Windows.Forms.Padding(2);
            this.cboxMesYear.Name = "cboxMesYear";
            this.cboxMesYear.Size = new System.Drawing.Size(275, 28);
            this.cboxMesYear.TabIndex = 72;
            // 
            // rbtnFecha
            // 
            this.rbtnFecha.AutoSize = true;
            this.rbtnFecha.Location = new System.Drawing.Point(14, 97);
            this.rbtnFecha.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnFecha.Name = "rbtnFecha";
            this.rbtnFecha.Size = new System.Drawing.Size(72, 24);
            this.rbtnFecha.TabIndex = 71;
            this.rbtnFecha.TabStop = true;
            this.rbtnFecha.Text = "Fecha";
            this.rbtnFecha.UseVisualStyleBackColor = true;
            this.rbtnFecha.CheckedChanged += new System.EventHandler(this.rbtnFecha_CheckedChanged);
            // 
            // rbtnYear
            // 
            this.rbtnYear.AutoSize = true;
            this.rbtnYear.Location = new System.Drawing.Point(14, 50);
            this.rbtnYear.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnYear.Name = "rbtnYear";
            this.rbtnYear.Size = new System.Drawing.Size(56, 24);
            this.rbtnYear.TabIndex = 70;
            this.rbtnYear.TabStop = true;
            this.rbtnYear.Text = "Año";
            this.rbtnYear.UseVisualStyleBackColor = true;
            this.rbtnYear.CheckedChanged += new System.EventHandler(this.rbtnYear_CheckedChanged);
            // 
            // rbtnMes
            // 
            this.rbtnMes.AutoSize = true;
            this.rbtnMes.Location = new System.Drawing.Point(14, 22);
            this.rbtnMes.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnMes.Name = "rbtnMes";
            this.rbtnMes.Size = new System.Drawing.Size(57, 24);
            this.rbtnMes.TabIndex = 69;
            this.rbtnMes.TabStop = true;
            this.rbtnMes.Text = "Mes";
            this.rbtnMes.UseVisualStyleBackColor = true;
            this.rbtnMes.CheckedChanged += new System.EventHandler(this.rbtnMes_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(112, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 20);
            this.label3.TabIndex = 65;
            this.label3.Text = "Fecha inicial";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(112, 99);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 66;
            this.label2.Text = "Fecha final";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtFechaFinal
            // 
            this.dtFechaFinal.Enabled = false;
            this.dtFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtFechaFinal.Location = new System.Drawing.Point(208, 98);
            this.dtFechaFinal.Margin = new System.Windows.Forms.Padding(2);
            this.dtFechaFinal.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtFechaFinal.MinDate = new System.DateTime(2018, 12, 1, 0, 0, 0, 0);
            this.dtFechaFinal.Name = "dtFechaFinal";
            this.dtFechaFinal.Size = new System.Drawing.Size(290, 26);
            this.dtFechaFinal.TabIndex = 68;
            // 
            // dtFechaInicial
            // 
            this.dtFechaInicial.Enabled = false;
            this.dtFechaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtFechaInicial.Location = new System.Drawing.Point(208, 68);
            this.dtFechaInicial.Margin = new System.Windows.Forms.Padding(2);
            this.dtFechaInicial.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtFechaInicial.MinDate = new System.DateTime(2018, 12, 1, 0, 0, 0, 0);
            this.dtFechaInicial.Name = "dtFechaInicial";
            this.dtFechaInicial.Size = new System.Drawing.Size(290, 26);
            this.dtFechaInicial.TabIndex = 67;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Silver;
            this.chart1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.VerticalCenter;
            this.chart1.BorderlineColor = System.Drawing.Color.Empty;
            this.chart1.BorderlineWidth = 0;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Default;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(11, 159);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.EmptyPointStyle.IsVisibleInLegend = false;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            series1.Legend = "Legend1";
            series1.Name = "Ventas";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1077, 442);
            this.chart1.TabIndex = 98;
            this.chart1.Text = "char1";
            // 
            // ReportesVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 660);
            this.Controls.Add(this.lblSinVentas);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblTotalVendido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ReportesVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de ventas";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSinVentas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnNinguno;
        private RoundedButton rbtnFiltrar;
        private System.Windows.Forms.ComboBox cboxCajaEmpleado;
        private System.Windows.Forms.RadioButton rbtnEmpleado;
        private System.Windows.Forms.RadioButton rbtnCaja;
        private System.Windows.Forms.Label lblTotalVendido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboxMesYear;
        private System.Windows.Forms.RadioButton rbtnFecha;
        private System.Windows.Forms.RadioButton rbtnYear;
        private System.Windows.Forms.RadioButton rbtnMes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFechaFinal;
        private System.Windows.Forms.DateTimePicker dtFechaInicial;
        private System.Windows.Forms.ComboBox cboxCYear;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}