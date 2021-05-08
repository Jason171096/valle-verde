namespace ValleVerdeComun.Vistas
{
    partial class Facturar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Facturar));
            this.cbUsoCFDI = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tcFacturar = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnAsignarCliente = new ValleVerdeComun.RoundedButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btnCancelar = new ValleVerdeComun.RoundedButton();
            this.panelDatosFacturacion = new System.Windows.Forms.Panel();
            this.btnAgregarRFC = new ValleVerdeComun.RoundedButton();
            this.btnAgregarCorreo = new ValleVerdeComun.RoundedButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRFC = new System.Windows.Forms.Label();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.panelReferencia = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.cbFormaPago = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.roundedButton2 = new ValleVerdeComun.RoundedButton();
            this.chkEnviar = new System.Windows.Forms.CheckBox();
            this.roundedButton1 = new ValleVerdeComun.RoundedButton();
            this.timerActualizarImagenFlotante = new System.Windows.Forms.Timer(this.components);
            this.tcFacturar.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.panelDatosFacturacion.SuspendLayout();
            this.panelReferencia.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbUsoCFDI
            // 
            this.cbUsoCFDI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbUsoCFDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsoCFDI.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUsoCFDI.FormattingEnabled = true;
            this.cbUsoCFDI.Location = new System.Drawing.Point(11, 308);
            this.cbUsoCFDI.Name = "cbUsoCFDI";
            this.cbUsoCFDI.Size = new System.Drawing.Size(410, 39);
            this.cbUsoCFDI.TabIndex = 10;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(98, 266);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(237, 39);
            this.label20.TabIndex = 40;
            this.label20.Text = "Uso de CFDI:";
            // 
            // tcFacturar
            // 
            this.tcFacturar.Controls.Add(this.tabPage4);
            this.tcFacturar.Controls.Add(this.tabPage5);
            this.tcFacturar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcFacturar.Location = new System.Drawing.Point(0, 0);
            this.tcFacturar.Name = "tcFacturar";
            this.tcFacturar.SelectedIndex = 0;
            this.tcFacturar.Size = new System.Drawing.Size(859, 540);
            this.tcFacturar.TabIndex = 47;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabPage4.Controls.Add(this.btnAsignarCliente);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(851, 514);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "tabPage4";
            // 
            // btnAsignarCliente
            // 
            this.btnAsignarCliente.BackColor = System.Drawing.Color.White;
            this.btnAsignarCliente.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnAsignarCliente.FlatAppearance.BorderSize = 5;
            this.btnAsignarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignarCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnAsignarCliente.Image = global::ValleVerdeComun.Properties.Resources.cliente24;
            this.btnAsignarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignarCliente.Location = new System.Drawing.Point(331, 364);
            this.btnAsignarCliente.Name = "btnAsignarCliente";
            this.btnAsignarCliente.Size = new System.Drawing.Size(220, 46);
            this.btnAsignarCliente.TabIndex = 46;
            this.btnAsignarCliente.Text = "F4 - Asignar cliente";
            this.btnAsignarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAsignarCliente.UseVisualStyleBackColor = false;
            this.btnAsignarCliente.Click += new System.EventHandler(this.btnAsignarCliente_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(848, 119);
            this.label2.TabIndex = 45;
            this.label2.Text = "Sin cliente, asigna un cliente para continuar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tabPage5.Controls.Add(this.btnCancelar);
            this.tabPage5.Controls.Add(this.panelDatosFacturacion);
            this.tabPage5.Controls.Add(this.roundedButton2);
            this.tabPage5.Controls.Add(this.chkEnviar);
            this.tabPage5.Controls.Add(this.roundedButton1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(851, 514);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "tabPage5";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnCancelar.FlatAppearance.BorderSize = 5;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(474, 452);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(172, 54);
            this.btnCancelar.TabIndex = 67;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // panelDatosFacturacion
            // 
            this.panelDatosFacturacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelDatosFacturacion.Controls.Add(this.btnAgregarRFC);
            this.panelDatosFacturacion.Controls.Add(this.btnAgregarCorreo);
            this.panelDatosFacturacion.Controls.Add(this.label5);
            this.panelDatosFacturacion.Controls.Add(this.label4);
            this.panelDatosFacturacion.Controls.Add(this.lblTotal);
            this.panelDatosFacturacion.Controls.Add(this.label3);
            this.panelDatosFacturacion.Controls.Add(this.lblRFC);
            this.panelDatosFacturacion.Controls.Add(this.lblNombreCliente);
            this.panelDatosFacturacion.Controls.Add(this.panelReferencia);
            this.panelDatosFacturacion.Controls.Add(this.cbFormaPago);
            this.panelDatosFacturacion.Controls.Add(this.label6);
            this.panelDatosFacturacion.Controls.Add(this.label1);
            this.panelDatosFacturacion.Controls.Add(this.lblCorreo);
            this.panelDatosFacturacion.Controls.Add(this.label20);
            this.panelDatosFacturacion.Controls.Add(this.cbUsoCFDI);
            this.panelDatosFacturacion.Location = new System.Drawing.Point(7, 5);
            this.panelDatosFacturacion.Name = "panelDatosFacturacion";
            this.panelDatosFacturacion.Size = new System.Drawing.Size(842, 447);
            this.panelDatosFacturacion.TabIndex = 66;
            // 
            // btnAgregarRFC
            // 
            this.btnAgregarRFC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarRFC.BackColor = System.Drawing.Color.White;
            this.btnAgregarRFC.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnAgregarRFC.FlatAppearance.BorderSize = 5;
            this.btnAgregarRFC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarRFC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnAgregarRFC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarRFC.Location = new System.Drawing.Point(140, 162);
            this.btnAgregarRFC.Name = "btnAgregarRFC";
            this.btnAgregarRFC.Size = new System.Drawing.Size(135, 41);
            this.btnAgregarRFC.TabIndex = 61;
            this.btnAgregarRFC.Text = "Agregar";
            this.btnAgregarRFC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarRFC.UseVisualStyleBackColor = false;
            this.btnAgregarRFC.Visible = false;
            this.btnAgregarRFC.Click += new System.EventHandler(this.btnAgregarRFC_Click);
            // 
            // btnAgregarCorreo
            // 
            this.btnAgregarCorreo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarCorreo.BackColor = System.Drawing.Color.White;
            this.btnAgregarCorreo.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnAgregarCorreo.FlatAppearance.BorderSize = 5;
            this.btnAgregarCorreo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnAgregarCorreo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarCorreo.Location = new System.Drawing.Point(565, 162);
            this.btnAgregarCorreo.Name = "btnAgregarCorreo";
            this.btnAgregarCorreo.Size = new System.Drawing.Size(135, 41);
            this.btnAgregarCorreo.TabIndex = 62;
            this.btnAgregarCorreo.Text = "Agregar";
            this.btnAgregarCorreo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarCorreo.UseVisualStyleBackColor = false;
            this.btnAgregarCorreo.Visible = false;
            this.btnAgregarCorreo.Click += new System.EventHandler(this.btnAgregarCorreo_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(179, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(469, 33);
            this.label5.TabIndex = 53;
            this.label5.Text = "Cliente:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(848, 39);
            this.label4.TabIndex = 48;
            this.label4.Text = "Total Factura";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Green;
            this.lblTotal.Location = new System.Drawing.Point(-10, 203);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(852, 63);
            this.lblTotal.TabIndex = 47;
            this.lblTotal.Text = "$0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(-3, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(429, 33);
            this.label3.TabIndex = 46;
            this.label3.Text = "R.F.C.:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRFC
            // 
            this.lblRFC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRFC.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRFC.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblRFC.Location = new System.Drawing.Point(3, 127);
            this.lblRFC.Name = "lblRFC";
            this.lblRFC.Size = new System.Drawing.Size(430, 33);
            this.lblRFC.TabIndex = 45;
            this.lblRFC.Text = "XAXX010101000";
            this.lblRFC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombreCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCliente.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblNombreCliente.Location = new System.Drawing.Point(-4, 38);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(848, 55);
            this.lblNombreCliente.TabIndex = 44;
            this.lblNombreCliente.Text = "Nombre del cliente";
            this.lblNombreCliente.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelReferencia
            // 
            this.panelReferencia.Controls.Add(this.label8);
            this.panelReferencia.Controls.Add(this.txtReferencia);
            this.panelReferencia.Location = new System.Drawing.Point(3, 359);
            this.panelReferencia.Name = "panelReferencia";
            this.panelReferencia.Size = new System.Drawing.Size(833, 82);
            this.panelReferencia.TabIndex = 60;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(33, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(331, 39);
            this.label8.TabIndex = 57;
            this.label8.Text = "Condicion de pago:";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReferencia.Location = new System.Drawing.Point(370, 19);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(439, 47);
            this.txtReferencia.TabIndex = 58;
            // 
            // cbFormaPago
            // 
            this.cbFormaPago.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFormaPago.FormattingEnabled = true;
            this.cbFormaPago.Location = new System.Drawing.Point(429, 308);
            this.cbFormaPago.Name = "cbFormaPago";
            this.cbFormaPago.Size = new System.Drawing.Size(400, 39);
            this.cbFormaPago.TabIndex = 56;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(486, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(278, 39);
            this.label6.TabIndex = 55;
            this.label6.Text = "Forma de Pago:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(429, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 33);
            this.label1.TabIndex = 52;
            this.label1.Text = "Correo:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCorreo
            // 
            this.lblCorreo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblCorreo.Location = new System.Drawing.Point(429, 126);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(411, 33);
            this.lblCorreo.TabIndex = 51;
            this.lblCorreo.Text = "jorge_a380@hotmail.com";
            this.lblCorreo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roundedButton2
            // 
            this.roundedButton2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedButton2.BackColor = System.Drawing.Color.White;
            this.roundedButton2.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.roundedButton2.FlatAppearance.BorderSize = 5;
            this.roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.roundedButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roundedButton2.Location = new System.Drawing.Point(279, 462);
            this.roundedButton2.Name = "roundedButton2";
            this.roundedButton2.Size = new System.Drawing.Size(189, 41);
            this.roundedButton2.TabIndex = 65;
            this.roundedButton2.Text = "Cambiar cliente";
            this.roundedButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.roundedButton2.UseVisualStyleBackColor = false;
            this.roundedButton2.Click += new System.EventHandler(this.roundedButton2_Click);
            // 
            // chkEnviar
            // 
            this.chkEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEnviar.AutoSize = true;
            this.chkEnviar.Checked = true;
            this.chkEnviar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnviar.Location = new System.Drawing.Point(24, 462);
            this.chkEnviar.Name = "chkEnviar";
            this.chkEnviar.Size = new System.Drawing.Size(258, 37);
            this.chkEnviar.TabIndex = 54;
            this.chkEnviar.Text = "Enviar por correo";
            this.chkEnviar.UseVisualStyleBackColor = true;
            // 
            // roundedButton1
            // 
            this.roundedButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedButton1.BackColor = System.Drawing.Color.White;
            this.roundedButton1.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.roundedButton1.FlatAppearance.BorderSize = 5;
            this.roundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundedButton1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.roundedButton1.Image = global::ValleVerdeComun.Properties.Resources.cliente24;
            this.roundedButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roundedButton1.Location = new System.Drawing.Point(652, 452);
            this.roundedButton1.Name = "roundedButton1";
            this.roundedButton1.Size = new System.Drawing.Size(191, 54);
            this.roundedButton1.TabIndex = 50;
            this.roundedButton1.Text = "Facturar";
            this.roundedButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.roundedButton1.UseVisualStyleBackColor = false;
            this.roundedButton1.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // timerActualizarImagenFlotante
            // 
            this.timerActualizarImagenFlotante.Enabled = true;
            this.timerActualizarImagenFlotante.Interval = 500;
            this.timerActualizarImagenFlotante.Tick += new System.EventHandler(this.timerActualizarImagenFlotante_Tick);
            // 
            // Facturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(859, 540);
            this.Controls.Add(this.tcFacturar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Facturar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturar";
            this.Load += new System.EventHandler(this.Facturar_Load);
            this.tcFacturar.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.panelDatosFacturacion.ResumeLayout(false);
            this.panelDatosFacturacion.PerformLayout();
            this.panelReferencia.ResumeLayout(false);
            this.panelReferencia.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUsoCFDI;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TabControl tcFacturar;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Label lblRFC;
        private RoundedButton btnAsignarCliente;
        private RoundedButton roundedButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkEnviar;
        private System.Windows.Forms.ComboBox cbFormaPago;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Panel panelReferencia;
        private RoundedButton btnAgregarCorreo;
        private RoundedButton btnAgregarRFC;
        private RoundedButton roundedButton2;
        private System.Windows.Forms.Panel panelDatosFacturacion;
        private System.Windows.Forms.Timer timerActualizarImagenFlotante;
        private RoundedButton btnCancelar;
    }
}