namespace ValleVerde.Vistas.Utileria
{
    partial class VerificarInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerificarInventario));
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tablaver = new System.Windows.Forms.DataGridView();
            this.IDClaveVerificar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigoo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Granel2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.cbubicacion = new System.Windows.Forms.ComboBox();
            this.tablaalma = new System.Windows.Forms.DataGridView();
            this.IDVerifUbi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ubica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Granel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button9 = new System.Windows.Forms.Button();
            this.nom = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtnom = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.roundedButton2 = new ValleVerde.RoundedButton();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.finalizar = new ValleVerde.RoundedButton();
            this.Aceptar = new ValleVerde.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.tablaver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaalma)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Buscar Codigo";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(212, 74);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(262, 28);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // tablaver
            // 
            this.tablaver.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaver.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaver.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDClaveVerificar,
            this.Codigoo,
            this.Nombree,
            this.Granel2});
            this.tablaver.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.tablaver.Location = new System.Drawing.Point(46, 176);
            this.tablaver.Name = "tablaver";
            this.tablaver.RowHeadersVisible = false;
            this.tablaver.RowHeadersWidth = 51;
            this.tablaver.RowTemplate.Height = 24;
            this.tablaver.Size = new System.Drawing.Size(613, 453);
            this.tablaver.TabIndex = 2;
            // 
            // IDClaveVerificar
            // 
            this.IDClaveVerificar.HeaderText = "IDClaveVerificar";
            this.IDClaveVerificar.MinimumWidth = 6;
            this.IDClaveVerificar.Name = "IDClaveVerificar";
            this.IDClaveVerificar.Visible = false;
            this.IDClaveVerificar.Width = 125;
            // 
            // Codigoo
            // 
            this.Codigoo.HeaderText = "Codigo";
            this.Codigoo.MinimumWidth = 6;
            this.Codigoo.Name = "Codigoo";
            this.Codigoo.Width = 125;
            // 
            // Nombree
            // 
            this.Nombree.HeaderText = "Nombre";
            this.Nombree.MinimumWidth = 6;
            this.Nombree.Name = "Nombree";
            this.Nombree.Width = 125;
            // 
            // Granel2
            // 
            this.Granel2.HeaderText = "Granel";
            this.Granel2.MinimumWidth = 6;
            this.Granel2.Name = "Granel2";
            this.Granel2.Visible = false;
            this.Granel2.Width = 125;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(236, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 24);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ubicaciones";
            // 
            // cbubicacion
            // 
            this.cbubicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbubicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbubicacion.FormattingEnabled = true;
            this.cbubicacion.Location = new System.Drawing.Point(239, 212);
            this.cbubicacion.Name = "cbubicacion";
            this.cbubicacion.Size = new System.Drawing.Size(266, 28);
            this.cbubicacion.TabIndex = 5;
            // 
            // tablaalma
            // 
            this.tablaalma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaalma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaalma.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDVerifUbi,
            this.Ubica,
            this.IDUsuario,
            this.Cantidad,
            this.Granel});
            this.tablaalma.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.tablaalma.Location = new System.Drawing.Point(677, 279);
            this.tablaalma.MultiSelect = false;
            this.tablaalma.Name = "tablaalma";
            this.tablaalma.RowHeadersVisible = false;
            this.tablaalma.RowHeadersWidth = 51;
            this.tablaalma.RowTemplate.Height = 24;
            this.tablaalma.Size = new System.Drawing.Size(681, 350);
            this.tablaalma.TabIndex = 50;
            // 
            // IDVerifUbi
            // 
            this.IDVerifUbi.HeaderText = "IDVerifUbi";
            this.IDVerifUbi.MinimumWidth = 6;
            this.IDVerifUbi.Name = "IDVerifUbi";
            this.IDVerifUbi.Visible = false;
            this.IDVerifUbi.Width = 125;
            // 
            // Ubica
            // 
            this.Ubica.HeaderText = "Ubicación";
            this.Ubica.MinimumWidth = 6;
            this.Ubica.Name = "Ubica";
            this.Ubica.ReadOnly = true;
            this.Ubica.Width = 125;
            // 
            // IDUsuario
            // 
            this.IDUsuario.HeaderText = "IDUsuario";
            this.IDUsuario.MinimumWidth = 6;
            this.IDUsuario.Name = "IDUsuario";
            this.IDUsuario.ReadOnly = true;
            this.IDUsuario.Visible = false;
            this.IDUsuario.Width = 125;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 125;
            // 
            // Granel
            // 
            this.Granel.HeaderText = "Granel";
            this.Granel.MinimumWidth = 6;
            this.Granel.Name = "Granel";
            this.Granel.Visible = false;
            this.Granel.Width = 125;
            // 
            // button9
            // 
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Image = global::ValleVerde.Properties.Resources.lupa;
            this.button9.Location = new System.Drawing.Point(481, 74);
            this.button9.Margin = new System.Windows.Forms.Padding(4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(39, 36);
            this.button9.TabIndex = 49;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // nom
            // 
            this.nom.AutoSize = true;
            this.nom.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nom.Location = new System.Drawing.Point(236, 16);
            this.nom.Name = "nom";
            this.nom.Size = new System.Drawing.Size(91, 24);
            this.nom.TabIndex = 53;
            this.nom.Text = "Nombre:";
            this.nom.Click += new System.EventHandler(this.nom_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 251);
            this.panel1.TabIndex = 54;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(219, 245);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 55;
            this.pictureBox1.TabStop = false;
            // 
            // txtnom
            // 
            this.txtnom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtnom.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnom.Location = new System.Drawing.Point(237, 40);
            this.txtnom.Name = "txtnom";
            this.txtnom.Size = new System.Drawing.Size(461, 105);
            this.txtnom.TabIndex = 55;
            this.txtnom.Click += new System.EventHandler(this.txtnom_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.nom);
            this.panel2.Controls.Add(this.txtnom);
            this.panel2.Controls.Add(this.cbubicacion);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.roundedButton2);
            this.panel2.Location = new System.Drawing.Point(660, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(697, 262);
            this.panel2.TabIndex = 56;
            // 
            // roundedButton2
            // 
            this.roundedButton2.BackColor = System.Drawing.Color.White;
            this.roundedButton2.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.roundedButton2.FlatAppearance.BorderSize = 5;
            this.roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.roundedButton2.Location = new System.Drawing.Point(541, 200);
            this.roundedButton2.Name = "roundedButton2";
            this.roundedButton2.Size = new System.Drawing.Size(130, 54);
            this.roundedButton2.TabIndex = 3;
            this.roundedButton2.Text = "Agregar";
            this.roundedButton2.UseVisualStyleBackColor = false;
            this.roundedButton2.Click += new System.EventHandler(this.roundedButton2_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(1183, 646);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(143, 35);
            this.textBox3.TabIndex = 57;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // finalizar
            // 
            this.finalizar.BackColor = System.Drawing.Color.White;
            this.finalizar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.finalizar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.finalizar.FlatAppearance.BorderSize = 5;
            this.finalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.finalizar.Location = new System.Drawing.Point(974, 636);
            this.finalizar.Name = "finalizar";
            this.finalizar.Size = new System.Drawing.Size(131, 59);
            this.finalizar.TabIndex = 52;
            this.finalizar.Text = "Finalizar";
            this.finalizar.UseVisualStyleBackColor = false;
            this.finalizar.Click += new System.EventHandler(this.finalizar_Click);
            // 
            // Aceptar
            // 
            this.Aceptar.BackColor = System.Drawing.Color.White;
            this.Aceptar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.Aceptar.FlatAppearance.BorderSize = 5;
            this.Aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Aceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.Aceptar.Location = new System.Drawing.Point(279, 117);
            this.Aceptar.Name = "Aceptar";
            this.Aceptar.Size = new System.Drawing.Size(124, 53);
            this.Aceptar.TabIndex = 51;
            this.Aceptar.Text = "Aceptar";
            this.Aceptar.UseVisualStyleBackColor = false;
            this.Aceptar.Click += new System.EventHandler(this.Aceptar_Click);
            // 
            // VerificarInventario
            // 
            this.ClientSize = new System.Drawing.Size(1370, 707);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.finalizar);
            this.Controls.Add(this.Aceptar);
            this.Controls.Add(this.tablaalma);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.tablaver);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VerificarInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verificar Inventario";
            this.Load += new System.EventHandler(this.VerificarInventario_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.tablaver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaalma)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView tablaverificar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private RoundedButton roundedButton1;
        private System.Windows.Forms.DataGridView tablachecar;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreBusqueda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Almacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estanteria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView tablaver;
        private RoundedButton roundedButton2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbubicacion;
        private System.Windows.Forms.Button button9;
        private RoundedButton Aceptar;
        private RoundedButton finalizar;
        private System.Windows.Forms.Label nom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label txtnom;
        private System.Windows.Forms.DataGridView tablaalma;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDVerifUbi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ubica;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Granel;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDClaveVerificar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigoo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombree;
        private System.Windows.Forms.DataGridViewTextBoxColumn Granel2;
    }
}