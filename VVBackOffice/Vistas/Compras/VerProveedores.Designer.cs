using System.Windows.Forms;

namespace ValleVerde.Vistas.Compras
{
    partial class Proveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Proveedores));
            this.tablaprov = new ValleVerde.Vistas.Compras.MyDataGridView();
            this.IDProv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LimiteCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDDiasVisita = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RFC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Celular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Activo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Colonia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Poblacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrimerPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SegundoPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCredito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbestado = new System.Windows.Forms.ComboBox();
            this.cbciudad = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkciudad = new System.Windows.Forms.CheckBox();
            this.checkestado = new System.Windows.Forms.CheckBox();
            this.checktodo = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.excel = new ValleVerde.RoundedButton();
            this.pdf = new ValleVerde.RoundedButton();
            this.Agreagr = new ValleVerde.RoundedButton();
            this.Agregar = new ValleVerde.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.tablaprov)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaprov
            // 
            this.tablaprov.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaprov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaprov.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDProv,
            this.Nombre,
            this.Direccion,
            this.Ciudad,
            this.Estado,
            this.Telefono,
            this.DiasCredito,
            this.Correo,
            this.LimiteCredito,
            this.IDDiasVisita,
            this.RFC,
            this.Celular,
            this.IDUsuario,
            this.FechaUsuario,
            this.Activo,
            this.Colonia,
            this.CP,
            this.Poblacion,
            this.PrimerPago,
            this.SegundoPago,
            this.TotalCredito});
            this.tablaprov.Location = new System.Drawing.Point(12, 203);
            this.tablaprov.Name = "tablaprov";
            this.tablaprov.RowHeadersVisible = false;
            this.tablaprov.Size = new System.Drawing.Size(1124, 366);
            this.tablaprov.TabIndex = 4;
            this.tablaprov.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tablaprov_CellMouseDoubleClick);
            this.tablaprov.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaprov_CellValueChanged);
            this.tablaprov.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tablaprov_KeyPress_1);
            // 
            // IDProv
            // 
            this.IDProv.HeaderText = "IDProveedor";
            this.IDProv.Name = "IDProv";
            this.IDProv.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Direccion
            // 
            this.Direccion.HeaderText = "Direccion";
            this.Direccion.Name = "Direccion";
            // 
            // Ciudad
            // 
            this.Ciudad.HeaderText = "Ciudad";
            this.Ciudad.Name = "Ciudad";
            this.Ciudad.Visible = false;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Visible = false;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            // 
            // DiasCredito
            // 
            this.DiasCredito.HeaderText = "DiasCredito";
            this.DiasCredito.Name = "DiasCredito";
            // 
            // Correo
            // 
            this.Correo.HeaderText = "Correo";
            this.Correo.Name = "Correo";
            // 
            // LimiteCredito
            // 
            this.LimiteCredito.HeaderText = "LimiteCredito";
            this.LimiteCredito.Name = "LimiteCredito";
            this.LimiteCredito.Visible = false;
            // 
            // IDDiasVisita
            // 
            this.IDDiasVisita.HeaderText = "IDDiasVisita";
            this.IDDiasVisita.Name = "IDDiasVisita";
            this.IDDiasVisita.Visible = false;
            // 
            // RFC
            // 
            this.RFC.HeaderText = "RFC";
            this.RFC.Name = "RFC";
            this.RFC.Visible = false;
            // 
            // Celular
            // 
            this.Celular.HeaderText = "Celular";
            this.Celular.Name = "Celular";
            this.Celular.Visible = false;
            // 
            // IDUsuario
            // 
            this.IDUsuario.HeaderText = "IDUsuario";
            this.IDUsuario.Name = "IDUsuario";
            this.IDUsuario.Visible = false;
            // 
            // FechaUsuario
            // 
            this.FechaUsuario.HeaderText = "FechaUsuario";
            this.FechaUsuario.Name = "FechaUsuario";
            this.FechaUsuario.Visible = false;
            // 
            // Activo
            // 
            this.Activo.HeaderText = "Activo";
            this.Activo.Name = "Activo";
            this.Activo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Colonia
            // 
            this.Colonia.HeaderText = "Colonia";
            this.Colonia.Name = "Colonia";
            this.Colonia.Visible = false;
            // 
            // CP
            // 
            this.CP.HeaderText = "CP";
            this.CP.Name = "CP";
            this.CP.Visible = false;
            // 
            // Poblacion
            // 
            this.Poblacion.HeaderText = "Poblacion";
            this.Poblacion.Name = "Poblacion";
            this.Poblacion.Visible = false;
            // 
            // PrimerPago
            // 
            this.PrimerPago.HeaderText = "Primer Pago ";
            this.PrimerPago.Name = "PrimerPago";
            this.PrimerPago.Visible = false;
            // 
            // SegundoPago
            // 
            this.SegundoPago.HeaderText = "Segundo Pago";
            this.SegundoPago.Name = "SegundoPago";
            this.SegundoPago.Visible = false;
            // 
            // TotalCredito
            // 
            this.TotalCredito.HeaderText = "Total Credito a Pagar";
            this.TotalCredito.Name = "TotalCredito";
            this.TotalCredito.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(12, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(563, 29);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Escribe para Buscar:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbestado
            // 
            this.cbestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbestado.FormattingEnabled = true;
            this.cbestado.Location = new System.Drawing.Point(185, 141);
            this.cbestado.Name = "cbestado";
            this.cbestado.Size = new System.Drawing.Size(301, 32);
            this.cbestado.TabIndex = 7;
            this.cbestado.SelectedIndexChanged += new System.EventHandler(this.cbestado_SelectedIndexChanged);
            // 
            // cbciudad
            // 
            this.cbciudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbciudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbciudad.FormattingEnabled = true;
            this.cbciudad.Location = new System.Drawing.Point(593, 141);
            this.cbciudad.Name = "cbciudad";
            this.cbciudad.Size = new System.Drawing.Size(311, 32);
            this.cbciudad.TabIndex = 10;
            this.cbciudad.SelectedIndexChanged += new System.EventHandler(this.cbciudad_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(910, 109);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 28);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "Activo";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(910, 143);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(92, 28);
            this.checkBox2.TabIndex = 12;
            this.checkBox2.Text = "Inactivo";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkciudad
            // 
            this.checkciudad.AutoSize = true;
            this.checkciudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkciudad.Location = new System.Drawing.Point(498, 145);
            this.checkciudad.Name = "checkciudad";
            this.checkciudad.Size = new System.Drawing.Size(89, 28);
            this.checkciudad.TabIndex = 14;
            this.checkciudad.Text = "Ciudad";
            this.checkciudad.UseVisualStyleBackColor = true;
            this.checkciudad.CheckedChanged += new System.EventHandler(this.checkciudad_CheckedChanged);
            // 
            // checkestado
            // 
            this.checkestado.AutoSize = true;
            this.checkestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkestado.Location = new System.Drawing.Point(92, 143);
            this.checkestado.Name = "checkestado";
            this.checkestado.Size = new System.Drawing.Size(87, 28);
            this.checkestado.TabIndex = 15;
            this.checkestado.Text = "Estado";
            this.checkestado.UseVisualStyleBackColor = true;
            this.checkestado.CheckedChanged += new System.EventHandler(this.checkestado_CheckedChanged);
            // 
            // checktodo
            // 
            this.checktodo.AutoSize = true;
            this.checktodo.Checked = true;
            this.checktodo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checktodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checktodo.Location = new System.Drawing.Point(12, 143);
            this.checktodo.Name = "checktodo";
            this.checktodo.Size = new System.Drawing.Size(74, 28);
            this.checktodo.TabIndex = 16;
            this.checktodo.Text = "Todo";
            this.checktodo.UseVisualStyleBackColor = true;
            this.checktodo.CheckedChanged += new System.EventHandler(this.checktodo_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(910, 75);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(236, 28);
            this.checkBox3.TabIndex = 18;
            this.checkBox3.Text = "Ver Toda La Informacion";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(518, 180);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(618, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "*NOTA: Para activar o desactivar un Proveedor dar doble click al estatus del Prov" +
    "eedor.";
            // 
            // excel
            // 
            this.excel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.excel.BackColor = System.Drawing.Color.White;
            this.excel.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.excel.FlatAppearance.BorderSize = 5;
            this.excel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.excel.Image = global::ValleVerde.Properties.Resources.excel24;
            this.excel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.excel.Location = new System.Drawing.Point(925, 12);
            this.excel.Name = "excel";
            this.excel.Size = new System.Drawing.Size(163, 57);
            this.excel.TabIndex = 3;
            this.excel.Text = "ExportarExcel";
            this.excel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.excel.UseVisualStyleBackColor = false;
            this.excel.Click += new System.EventHandler(this.excel_Click);
            // 
            // pdf
            // 
            this.pdf.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pdf.BackColor = System.Drawing.Color.White;
            this.pdf.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.pdf.FlatAppearance.BorderSize = 5;
            this.pdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pdf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.pdf.Image = global::ValleVerde.Properties.Resources.pdf24;
            this.pdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pdf.Location = new System.Drawing.Point(621, 12);
            this.pdf.Name = "pdf";
            this.pdf.Size = new System.Drawing.Size(163, 57);
            this.pdf.TabIndex = 2;
            this.pdf.Text = "Exportar PDF";
            this.pdf.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.pdf.UseVisualStyleBackColor = false;
            this.pdf.Click += new System.EventHandler(this.pdf_Click);
            // 
            // Agreagr
            // 
            this.Agreagr.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Agreagr.BackColor = System.Drawing.Color.White;
            this.Agreagr.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.Agreagr.FlatAppearance.BorderSize = 5;
            this.Agreagr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Agreagr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Agreagr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.Agreagr.Image = global::ValleVerde.Properties.Resources.agregar;
            this.Agreagr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Agreagr.Location = new System.Drawing.Point(40, 12);
            this.Agreagr.Name = "Agreagr";
            this.Agreagr.Size = new System.Drawing.Size(126, 57);
            this.Agreagr.TabIndex = 1;
            this.Agreagr.Text = "     Agregar";
            this.Agreagr.UseVisualStyleBackColor = false;
            this.Agreagr.Click += new System.EventHandler(this.Agreagr_Click);
            // 
            // Agregar
            // 
            this.Agregar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Agregar.BackColor = System.Drawing.Color.White;
            this.Agregar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.Agregar.FlatAppearance.BorderSize = 5;
            this.Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Agregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.Agregar.Image = global::ValleVerde.Properties.Resources.modificar24;
            this.Agregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Agregar.Location = new System.Drawing.Point(329, 12);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(126, 57);
            this.Agregar.TabIndex = 0;
            this.Agregar.Text = "Modificar";
            this.Agregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Agregar.UseVisualStyleBackColor = false;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // Proveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 581);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checktodo);
            this.Controls.Add(this.checkestado);
            this.Controls.Add(this.checkciudad);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cbciudad);
            this.Controls.Add(this.cbestado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tablaprov);
            this.Controls.Add(this.excel);
            this.Controls.Add(this.pdf);
            this.Controls.Add(this.Agreagr);
            this.Controls.Add(this.Agregar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Proveedores";
            this.Text = "VerProveedores";
            this.Load += new System.EventHandler(this.VerProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablaprov)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RoundedButton Agregar;
        private RoundedButton Agreagr;
        private RoundedButton pdf;
        private RoundedButton excel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbestado;
        private System.Windows.Forms.ComboBox cbciudad;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkciudad;
        private System.Windows.Forms.CheckBox checkestado;
        private System.Windows.Forms.CheckBox checktodo;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ciudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn LimiteCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDDiasVisita;
        private System.Windows.Forms.DataGridViewTextBoxColumn RFC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Celular;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Activo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Colonia;
        private System.Windows.Forms.DataGridViewTextBoxColumn CP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Poblacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrimerPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn SegundoPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCredito;
        private MyDataGridView tablaprov;
    }

    class MyDataGridView : System.Windows.Forms.DataGridView
    {
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {

            //System.Windows.MessageBox.Show("Key Press Detected");

            if ((keyData == (Keys.Alt | Keys.S)))
            {
                //Save data
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}