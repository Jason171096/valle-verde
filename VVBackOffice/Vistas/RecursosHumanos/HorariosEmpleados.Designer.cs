namespace ValleVerde.Vistas.RecursosHumanos
{
    partial class HorariosEmpleados
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
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HorariosEmpleados));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Turno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoraSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Asignar = new ValleVerde.RoundedButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new ValleVerde.RoundedButton();
            this.groupDescanso = new System.Windows.Forms.GroupBox();
            this.Descanso = new ValleVerde.RoundedButton();
            this.label2 = new System.Windows.Forms.Label();
            this.checkDescanso = new System.Windows.Forms.CheckBox();
            this.tiempoDescanso = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupDescanso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiempoDescanso)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(217, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(258, 32);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Empleados:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Turno,
            this.HoraEntrada,
            this.HoraSalida});
            this.dataGridView1.Location = new System.Drawing.Point(41, 70);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(327, 427);
            this.dataGridView1.TabIndex = 2;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // Turno
            // 
            this.Turno.HeaderText = "Turno";
            this.Turno.Name = "Turno";
            // 
            // HoraEntrada
            // 
            this.HoraEntrada.HeaderText = "Hora de Entrada";
            this.HoraEntrada.Name = "HoraEntrada";
            // 
            // HoraSalida
            // 
            this.HoraSalida.HeaderText = "Hora de Salida";
            this.HoraSalida.Name = "HoraSalida";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Asignar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(400, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 88);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asignar Horario";
            // 
            // Asignar
            // 
            this.Asignar.BackColor = System.Drawing.Color.White;
            this.Asignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Asignar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Asignar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.Asignar.Location = new System.Drawing.Point(65, 37);
            this.Asignar.Name = "Asignar";
            this.Asignar.Size = new System.Drawing.Size(87, 33);
            this.Asignar.TabIndex = 3;
            this.Asignar.Text = "Asignar";
            this.Asignar.UseVisualStyleBackColor = true;
            this.Asignar.Click += new System.EventHandler(this.Asignar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(400, 400);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 93);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Eliminar Horario";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.button2.Location = new System.Drawing.Point(65, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 36);
            this.button2.TabIndex = 4;
            this.button2.Text = "Eliminar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupDescanso
            // 
            this.groupDescanso.Controls.Add(this.Descanso);
            this.groupDescanso.Controls.Add(this.label2);
            this.groupDescanso.Controls.Add(this.checkDescanso);
            this.groupDescanso.Controls.Add(this.tiempoDescanso);
            this.groupDescanso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupDescanso.Location = new System.Drawing.Point(400, 195);
            this.groupDescanso.Name = "groupDescanso";
            this.groupDescanso.Size = new System.Drawing.Size(210, 179);
            this.groupDescanso.TabIndex = 7;
            this.groupDescanso.TabStop = false;
            this.groupDescanso.Text = "Tiempo de Descanso";
            // 
            // Descanso
            // 
            this.Descanso.BackColor = System.Drawing.Color.White;
            this.Descanso.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.Descanso.FlatAppearance.BorderSize = 5;
            this.Descanso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Descanso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.Descanso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.Descanso.Location = new System.Drawing.Point(65, 127);
            this.Descanso.Name = "Descanso";
            this.Descanso.Size = new System.Drawing.Size(87, 37);
            this.Descanso.TabIndex = 3;
            this.Descanso.Text = "Agregar";
            this.Descanso.UseVisualStyleBackColor = false;
            this.Descanso.Click += new System.EventHandler(this.Descanso_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(140, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "min.";
            // 
            // checkDescanso
            // 
            this.checkDescanso.AutoSize = true;
            this.checkDescanso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkDescanso.Location = new System.Drawing.Point(27, 81);
            this.checkDescanso.Name = "checkDescanso";
            this.checkDescanso.Size = new System.Drawing.Size(157, 24);
            this.checkDescanso.TabIndex = 1;
            this.checkDescanso.Text = "Todos los horarios";
            this.checkDescanso.UseVisualStyleBackColor = true;
            // 
            // tiempoDescanso
            // 
            this.tiempoDescanso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tiempoDescanso.Location = new System.Drawing.Point(13, 37);
            this.tiempoDescanso.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.tiempoDescanso.Name = "tiempoDescanso";
            this.tiempoDescanso.Size = new System.Drawing.Size(120, 26);
            this.tiempoDescanso.TabIndex = 0;
            this.tiempoDescanso.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // HorariosEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 528);
            this.Controls.Add(this.groupDescanso);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HorariosEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Horario Empleado";
            this.Load += new System.EventHandler(this.HorariosEmpleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupDescanso.ResumeLayout(false);
            this.groupDescanso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tiempoDescanso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Turno;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoraSalida;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private RoundedButton Asignar;
        private RoundedButton button2;
        private System.Windows.Forms.GroupBox groupDescanso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkDescanso;
        private System.Windows.Forms.NumericUpDown tiempoDescanso;
        private RoundedButton Descanso;
    }
}