namespace ValleVerde.Vistas.Compras
{
    partial class RecibirMercanciaPreguntar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecibirMercanciaPreguntar));
            this.noPed = new ValleVerde.RoundedButton();
            this.ped = new ValleVerde.RoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // noPed
            // 
            this.noPed.BackColor = System.Drawing.Color.White;
            this.noPed.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.noPed.FlatAppearance.BorderSize = 5;
            this.noPed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noPed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.noPed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.noPed.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.noPed.Location = new System.Drawing.Point(12, 45);
            this.noPed.Name = "noPed";
            this.noPed.Size = new System.Drawing.Size(168, 46);
            this.noPed.TabIndex = 0;
            this.noPed.Text = "Productos no pedidos";
            this.noPed.UseVisualStyleBackColor = false;
            this.noPed.Click += new System.EventHandler(this.noPed_Click);
            // 
            // ped
            // 
            this.ped.BackColor = System.Drawing.Color.White;
            this.ped.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.ped.FlatAppearance.BorderSize = 5;
            this.ped.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ped.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.ped.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.ped.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ped.Location = new System.Drawing.Point(196, 45);
            this.ped.Name = "ped";
            this.ped.Size = new System.Drawing.Size(148, 46);
            this.ped.TabIndex = 1;
            this.ped.Text = "Pedidos";
            this.ped.UseVisualStyleBackColor = false;
            this.ped.Click += new System.EventHandler(this.ped_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 20);
            this.label1.TabIndex = 130;
            this.label1.Text = "¿Qué desea recibir?";
            // 
            // RecibirMercanciaPreguntar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 113);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ped);
            this.Controls.Add(this.noPed);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RecibirMercanciaPreguntar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pregunta";
            this.Load += new System.EventHandler(this.RecibirMercanciaPreguntar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
            //No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, comerciales, o cualquier otro fin, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
        }

        #endregion

        private RoundedButton noPed;
        private RoundedButton ped;
        private System.Windows.Forms.Label label1;
    }
}