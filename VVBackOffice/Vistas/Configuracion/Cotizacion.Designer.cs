namespace ValleVerde.Vistas.Configuracion
{
    partial class Cotizacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cotizacion));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toggleSinLimite = new ValleVerde.Toggle();
            this.label2 = new System.Windows.Forms.Label();
            this.toggleDuracion = new ValleVerde.Toggle();
            this.agregarDuracion = new ValleVerde.RoundedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.Horas = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toggleRespetar = new ValleVerde.Toggle();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Horas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.toggleSinLimite);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.toggleDuracion);
            this.groupBox1.Controls.Add(this.agregarDuracion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Horas);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(75, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 249);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Duración de cotización en horas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(79, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(268, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "*0 (cero)  es sin limite de horas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(237, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 29);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sin Limite";
            // 
            // toggleSinLimite
            // 
            this.toggleSinLimite.BorderColor = System.Drawing.Color.LightGray;
            this.toggleSinLimite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleSinLimite.ForeColor = System.Drawing.Color.White;
            this.toggleSinLimite.IsOn = false;
            this.toggleSinLimite.Location = new System.Drawing.Point(362, 174);
            this.toggleSinLimite.Name = "toggleSinLimite";
            this.toggleSinLimite.OffColor = System.Drawing.Color.Red;
            this.toggleSinLimite.OffText = "OFF";
            this.toggleSinLimite.OnColor = System.Drawing.Color.LightGreen;
            this.toggleSinLimite.OnText = "ON";
            this.toggleSinLimite.Size = new System.Drawing.Size(60, 35);
            this.toggleSinLimite.TabIndex = 5;
            this.toggleSinLimite.Text = "toggleSinLimite";
            this.toggleSinLimite.TextEnabled = true;
            this.toggleSinLimite.Click += new System.EventHandler(this.toggleSinLimite_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(266, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "Modificar";
            // 
            // toggleDuracion
            // 
            this.toggleDuracion.BorderColor = System.Drawing.Color.LightGray;
            this.toggleDuracion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleDuracion.ForeColor = System.Drawing.Color.White;
            this.toggleDuracion.IsOn = false;
            this.toggleDuracion.Location = new System.Drawing.Point(370, 39);
            this.toggleDuracion.Name = "toggleDuracion";
            this.toggleDuracion.OffColor = System.Drawing.Color.Red;
            this.toggleDuracion.OffText = "OFF";
            this.toggleDuracion.OnColor = System.Drawing.Color.LightGreen;
            this.toggleDuracion.OnText = "ON";
            this.toggleDuracion.Size = new System.Drawing.Size(52, 28);
            this.toggleDuracion.TabIndex = 3;
            this.toggleDuracion.Text = "toggleDuracion";
            this.toggleDuracion.TextEnabled = true;
            this.toggleDuracion.Click += new System.EventHandler(this.toggleDuracion_Click);
            // 
            // agregarDuracion
            // 
            this.agregarDuracion.BackColor = System.Drawing.Color.White;
            this.agregarDuracion.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.agregarDuracion.FlatAppearance.BorderSize = 5;
            this.agregarDuracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregarDuracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.agregarDuracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.agregarDuracion.Image = global::ValleVerde.Properties.Resources.correcto;
            this.agregarDuracion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.agregarDuracion.Location = new System.Drawing.Point(63, 174);
            this.agregarDuracion.Name = "agregarDuracion";
            this.agregarDuracion.Size = new System.Drawing.Size(112, 38);
            this.agregarDuracion.TabIndex = 2;
            this.agregarDuracion.Text = "Agregar";
            this.agregarDuracion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.agregarDuracion.UseVisualStyleBackColor = false;
            this.agregarDuracion.Click += new System.EventHandler(this.agregarDuracion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Horas:";
            // 
            // Horas
            // 
            this.Horas.Location = new System.Drawing.Point(139, 80);
            this.Horas.Name = "Horas";
            this.Horas.Size = new System.Drawing.Size(188, 38);
            this.Horas.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.toggleRespetar);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(75, 313);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 118);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Respetar precios de cotización";
            // 
            // toggleRespetar
            // 
            this.toggleRespetar.BorderColor = System.Drawing.Color.LightGray;
            this.toggleRespetar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleRespetar.ForeColor = System.Drawing.Color.White;
            this.toggleRespetar.IsOn = false;
            this.toggleRespetar.Location = new System.Drawing.Point(176, 51);
            this.toggleRespetar.Name = "toggleRespetar";
            this.toggleRespetar.OffColor = System.Drawing.Color.Red;
            this.toggleRespetar.OffText = "OFF";
            this.toggleRespetar.OnColor = System.Drawing.Color.LightGreen;
            this.toggleRespetar.OnText = "ON";
            this.toggleRespetar.Size = new System.Drawing.Size(80, 42);
            this.toggleRespetar.TabIndex = 0;
            this.toggleRespetar.Text = "toggle2";
            this.toggleRespetar.TextEnabled = true;
            this.toggleRespetar.Click += new System.EventHandler(this.toggleRespetar_Click);
            // 
            // Cotizacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(592, 473);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Cotizacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cotización";
            this.Load += new System.EventHandler(this.Cotizacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Horas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private RoundedButton agregarDuracion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Horas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private Toggle toggleDuracion;
        private Toggle toggleRespetar;
        private System.Windows.Forms.Label label3;
        private Toggle toggleSinLimite;
        private System.Windows.Forms.Label label4;
    }
}