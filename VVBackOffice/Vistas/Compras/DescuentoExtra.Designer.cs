namespace ValleVerde.Vistas.Compras
{
    partial class DescuentoExtra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DescuentoExtra));
            this.tlp = new System.Windows.Forms.TableLayoutPanel();
            this.agr = new ValleVerde.RoundedButton();
            this.SuspendLayout();
            // 
            // tlp
            // 
            this.tlp.ColumnCount = 6;
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tlp.Location = new System.Drawing.Point(13, 13);
            this.tlp.Name = "tlp";
            this.tlp.RowCount = 1;
            this.tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp.Size = new System.Drawing.Size(1325, 10);
            this.tlp.TabIndex = 166;
            // 
            // agr
            // 
            this.agr.BackColor = System.Drawing.Color.White;
            this.agr.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.agr.FlatAppearance.BorderSize = 5;
            this.agr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.agr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.agr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.agr.Location = new System.Drawing.Point(609, 19);
            this.agr.Name = "agr";
            this.agr.Size = new System.Drawing.Size(148, 46);
            this.agr.TabIndex = 164;
            this.agr.Text = "+ Agregar";
            this.agr.UseVisualStyleBackColor = false;
            this.agr.Click += new System.EventHandler(this.agr_Click);
            // 
            // DescuentoExtra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1350, 77);
            this.Controls.Add(this.tlp);
            this.Controls.Add(this.agr);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DescuentoExtra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Descuentos extra";
            this.Load += new System.EventHandler(this.DescuentoExtra_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private RoundedButton agr;
        private System.Windows.Forms.TableLayoutPanel tlp;
        //No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, comerciales, o cualquier otro fin, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
    }
}