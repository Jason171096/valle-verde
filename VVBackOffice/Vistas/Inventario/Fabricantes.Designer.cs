namespace ValleVerde
{
    partial class Fabricantes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fabricantes));
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dvgFabricantes = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.roundedButton2 = new ValleVerde.RoundedButton();
            this.roundedButton1 = new ValleVerde.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.dvgFabricantes)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(133, 63);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(278, 29);
            this.txtNombre.TabIndex = 72;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(36, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 24);
            this.label7.TabIndex = 71;
            this.label7.Text = "Nombre:";
            // 
            // dvgFabricantes
            // 
            this.dvgFabricantes.AllowUserToAddRows = false;
            this.dvgFabricantes.AllowUserToDeleteRows = false;
            this.dvgFabricantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgFabricantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgFabricantes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Descripcion,
            this.Column1,
            this.Column7});
            this.dvgFabricantes.Location = new System.Drawing.Point(12, 170);
            this.dvgFabricantes.Name = "dvgFabricantes";
            this.dvgFabricantes.ReadOnly = true;
            this.dvgFabricantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvgFabricantes.Size = new System.Drawing.Size(723, 321);
            this.dvgFabricantes.TabIndex = 69;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "No.";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Nombre";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Descripcion";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "No. de productos";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 24);
            this.label3.TabIndex = 68;
            this.label3.Text = "Fabricantes:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::ValleVerde.Properties.Resources.menos22;
            this.button1.Location = new System.Drawing.Point(741, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 24);
            this.button1.TabIndex = 70;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(169, 109);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(343, 29);
            this.txtDescripcion.TabIndex = 76;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 24);
            this.label1.TabIndex = 75;
            this.label1.Text = "Descripcion:";
            // 
            // roundedButton2
            // 
            this.roundedButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedButton2.BackColor = System.Drawing.Color.White;
            this.roundedButton2.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.roundedButton2.FlatAppearance.BorderSize = 5;
            this.roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.roundedButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.roundedButton2.Image = global::ValleVerde.Properties.Resources.mas24;
            this.roundedButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.roundedButton2.Location = new System.Drawing.Point(673, 109);
            this.roundedButton2.Name = "roundedButton2";
            this.roundedButton2.Size = new System.Drawing.Size(99, 36);
            this.roundedButton2.TabIndex = 74;
            this.roundedButton2.Text = "Nuevo";
            this.roundedButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roundedButton2.UseVisualStyleBackColor = false;
            this.roundedButton2.Click += new System.EventHandler(this.roundedButton2_Click);
            // 
            // roundedButton1
            // 
            this.roundedButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedButton1.BackColor = System.Drawing.Color.White;
            this.roundedButton1.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.roundedButton1.FlatAppearance.BorderSize = 5;
            this.roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.roundedButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.roundedButton1.Location = new System.Drawing.Point(624, 497);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(141, 46);
            this.roundedButton1.TabIndex = 73;
            this.roundedButton1.Text = "Aceptar";
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // Fabricantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roundedButton2);
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dvgFabricantes);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fabricantes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fabricantes";
            this.Load += new System.EventHandler(this.Fabricantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgFabricantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton roundedButton2;
        private RoundedButton roundedButton1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dvgFabricantes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
    }
}