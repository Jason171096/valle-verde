namespace ValleVerde.Vistas.Compras
{
    partial class PreguntaProductoDevolucion
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
            this.label1 = new System.Windows.Forms.Label();
            this.cb = new System.Windows.Forms.ComboBox();
            this.tbCan = new System.Windows.Forms.TextBox();
            this.tbCos = new System.Windows.Forms.TextBox();
            this.lCan = new System.Windows.Forms.Label();
            this.lCos = new System.Windows.Forms.Label();
            this.bAce = new ValleVerde.RoundedButton();
            this.tbCodBar = new System.Windows.Forms.TextBox();
            this.lCodBar = new System.Windows.Forms.Label();
            this.bSelProd = new ValleVerde.RoundedButton();
            this.bMos = new ValleVerde.RoundedButton();
            this.lDes = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lSeDev = new System.Windows.Forms.Label();
            this.lDescrProd = new System.Windows.Forms.Label();
            this.lImpo2 = new System.Windows.Forms.Label();
            this.lImpo1 = new System.Windows.Forms.Label();
            this.bSal = new ValleVerde.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Qué se recibirá a cambio de este producto?";
            // 
            // cb
            // 
            this.cb.FormattingEnabled = true;
            this.cb.Location = new System.Drawing.Point(16, 80);
            this.cb.Name = "cb";
            this.cb.Size = new System.Drawing.Size(406, 28);
            this.cb.TabIndex = 0;
            // 
            // tbCan
            // 
            this.tbCan.Location = new System.Drawing.Point(16, 246);
            this.tbCan.Name = "tbCan";
            this.tbCan.Size = new System.Drawing.Size(100, 26);
            this.tbCan.TabIndex = 2;
            this.tbCan.Text = "1";
            // 
            // tbCos
            // 
            this.tbCos.Location = new System.Drawing.Point(322, 246);
            this.tbCos.Name = "tbCos";
            this.tbCos.Size = new System.Drawing.Size(100, 26);
            this.tbCos.TabIndex = 3;
            this.tbCos.Text = "0";
            // 
            // lCan
            // 
            this.lCan.AutoSize = true;
            this.lCan.Location = new System.Drawing.Point(12, 223);
            this.lCan.Name = "lCan";
            this.lCan.Size = new System.Drawing.Size(77, 20);
            this.lCan.TabIndex = 4;
            this.lCan.Text = "Cantidad:";
            // 
            // lCos
            // 
            this.lCos.AutoSize = true;
            this.lCos.Location = new System.Drawing.Point(318, 223);
            this.lCos.Name = "lCos";
            this.lCos.Size = new System.Drawing.Size(55, 20);
            this.lCos.TabIndex = 5;
            this.lCos.Text = "Costo:";
            // 
            // bAce
            // 
            this.bAce.BackColor = System.Drawing.Color.White;
            this.bAce.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bAce.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.bAce.FlatAppearance.BorderSize = 5;
            this.bAce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bAce.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.bAce.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.bAce.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bAce.Location = new System.Drawing.Point(175, 346);
            this.bAce.Name = "bAce";
            this.bAce.Size = new System.Drawing.Size(100, 46);
            this.bAce.TabIndex = 4;
            this.bAce.Text = "Guardar";
            this.bAce.UseVisualStyleBackColor = false;
            this.bAce.Click += new System.EventHandler(this.bAce_Click);
            // 
            // tbCodBar
            // 
            this.tbCodBar.Location = new System.Drawing.Point(16, 144);
            this.tbCodBar.Name = "tbCodBar";
            this.tbCodBar.Size = new System.Drawing.Size(247, 26);
            this.tbCodBar.TabIndex = 1;
            // 
            // lCodBar
            // 
            this.lCodBar.AutoSize = true;
            this.lCodBar.Location = new System.Drawing.Point(12, 121);
            this.lCodBar.Name = "lCodBar";
            this.lCodBar.Size = new System.Drawing.Size(77, 20);
            this.lCodBar.TabIndex = 11;
            this.lCodBar.Text = "Producto:";
            // 
            // bSelProd
            // 
            this.bSelProd.BackColor = System.Drawing.SystemColors.Control;
            this.bSelProd.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.bSelProd.FlatAppearance.BorderSize = 5;
            this.bSelProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSelProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.bSelProd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.bSelProd.Image = global::ValleVerde.Properties.Resources.lupa;
            this.bSelProd.Location = new System.Drawing.Point(269, 134);
            this.bSelProd.Name = "bSelProd";
            this.bSelProd.Size = new System.Drawing.Size(43, 46);
            this.bSelProd.TabIndex = 134;
            this.bSelProd.UseVisualStyleBackColor = false;
            this.bSelProd.Click += new System.EventHandler(this.bSelProd_Click);
            // 
            // bMos
            // 
            this.bMos.BackColor = System.Drawing.Color.White;
            this.bMos.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.bMos.FlatAppearance.BorderSize = 5;
            this.bMos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.bMos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.bMos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bMos.Location = new System.Drawing.Point(318, 134);
            this.bMos.Name = "bMos";
            this.bMos.Size = new System.Drawing.Size(104, 46);
            this.bMos.TabIndex = 135;
            this.bMos.Text = "Mostrar";
            this.bMos.UseVisualStyleBackColor = false;
            this.bMos.Click += new System.EventHandler(this.bMos_Click);
            // 
            // lDes
            // 
            this.lDes.AutoSize = true;
            this.lDes.Location = new System.Drawing.Point(12, 183);
            this.lDes.Name = "lDes";
            this.lDes.Size = new System.Drawing.Size(92, 20);
            this.lDes.TabIndex = 137;
            this.lDes.Text = "Descripción";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(132, 205);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 135);
            this.pictureBox1.TabIndex = 138;
            this.pictureBox1.TabStop = false;
            // 
            // lSeDev
            // 
            this.lSeDev.AutoSize = true;
            this.lSeDev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSeDev.Location = new System.Drawing.Point(12, 9);
            this.lSeDev.Name = "lSeDev";
            this.lSeDev.Size = new System.Drawing.Size(104, 20);
            this.lSeDev.TabIndex = 139;
            this.lSeDev.Text = "Se devolverá:";
            // 
            // lDescrProd
            // 
            this.lDescrProd.AutoSize = true;
            this.lDescrProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDescrProd.Location = new System.Drawing.Point(12, 29);
            this.lDescrProd.Name = "lDescrProd";
            this.lDescrProd.Size = new System.Drawing.Size(208, 20);
            this.lDescrProd.TabIndex = 140;
            this.lDescrProd.Text = "Cantidad, descripción, costo";
            // 
            // lImpo2
            // 
            this.lImpo2.AutoSize = true;
            this.lImpo2.Location = new System.Drawing.Point(318, 307);
            this.lImpo2.Name = "lImpo2";
            this.lImpo2.Size = new System.Drawing.Size(49, 20);
            this.lImpo2.TabIndex = 141;
            this.lImpo2.Text = "$0.00";
            // 
            // lImpo1
            // 
            this.lImpo1.AutoSize = true;
            this.lImpo1.Location = new System.Drawing.Point(318, 287);
            this.lImpo1.Name = "lImpo1";
            this.lImpo1.Size = new System.Drawing.Size(68, 20);
            this.lImpo1.TabIndex = 142;
            this.lImpo1.Text = "Importe:";
            // 
            // bSal
            // 
            this.bSal.BackColor = System.Drawing.Color.White;
            this.bSal.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.bSal.FlatAppearance.BorderSize = 5;
            this.bSal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.bSal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.bSal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSal.Location = new System.Drawing.Point(322, 348);
            this.bSal.Name = "bSal";
            this.bSal.Size = new System.Drawing.Size(100, 46);
            this.bSal.TabIndex = 143;
            this.bSal.Text = "Salir";
            this.bSal.UseVisualStyleBackColor = false;
            this.bSal.Visible = false;
            // 
            // PreguntaProductoDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 406);
            this.Controls.Add(this.bSal);
            this.Controls.Add(this.lImpo1);
            this.Controls.Add(this.lImpo2);
            this.Controls.Add(this.lDescrProd);
            this.Controls.Add(this.lSeDev);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lDes);
            this.Controls.Add(this.bMos);
            this.Controls.Add(this.bSelProd);
            this.Controls.Add(this.lCodBar);
            this.Controls.Add(this.tbCodBar);
            this.Controls.Add(this.bAce);
            this.Controls.Add(this.lCos);
            this.Controls.Add(this.lCan);
            this.Controls.Add(this.tbCos);
            this.Controls.Add(this.tbCan);
            this.Controls.Add(this.cb);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PreguntaProductoDevolucion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolución de producto";
            this.Load += new System.EventHandler(this.PreguntaProductoDevolucion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cb;
        public System.Windows.Forms.TextBox tbCan;
        public System.Windows.Forms.TextBox tbCos;
        private System.Windows.Forms.Label lCan;
        private System.Windows.Forms.Label lCos;
        private RoundedButton bAce;
        public System.Windows.Forms.TextBox tbCodBar;
        private System.Windows.Forms.Label lCodBar;
        private RoundedButton bSelProd;
        private RoundedButton bMos;
        private System.Windows.Forms.Label lDes;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lSeDev;
        private System.Windows.Forms.Label lDescrProd;
        private System.Windows.Forms.Label lImpo2;
        private System.Windows.Forms.Label lImpo1;
        private RoundedButton bSal;

        //No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, comerciales, o cualquier otro fin, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
    }
}