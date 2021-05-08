namespace ValleVerde.Vistas
{
    partial class BuscarProveedor2
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
            this.butAce = new ValleVerde.RoundedButton();
            this.butBus = new ValleVerde.RoundedButton();
            this.datGriVieBusPro = new System.Windows.Forms.DataGridView();
            this.texBoxBus = new System.Windows.Forms.TextBox();
            this.idPro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diaVis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.est = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.corEle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diaCre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limCre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datGriVieBusPro)).BeginInit();
            this.SuspendLayout();
            // 
            // butAce
            // 
            this.butAce.BackColor = System.Drawing.Color.White;
            this.butAce.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.butAce.FlatAppearance.BorderSize = 5;
            this.butAce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAce.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butAce.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.butAce.Location = new System.Drawing.Point(926, 548);
            this.butAce.Name = "butAce";
            this.butAce.Size = new System.Drawing.Size(76, 33);
            this.butAce.TabIndex = 78;
            this.butAce.Text = "Aceptar";
            this.butAce.UseVisualStyleBackColor = false;
            this.butAce.Click += new System.EventHandler(this.butAce_Click);
            // 
            // butBus
            // 
            this.butBus.BackColor = System.Drawing.Color.White;
            this.butBus.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.butBus.FlatAppearance.BorderSize = 5;
            this.butBus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butBus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.butBus.Location = new System.Drawing.Point(926, 4);
            this.butBus.Name = "butBus";
            this.butBus.Size = new System.Drawing.Size(76, 36);
            this.butBus.TabIndex = 77;
            this.butBus.Text = "Buscar";
            this.butBus.UseVisualStyleBackColor = false;
            this.butBus.Click += new System.EventHandler(this.butBus_Click);
            // 
            // datGriVieBusPro
            // 
            this.datGriVieBusPro.AllowUserToAddRows = false;
            this.datGriVieBusPro.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datGriVieBusPro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datGriVieBusPro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGriVieBusPro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPro,
            this.nom,
            this.RFC,
            this.diaVis,
            this.Direccion,
            this.ciu,
            this.est,
            this.cel,
            this.tel,
            this.corEle,
            this.diaCre,
            this.limCre});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datGriVieBusPro.DefaultCellStyle = dataGridViewCellStyle2;
            this.datGriVieBusPro.Location = new System.Drawing.Point(9, 45);
            this.datGriVieBusPro.Margin = new System.Windows.Forms.Padding(2);
            this.datGriVieBusPro.MultiSelect = false;
            this.datGriVieBusPro.Name = "datGriVieBusPro";
            this.datGriVieBusPro.ReadOnly = true;
            this.datGriVieBusPro.RowHeadersVisible = false;
            this.datGriVieBusPro.RowHeadersWidth = 51;
            this.datGriVieBusPro.RowTemplate.Height = 24;
            this.datGriVieBusPro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datGriVieBusPro.Size = new System.Drawing.Size(993, 498);
            this.datGriVieBusPro.TabIndex = 76;
            // 
            // texBoxBus
            // 
            this.texBoxBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.texBoxBus.Location = new System.Drawing.Point(9, 9);
            this.texBoxBus.Margin = new System.Windows.Forms.Padding(2);
            this.texBoxBus.Name = "texBoxBus";
            this.texBoxBus.Size = new System.Drawing.Size(912, 26);
            this.texBoxBus.TabIndex = 75;
            // 
            // idPro
            // 
            this.idPro.HeaderText = "idPro";
            this.idPro.MinimumWidth = 6;
            this.idPro.Name = "idPro";
            this.idPro.ReadOnly = true;
            this.idPro.Visible = false;
            // 
            // nom
            // 
            this.nom.HeaderText = "Nombre completo";
            this.nom.MinimumWidth = 6;
            this.nom.Name = "nom";
            this.nom.ReadOnly = true;
            // 
            // RFC
            // 
            this.RFC.HeaderText = "R.F.C.";
            this.RFC.MinimumWidth = 6;
            this.RFC.Name = "RFC";
            this.RFC.ReadOnly = true;
            // 
            // diaVis
            // 
            this.diaVis.HeaderText = "Días de visita";
            this.diaVis.MinimumWidth = 6;
            this.diaVis.Name = "diaVis";
            this.diaVis.ReadOnly = true;
            // 
            // Direccion
            // 
            this.Direccion.HeaderText = "Dirección";
            this.Direccion.MinimumWidth = 6;
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            // 
            // ciu
            // 
            this.ciu.HeaderText = "Ciudad";
            this.ciu.MinimumWidth = 6;
            this.ciu.Name = "ciu";
            this.ciu.ReadOnly = true;
            // 
            // est
            // 
            this.est.HeaderText = "Estado";
            this.est.MinimumWidth = 6;
            this.est.Name = "est";
            this.est.ReadOnly = true;
            // 
            // cel
            // 
            this.cel.HeaderText = "Celular";
            this.cel.MinimumWidth = 6;
            this.cel.Name = "cel";
            this.cel.ReadOnly = true;
            // 
            // tel
            // 
            this.tel.HeaderText = "Teléfono";
            this.tel.MinimumWidth = 6;
            this.tel.Name = "tel";
            this.tel.ReadOnly = true;
            // 
            // corEle
            // 
            this.corEle.HeaderText = "Correo electrónico";
            this.corEle.MinimumWidth = 6;
            this.corEle.Name = "corEle";
            this.corEle.ReadOnly = true;
            // 
            // diaCre
            // 
            this.diaCre.HeaderText = "Días de crédito";
            this.diaCre.MinimumWidth = 6;
            this.diaCre.Name = "diaCre";
            this.diaCre.ReadOnly = true;
            // 
            // limCre
            // 
            this.limCre.HeaderText = "Limite de crédito";
            this.limCre.MinimumWidth = 6;
            this.limCre.Name = "limCre";
            this.limCre.ReadOnly = true;
            // 
            // BuscarProveedor2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 586);
            this.Controls.Add(this.butAce);
            this.Controls.Add(this.butBus);
            this.Controls.Add(this.datGriVieBusPro);
            this.Controls.Add(this.texBoxBus);
            this.Name = "BuscarProveedor2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BuscarProveedor2";
            this.Load += new System.EventHandler(this.BuscarProveedor2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datGriVieBusPro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton butAce;
        private RoundedButton butBus;
        private System.Windows.Forms.DataGridView datGriVieBusPro;
        private System.Windows.Forms.TextBox texBoxBus;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPro;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFC;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaVis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciu;
        private System.Windows.Forms.DataGridViewTextBoxColumn est;
        private System.Windows.Forms.DataGridViewTextBoxColumn cel;
        private System.Windows.Forms.DataGridViewTextBoxColumn tel;
        private System.Windows.Forms.DataGridViewTextBoxColumn corEle;
        private System.Windows.Forms.DataGridViewTextBoxColumn diaCre;
        private System.Windows.Forms.DataGridViewTextBoxColumn limCre;
    }
}