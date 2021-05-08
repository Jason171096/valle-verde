namespace ValleVerde.Vistas.RecursosHumanos
{
    partial class BonosyPenalizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BonosyPenalizacion));
            this.dgvBonos = new System.Windows.Forms.DataGridView();
            this.CID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CImpor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CElim = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvPenalizaciones = new System.Windows.Forms.DataGridView();
            this.CIDPena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CDescriP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CImpoP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CElimiP = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnGuardar = new ValleVerde.RoundedButton();
            this.btnCancelar = new ValleVerde.RoundedButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenalizaciones)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvBonos
            // 
            this.dgvBonos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBonos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CID,
            this.CDes,
            this.CImpor,
            this.CElim});
            this.dgvBonos.Location = new System.Drawing.Point(6, 6);
            this.dgvBonos.Name = "dgvBonos";
            this.dgvBonos.RowHeadersVisible = false;
            this.dgvBonos.Size = new System.Drawing.Size(725, 347);
            this.dgvBonos.TabIndex = 0;
            this.dgvBonos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBonos_CellClick);
            this.dgvBonos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvBonos_EditingControlShowing);
            // 
            // CID
            // 
            this.CID.HeaderText = "IDBono";
            this.CID.Name = "CID";
            this.CID.Visible = false;
            // 
            // CDes
            // 
            this.CDes.HeaderText = "Descripción";
            this.CDes.Name = "CDes";
            // 
            // CImpor
            // 
            this.CImpor.HeaderText = "Importe";
            this.CImpor.Name = "CImpor";
            // 
            // CElim
            // 
            this.CElim.HeaderText = "Eliminar";
            this.CElim.Image = global::ValleVerde.Properties.Resources.darBajaUsuario1;
            this.CElim.Name = "CElim";
            this.CElim.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CElim.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvPenalizaciones
            // 
            this.dgvPenalizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPenalizaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CIDPena,
            this.CDescriP,
            this.CImpoP,
            this.CElimiP});
            this.dgvPenalizaciones.Location = new System.Drawing.Point(6, 6);
            this.dgvPenalizaciones.Name = "dgvPenalizaciones";
            this.dgvPenalizaciones.RowHeadersVisible = false;
            this.dgvPenalizaciones.Size = new System.Drawing.Size(725, 346);
            this.dgvPenalizaciones.TabIndex = 1;
            this.dgvPenalizaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPenalizaciones_CellClick);
            this.dgvPenalizaciones.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvPenalizaciones_EditingControlShowing);
            // 
            // CIDPena
            // 
            this.CIDPena.HeaderText = "IDPenalizacion";
            this.CIDPena.Name = "CIDPena";
            this.CIDPena.Visible = false;
            // 
            // CDescriP
            // 
            this.CDescriP.HeaderText = "Descripción";
            this.CDescriP.Name = "CDescriP";
            // 
            // CImpoP
            // 
            this.CImpoP.HeaderText = "Importe";
            this.CImpoP.Name = "CImpoP";
            // 
            // CElimiP
            // 
            this.CElimiP.HeaderText = "Eliminar";
            this.CElimiP.Image = global::ValleVerde.Properties.Resources.darBajaUsuario1;
            this.CElimiP.Name = "CElimiP";
            this.CElimiP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CElimiP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.White;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnGuardar.FlatAppearance.BorderSize = 5;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(565, 472);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 50);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCancelar.FlatAppearance.BorderSize = 5;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(60, 472);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 50);
            this.btnCancelar.TabIndex = 126;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(6, 69);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(745, 391);
            this.tabControl1.TabIndex = 127;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvBonos);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(737, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bonos";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvPenalizaciones);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(737, 358);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Penalizaciones";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 20);
            this.label1.TabIndex = 128;
            this.label1.Text = "Agregar Bono ú Penalización:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(250, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(343, 20);
            this.label2.TabIndex = 129;
            this.label2.Text = "Seleccione la ultima celda que esta vacía \r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Olive;
            this.label3.Location = new System.Drawing.Point(18, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 20);
            this.label3.TabIndex = 130;
            this.label3.Text = "Editar Bono ú Penalización:\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(250, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(466, 20);
            this.label4.TabIndex = 131;
            this.label4.Text = "Seleccione la celda que desee editar y de Boton Guardar\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(2, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(246, 20);
            this.label5.TabIndex = 132;
            this.label5.Text = "Eliminar Bono ú Penalización:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(250, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(501, 20);
            this.label6.TabIndex = 133;
            this.label6.Text = "Da click en la Imagen del Basurero de la Fila correspondiente";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(310, 467);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(249, 60);
            this.label7.TabIndex = 134;
            this.label7.Text = "Si EDITO o AGREGO nuevos \r\nBonos y Penalizaciones de \r\nen el boton de GUARDAR";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BonosyPenalizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(760, 536);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BonosyPenalizacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bonos y Penalizacion";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPenalizaciones)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBonos;
        private System.Windows.Forms.DataGridView dgvPenalizaciones;
        internal RoundedButton btnGuardar;
        internal RoundedButton btnCancelar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn CImpor;
        private System.Windows.Forms.DataGridViewImageColumn CElim;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIDPena;
        private System.Windows.Forms.DataGridViewTextBoxColumn CDescriP;
        private System.Windows.Forms.DataGridViewTextBoxColumn CImpoP;
        private System.Windows.Forms.DataGridViewImageColumn CElimiP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}