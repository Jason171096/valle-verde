namespace ValleVerde
{
    partial class ReportesCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportesCompras));
            this.lblSinCompras = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnMarca = new System.Windows.Forms.RadioButton();
            this.rbtnNinguno = new System.Windows.Forms.RadioButton();
            this.rbtnProveedor = new System.Windows.Forms.RadioButton();
            this.rbtnFiltrar = new ValleVerde.RoundedButton();
            this.cboxLineaFabriPro = new System.Windows.Forms.ComboBox();
            this.rbtnFabricante = new System.Windows.Forms.RadioButton();
            this.rbtnLinea = new System.Windows.Forms.RadioButton();
            this.lblTotalComprado = new System.Windows.Forms.Label();
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
            // lblSinCompras
            // 
            this.lblSinCompras.AutoSize = true;
            this.lblSinCompras.BackColor = System.Drawing.Color.Transparent;
            this.lblSinCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinCompras.Location = new System.Drawing.Point(245, 299);
            this.lblSinCompras.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSinCompras.Name = "lblSinCompras";
            this.lblSinCompras.Size = new System.Drawing.Size(740, 108);
            this.lblSinCompras.TabIndex = 105;
            this.lblSinCompras.Text = "No hay compras";
            this.lblSinCompras.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.ForestGreen;
            this.label5.Location = new System.Drawing.Point(385, 656);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 29);
            this.label5.TabIndex = 103;
            this.label5.Text = "$0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(239, 656);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 29);
            this.label6.TabIndex = 102;
            this.label6.Text = "Ganancias:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnMarca);
            this.groupBox2.Controls.Add(this.rbtnNinguno);
            this.groupBox2.Controls.Add(this.rbtnProveedor);
            this.groupBox2.Controls.Add(this.rbtnFiltrar);
            this.groupBox2.Controls.Add(this.cboxLineaFabriPro);
            this.groupBox2.Controls.Add(this.rbtnFabricante);
            this.groupBox2.Controls.Add(this.rbtnLinea);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox2.Location = new System.Drawing.Point(544, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(561, 154);
            this.groupBox2.TabIndex = 101;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtrar por";
            // 
            // rbtnMarca
            // 
            this.rbtnMarca.AutoSize = true;
            this.rbtnMarca.Location = new System.Drawing.Point(14, 47);
            this.rbtnMarca.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnMarca.Name = "rbtnMarca";
            this.rbtnMarca.Size = new System.Drawing.Size(71, 24);
            this.rbtnMarca.TabIndex = 86;
            this.rbtnMarca.TabStop = true;
            this.rbtnMarca.Text = "Marca";
            this.rbtnMarca.UseVisualStyleBackColor = true;
            this.rbtnMarca.CheckedChanged += new System.EventHandler(this.rbtnMarca_CheckedChanged);
            // 
            // rbtnNinguno
            // 
            this.rbtnNinguno.AutoSize = true;
            this.rbtnNinguno.Location = new System.Drawing.Point(14, 121);
            this.rbtnNinguno.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnNinguno.Name = "rbtnNinguno";
            this.rbtnNinguno.Size = new System.Drawing.Size(86, 24);
            this.rbtnNinguno.TabIndex = 85;
            this.rbtnNinguno.TabStop = true;
            this.rbtnNinguno.Text = "Ninguno";
            this.rbtnNinguno.UseVisualStyleBackColor = true;
            this.rbtnNinguno.CheckedChanged += new System.EventHandler(this.rbtnNinguno_CheckedChanged);
            // 
            // rbtnProveedor
            // 
            this.rbtnProveedor.AutoSize = true;
            this.rbtnProveedor.Location = new System.Drawing.Point(14, 98);
            this.rbtnProveedor.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnProveedor.Name = "rbtnProveedor";
            this.rbtnProveedor.Size = new System.Drawing.Size(99, 24);
            this.rbtnProveedor.TabIndex = 84;
            this.rbtnProveedor.TabStop = true;
            this.rbtnProveedor.Text = "Proveedor";
            this.rbtnProveedor.UseVisualStyleBackColor = true;
            this.rbtnProveedor.CheckedChanged += new System.EventHandler(this.rbtnProveedor_CheckedChanged);
            // 
            // rbtnFiltrar
            // 
            this.rbtnFiltrar.BackColor = System.Drawing.Color.White;
            this.rbtnFiltrar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.rbtnFiltrar.FlatAppearance.BorderSize = 5;
            this.rbtnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbtnFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rbtnFiltrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.rbtnFiltrar.Location = new System.Drawing.Point(273, 87);
            this.rbtnFiltrar.Name = "rbtnFiltrar";
            this.rbtnFiltrar.Size = new System.Drawing.Size(100, 46);
            this.rbtnFiltrar.TabIndex = 83;
            this.rbtnFiltrar.Text = "Filtrar";
            this.rbtnFiltrar.UseVisualStyleBackColor = false;
            this.rbtnFiltrar.Click += new System.EventHandler(this.rbtnFiltrar_Click);
            // 
            // cboxLineaFabriPro
            // 
            this.cboxLineaFabriPro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxLineaFabriPro.FormattingEnabled = true;
            this.cboxLineaFabriPro.Location = new System.Drawing.Point(135, 47);
            this.cboxLineaFabriPro.Margin = new System.Windows.Forms.Padding(2);
            this.cboxLineaFabriPro.Name = "cboxLineaFabriPro";
            this.cboxLineaFabriPro.Size = new System.Drawing.Size(399, 28);
            this.cboxLineaFabriPro.TabIndex = 73;
            // 
            // rbtnFabricante
            // 
            this.rbtnFabricante.AutoSize = true;
            this.rbtnFabricante.Location = new System.Drawing.Point(14, 75);
            this.rbtnFabricante.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnFabricante.Name = "rbtnFabricante";
            this.rbtnFabricante.Size = new System.Drawing.Size(103, 24);
            this.rbtnFabricante.TabIndex = 70;
            this.rbtnFabricante.TabStop = true;
            this.rbtnFabricante.Text = "Fabricante";
            this.rbtnFabricante.UseVisualStyleBackColor = true;
            this.rbtnFabricante.CheckedChanged += new System.EventHandler(this.rbtnFabricante_CheckedChanged);
            // 
            // rbtnLinea
            // 
            this.rbtnLinea.AutoSize = true;
            this.rbtnLinea.Location = new System.Drawing.Point(14, 22);
            this.rbtnLinea.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnLinea.Name = "rbtnLinea";
            this.rbtnLinea.Size = new System.Drawing.Size(66, 24);
            this.rbtnLinea.TabIndex = 69;
            this.rbtnLinea.TabStop = true;
            this.rbtnLinea.Text = "Linea";
            this.rbtnLinea.UseVisualStyleBackColor = true;
            this.rbtnLinea.CheckedChanged += new System.EventHandler(this.rbtnLinea_CheckedChanged);
            // 
            // lblTotalComprado
            // 
            this.lblTotalComprado.AutoSize = true;
            this.lblTotalComprado.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalComprado.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalComprado.Location = new System.Drawing.Point(731, 656);
            this.lblTotalComprado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalComprado.Name = "lblTotalComprado";
            this.lblTotalComprado.Size = new System.Drawing.Size(41, 29);
            this.lblTotalComprado.TabIndex = 100;
            this.lblTotalComprado.Text = "$0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(523, 656);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 29);
            this.label1.TabIndex = 99;
            this.label1.Text = "Total comprado:";
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
            this.groupBox1.Location = new System.Drawing.Point(26, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(514, 151);
            this.groupBox1.TabIndex = 98;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ver por";
            // 
            // cboxCYear
            // 
            this.cboxCYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxCYear.FormattingEnabled = true;
            this.cboxCYear.Location = new System.Drawing.Point(407, 23);
            this.cboxCYear.Margin = new System.Windows.Forms.Padding(2);
            this.cboxCYear.Name = "cboxCYear";
            this.cboxCYear.Size = new System.Drawing.Size(88, 28);
            this.cboxCYear.TabIndex = 74;
            // 
            // cboxMesYear
            // 
            this.cboxMesYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxMesYear.FormattingEnabled = true;
            this.cboxMesYear.Location = new System.Drawing.Point(126, 23);
            this.cboxMesYear.Margin = new System.Windows.Forms.Padding(2);
            this.cboxMesYear.Name = "cboxMesYear";
            this.cboxMesYear.Size = new System.Drawing.Size(262, 28);
            this.cboxMesYear.TabIndex = 72;
            // 
            // rbtnFecha
            // 
            this.rbtnFecha.AutoSize = true;
            this.rbtnFecha.Location = new System.Drawing.Point(14, 95);
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
            this.label3.Location = new System.Drawing.Point(109, 84);
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
            this.label2.Location = new System.Drawing.Point(109, 111);
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
            this.dtFechaFinal.Location = new System.Drawing.Point(205, 110);
            this.dtFechaFinal.Margin = new System.Windows.Forms.Padding(2);
            this.dtFechaFinal.Name = "dtFechaFinal";
            this.dtFechaFinal.Size = new System.Drawing.Size(290, 26);
            this.dtFechaFinal.TabIndex = 68;
            // 
            // dtFechaInicial
            // 
            this.dtFechaInicial.Enabled = false;
            this.dtFechaInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtFechaInicial.Location = new System.Drawing.Point(205, 80);
            this.dtFechaInicial.Margin = new System.Windows.Forms.Padding(2);
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
            this.chart1.Location = new System.Drawing.Point(12, 167);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.EmptyPointStyle.IsVisibleInLegend = false;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            series1.Legend = "Legend1";
            series1.Name = "Compras";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1077, 467);
            this.chart1.TabIndex = 106;
            this.chart1.Text = "char1";
            // 
            // ReportesCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 694);
            this.Controls.Add(this.lblSinCompras);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblTotalComprado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ReportesCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de compras";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSinCompras;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnMarca;
        private System.Windows.Forms.RadioButton rbtnNinguno;
        private System.Windows.Forms.RadioButton rbtnProveedor;
        private RoundedButton rbtnFiltrar;
        private System.Windows.Forms.ComboBox cboxLineaFabriPro;
        private System.Windows.Forms.RadioButton rbtnFabricante;
        private System.Windows.Forms.RadioButton rbtnLinea;
        private System.Windows.Forms.Label lblTotalComprado;
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox cboxCYear;
    }
}