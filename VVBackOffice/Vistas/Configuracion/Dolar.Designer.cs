namespace ValleVerde.Vistas.Configuracion
{
    partial class Dolar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dolar));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dolarBaseTienda = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.toggle1 = new ValleVerde.Toggle();
            this.actualizar = new ValleVerde.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.dolarBaseTienda)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dolar Hoy: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dolar en la tienda:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(234, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 29);
            this.label4.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(320, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 31);
            this.label5.TabIndex = 8;
            // 
            // dolarBaseTienda
            // 
            this.dolarBaseTienda.DecimalPlaces = 2;
            this.dolarBaseTienda.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dolarBaseTienda.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.dolarBaseTienda.Location = new System.Drawing.Point(283, 154);
            this.dolarBaseTienda.Name = "dolarBaseTienda";
            this.dolarBaseTienda.Size = new System.Drawing.Size(159, 32);
            this.dolarBaseTienda.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(503, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 26);
            this.label3.TabIndex = 11;
            this.label3.Text = "Modificar";
            // 
            // toggle1
            // 
            this.toggle1.BorderColor = System.Drawing.Color.LightGray;
            this.toggle1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggle1.ForeColor = System.Drawing.Color.White;
            this.toggle1.IsOn = false;
            this.toggle1.Location = new System.Drawing.Point(523, 159);
            this.toggle1.Name = "toggle1";
            this.toggle1.OffColor = System.Drawing.Color.DarkGray;
            this.toggle1.OffText = "OFF";
            this.toggle1.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.toggle1.OnText = "ON";
            this.toggle1.Size = new System.Drawing.Size(60, 35);
            this.toggle1.TabIndex = 10;
            this.toggle1.Text = "toggle1";
            this.toggle1.TextEnabled = true;
            this.toggle1.Click += new System.EventHandler(this.toggle1_Click);
            // 
            // actualizar
            // 
            this.actualizar.BackColor = System.Drawing.Color.White;
            this.actualizar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.actualizar.FlatAppearance.BorderSize = 5;
            this.actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.actualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.actualizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.actualizar.Image = global::ValleVerde.Properties.Resources.correcto;
            this.actualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.actualizar.Location = new System.Drawing.Point(266, 226);
            this.actualizar.Name = "actualizar";
            this.actualizar.Size = new System.Drawing.Size(136, 52);
            this.actualizar.TabIndex = 4;
            this.actualizar.Text = "Actualizar";
            this.actualizar.UseVisualStyleBackColor = false;
            this.actualizar.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // Dolar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 379);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toggle1);
            this.Controls.Add(this.dolarBaseTienda);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.actualizar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Dolar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajuste del Dolar";
            this.Load += new System.EventHandler(this.Dolar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dolarBaseTienda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private RoundedButton actualizar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown dolarBaseTienda;
        private Toggle toggle1;
        private System.Windows.Forms.Label label3;
    }
}