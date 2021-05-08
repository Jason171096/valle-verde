namespace ValleVerde.Vistas.Compras
{
    partial class VerificarProductoRapido
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
            this.lUniPorCaj = new System.Windows.Forms.Label();
            this.tbUniPorCaj = new System.Windows.Forms.TextBox();
            this.labCan = new System.Windows.Forms.Label();
            this.tbCan = new System.Windows.Forms.TextBox();
            this.labDes = new System.Windows.Forms.Label();
            this.butCon = new ValleVerde.RoundedButton();
            this.SuspendLayout();
            // 
            // lUniPorCaj
            // 
            this.lUniPorCaj.AutoSize = true;
            this.lUniPorCaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lUniPorCaj.Location = new System.Drawing.Point(12, 47);
            this.lUniPorCaj.Name = "lUniPorCaj";
            this.lUniPorCaj.Size = new System.Drawing.Size(141, 20);
            this.lUniPorCaj.TabIndex = 138;
            this.lUniPorCaj.Text = "Unidades por caja:";
            this.lUniPorCaj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbUniPorCaj
            // 
            this.tbUniPorCaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbUniPorCaj.Location = new System.Drawing.Point(159, 44);
            this.tbUniPorCaj.Name = "tbUniPorCaj";
            this.tbUniPorCaj.Size = new System.Drawing.Size(313, 26);
            this.tbUniPorCaj.TabIndex = 1;
            // 
            // labCan
            // 
            this.labCan.AutoSize = true;
            this.labCan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labCan.Location = new System.Drawing.Point(13, 15);
            this.labCan.Name = "labCan";
            this.labCan.Size = new System.Drawing.Size(140, 20);
            this.labCan.TabIndex = 137;
            this.labCan.Text = "Cantidad de cajas:";
            this.labCan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbCan
            // 
            this.tbCan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbCan.Location = new System.Drawing.Point(159, 12);
            this.tbCan.Name = "tbCan";
            this.tbCan.Size = new System.Drawing.Size(313, 26);
            this.tbCan.TabIndex = 0;
            // 
            // labDes
            // 
            this.labDes.AutoSize = true;
            this.labDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labDes.Location = new System.Drawing.Point(12, 79);
            this.labDes.Name = "labDes";
            this.labDes.Size = new System.Drawing.Size(92, 20);
            this.labDes.TabIndex = 139;
            this.labDes.Text = "Descripción";
            this.labDes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.butCon.Location = new System.Drawing.Point(170, 105);
            this.butCon.Name = "butCon";
            this.butCon.Size = new System.Drawing.Size(148, 46);
            this.butCon.TabIndex = 2;
            this.butCon.Text = "Continuar";
            this.butCon.UseVisualStyleBackColor = false;
            this.butCon.Click += new System.EventHandler(this.butCon_Click);
            // 
            // VerificarProductoRapido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 163);
            this.Controls.Add(this.butCon);
            this.Controls.Add(this.labDes);
            this.Controls.Add(this.lUniPorCaj);
            this.Controls.Add(this.tbUniPorCaj);
            this.Controls.Add(this.labCan);
            this.Controls.Add(this.tbCan);
            this.Name = "VerificarProductoRapido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verificar producto rapido";
            this.Load += new System.EventHandler(this.VerificarProductoRapido_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lUniPorCaj;
        public System.Windows.Forms.TextBox tbUniPorCaj;
        private System.Windows.Forms.Label labCan;
        public System.Windows.Forms.TextBox tbCan;
        private System.Windows.Forms.Label labDes;
        private RoundedButton butCon;
    }
}