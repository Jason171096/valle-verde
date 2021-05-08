namespace ValleVerde.Vistas.Compras
{
    partial class DevolverArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DevolverArticulo));
            this.lCan = new System.Windows.Forms.Label();
            this.tbCan = new System.Windows.Forms.TextBox();
            this.devProd = new ValleVerde.RoundedButton();
            this.SuspendLayout();
            // 
            // lCan
            // 
            this.lCan.AutoSize = true;
            this.lCan.Location = new System.Drawing.Point(12, 15);
            this.lCan.Name = "lCan";
            this.lCan.Size = new System.Drawing.Size(77, 20);
            this.lCan.TabIndex = 0;
            this.lCan.Text = "Cantidad:";
            // 
            // tbCan
            // 
            this.tbCan.Location = new System.Drawing.Point(95, 12);
            this.tbCan.Name = "tbCan";
            this.tbCan.Size = new System.Drawing.Size(100, 26);
            this.tbCan.TabIndex = 0;
            // 
            // devProd
            // 
            this.devProd.BackColor = System.Drawing.Color.White;
            this.devProd.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.devProd.FlatAppearance.BorderSize = 5;
            this.devProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.devProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.devProd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.devProd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.devProd.Location = new System.Drawing.Point(27, 44);
            this.devProd.Name = "devProd";
            this.devProd.Size = new System.Drawing.Size(148, 46);
            this.devProd.TabIndex = 1;
            this.devProd.Text = "Devolver";
            this.devProd.UseVisualStyleBackColor = false;
            this.devProd.Click += new System.EventHandler(this.devProd_Click);
            // 
            // DevolverArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 97);
            this.Controls.Add(this.devProd);
            this.Controls.Add(this.tbCan);
            this.Controls.Add(this.lCan);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "DevolverArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DevolverArticulo";
            this.Load += new System.EventHandler(this.DevolverArticulo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lCan;
        private System.Windows.Forms.TextBox tbCan;
        private RoundedButton devProd;
        //No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, comerciales, o cualquier otro fin, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
    }
}