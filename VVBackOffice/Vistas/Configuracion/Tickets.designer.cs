using System;

namespace ValleVerde
{
    partial class Tickets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tickets));
            this.datGriVieTic = new System.Windows.Forms.DataGridView();
            this.Imagen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cheBoxMen1PiePag = new System.Windows.Forms.CheckBox();
            this.cheBoxAho = new System.Windows.Forms.CheckBox();
            this.cheBoxCli = new System.Windows.Forms.CheckBox();
            this.cheBoxTel = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.texBoxNom = new System.Windows.Forms.TextBox();
            this.labNom = new System.Windows.Forms.Label();
            this.cheBoxMen2PiePag = new System.Windows.Forms.CheckBox();
            this.cheBoxMen3PiePag = new System.Windows.Forms.CheckBox();
            this.cheBoxMenCab = new System.Windows.Forms.CheckBox();
            this.cheBoxCaj = new System.Windows.Forms.CheckBox();
            this.cheBoxEmp = new System.Windows.Forms.CheckBox();
            this.cheBoxSuc = new System.Windows.Forms.CheckBox();
            this.cheBoxLogo = new System.Windows.Forms.CheckBox();
            this.cheBoxDir = new System.Windows.Forms.CheckBox();
            this.cheBoxRfc = new System.Windows.Forms.CheckBox();
            this.texBoxMenCab = new System.Windows.Forms.TextBox();
            this.texBoxMen1PiePag = new System.Windows.Forms.TextBox();
            this.texBoxMen2PiePag = new System.Windows.Forms.TextBox();
            this.texBoxMen3PiePag = new System.Windows.Forms.TextBox();
            this.cheBoxCorEle = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comBoxDigBas = new System.Windows.Forms.ComboBox();
            this.butLim = new ValleVerde.RoundedButton();
            this.butAplCam = new ValleVerde.RoundedButton();
            this.butEliTicSel = new ValleVerde.RoundedButton();
            this.butCre = new ValleVerde.RoundedButton();
            ((System.ComponentModel.ISupportInitialize)(this.datGriVieTic)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // datGriVieTic
            // 
            this.datGriVieTic.AllowUserToAddRows = false;
            this.datGriVieTic.AllowUserToDeleteRows = false;
            this.datGriVieTic.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datGriVieTic.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datGriVieTic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGriVieTic.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Imagen,
            this.Nombre});
            this.datGriVieTic.Location = new System.Drawing.Point(9, 10);
            this.datGriVieTic.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.datGriVieTic.MultiSelect = false;
            this.datGriVieTic.Name = "datGriVieTic";
            this.datGriVieTic.RowHeadersVisible = false;
            this.datGriVieTic.RowHeadersWidth = 51;
            this.datGriVieTic.RowTemplate.Height = 24;
            this.datGriVieTic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datGriVieTic.Size = new System.Drawing.Size(262, 576);
            this.datGriVieTic.TabIndex = 1;
            this.datGriVieTic.SelectionChanged += new System.EventHandler(this.datGriVieTic_SelectionChanged);
            // 
            // Imagen
            // 
            this.Imagen.FillWeight = 32.08556F;
            this.Imagen.HeaderText = "No.";
            this.Imagen.MinimumWidth = 6;
            this.Imagen.Name = "Imagen";
            // 
            // Nombre
            // 
            this.Nombre.FillWeight = 167.9144F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(290, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(314, 576);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ticket 1";
            // 
            // cheBoxMen1PiePag
            // 
            this.cheBoxMen1PiePag.AutoSize = true;
            this.cheBoxMen1PiePag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cheBoxMen1PiePag.Location = new System.Drawing.Point(886, 122);
            this.cheBoxMen1PiePag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cheBoxMen1PiePag.Name = "cheBoxMen1PiePag";
            this.cheBoxMen1PiePag.Size = new System.Drawing.Size(216, 24);
            this.cheBoxMen1PiePag.TabIndex = 26;
            this.cheBoxMen1PiePag.Text = "Mensaje 1 al pie de página";
            this.cheBoxMen1PiePag.UseVisualStyleBackColor = true;
            // 
            // cheBoxAho
            // 
            this.cheBoxAho.AutoSize = true;
            this.cheBoxAho.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cheBoxAho.Location = new System.Drawing.Point(614, 400);
            this.cheBoxAho.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cheBoxAho.Name = "cheBoxAho";
            this.cheBoxAho.Size = new System.Drawing.Size(76, 24);
            this.cheBoxAho.TabIndex = 25;
            this.cheBoxAho.Text = "Ahorro";
            this.cheBoxAho.UseVisualStyleBackColor = true;
            // 
            // cheBoxCli
            // 
            this.cheBoxCli.AutoSize = true;
            this.cheBoxCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cheBoxCli.Location = new System.Drawing.Point(614, 371);
            this.cheBoxCli.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cheBoxCli.Name = "cheBoxCli";
            this.cheBoxCli.Size = new System.Drawing.Size(231, 24);
            this.cheBoxCli.TabIndex = 23;
            this.cheBoxCli.Text = "Cliente (solo si se especifica)";
            this.cheBoxCli.UseVisualStyleBackColor = true;
            // 
            // cheBoxTel
            // 
            this.cheBoxTel.AutoSize = true;
            this.cheBoxTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cheBoxTel.Location = new System.Drawing.Point(614, 113);
            this.cheBoxTel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cheBoxTel.Name = "cheBoxTel";
            this.cheBoxTel.Size = new System.Drawing.Size(90, 24);
            this.cheBoxTel.TabIndex = 20;
            this.cheBoxTel.Text = "Teléfono";
            this.cheBoxTel.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.butCre);
            this.groupBox2.Controls.Add(this.texBoxNom);
            this.groupBox2.Controls.Add(this.labNom);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(847, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(290, 107);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Crear ticket";
            // 
            // texBoxNom
            // 
            this.texBoxNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.texBoxNom.Location = new System.Drawing.Point(73, 21);
            this.texBoxNom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.texBoxNom.Name = "texBoxNom";
            this.texBoxNom.Size = new System.Drawing.Size(213, 26);
            this.texBoxNom.TabIndex = 93;
            // 
            // labNom
            // 
            this.labNom.AutoSize = true;
            this.labNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labNom.Location = new System.Drawing.Point(4, 24);
            this.labNom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labNom.Name = "labNom";
            this.labNom.Size = new System.Drawing.Size(69, 20);
            this.labNom.TabIndex = 92;
            this.labNom.Text = "Nombre:";
            this.labNom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cheBoxMen2PiePag
            // 
            this.cheBoxMen2PiePag.AutoSize = true;
            this.cheBoxMen2PiePag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cheBoxMen2PiePag.Location = new System.Drawing.Point(886, 261);
            this.cheBoxMen2PiePag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cheBoxMen2PiePag.Name = "cheBoxMen2PiePag";
            this.cheBoxMen2PiePag.Size = new System.Drawing.Size(216, 24);
            this.cheBoxMen2PiePag.TabIndex = 86;
            this.cheBoxMen2PiePag.Text = "Mensaje 2 al pie de página";
            this.cheBoxMen2PiePag.UseVisualStyleBackColor = true;
            // 
            // cheBoxMen3PiePag
            // 
            this.cheBoxMen3PiePag.AutoSize = true;
            this.cheBoxMen3PiePag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cheBoxMen3PiePag.Location = new System.Drawing.Point(886, 400);
            this.cheBoxMen3PiePag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cheBoxMen3PiePag.Name = "cheBoxMen3PiePag";
            this.cheBoxMen3PiePag.Size = new System.Drawing.Size(216, 24);
            this.cheBoxMen3PiePag.TabIndex = 88;
            this.cheBoxMen3PiePag.Text = "Mensaje 3 al pie de página";
            this.cheBoxMen3PiePag.UseVisualStyleBackColor = true;
            // 
            // cheBoxMenCab
            // 
            this.cheBoxMenCab.AutoSize = true;
            this.cheBoxMenCab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cheBoxMenCab.Location = new System.Drawing.Point(614, 176);
            this.cheBoxMenCab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cheBoxMenCab.Name = "cheBoxMenCab";
            this.cheBoxMenCab.Size = new System.Drawing.Size(180, 24);
            this.cheBoxMenCab.TabIndex = 90;
            this.cheBoxMenCab.Text = "Mensaje de cabecera";
            this.cheBoxMenCab.UseVisualStyleBackColor = true;
            // 
            // cheBoxCaj
            // 
            this.cheBoxCaj.AutoSize = true;
            this.cheBoxCaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cheBoxCaj.Location = new System.Drawing.Point(614, 314);
            this.cheBoxCaj.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cheBoxCaj.Name = "cheBoxCaj";
            this.cheBoxCaj.Size = new System.Drawing.Size(60, 24);
            this.cheBoxCaj.TabIndex = 92;
            this.cheBoxCaj.Text = "Caja";
            this.cheBoxCaj.UseVisualStyleBackColor = true;
            // 
            // cheBoxEmp
            // 
            this.cheBoxEmp.AutoSize = true;
            this.cheBoxEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cheBoxEmp.Location = new System.Drawing.Point(614, 343);
            this.cheBoxEmp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cheBoxEmp.Name = "cheBoxEmp";
            this.cheBoxEmp.Size = new System.Drawing.Size(100, 24);
            this.cheBoxEmp.TabIndex = 93;
            this.cheBoxEmp.Text = "Empleado";
            this.cheBoxEmp.UseVisualStyleBackColor = true;
            // 
            // cheBoxSuc
            // 
            this.cheBoxSuc.AutoSize = true;
            this.cheBoxSuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cheBoxSuc.Location = new System.Drawing.Point(616, 30);
            this.cheBoxSuc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cheBoxSuc.Name = "cheBoxSuc";
            this.cheBoxSuc.Size = new System.Drawing.Size(90, 24);
            this.cheBoxSuc.TabIndex = 97;
            this.cheBoxSuc.Text = "Sucursal";
            this.cheBoxSuc.UseVisualStyleBackColor = true;
            // 
            // cheBoxLogo
            // 
            this.cheBoxLogo.AutoSize = true;
            this.cheBoxLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cheBoxLogo.Location = new System.Drawing.Point(616, 7);
            this.cheBoxLogo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cheBoxLogo.Name = "cheBoxLogo";
            this.cheBoxLogo.Size = new System.Drawing.Size(90, 24);
            this.cheBoxLogo.TabIndex = 96;
            this.cheBoxLogo.Text = "Logotipo";
            this.cheBoxLogo.UseVisualStyleBackColor = true;
            // 
            // cheBoxDir
            // 
            this.cheBoxDir.AutoSize = true;
            this.cheBoxDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cheBoxDir.Location = new System.Drawing.Point(616, 56);
            this.cheBoxDir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cheBoxDir.Name = "cheBoxDir";
            this.cheBoxDir.Size = new System.Drawing.Size(94, 24);
            this.cheBoxDir.TabIndex = 98;
            this.cheBoxDir.Text = "Dirección";
            this.cheBoxDir.UseVisualStyleBackColor = true;
            // 
            // cheBoxRfc
            // 
            this.cheBoxRfc.AutoSize = true;
            this.cheBoxRfc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cheBoxRfc.Location = new System.Drawing.Point(616, 84);
            this.cheBoxRfc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cheBoxRfc.Name = "cheBoxRfc";
            this.cheBoxRfc.Size = new System.Drawing.Size(73, 24);
            this.cheBoxRfc.TabIndex = 99;
            this.cheBoxRfc.Text = "R.F.C.";
            this.cheBoxRfc.UseVisualStyleBackColor = true;
            // 
            // texBoxMenCab
            // 
            this.texBoxMenCab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.texBoxMenCab.Location = new System.Drawing.Point(614, 204);
            this.texBoxMenCab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.texBoxMenCab.Multiline = true;
            this.texBoxMenCab.Name = "texBoxMenCab";
            this.texBoxMenCab.Size = new System.Drawing.Size(216, 106);
            this.texBoxMenCab.TabIndex = 100;
            this.texBoxMenCab.Text = "Pregunte por nuestras ofertas.";
            // 
            // texBoxMen1PiePag
            // 
            this.texBoxMen1PiePag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.texBoxMen1PiePag.Location = new System.Drawing.Point(886, 150);
            this.texBoxMen1PiePag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.texBoxMen1PiePag.Multiline = true;
            this.texBoxMen1PiePag.Name = "texBoxMen1PiePag";
            this.texBoxMen1PiePag.Size = new System.Drawing.Size(216, 106);
            this.texBoxMen1PiePag.TabIndex = 101;
            this.texBoxMen1PiePag.Text = "Gracias por su preferencia.";
            this.texBoxMen1PiePag.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // texBoxMen2PiePag
            // 
            this.texBoxMen2PiePag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.texBoxMen2PiePag.Location = new System.Drawing.Point(886, 289);
            this.texBoxMen2PiePag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.texBoxMen2PiePag.Multiline = true;
            this.texBoxMen2PiePag.Name = "texBoxMen2PiePag";
            this.texBoxMen2PiePag.Size = new System.Drawing.Size(216, 106);
            this.texBoxMen2PiePag.TabIndex = 102;
            this.texBoxMen2PiePag.Text = "Valle Verde le desea felices vacaciones de Semana Santa.";
            // 
            // texBoxMen3PiePag
            // 
            this.texBoxMen3PiePag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.texBoxMen3PiePag.Location = new System.Drawing.Point(886, 428);
            this.texBoxMen3PiePag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.texBoxMen3PiePag.Multiline = true;
            this.texBoxMen3PiePag.Name = "texBoxMen3PiePag";
            this.texBoxMen3PiePag.Size = new System.Drawing.Size(216, 98);
            this.texBoxMen3PiePag.TabIndex = 103;
            this.texBoxMen3PiePag.Text = "¡Feliz Navidad!";
            // 
            // cheBoxCorEle
            // 
            this.cheBoxCorEle.AutoSize = true;
            this.cheBoxCorEle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cheBoxCorEle.Location = new System.Drawing.Point(614, 141);
            this.cheBoxCorEle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cheBoxCorEle.Name = "cheBoxCorEle";
            this.cheBoxCorEle.Size = new System.Drawing.Size(157, 24);
            this.cheBoxCorEle.TabIndex = 104;
            this.cheBoxCorEle.Text = "Correo electrónico";
            this.cheBoxCorEle.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(612, 428);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 20);
            this.label1.TabIndex = 94;
            this.label1.Text = "Dígitos a mostrar de la bascula:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comBoxDigBas
            // 
            this.comBoxDigBas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comBoxDigBas.FormattingEnabled = true;
            this.comBoxDigBas.Location = new System.Drawing.Point(840, 425);
            this.comBoxDigBas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comBoxDigBas.Name = "comBoxDigBas";
            this.comBoxDigBas.Size = new System.Drawing.Size(42, 28);
            this.comBoxDigBas.TabIndex = 105;
            this.comBoxDigBas.Text = "2";
            // 
            // butLim
            // 
            this.butLim.BackColor = System.Drawing.Color.White;
            this.butLim.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.butLim.FlatAppearance.BorderSize = 5;
            this.butLim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butLim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butLim.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.butLim.Image = global::ValleVerde.Properties.Resources.limpiar;
            this.butLim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butLim.Location = new System.Drawing.Point(609, 533);
            this.butLim.Name = "butLim";
            this.butLim.Size = new System.Drawing.Size(101, 53);
            this.butLim.TabIndex = 106;
            this.butLim.Text = "Limpiar";
            this.butLim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butLim.UseVisualStyleBackColor = false;
            this.butLim.Click += new System.EventHandler(this.butLim_Click);
            // 
            // butAplCam
            // 
            this.butAplCam.BackColor = System.Drawing.Color.White;
            this.butAplCam.Enabled = false;
            this.butAplCam.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.butAplCam.FlatAppearance.BorderSize = 5;
            this.butAplCam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butAplCam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butAplCam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.butAplCam.Image = global::ValleVerde.Properties.Resources.correcto;
            this.butAplCam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butAplCam.Location = new System.Drawing.Point(979, 533);
            this.butAplCam.Name = "butAplCam";
            this.butAplCam.Size = new System.Drawing.Size(158, 53);
            this.butAplCam.TabIndex = 95;
            this.butAplCam.Text = "Aplicar cambios";
            this.butAplCam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butAplCam.UseVisualStyleBackColor = false;
            this.butAplCam.Click += new System.EventHandler(this.butAplCam_Click);
            // 
            // butEliTicSel
            // 
            this.butEliTicSel.BackColor = System.Drawing.Color.White;
            this.butEliTicSel.Enabled = false;
            this.butEliTicSel.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.butEliTicSel.FlatAppearance.BorderSize = 5;
            this.butEliTicSel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butEliTicSel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butEliTicSel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.butEliTicSel.Image = global::ValleVerde.Properties.Resources.darBajaUsuario1;
            this.butEliTicSel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butEliTicSel.Location = new System.Drawing.Point(745, 533);
            this.butEliTicSel.Name = "butEliTicSel";
            this.butEliTicSel.Size = new System.Drawing.Size(228, 53);
            this.butEliTicSel.TabIndex = 85;
            this.butEliTicSel.Text = "Eliminar ticket seleccionado";
            this.butEliTicSel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.butEliTicSel.UseVisualStyleBackColor = false;
            this.butEliTicSel.Click += new System.EventHandler(this.butEliTicSel_Click);
            // 
            // butCre
            // 
            this.butCre.BackColor = System.Drawing.Color.White;
            this.butCre.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.butCre.FlatAppearance.BorderSize = 5;
            this.butCre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butCre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butCre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.butCre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butCre.Location = new System.Drawing.Point(99, 52);
            this.butCre.Name = "butCre";
            this.butCre.Size = new System.Drawing.Size(99, 53);
            this.butCre.TabIndex = 86;
            this.butCre.Text = "Crear";
            this.butCre.UseVisualStyleBackColor = false;
            this.butCre.Click += new System.EventHandler(this.butCre_Click);
            // 
            // Tickets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 598);
            this.Controls.Add(this.butLim);
            this.Controls.Add(this.comBoxDigBas);
            this.Controls.Add(this.cheBoxCorEle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.texBoxMen3PiePag);
            this.Controls.Add(this.texBoxMen2PiePag);
            this.Controls.Add(this.texBoxMen1PiePag);
            this.Controls.Add(this.texBoxMenCab);
            this.Controls.Add(this.cheBoxRfc);
            this.Controls.Add(this.cheBoxDir);
            this.Controls.Add(this.cheBoxSuc);
            this.Controls.Add(this.cheBoxLogo);
            this.Controls.Add(this.butAplCam);
            this.Controls.Add(this.cheBoxEmp);
            this.Controls.Add(this.cheBoxCaj);
            this.Controls.Add(this.cheBoxMenCab);
            this.Controls.Add(this.cheBoxMen3PiePag);
            this.Controls.Add(this.cheBoxMen2PiePag);
            this.Controls.Add(this.butEliTicSel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cheBoxMen1PiePag);
            this.Controls.Add(this.cheBoxAho);
            this.Controls.Add(this.cheBoxCli);
            this.Controls.Add(this.cheBoxTel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.datGriVieTic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Tickets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tickets";
            this.Load += new System.EventHandler(this.Tickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datGriVieTic)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datGriVieTic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Imagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cheBoxMen1PiePag;
        private System.Windows.Forms.CheckBox cheBoxAho;
        private System.Windows.Forms.CheckBox cheBoxCli;
        private System.Windows.Forms.CheckBox cheBoxTel;
        private System.Windows.Forms.GroupBox groupBox2;
        private RoundedButton butEliTicSel;
        private RoundedButton butCre;
        private System.Windows.Forms.TextBox texBoxNom;
        private System.Windows.Forms.Label labNom;
        private System.Windows.Forms.CheckBox cheBoxMen2PiePag;
        private System.Windows.Forms.CheckBox cheBoxMen3PiePag;
        private System.Windows.Forms.CheckBox cheBoxMenCab;
        private System.Windows.Forms.CheckBox cheBoxCaj;
        private System.Windows.Forms.CheckBox cheBoxEmp;
        private RoundedButton butAplCam;
        private System.Windows.Forms.CheckBox cheBoxSuc;
        private System.Windows.Forms.CheckBox cheBoxLogo;
        private System.Windows.Forms.CheckBox cheBoxDir;
        private System.Windows.Forms.CheckBox cheBoxRfc;
        private System.Windows.Forms.TextBox texBoxMenCab;
        private System.Windows.Forms.TextBox texBoxMen1PiePag;
        private System.Windows.Forms.TextBox texBoxMen2PiePag;
        private System.Windows.Forms.TextBox texBoxMen3PiePag;
        private System.Windows.Forms.CheckBox cheBoxCorEle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comBoxDigBas;
        private RoundedButton butLim;
    }
}