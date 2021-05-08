namespace ValleVerde.Vistas.Reportes
{
    partial class ReporteChecador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteChecador));
            this.Desde = new System.Windows.Forms.DateTimePicker();
            this.Hasta = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dgvChecador = new System.Windows.Forms.DataGridView();
            this.pagado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InicioAlmuerzo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinAlmuerzo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Horas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comentario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horasT = new System.Windows.Forms.Label();
            this.diasT = new System.Windows.Forms.Label();
            this.diasR = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.minutosT = new System.Windows.Forms.Label();
            this.registros = new ValleVerde.RoundedButton();
            this.pagar = new ValleVerde.RoundedButton();
            this.button1 = new ValleVerde.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecador)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Desde
            // 
            this.Desde.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Desde.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Desde.CustomFormat = "";
            this.Desde.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Desde.Location = new System.Drawing.Point(259, 90);
            this.Desde.Name = "Desde";
            this.Desde.Size = new System.Drawing.Size(333, 29);
            this.Desde.TabIndex = 0;
            this.Desde.Value = new System.DateTime(2020, 5, 1, 0, 0, 0, 0);
            // 
            // Hasta
            // 
            this.Hasta.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Hasta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hasta.Location = new System.Drawing.Point(731, 90);
            this.Hasta.Name = "Hasta";
            this.Hasta.Size = new System.Drawing.Size(332, 29);
            this.Hasta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(361, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Empleado: ";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(163, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Desde: ";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(644, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hasta: ";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(490, 32);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(237, 24);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dgvChecador
            // 
            this.dgvChecador.AllowUserToAddRows = false;
            this.dgvChecador.AllowUserToDeleteRows = false;
            this.dgvChecador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChecador.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChecador.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChecador.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pagado,
            this.Fecha,
            this.Entrada,
            this.InicioAlmuerzo,
            this.FinAlmuerzo,
            this.Salida,
            this.Horas,
            this.Comentario});
            this.dgvChecador.Location = new System.Drawing.Point(12, 153);
            this.dgvChecador.Name = "dgvChecador";
            this.dgvChecador.ReadOnly = true;
            this.dgvChecador.RowHeadersVisible = false;
            this.dgvChecador.Size = new System.Drawing.Size(1216, 334);
            this.dgvChecador.TabIndex = 8;
            this.dgvChecador.DoubleClick += new System.EventHandler(this.dgvChecador_DoubleClick);
            // 
            // pagado
            // 
            this.pagado.FillWeight = 52.79187F;
            this.pagado.HeaderText = "Pagado";
            this.pagado.Name = "pagado";
            this.pagado.ReadOnly = true;
            this.pagado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pagado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Fecha
            // 
            this.Fecha.FillWeight = 136.8921F;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Entrada
            // 
            this.Entrada.FillWeight = 95.62868F;
            this.Entrada.HeaderText = "Entrada";
            this.Entrada.Name = "Entrada";
            this.Entrada.ReadOnly = true;
            // 
            // InicioAlmuerzo
            // 
            this.InicioAlmuerzo.FillWeight = 93.55151F;
            this.InicioAlmuerzo.HeaderText = "Inicio Descanso";
            this.InicioAlmuerzo.Name = "InicioAlmuerzo";
            this.InicioAlmuerzo.ReadOnly = true;
            // 
            // FinAlmuerzo
            // 
            this.FinAlmuerzo.FillWeight = 89.36647F;
            this.FinAlmuerzo.HeaderText = "Fin Descanso";
            this.FinAlmuerzo.Name = "FinAlmuerzo";
            this.FinAlmuerzo.ReadOnly = true;
            // 
            // Salida
            // 
            this.Salida.FillWeight = 92.05013F;
            this.Salida.HeaderText = "Salida";
            this.Salida.Name = "Salida";
            this.Salida.ReadOnly = true;
            // 
            // Horas
            // 
            this.Horas.FillWeight = 91.79466F;
            this.Horas.HeaderText = "Horas";
            this.Horas.Name = "Horas";
            this.Horas.ReadOnly = true;
            // 
            // Comentario
            // 
            this.Comentario.FillWeight = 147.9245F;
            this.Comentario.HeaderText = "Comentarios";
            this.Comentario.Name = "Comentario";
            this.Comentario.ReadOnly = true;
            // 
            // horasT
            // 
            this.horasT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.horasT.AutoSize = true;
            this.horasT.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.horasT.Location = new System.Drawing.Point(17, 519);
            this.horasT.Name = "horasT";
            this.horasT.Size = new System.Drawing.Size(226, 37);
            this.horasT.TabIndex = 9;
            this.horasT.Text = "Horas Totales:";
            this.horasT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // diasT
            // 
            this.diasT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diasT.AutoSize = true;
            this.diasT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diasT.ForeColor = System.Drawing.Color.DarkRed;
            this.diasT.Location = new System.Drawing.Point(676, 514);
            this.diasT.Name = "diasT";
            this.diasT.Size = new System.Drawing.Size(90, 20);
            this.diasT.TabIndex = 10;
            this.diasT.Text = "Días Tarde:";
            // 
            // diasR
            // 
            this.diasR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.diasR.AutoSize = true;
            this.diasR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diasR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.diasR.Location = new System.Drawing.Point(676, 540);
            this.diasR.Name = "diasR";
            this.diasR.Size = new System.Drawing.Size(107, 20);
            this.diasR.TabIndex = 11;
            this.diasR.Text = "Días Retardo:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.registros);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1062, 500);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 70);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ver todos registros";
            // 
            // minutosT
            // 
            this.minutosT.AutoSize = true;
            this.minutosT.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minutosT.Location = new System.Drawing.Point(418, 527);
            this.minutosT.Name = "minutosT";
            this.minutosT.Size = new System.Drawing.Size(136, 24);
            this.minutosT.TabIndex = 15;
            this.minutosT.Text = "Minutos Tarde:";
            // 
            // registros
            // 
            this.registros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.registros.BackColor = System.Drawing.Color.White;
            this.registros.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.registros.FlatAppearance.BorderSize = 5;
            this.registros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.registros.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.registros.Location = new System.Drawing.Point(45, 23);
            this.registros.Name = "registros";
            this.registros.Size = new System.Drawing.Size(87, 40);
            this.registros.TabIndex = 13;
            this.registros.Text = "Registro";
            this.registros.UseVisualStyleBackColor = false;
            this.registros.Click += new System.EventHandler(this.registros_Click);
            // 
            // pagar
            // 
            this.pagar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pagar.BackColor = System.Drawing.Color.White;
            this.pagar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.pagar.FlatAppearance.BorderSize = 5;
            this.pagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.pagar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.pagar.Location = new System.Drawing.Point(927, 525);
            this.pagar.Name = "pagar";
            this.pagar.Size = new System.Drawing.Size(75, 36);
            this.pagar.TabIndex = 12;
            this.pagar.Text = "Pagar";
            this.pagar.UseVisualStyleBackColor = false;
            this.pagar.Click += new System.EventHandler(this.pagar_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.button1.Location = new System.Drawing.Point(800, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReporteChecador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 579);
            this.Controls.Add(this.minutosT);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pagar);
            this.Controls.Add(this.diasR);
            this.Controls.Add(this.diasT);
            this.Controls.Add(this.horasT);
            this.Controls.Add(this.dgvChecador);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Hasta);
            this.Controls.Add(this.Desde);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReporteChecador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Checador";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecador)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker Desde;
        private System.Windows.Forms.DateTimePicker Hasta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dgvChecador;
        private System.Windows.Forms.Label horasT;
        private System.Windows.Forms.Label diasT;
        private System.Windows.Forms.Label diasR;
        private RoundedButton button1;
        private RoundedButton pagar;
        private RoundedButton registros;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn InicioAlmuerzo;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinAlmuerzo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Horas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comentario;
        private System.Windows.Forms.Label minutosT;
    }
}