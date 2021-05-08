namespace ValleVerde.Vistas.Compras
{
    partial class PreguntaGenerarCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreguntaGenerarCompra));
            this.label1 = new System.Windows.Forms.Label();
            this.si = new ValleVerde.RoundedButton();
            this.no = new ValleVerde.RoundedButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Está seguro de que ha recibido la mercancía correctamente?";
            // 
            // si
            // 
            this.si.BackColor = System.Drawing.Color.White;
            this.si.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.si.FlatAppearance.BorderSize = 5;
            this.si.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.si.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.si.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.si.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.si.Location = new System.Drawing.Point(173, 32);
            this.si.Name = "si";
            this.si.Size = new System.Drawing.Size(44, 46);
            this.si.TabIndex = 168;
            this.si.Text = "Si";
            this.si.UseVisualStyleBackColor = false;
            this.si.Click += new System.EventHandler(this.si_Click);
            // 
            // no
            // 
            this.no.BackColor = System.Drawing.Color.White;
            this.no.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.no.FlatAppearance.BorderSize = 5;
            this.no.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.no.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.no.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.no.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.no.Location = new System.Drawing.Point(285, 32);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(44, 46);
            this.no.TabIndex = 169;
            this.no.Text = "No";
            this.no.UseVisualStyleBackColor = false;
            this.no.Click += new System.EventHandler(this.no_Click);
            // 
            // PreguntaGenerarCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 97);
            this.Controls.Add(this.no);
            this.Controls.Add(this.si);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PreguntaGenerarCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pregunta";
            this.Load += new System.EventHandler(this.PreguntaGenerarCompra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private RoundedButton si;
        private RoundedButton no;
        //No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, comerciales, o cualquier otro fin, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
    }
}