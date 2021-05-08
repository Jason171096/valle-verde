namespace ValleVerde.Vistas.Compras
{
    partial class PreguntaCodigoNoExiste
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
            this.bNo = new ValleVerde.RoundedButton();
            this.bSi = new ValleVerde.RoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bNo
            // 
            this.bNo.BackColor = System.Drawing.Color.White;
            this.bNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.bNo.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.bNo.FlatAppearance.BorderSize = 5;
            this.bNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.bNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.bNo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bNo.Location = new System.Drawing.Point(12, 84);
            this.bNo.Name = "bNo";
            this.bNo.Size = new System.Drawing.Size(100, 46);
            this.bNo.TabIndex = 1;
            this.bNo.Text = "No";
            this.bNo.UseVisualStyleBackColor = false;
            // 
            // bSi
            // 
            this.bSi.BackColor = System.Drawing.Color.White;
            this.bSi.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.bSi.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.bSi.FlatAppearance.BorderSize = 5;
            this.bSi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.bSi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.bSi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSi.Location = new System.Drawing.Point(213, 84);
            this.bSi.Name = "bSi";
            this.bSi.Size = new System.Drawing.Size(100, 46);
            this.bSi.TabIndex = 0;
            this.bSi.Text = "Si";
            this.bSi.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 66);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // PreguntaCodigoNoExiste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bNo;
            this.ClientSize = new System.Drawing.Size(327, 142);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bNo);
            this.Controls.Add(this.bSi);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PreguntaCodigoNoExiste";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Este código de barras no existe";
            this.Load += new System.EventHandler(this.PreguntaCodigoNoExiste_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private RoundedButton bSi;
        private RoundedButton bNo;
        private System.Windows.Forms.Label label1;
        //No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, comerciales, o cualquier otro fin, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
    }
}