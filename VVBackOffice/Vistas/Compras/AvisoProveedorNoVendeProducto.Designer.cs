namespace ValleVerde.Vistas.Compras
{
    partial class AvisoProveedorNoVendeProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvisoProveedorNoVendeProducto));
            this.no = new ValleVerde.RoundedButton();
            this.si = new ValleVerde.RoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // no
            // 
            this.no.BackColor = System.Drawing.Color.White;
            this.no.DialogResult = System.Windows.Forms.DialogResult.No;
            this.no.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.no.FlatAppearance.BorderSize = 5;
            this.no.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.no.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.no.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.no.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.no.Location = new System.Drawing.Point(142, 83);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(44, 46);
            this.no.TabIndex = 172;
            this.no.Text = "No";
            this.no.UseVisualStyleBackColor = false;
            this.no.Click += new System.EventHandler(this.no_Click);
            // 
            // si
            // 
            this.si.BackColor = System.Drawing.Color.White;
            this.si.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.si.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.si.FlatAppearance.BorderSize = 5;
            this.si.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.si.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.si.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.si.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.si.Location = new System.Drawing.Point(254, 83);
            this.si.Name = "si";
            this.si.Size = new System.Drawing.Size(44, 46);
            this.si.TabIndex = 171;
            this.si.Text = "Si";
            this.si.UseVisualStyleBackColor = false;
            this.si.Click += new System.EventHandler(this.si_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 65);
            this.label1.TabIndex = 173;
            this.label1.Text = "label1";
            // 
            // AvisoProveedorNoVendeProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.no;
            this.ClientSize = new System.Drawing.Size(449, 146);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.no);
            this.Controls.Add(this.si);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AvisoProveedorNoVendeProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aviso";
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedButton no;
        private RoundedButton si;
        private System.Windows.Forms.Label label1;
        //No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, comerciales, o cualquier otro fin, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
    }
}