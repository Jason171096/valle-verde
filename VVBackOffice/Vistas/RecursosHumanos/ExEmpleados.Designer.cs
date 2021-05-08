namespace ValleVerde.Vistas.RecursosHumanos
{
    partial class ExEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExEmpleados));
            this.dgvExEmpleados = new System.Windows.Forms.DataGridView();
            this.textBoxBuscarExEmpleado = new System.Windows.Forms.TextBox();
            this.btnReingresar = new ValleVerde.RoundedButton();
            this.btnImprimirEx = new ValleVerde.RoundedButton();
            this.btnListaExEmpleados = new ValleVerde.RoundedButton();
            this.btnCartaReco = new ValleVerde.RoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewExEmpleados
            // 
            this.dgvExEmpleados.AllowUserToAddRows = false;
            this.dgvExEmpleados.AllowUserToDeleteRows = false;
            this.dgvExEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExEmpleados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExEmpleados.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvExEmpleados.Location = new System.Drawing.Point(11, 45);
            this.dgvExEmpleados.Margin = new System.Windows.Forms.Padding(2);
            this.dgvExEmpleados.Name = "dataGridViewExEmpleados";
            this.dgvExEmpleados.ReadOnly = true;
            this.dgvExEmpleados.RowHeadersVisible = false;
            this.dgvExEmpleados.RowHeadersWidth = 51;
            this.dgvExEmpleados.RowTemplate.Height = 24;
            this.dgvExEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExEmpleados.Size = new System.Drawing.Size(786, 313);
            this.dgvExEmpleados.TabIndex = 77;
            // 
            // textBoxBuscarExEmpleado
            // 
            this.textBoxBuscarExEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxBuscarExEmpleado.Location = new System.Drawing.Point(85, 15);
            this.textBoxBuscarExEmpleado.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxBuscarExEmpleado.Name = "textBoxBuscarExEmpleado";
            this.textBoxBuscarExEmpleado.Size = new System.Drawing.Size(712, 26);
            this.textBoxBuscarExEmpleado.TabIndex = 78;
            this.textBoxBuscarExEmpleado.TextChanged += new System.EventHandler(this.textBoxBuscarExEmpleado_TextChanged);
            // 
            // btnReingresar
            // 
            this.btnReingresar.BackColor = System.Drawing.Color.White;
            this.btnReingresar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnReingresar.FlatAppearance.BorderSize = 5;
            this.btnReingresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReingresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnReingresar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnReingresar.Location = new System.Drawing.Point(812, 306);
            this.btnReingresar.Name = "btnReingresar";
            this.btnReingresar.Size = new System.Drawing.Size(157, 51);
            this.btnReingresar.TabIndex = 99;
            this.btnReingresar.Text = "Reingresar";
            this.btnReingresar.UseVisualStyleBackColor = false;
            this.btnReingresar.Click += new System.EventHandler(this.btnReingresar_Click);
            // 
            // btnImprimirEx
            // 
            this.btnImprimirEx.BackColor = System.Drawing.Color.White;
            this.btnImprimirEx.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnImprimirEx.FlatAppearance.BorderSize = 5;
            this.btnImprimirEx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirEx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnImprimirEx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnImprimirEx.Location = new System.Drawing.Point(812, 15);
            this.btnImprimirEx.Name = "btnImprimirEx";
            this.btnImprimirEx.Size = new System.Drawing.Size(157, 71);
            this.btnImprimirEx.TabIndex = 98;
            this.btnImprimirEx.Text = "Datos para imprimir";
            this.btnImprimirEx.UseVisualStyleBackColor = false;
            this.btnImprimirEx.Click += new System.EventHandler(this.btnImprimirEx_Click);
            // 
            // btnListaExEmpleados
            // 
            this.btnListaExEmpleados.BackColor = System.Drawing.Color.White;
            this.btnListaExEmpleados.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnListaExEmpleados.FlatAppearance.BorderSize = 5;
            this.btnListaExEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListaExEmpleados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnListaExEmpleados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnListaExEmpleados.Location = new System.Drawing.Point(812, 172);
            this.btnListaExEmpleados.Name = "btnListaExEmpleados";
            this.btnListaExEmpleados.Size = new System.Drawing.Size(157, 75);
            this.btnListaExEmpleados.TabIndex = 97;
            this.btnListaExEmpleados.Text = "Lista ex - empleados";
            this.btnListaExEmpleados.UseVisualStyleBackColor = false;
            this.btnListaExEmpleados.Click += new System.EventHandler(this.btnListaExEmpleados_Click);
            // 
            // btnCartaReco
            // 
            this.btnCartaReco.BackColor = System.Drawing.Color.White;
            this.btnCartaReco.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCartaReco.FlatAppearance.BorderSize = 5;
            this.btnCartaReco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCartaReco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnCartaReco.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnCartaReco.Location = new System.Drawing.Point(812, 92);
            this.btnCartaReco.Name = "btnCartaReco";
            this.btnCartaReco.Size = new System.Drawing.Size(157, 74);
            this.btnCartaReco.TabIndex = 96;
            this.btnCartaReco.Text = "Carta de recomendación";
            this.btnCartaReco.UseVisualStyleBackColor = false;
            this.btnCartaReco.Click += new System.EventHandler(this.btnCartaReco_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 138;
            this.label1.Text = "Buscar:";
            // 
            // ExEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 369);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReingresar);
            this.Controls.Add(this.btnImprimirEx);
            this.Controls.Add(this.btnListaExEmpleados);
            this.Controls.Add(this.btnCartaReco);
            this.Controls.Add(this.textBoxBuscarExEmpleado);
            this.Controls.Add(this.dgvExEmpleados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ExEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ex Empleados";
            this.Load += new System.EventHandler(this.ExEmpleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExEmpleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvExEmpleados;
        private System.Windows.Forms.TextBox textBoxBuscarExEmpleado;
        private RoundedButton btnReingresar;
        private RoundedButton btnImprimirEx;
        private RoundedButton btnListaExEmpleados;
        private RoundedButton btnCartaReco;
        private System.Windows.Forms.Label label1;
    }
}