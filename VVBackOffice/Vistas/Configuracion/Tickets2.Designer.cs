namespace ValleVerde.Vistas.Configuracion
{
    partial class Tickets2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tickets2));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toggleVentas = new ValleVerde.Toggle();
            this.ventas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.toggleDevolucion = new ValleVerde.Toggle();
            this.devolucion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.agregarMaxPend = new ValleVerde.RoundedButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.togglePendientes = new ValleVerde.Toggle();
            this.label3 = new System.Windows.Forms.Label();
            this.TicketsPendientes = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TicketsPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.toggleVentas);
            this.groupBox1.Controls.Add(this.ventas);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(62, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 186);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selección de Tickets de Ventas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(342, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Modificar";
            // 
            // toggleVentas
            // 
            this.toggleVentas.BorderColor = System.Drawing.Color.LightGray;
            this.toggleVentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleVentas.ForeColor = System.Drawing.Color.White;
            this.toggleVentas.IsOn = false;
            this.toggleVentas.Location = new System.Drawing.Point(448, 37);
            this.toggleVentas.Name = "toggleVentas";
            this.toggleVentas.OffColor = System.Drawing.Color.DarkGray;
            this.toggleVentas.OffText = "OFF";
            this.toggleVentas.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.toggleVentas.OnText = "ON";
            this.toggleVentas.Size = new System.Drawing.Size(48, 26);
            this.toggleVentas.TabIndex = 2;
            this.toggleVentas.TextEnabled = true;
            this.toggleVentas.Click += new System.EventHandler(this.toggle1_Click);
            // 
            // ventas
            // 
            this.ventas.CausesValidation = false;
            this.ventas.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ventas.FormattingEnabled = true;
            this.ventas.Location = new System.Drawing.Point(184, 108);
            this.ventas.Name = "ventas";
            this.ventas.Size = new System.Drawing.Size(294, 41);
            this.ventas.TabIndex = 1;
            this.ventas.SelectedIndexChanged += new System.EventHandler(this.ventas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ticket:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.toggleDevolucion);
            this.groupBox2.Controls.Add(this.devolucion);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(62, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(512, 150);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selección de Tickets de Devolución";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(342, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 26);
            this.label5.TabIndex = 5;
            this.label5.Text = "Modificar";
            // 
            // toggleDevolucion
            // 
            this.toggleDevolucion.BorderColor = System.Drawing.Color.LightGray;
            this.toggleDevolucion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleDevolucion.ForeColor = System.Drawing.Color.White;
            this.toggleDevolucion.IsOn = false;
            this.toggleDevolucion.Location = new System.Drawing.Point(448, 37);
            this.toggleDevolucion.Name = "toggleDevolucion";
            this.toggleDevolucion.OffColor = System.Drawing.Color.DarkGray;
            this.toggleDevolucion.OffText = "OFF";
            this.toggleDevolucion.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.toggleDevolucion.OnText = "ON";
            this.toggleDevolucion.Size = new System.Drawing.Size(48, 26);
            this.toggleDevolucion.TabIndex = 4;
            this.toggleDevolucion.Text = "toggle2";
            this.toggleDevolucion.TextEnabled = true;
            this.toggleDevolucion.Click += new System.EventHandler(this.toggleDevolucion_Click);
            // 
            // devolucion
            // 
            this.devolucion.CausesValidation = false;
            this.devolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devolucion.FormattingEnabled = true;
            this.devolucion.Location = new System.Drawing.Point(184, 82);
            this.devolucion.Name = "devolucion";
            this.devolucion.Size = new System.Drawing.Size(294, 41);
            this.devolucion.TabIndex = 3;
            this.devolucion.SelectedIndexChanged += new System.EventHandler(this.devolucion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ticket:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.agregarMaxPend);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.togglePendientes);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.TicketsPendientes);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(62, 421);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(512, 219);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Maximo de Tickets pendientes por caja";
            // 
            // agregarMaxPend
            // 
            this.agregarMaxPend.BackColor = System.Drawing.Color.White;
            this.agregarMaxPend.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.agregarMaxPend.FlatAppearance.BorderSize = 5;
            this.agregarMaxPend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.agregarMaxPend.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.agregarMaxPend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.agregarMaxPend.Image = global::ValleVerde.Properties.Resources.correcto;
            this.agregarMaxPend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.agregarMaxPend.Location = new System.Drawing.Point(204, 160);
            this.agregarMaxPend.Name = "agregarMaxPend";
            this.agregarMaxPend.Size = new System.Drawing.Size(139, 42);
            this.agregarMaxPend.TabIndex = 9;
            this.agregarMaxPend.Text = "Agregar";
            this.agregarMaxPend.UseVisualStyleBackColor = false;
            this.agregarMaxPend.Click += new System.EventHandler(this.agregarMaxPend_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(64, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(432, 26);
            this.label7.TabIndex = 8;
            this.label7.Text = "*0 (cero) es sin limite de Tickets pendientes";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(342, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 26);
            this.label6.TabIndex = 7;
            this.label6.Text = "Modificar";
            // 
            // togglePendientes
            // 
            this.togglePendientes.BorderColor = System.Drawing.Color.LightGray;
            this.togglePendientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.togglePendientes.ForeColor = System.Drawing.Color.White;
            this.togglePendientes.IsOn = false;
            this.togglePendientes.Location = new System.Drawing.Point(448, 33);
            this.togglePendientes.Name = "togglePendientes";
            this.togglePendientes.OffColor = System.Drawing.Color.DarkGray;
            this.togglePendientes.OffText = "OFF";
            this.togglePendientes.OnColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.togglePendientes.OnText = "ON";
            this.togglePendientes.Size = new System.Drawing.Size(48, 26);
            this.togglePendientes.TabIndex = 6;
            this.togglePendientes.Text = "toggle3";
            this.togglePendientes.TextEnabled = true;
            this.togglePendientes.Click += new System.EventHandler(this.togglePendientes_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 31);
            this.label3.TabIndex = 1;
            this.label3.Text = "Número:";
            // 
            // TicketsPendientes
            // 
            this.TicketsPendientes.Location = new System.Drawing.Point(184, 62);
            this.TicketsPendientes.Name = "TicketsPendientes";
            this.TicketsPendientes.Size = new System.Drawing.Size(193, 38);
            this.TicketsPendientes.TabIndex = 0;
            // 
            // Tickets2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 664);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Tickets2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selección de Tickets";
            this.Load += new System.EventHandler(this.Tickets2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TicketsPendientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox ventas;
        private System.Windows.Forms.Label label1;
        private Toggle toggleVentas;
        private System.Windows.Forms.GroupBox groupBox2;
        private Toggle toggleDevolucion;
        private System.Windows.Forms.ComboBox devolucion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown TicketsPendientes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Toggle togglePendientes;
        private System.Windows.Forms.Label label7;
        private RoundedButton agregarMaxPend;
    }
}