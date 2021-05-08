namespace ValleVerde.Vistas.Reportes
{
    partial class ReporteEmpleado
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.obtenerEmpleadoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.valleverdeDataSetEmpleados = new ValleVerde.valleverdeDataSetEmpleados();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.obtenerEmpleadoTableAdapter = new ValleVerde.valleverdeDataSetEmpleadosTableAdapters.ObtenerEmpleadoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.obtenerEmpleadoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valleverdeDataSetEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // obtenerEmpleadoBindingSource
            // 
            this.obtenerEmpleadoBindingSource.DataMember = "ObtenerEmpleado";
            this.obtenerEmpleadoBindingSource.DataSource = this.valleverdeDataSetEmpleados;
            // 
            // valleverdeDataSetEmpleados
            // 
            this.valleverdeDataSetEmpleados.DataSetName = "valleverdeDataSetEmpleados";
            this.valleverdeDataSetEmpleados.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.obtenerEmpleadoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ValleVerde.Vistas.Reportes.ReporteEmpleado.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(755, 648);
            this.reportViewer1.TabIndex = 0;
            // 
            // obtenerEmpleadoTableAdapter
            // 
            this.obtenerEmpleadoTableAdapter.ClearBeforeFill = true;
            // 
            // ReporteEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 648);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReporteEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReporteEmpleado";
            this.Load += new System.EventHandler(this.ReporteEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.obtenerEmpleadoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valleverdeDataSetEmpleados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource obtenerEmpleadoBindingSource;
        private valleverdeDataSetEmpleados valleverdeDataSetEmpleados;
        private valleverdeDataSetEmpleadosTableAdapters.ObtenerEmpleadoTableAdapter obtenerEmpleadoTableAdapter;
    }
}