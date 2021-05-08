namespace ValleVerde.Vistas.Utileria
{
    partial class HistorialImpresionesEtiquetas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistorialImpresionesEtiquetas));
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new ValleVerde.RoundedButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkCambioPrecio = new System.Windows.Forms.CheckBox();
            this.checkConPrecio = new System.Windows.Forms.CheckBox();
            this.checkFinalizado = new System.Windows.Forms.CheckBox();
            this.checkPegados = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkFecha = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(12, 100);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.Size = new System.Drawing.Size(919, 372);
            this.dgvHistorial.TabIndex = 0;
            this.dgvHistorial.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvHistorial_CellPainting);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCancelar.FlatAppearance.BorderSize = 5;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnCancelar.Location = new System.Drawing.Point(762, 478);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(169, 49);
            this.btnCancelar.TabIndex = 53;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.checkCambioPrecio);
            this.panel2.Controls.Add(this.checkConPrecio);
            this.panel2.Controls.Add(this.checkFinalizado);
            this.panel2.Controls.Add(this.checkPegados);
            this.panel2.Location = new System.Drawing.Point(475, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(456, 87);
            this.panel2.TabIndex = 55;
            // 
            // checkCambioPrecio
            // 
            this.checkCambioPrecio.AutoSize = true;
            this.checkCambioPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkCambioPrecio.Location = new System.Drawing.Point(209, 52);
            this.checkCambioPrecio.Name = "checkCambioPrecio";
            this.checkCambioPrecio.Size = new System.Drawing.Size(197, 24);
            this.checkCambioPrecio.TabIndex = 152;
            this.checkCambioPrecio.Text = "Por cambio de Precio";
            this.checkCambioPrecio.UseVisualStyleBackColor = true;
            this.checkCambioPrecio.CheckedChanged += new System.EventHandler(this.checkCambioPrecio_CheckedChanged);
            // 
            // checkConPrecio
            // 
            this.checkConPrecio.AutoSize = true;
            this.checkConPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkConPrecio.Location = new System.Drawing.Point(209, 16);
            this.checkConPrecio.Name = "checkConPrecio";
            this.checkConPrecio.Size = new System.Drawing.Size(115, 24);
            this.checkConPrecio.TabIndex = 151;
            this.checkConPrecio.Text = "Con Precio";
            this.checkConPrecio.UseVisualStyleBackColor = true;
            this.checkConPrecio.CheckedChanged += new System.EventHandler(this.checkConPrecio_CheckedChanged);
            // 
            // checkFinalizado
            // 
            this.checkFinalizado.AutoSize = true;
            this.checkFinalizado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkFinalizado.Location = new System.Drawing.Point(34, 51);
            this.checkFinalizado.Name = "checkFinalizado";
            this.checkFinalizado.Size = new System.Drawing.Size(110, 24);
            this.checkFinalizado.TabIndex = 150;
            this.checkFinalizado.Text = "Finalizado";
            this.checkFinalizado.UseVisualStyleBackColor = true;
            this.checkFinalizado.CheckedChanged += new System.EventHandler(this.checkFinalizado_CheckedChanged);
            // 
            // checkPegados
            // 
            this.checkPegados.AutoSize = true;
            this.checkPegados.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkPegados.Location = new System.Drawing.Point(34, 16);
            this.checkPegados.Name = "checkPegados";
            this.checkPegados.Size = new System.Drawing.Size(98, 24);
            this.checkPegados.TabIndex = 149;
            this.checkPegados.Text = "Pegados";
            this.checkPegados.UseVisualStyleBackColor = true;
            this.checkPegados.CheckedChanged += new System.EventHandler(this.checkPegados_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.checkFecha);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtpFechaInicio);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtpFechaFinal);
            this.panel1.Location = new System.Drawing.Point(12, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(457, 87);
            this.panel1.TabIndex = 56;
            // 
            // checkFecha
            // 
            this.checkFecha.AutoSize = true;
            this.checkFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkFecha.Location = new System.Drawing.Point(19, 32);
            this.checkFecha.Name = "checkFecha";
            this.checkFecha.Size = new System.Drawing.Size(138, 24);
            this.checkFecha.TabIndex = 146;
            this.checkFecha.Text = "Activar Fecha";
            this.checkFecha.UseVisualStyleBackColor = true;
            this.checkFecha.CheckedChanged += new System.EventHandler(this.checkFecha_CheckedChanged_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(171, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 148;
            this.label3.Text = "Fecha Inicio:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Enabled = false;
            this.dtpFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(288, 8);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(160, 31);
            this.dtpFechaInicio.TabIndex = 144;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(172, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 147;
            this.label2.Text = "Fecha Final:";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFinal.Enabled = false;
            this.dtpFechaFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(288, 45);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(160, 31);
            this.dtpFechaFinal.TabIndex = 145;
            // 
            // HistorialImpresionesEtiquetas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(943, 539);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgvHistorial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "HistorialImpresionesEtiquetas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial Impresiones Etiquetas";
            this.Load += new System.EventHandler(this.HistorialImpresionesEtiquetas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorial;
        internal RoundedButton btnCancelar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkCambioPrecio;
        private System.Windows.Forms.CheckBox checkConPrecio;
        private System.Windows.Forms.CheckBox checkFinalizado;
        private System.Windows.Forms.CheckBox checkPegados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
    }
}