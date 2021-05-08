namespace ValleVerde.Vistas.Compras
{
    partial class VerificarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerificarProducto));
            this.label1 = new System.Windows.Forms.Label();
            this.tbCan = new System.Windows.Forms.TextBox();
            this.labCan = new System.Windows.Forms.Label();
            this.lImpo = new System.Windows.Forms.Label();
            this.tbImpo = new System.Windows.Forms.TextBox();
            this.labDes = new System.Windows.Forms.Label();
            this.lUniPorCaj = new System.Windows.Forms.Label();
            this.tbUniPorCaj = new System.Windows.Forms.TextBox();
            this.butCon = new ValleVerde.RoundedButton();
            this.bSal = new ValleVerde.RoundedButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(193, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Los datos son correctos?";
            // 
            // tbCan
            // 
            this.tbCan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbCan.Location = new System.Drawing.Point(201, 38);
            this.tbCan.Name = "tbCan";
            this.tbCan.Size = new System.Drawing.Size(313, 26);
            this.tbCan.TabIndex = 0;
            // 
            // labCan
            // 
            this.labCan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labCan.Location = new System.Drawing.Point(13, 38);
            this.labCan.Name = "labCan";
            this.labCan.Size = new System.Drawing.Size(182, 20);
            this.labCan.TabIndex = 129;
            this.labCan.Text = "Cantidad:";
            this.labCan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labCan.Click += new System.EventHandler(this.labCan_Click);
            // 
            // lImpo
            // 
            this.lImpo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lImpo.Location = new System.Drawing.Point(12, 102);
            this.lImpo.Name = "lImpo";
            this.lImpo.Size = new System.Drawing.Size(183, 20);
            this.lImpo.TabIndex = 131;
            this.lImpo.Text = "Importe (Sin impuestos):";
            this.lImpo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbImpo
            // 
            this.tbImpo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbImpo.Location = new System.Drawing.Point(201, 102);
            this.tbImpo.Name = "tbImpo";
            this.tbImpo.Size = new System.Drawing.Size(313, 26);
            this.tbImpo.TabIndex = 2;
            // 
            // labDes
            // 
            this.labDes.AutoSize = true;
            this.labDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labDes.Location = new System.Drawing.Point(12, 131);
            this.labDes.Name = "labDes";
            this.labDes.Size = new System.Drawing.Size(92, 20);
            this.labDes.TabIndex = 132;
            this.labDes.Text = "Descripción";
            this.labDes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lUniPorCaj
            // 
            this.lUniPorCaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lUniPorCaj.Location = new System.Drawing.Point(12, 70);
            this.lUniPorCaj.Name = "lUniPorCaj";
            this.lUniPorCaj.Size = new System.Drawing.Size(183, 20);
            this.lUniPorCaj.TabIndex = 134;
            this.lUniPorCaj.Text = "Unidades por caja:";
            this.lUniPorCaj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbUniPorCaj
            // 
            this.tbUniPorCaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbUniPorCaj.Location = new System.Drawing.Point(201, 70);
            this.tbUniPorCaj.Name = "tbUniPorCaj";
            this.tbUniPorCaj.Size = new System.Drawing.Size(313, 26);
            this.tbUniPorCaj.TabIndex = 1;
            // 
            // butCon
            // 
            this.butCon.BackColor = System.Drawing.Color.White;
            this.butCon.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butCon.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.butCon.FlatAppearance.BorderSize = 5;
            this.butCon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butCon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.butCon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCon.Location = new System.Drawing.Point(176, 154);
            this.butCon.Name = "butCon";
            this.butCon.Size = new System.Drawing.Size(148, 46);
            this.butCon.TabIndex = 3;
            this.butCon.Text = "Continuar";
            this.butCon.UseVisualStyleBackColor = false;
            this.butCon.Click += new System.EventHandler(this.butCon_Click);
            // 
            // bSal
            // 
            this.bSal.BackColor = System.Drawing.Color.White;
            this.bSal.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bSal.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.bSal.FlatAppearance.BorderSize = 5;
            this.bSal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.bSal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.bSal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bSal.Location = new System.Drawing.Point(361, 155);
            this.bSal.Name = "bSal";
            this.bSal.Size = new System.Drawing.Size(148, 46);
            this.bSal.TabIndex = 4;
            this.bSal.Text = "Salir";
            this.bSal.UseVisualStyleBackColor = false;
            this.bSal.Visible = false;
            // 
            // VerificarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 213);
            this.Controls.Add(this.bSal);
            this.Controls.Add(this.lUniPorCaj);
            this.Controls.Add(this.tbUniPorCaj);
            this.Controls.Add(this.labDes);
            this.Controls.Add(this.lImpo);
            this.Controls.Add(this.tbImpo);
            this.Controls.Add(this.labCan);
            this.Controls.Add(this.butCon);
            this.Controls.Add(this.tbCan);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VerificarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VerificarProducto";
            this.Load += new System.EventHandler(this.VerificarProducto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbCan;
        private RoundedButton butCon;
        private System.Windows.Forms.Label labCan;
        private System.Windows.Forms.Label lImpo;
        public System.Windows.Forms.TextBox tbImpo;
        private System.Windows.Forms.Label labDes;
        private System.Windows.Forms.Label lUniPorCaj;
        public System.Windows.Forms.TextBox tbUniPorCaj;
        private RoundedButton bSal;
        //No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, comerciales, o cualquier otro fin, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
    }
}