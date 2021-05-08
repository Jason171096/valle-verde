namespace ValleVerde.Vistas.Compras
{
    partial class AltaRapida
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
            this.lCodBar = new System.Windows.Forms.Label();
            this.tbCodBar = new System.Windows.Forms.TextBox();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.lNom = new System.Windows.Forms.Label();
            this.bCon = new ValleVerde.RoundedButton();
            this.SuspendLayout();
            // 
            // lCodBar
            // 
            this.lCodBar.AutoSize = true;
            this.lCodBar.Location = new System.Drawing.Point(12, 15);
            this.lCodBar.Name = "lCodBar";
            this.lCodBar.Size = new System.Drawing.Size(134, 20);
            this.lCodBar.TabIndex = 0;
            this.lCodBar.Text = "Código de barras:";
            // 
            // tbCodBar
            // 
            this.tbCodBar.Location = new System.Drawing.Point(152, 12);
            this.tbCodBar.Name = "tbCodBar";
            this.tbCodBar.Size = new System.Drawing.Size(250, 26);
            this.tbCodBar.TabIndex = 0;
            // 
            // tbNom
            // 
            this.tbNom.Location = new System.Drawing.Point(152, 44);
            this.tbNom.Multiline = true;
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(250, 52);
            this.tbNom.TabIndex = 1;
            // 
            // lNom
            // 
            this.lNom.AutoSize = true;
            this.lNom.Location = new System.Drawing.Point(77, 47);
            this.lNom.Name = "lNom";
            this.lNom.Size = new System.Drawing.Size(69, 20);
            this.lNom.TabIndex = 3;
            this.lNom.Text = "Nombre:";
            // 
            // bCon
            // 
            this.bCon.BackColor = System.Drawing.Color.White;
            this.bCon.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bCon.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.bCon.FlatAppearance.BorderSize = 5;
            this.bCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.bCon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.bCon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bCon.Location = new System.Drawing.Point(152, 112);
            this.bCon.Name = "bCon";
            this.bCon.Size = new System.Drawing.Size(110, 46);
            this.bCon.TabIndex = 2;
            this.bCon.Text = "Continuar";
            this.bCon.UseVisualStyleBackColor = false;
            // 
            // AltaRapida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 173);
            this.Controls.Add(this.bCon);
            this.Controls.Add(this.lNom);
            this.Controls.Add(this.tbNom);
            this.Controls.Add(this.tbCodBar);
            this.Controls.Add(this.lCodBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AltaRapida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta rápida";
            this.Load += new System.EventHandler(this.AltaRapida_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lCodBar;
        public System.Windows.Forms.TextBox tbCodBar;
        public System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.Label lNom;
        private RoundedButton bCon;
        //No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, comerciales, o cualquier otro fin, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
    }
}