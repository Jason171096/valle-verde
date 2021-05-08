namespace ValleVerde.Vistas.Compras
{
    partial class AjustarCostos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AjustarCostos));
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.colRoj = new System.Windows.Forms.PictureBox();
            this.colVer = new System.Windows.Forms.PictureBox();
            this.chVerPdfDiv = new System.Windows.Forms.CheckBox();
            this.con = new ValleVerde.RoundedButton();
            this.CodigoBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDClaveAdicional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NuevoCosto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NuevoPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CostoMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDProductoPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colRoj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colVer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Los siguientes productos necesitan que usted ajuste los costos.";
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoBarras,
            this.IDClaveAdicional,
            this.Descripcion,
            this.CostoActual,
            this.PrecioActual,
            this.NuevoCosto,
            this.NuevoPrecio,
            this.CostoMinimo,
            this.IDProductoPedido});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Location = new System.Drawing.Point(16, 45);
            this.dgv.Name = "dgv";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.Size = new System.Drawing.Size(772, 341);
            this.dgv.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(42, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 148;
            this.label4.Text = "Más caro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(42, 392);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 147;
            this.label2.Text = "Más barato";
            // 
            // colRoj
            // 
            this.colRoj.BackColor = System.Drawing.Color.DarkRed;
            this.colRoj.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colRoj.Location = new System.Drawing.Point(16, 418);
            this.colRoj.Name = "colRoj";
            this.colRoj.Size = new System.Drawing.Size(20, 20);
            this.colRoj.TabIndex = 150;
            this.colRoj.TabStop = false;
            // 
            // colVer
            // 
            this.colVer.BackColor = System.Drawing.Color.ForestGreen;
            this.colVer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.colVer.Location = new System.Drawing.Point(16, 392);
            this.colVer.Name = "colVer";
            this.colVer.Size = new System.Drawing.Size(20, 20);
            this.colVer.TabIndex = 149;
            this.colVer.TabStop = false;
            // 
            // chVerPdfDiv
            // 
            this.chVerPdfDiv.AutoSize = true;
            this.chVerPdfDiv.Checked = true;
            this.chVerPdfDiv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chVerPdfDiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.chVerPdfDiv.Location = new System.Drawing.Point(438, 404);
            this.chVerPdfDiv.Name = "chVerPdfDiv";
            this.chVerPdfDiv.Size = new System.Drawing.Size(234, 24);
            this.chVerPdfDiv.TabIndex = 151;
            this.chVerPdfDiv.Text = "Ver PDF dividido por facturas";
            this.chVerPdfDiv.UseVisualStyleBackColor = true;
            // 
            // con
            // 
            this.con.BackColor = System.Drawing.Color.White;
            this.con.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.con.FlatAppearance.BorderSize = 5;
            this.con.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.con.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.con.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.con.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.con.Location = new System.Drawing.Point(678, 392);
            this.con.Name = "con";
            this.con.Size = new System.Drawing.Size(110, 46);
            this.con.TabIndex = 133;
            this.con.Text = "Continuar";
            this.con.UseVisualStyleBackColor = false;
            this.con.Click += new System.EventHandler(this.con_Click);
            // 
            // CodigoBarras
            // 
            this.CodigoBarras.HeaderText = "Código de barras";
            this.CodigoBarras.Name = "CodigoBarras";
            this.CodigoBarras.ReadOnly = true;
            // 
            // IDClaveAdicional
            // 
            this.IDClaveAdicional.HeaderText = "ID de clave adicional";
            this.IDClaveAdicional.Name = "IDClaveAdicional";
            this.IDClaveAdicional.Visible = false;
            // 
            // Descripcion
            // 
            this.Descripcion.HeaderText = "Descripción";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            // 
            // CostoActual
            // 
            this.CostoActual.HeaderText = "Costo actual";
            this.CostoActual.Name = "CostoActual";
            this.CostoActual.ReadOnly = true;
            // 
            // PrecioActual
            // 
            this.PrecioActual.HeaderText = "Precio actual";
            this.PrecioActual.Name = "PrecioActual";
            this.PrecioActual.ReadOnly = true;
            // 
            // NuevoCosto
            // 
            this.NuevoCosto.HeaderText = "Nuevo costo";
            this.NuevoCosto.Name = "NuevoCosto";
            // 
            // NuevoPrecio
            // 
            this.NuevoPrecio.HeaderText = "Nuevo precio";
            this.NuevoPrecio.Name = "NuevoPrecio";
            this.NuevoPrecio.ReadOnly = true;
            // 
            // CostoMinimo
            // 
            this.CostoMinimo.HeaderText = "Costo mínimo";
            this.CostoMinimo.Name = "CostoMinimo";
            this.CostoMinimo.ReadOnly = true;
            this.CostoMinimo.Visible = false;
            // 
            // IDProductoPedido
            // 
            this.IDProductoPedido.HeaderText = "IDProductoPedido";
            this.IDProductoPedido.Name = "IDProductoPedido";
            this.IDProductoPedido.Visible = false;
            // 
            // AjustarCostos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chVerPdfDiv);
            this.Controls.Add(this.colRoj);
            this.Controls.Add(this.colVer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.con);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AjustarCostos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajustar costos";
            this.Load += new System.EventHandler(this.AjustarCostos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colRoj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colVer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv;
        private RoundedButton con;
        private System.Windows.Forms.PictureBox colRoj;
        private System.Windows.Forms.PictureBox colVer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chVerPdfDiv;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDClaveAdicional;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn NuevoCosto;
        private System.Windows.Forms.DataGridViewTextBoxColumn NuevoPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CostoMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProductoPedido;
        //No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, comerciales, o cualquier otro fin, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
    }
}

