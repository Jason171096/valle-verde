namespace ValleVerde.Vistas.Compras
{
    partial class VistaPreviaCompra
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VistaPreviaCompra));
            this.valleverdeDataSetEmpleadosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.valleverdeDataSetEmpleados = new ValleVerde.valleverdeDataSetEmpleados();
            this.dsVacio = new ValleVerde.Vistas.Compras.dsVacio();
            this.valleverdeDataSet1 = new ValleVerde.valleverdeDataSet();
            this.preFlo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pdfVie = new AxAcroPDFLib.AxAcroPDF();
            this.no = new ValleVerde.RoundedButton();
            this.si = new ValleVerde.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.valleverdeDataSetEmpleadosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valleverdeDataSetEmpleados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsVacio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valleverdeDataSet1)).BeginInit();
            this.preFlo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdfVie)).BeginInit();
            this.SuspendLayout();
            // 
            // valleverdeDataSetEmpleadosBindingSource
            // 
            this.valleverdeDataSetEmpleadosBindingSource.DataSource = this.valleverdeDataSetEmpleados;
            this.valleverdeDataSetEmpleadosBindingSource.Position = 0;
            // 
            // valleverdeDataSetEmpleados
            // 
            this.valleverdeDataSetEmpleados.DataSetName = "valleverdeDataSetEmpleados";
            this.valleverdeDataSetEmpleados.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dsVacio
            // 
            this.dsVacio.DataSetName = "dsVacio";
            this.dsVacio.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // valleverdeDataSet1
            // 
            this.valleverdeDataSet1.DataSetName = "valleverdeDataSet";
            this.valleverdeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // preFlo
            // 
            this.preFlo.Controls.Add(this.no);
            this.preFlo.Controls.Add(this.si);
            this.preFlo.Controls.Add(this.label1);
            this.preFlo.Location = new System.Drawing.Point(197, 121);
            this.preFlo.Name = "preFlo";
            this.preFlo.Size = new System.Drawing.Size(490, 200);
            this.preFlo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(19, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 20);
            this.label1.TabIndex = 170;
            this.label1.Text = "¿Está seguro de que ha recibido la mercancía correctamente?";
            // 
            // pdfVie
            // 
            this.pdfVie.Enabled = true;
            this.pdfVie.Location = new System.Drawing.Point(737, 78);
            this.pdfVie.Name = "pdfVie";
            this.pdfVie.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pdfVie.OcxState")));
            this.pdfVie.Size = new System.Drawing.Size(192, 192);
            this.pdfVie.TabIndex = 2;
            // 
            // no
            // 
            this.no.BackColor = System.Drawing.Color.White;
            this.no.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.no.FlatAppearance.BorderSize = 5;
            this.no.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.no.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.no.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.no.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.no.Location = new System.Drawing.Point(279, 66);
            this.no.Name = "no";
            this.no.Size = new System.Drawing.Size(44, 46);
            this.no.TabIndex = 172;
            this.no.Text = "No";
            this.no.UseVisualStyleBackColor = false;
            this.no.Click += new System.EventHandler(this.no_Click);
            // 
            // si
            // 
            this.si.BackColor = System.Drawing.Color.White;
            this.si.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.si.FlatAppearance.BorderSize = 5;
            this.si.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.si.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.si.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.si.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.si.Location = new System.Drawing.Point(167, 66);
            this.si.Name = "si";
            this.si.Size = new System.Drawing.Size(44, 46);
            this.si.TabIndex = 171;
            this.si.Text = "Si";
            this.si.UseVisualStyleBackColor = false;
            this.si.Click += new System.EventHandler(this.si_Click);
            // 
            // VistaPreviaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.preFlo);
            this.Controls.Add(this.pdfVie);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VistaPreviaCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vista previa de compra";
            this.Load += new System.EventHandler(this.VistaPreviaCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.valleverdeDataSetEmpleadosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valleverdeDataSetEmpleados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsVacio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valleverdeDataSet1)).EndInit();
            this.preFlo.ResumeLayout(false);
            this.preFlo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pdfVie)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private dsVacio dsVacio;
        private System.Windows.Forms.BindingSource valleverdeDataSetEmpleadosBindingSource;
        private valleverdeDataSetEmpleados valleverdeDataSetEmpleados;
        private valleverdeDataSet valleverdeDataSet1;
        private System.Windows.Forms.Panel preFlo;
        private RoundedButton no;
        private RoundedButton si;
        private System.Windows.Forms.Label label1;
        private AxAcroPDFLib.AxAcroPDF pdfVie;
        //No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, comerciales, o cualquier otro fin, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
    }
}