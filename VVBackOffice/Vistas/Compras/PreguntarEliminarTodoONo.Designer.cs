namespace ValleVerde.Vistas.Compras
{
    partial class PreguntarEliminarTodoONo
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
            this.sum = new ValleVerde.RoundedButton();
            this.rem = new ValleVerde.RoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sum
            // 
            this.sum.BackColor = System.Drawing.Color.White;
            this.sum.DialogResult = System.Windows.Forms.DialogResult.No;
            this.sum.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.sum.FlatAppearance.BorderSize = 5;
            this.sum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.sum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.sum.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sum.Location = new System.Drawing.Point(13, 44);
            this.sum.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sum.Name = "sum";
            this.sum.Size = new System.Drawing.Size(189, 44);
            this.sum.TabIndex = 133;
            this.sum.Text = "De todos los proveedores";
            this.sum.UseVisualStyleBackColor = false;
            // 
            // rem
            // 
            this.rem.BackColor = System.Drawing.Color.White;
            this.rem.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.rem.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.rem.FlatAppearance.BorderSize = 5;
            this.rem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.rem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.rem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.rem.Location = new System.Drawing.Point(210, 44);
            this.rem.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rem.Name = "rem";
            this.rem.Size = new System.Drawing.Size(143, 44);
            this.rem.TabIndex = 132;
            this.rem.Text = "De este proveedor";
            this.rem.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(341, 30);
            this.label1.TabIndex = 134;
            this.label1.Text = "¿De donde desea borrar este producto?";
            // 
            // PreguntarEliminarTodoONo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 101);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sum);
            this.Controls.Add(this.rem);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PreguntarEliminarTodoONo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "¿Eliminar todos o no?";
            this.ResumeLayout(false);

        }

        #endregion
        private RoundedButton sum;
        private RoundedButton rem;
        private System.Windows.Forms.Label label1;
        //No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, comerciales, o cualquier otro fin, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
    }
}