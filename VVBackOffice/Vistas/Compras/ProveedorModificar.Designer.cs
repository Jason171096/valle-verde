namespace ValleVerde.Vistas.Compras
{
    partial class ProveedorModificar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProveedorModificar));
            this.butMod = new ValleVerde.RoundedButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cheBoxDom = new System.Windows.Forms.CheckBox();
            this.cheBoxSab = new System.Windows.Forms.CheckBox();
            this.cheBoxVie = new System.Windows.Forms.CheckBox();
            this.cheBoxJue = new System.Windows.Forms.CheckBox();
            this.cheBoxMie = new System.Windows.Forms.CheckBox();
            this.cheBoxMar = new System.Windows.Forms.CheckBox();
            this.cheBoxLun = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.texBoxCel = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.texBoxEst = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.texBoxCiu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.texBoxLimCre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.texBoxDiaCre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.texBoxCorEle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.texBoxTel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.texBoxDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.texBoxNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butSelPro = new ValleVerde.RoundedButton();
            this.texBoxRfc = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // butMod
            // 
            this.butMod.BackColor = System.Drawing.Color.White;
            this.butMod.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.butMod.FlatAppearance.BorderSize = 5;
            this.butMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.butMod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.butMod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butMod.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.butMod.Location = new System.Drawing.Point(211, 499);
            this.butMod.Margin = new System.Windows.Forms.Padding(4);
            this.butMod.Name = "butMod";
            this.butMod.Size = new System.Drawing.Size(165, 57);
            this.butMod.TabIndex = 71;
            this.butMod.Text = "Modificar";
            this.butMod.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.butMod.UseVisualStyleBackColor = false;
            this.butMod.Click += new System.EventHandler(this.butMod_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cheBoxDom);
            this.groupBox1.Controls.Add(this.cheBoxSab);
            this.groupBox1.Controls.Add(this.cheBoxVie);
            this.groupBox1.Controls.Add(this.cheBoxJue);
            this.groupBox1.Controls.Add(this.cheBoxMie);
            this.groupBox1.Controls.Add(this.cheBoxMar);
            this.groupBox1.Controls.Add(this.cheBoxLun);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(16, 408);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 73);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Días de visita";
            // 
            // cheBoxDom
            // 
            this.cheBoxDom.AutoSize = true;
            this.cheBoxDom.Location = new System.Drawing.Point(462, 29);
            this.cheBoxDom.Name = "cheBoxDom";
            this.cheBoxDom.Size = new System.Drawing.Size(75, 29);
            this.cheBoxDom.TabIndex = 6;
            this.cheBoxDom.Text = "Dom";
            this.cheBoxDom.UseVisualStyleBackColor = true;
            // 
            // cheBoxSab
            // 
            this.cheBoxSab.AutoSize = true;
            this.cheBoxSab.Location = new System.Drawing.Point(386, 29);
            this.cheBoxSab.Name = "cheBoxSab";
            this.cheBoxSab.Size = new System.Drawing.Size(70, 29);
            this.cheBoxSab.TabIndex = 5;
            this.cheBoxSab.Text = "Sáb";
            this.cheBoxSab.UseVisualStyleBackColor = true;
            // 
            // cheBoxVie
            // 
            this.cheBoxVie.AutoSize = true;
            this.cheBoxVie.Location = new System.Drawing.Point(317, 29);
            this.cheBoxVie.Name = "cheBoxVie";
            this.cheBoxVie.Size = new System.Drawing.Size(63, 29);
            this.cheBoxVie.TabIndex = 4;
            this.cheBoxVie.Text = "Vie";
            this.cheBoxVie.UseVisualStyleBackColor = true;
            // 
            // cheBoxJue
            // 
            this.cheBoxJue.AutoSize = true;
            this.cheBoxJue.Location = new System.Drawing.Point(244, 29);
            this.cheBoxJue.Name = "cheBoxJue";
            this.cheBoxJue.Size = new System.Drawing.Size(67, 29);
            this.cheBoxJue.TabIndex = 3;
            this.cheBoxJue.Text = "Jue";
            this.cheBoxJue.UseVisualStyleBackColor = true;
            // 
            // cheBoxMie
            // 
            this.cheBoxMie.AutoSize = true;
            this.cheBoxMie.Location = new System.Drawing.Point(172, 29);
            this.cheBoxMie.Name = "cheBoxMie";
            this.cheBoxMie.Size = new System.Drawing.Size(66, 29);
            this.cheBoxMie.TabIndex = 2;
            this.cheBoxMie.Text = "Mié";
            this.cheBoxMie.UseVisualStyleBackColor = true;
            // 
            // cheBoxMar
            // 
            this.cheBoxMar.AutoSize = true;
            this.cheBoxMar.Location = new System.Drawing.Point(98, 29);
            this.cheBoxMar.Name = "cheBoxMar";
            this.cheBoxMar.Size = new System.Drawing.Size(68, 29);
            this.cheBoxMar.TabIndex = 1;
            this.cheBoxMar.Text = "Mar";
            this.cheBoxMar.UseVisualStyleBackColor = true;
            // 
            // cheBoxLun
            // 
            this.cheBoxLun.AutoSize = true;
            this.cheBoxLun.Location = new System.Drawing.Point(25, 29);
            this.cheBoxLun.Name = "cheBoxLun";
            this.cheBoxLun.Size = new System.Drawing.Size(67, 29);
            this.cheBoxLun.TabIndex = 0;
            this.cheBoxLun.Text = "Lun";
            this.cheBoxLun.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label11.Location = new System.Drawing.Point(122, 267);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 25);
            this.label11.TabIndex = 68;
            this.label11.Text = "R.F.C.";
            // 
            // texBoxCel
            // 
            this.texBoxCel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.texBoxCel.Location = new System.Drawing.Point(195, 48);
            this.texBoxCel.Name = "texBoxCel";
            this.texBoxCel.Size = new System.Drawing.Size(250, 30);
            this.texBoxCel.TabIndex = 67;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label10.Location = new System.Drawing.Point(115, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 25);
            this.label10.TabIndex = 66;
            this.label10.Text = "Celular";
            // 
            // texBoxEst
            // 
            this.texBoxEst.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.texBoxEst.Location = new System.Drawing.Point(195, 228);
            this.texBoxEst.Name = "texBoxEst";
            this.texBoxEst.Size = new System.Drawing.Size(250, 30);
            this.texBoxEst.TabIndex = 65;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label9.Location = new System.Drawing.Point(116, 231);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 25);
            this.label9.TabIndex = 64;
            this.label9.Text = "Estado";
            // 
            // texBoxCiu
            // 
            this.texBoxCiu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.texBoxCiu.Location = new System.Drawing.Point(195, 192);
            this.texBoxCiu.Name = "texBoxCiu";
            this.texBoxCiu.Size = new System.Drawing.Size(250, 30);
            this.texBoxCiu.TabIndex = 63;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(114, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 25);
            this.label8.TabIndex = 62;
            this.label8.Text = "Ciudad";
            // 
            // texBoxLimCre
            // 
            this.texBoxLimCre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.texBoxLimCre.Location = new System.Drawing.Point(195, 336);
            this.texBoxLimCre.Name = "texBoxLimCre";
            this.texBoxLimCre.Size = new System.Drawing.Size(250, 30);
            this.texBoxLimCre.TabIndex = 61;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(36, 339);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 25);
            this.label7.TabIndex = 60;
            this.label7.Text = "Límite de crédito";
            // 
            // texBoxDiaCre
            // 
            this.texBoxDiaCre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.texBoxDiaCre.Location = new System.Drawing.Point(195, 300);
            this.texBoxDiaCre.Name = "texBoxDiaCre";
            this.texBoxDiaCre.Size = new System.Drawing.Size(250, 30);
            this.texBoxDiaCre.TabIndex = 59;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(48, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 25);
            this.label6.TabIndex = 58;
            this.label6.Text = "Días de crédito";
            // 
            // texBoxCorEle
            // 
            this.texBoxCorEle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.texBoxCorEle.Location = new System.Drawing.Point(195, 120);
            this.texBoxCorEle.Name = "texBoxCorEle";
            this.texBoxCorEle.Size = new System.Drawing.Size(250, 30);
            this.texBoxCorEle.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(18, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 25);
            this.label5.TabIndex = 56;
            this.label5.Text = "Correo electrónico";
            // 
            // texBoxTel
            // 
            this.texBoxTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.texBoxTel.Location = new System.Drawing.Point(195, 84);
            this.texBoxTel.Name = "texBoxTel";
            this.texBoxTel.Size = new System.Drawing.Size(250, 30);
            this.texBoxTel.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(100, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 25);
            this.label4.TabIndex = 54;
            this.label4.Text = "Teléfono";
            // 
            // texBoxDir
            // 
            this.texBoxDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.texBoxDir.Location = new System.Drawing.Point(195, 156);
            this.texBoxDir.Name = "texBoxDir";
            this.texBoxDir.Size = new System.Drawing.Size(250, 30);
            this.texBoxDir.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(99, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 25);
            this.label3.TabIndex = 52;
            this.label3.Text = "Dirección";
            // 
            // texBoxNom
            // 
            this.texBoxNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.texBoxNom.Location = new System.Drawing.Point(195, 12);
            this.texBoxNom.Name = "texBoxNom";
            this.texBoxNom.Size = new System.Drawing.Size(250, 30);
            this.texBoxNom.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(24, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 25);
            this.label1.TabIndex = 48;
            this.label1.Text = "Nombre completo";
            // 
            // butSelPro
            // 
            this.butSelPro.BackColor = System.Drawing.Color.White;
            this.butSelPro.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.butSelPro.FlatAppearance.BorderSize = 5;
            this.butSelPro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butSelPro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.butSelPro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.butSelPro.Image = global::ValleVerde.Properties.Resources.lupa;
            this.butSelPro.Location = new System.Drawing.Point(452, 11);
            this.butSelPro.Margin = new System.Windows.Forms.Padding(4);
            this.butSelPro.Name = "butSelPro";
            this.butSelPro.Size = new System.Drawing.Size(37, 37);
            this.butSelPro.TabIndex = 72;
            this.butSelPro.UseVisualStyleBackColor = false;
            this.butSelPro.Click += new System.EventHandler(this.butSelPro_Click);
            // 
            // texBoxRfc
            // 
            this.texBoxRfc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.texBoxRfc.Location = new System.Drawing.Point(195, 264);
            this.texBoxRfc.Name = "texBoxRfc";
            this.texBoxRfc.Size = new System.Drawing.Size(250, 30);
            this.texBoxRfc.TabIndex = 73;
            // 
            // ProveedorModificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 573);
            this.Controls.Add(this.texBoxRfc);
            this.Controls.Add(this.butSelPro);
            this.Controls.Add(this.butMod);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.texBoxCel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.texBoxEst);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.texBoxCiu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.texBoxLimCre);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.texBoxDiaCre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.texBoxCorEle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.texBoxTel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.texBoxDir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.texBoxNom);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProveedorModificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modificar proveedor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private RoundedButton butMod;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cheBoxDom;
        private System.Windows.Forms.CheckBox cheBoxSab;
        private System.Windows.Forms.CheckBox cheBoxVie;
        private System.Windows.Forms.CheckBox cheBoxJue;
        private System.Windows.Forms.CheckBox cheBoxMie;
        private System.Windows.Forms.CheckBox cheBoxMar;
        private System.Windows.Forms.CheckBox cheBoxLun;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox texBoxCel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox texBoxEst;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox texBoxCiu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox texBoxLimCre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox texBoxDiaCre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox texBoxCorEle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox texBoxTel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox texBoxDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox texBoxNom;
        private System.Windows.Forms.Label label1;
        private RoundedButton butSelPro;
        private System.Windows.Forms.TextBox texBoxRfc;
        //No se otorga permiso para usar, copiar, modificar o distribuir este software con fines educativos, comerciales, o cualquier otro fin, con o sin lucro, sin un permiso escrito y firmado por Daniel Alejandro Gutiérrez Ruiz y Jorge Gabriel Gutiérrez Ruiz, estudiantes de Ingeniería en Sistemas Computacionales en el Instituto Tecnológico de Jiquilpan, con número de control 15420492 y 15420493, respectivamente, pertenecientes a la ciudad de Cotija de la Paz, Michoacán, México.Para solicitar permiso, comuníquese con Daniel Alejandro Gutiérrez Ruiz al correo electrónico: daniel_alejandro.12@icloud.com, o con Jorge Gabriel Gutiérrez Ruiz al correo electrónico: jorgea380 @icloud.com.
    }
}