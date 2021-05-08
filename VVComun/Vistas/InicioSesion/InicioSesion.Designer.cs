namespace ValleVerdeComun.Vistas.InicioSesion
{
    partial class InicioSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InicioSesion));
            this.txtMensaje = new System.Windows.Forms.RichTextBox();
            this.imgHuella = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRetry = new System.Windows.Forms.Button();
            this.panelHuella = new System.Windows.Forms.Panel();
            this.roundedButton1 = new ValleVerdeComun.RoundedButton();
            this.lblUsuarioNecesario = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgHuella)).BeginInit();
            this.panelHuella.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMensaje
            // 
            this.txtMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.Location = new System.Drawing.Point(155, 346);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.ReadOnly = true;
            this.txtMensaje.Size = new System.Drawing.Size(265, 54);
            this.txtMensaje.TabIndex = 5;
            this.txtMensaje.Text = "";
            // 
            // imgHuella
            // 
            this.imgHuella.BackColor = System.Drawing.Color.White;
            this.imgHuella.Image = global::ValleVerdeComun.Properties.Resources.huella100;
            this.imgHuella.Location = new System.Drawing.Point(155, 5);
            this.imgHuella.Name = "imgHuella";
            this.imgHuella.Size = new System.Drawing.Size(265, 335);
            this.imgHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgHuella.TabIndex = 4;
            this.imgHuella.TabStop = false;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(30, 173);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(313, 33);
            this.comboBox1.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(12, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(783, 75);
            this.lblTitulo.TabIndex = 7;
            this.lblTitulo.Text = "Ingresa tus datos o escanea tu huella para iniciar sesion en el sistema";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Usuario:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Contraseña:";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(30, 249);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(313, 31);
            this.textBox1.TabIndex = 2;
            this.textBox1.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "--- o ---";
            // 
            // btnRetry
            // 
            this.btnRetry.BackColor = System.Drawing.Color.White;
            this.btnRetry.Image = global::ValleVerdeComun.Properties.Resources.huellaescanear64;
            this.btnRetry.Location = new System.Drawing.Point(73, 267);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(76, 73);
            this.btnRetry.TabIndex = 13;
            this.btnRetry.UseVisualStyleBackColor = false;
            this.btnRetry.Visible = false;
            this.btnRetry.Click += new System.EventHandler(this.button1_Click);
            // 
            // panelHuella
            // 
            this.panelHuella.Controls.Add(this.btnRetry);
            this.panelHuella.Controls.Add(this.label4);
            this.panelHuella.Controls.Add(this.txtMensaje);
            this.panelHuella.Controls.Add(this.imgHuella);
            this.panelHuella.Location = new System.Drawing.Point(365, 48);
            this.panelHuella.Name = "panelHuella";
            this.panelHuella.Size = new System.Drawing.Size(430, 411);
            this.panelHuella.TabIndex = 14;
            // 
            // roundedButton1
            // 
            this.roundedButton1.BackColor = System.Drawing.Color.White;
            this.roundedButton1.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.roundedButton1.FlatAppearance.BorderSize = 5;
            this.roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.roundedButton1.Location = new System.Drawing.Point(85, 313);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(217, 71);
            this.roundedButton1.TabIndex = 3;
            this.roundedButton1.Text = "Iniciar Sesion";
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // lblUsuarioNecesario
            // 
            this.lblUsuarioNecesario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUsuarioNecesario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioNecesario.ForeColor = System.Drawing.Color.Orange;
            this.lblUsuarioNecesario.Location = new System.Drawing.Point(4, 387);
            this.lblUsuarioNecesario.Name = "lblUsuarioNecesario";
            this.lblUsuarioNecesario.Size = new System.Drawing.Size(355, 76);
            this.lblUsuarioNecesario.TabIndex = 15;
            this.lblUsuarioNecesario.Text = "*Debes ingresar como administrador o usuario  usuario  usuario para continuar.";
            this.lblUsuarioNecesario.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lblUsuarioNecesario.Visible = false;
            // 
            // InicioSesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.lblUsuarioNecesario);
            this.Controls.Add(this.panelHuella);
            this.Controls.Add(this.roundedButton1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.comboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InicioSesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesion";
            this.Load += new System.EventHandler(this.InicioSesion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgHuella)).EndInit();
            this.panelHuella.ResumeLayout(false);
            this.panelHuella.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtMensaje;
        public System.Windows.Forms.PictureBox imgHuella;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private RoundedButton roundedButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.Panel panelHuella;
        private System.Windows.Forms.Label lblUsuarioNecesario;
    }
}