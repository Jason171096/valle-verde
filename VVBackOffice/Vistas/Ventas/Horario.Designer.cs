namespace ValleVerde.Vistas.Ventas
{
    partial class Horario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Horario));
            this.dgvHorario = new System.Windows.Forms.DataGridView();
            this.groupHorario = new System.Windows.Forms.GroupBox();
            this.aceptar = new ValleVerde.RoundedButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dHFin = new System.Windows.Forms.DateTimePicker();
            this.dHInicio = new System.Windows.Forms.DateTimePicker();
            this.sHFin = new System.Windows.Forms.DateTimePicker();
            this.sHInicio = new System.Windows.Forms.DateTimePicker();
            this.vHFin = new System.Windows.Forms.DateTimePicker();
            this.vHInicio = new System.Windows.Forms.DateTimePicker();
            this.jHFin = new System.Windows.Forms.DateTimePicker();
            this.jHInicio = new System.Windows.Forms.DateTimePicker();
            this.miHFin = new System.Windows.Forms.DateTimePicker();
            this.miHInicio = new System.Windows.Forms.DateTimePicker();
            this.mHFin = new System.Windows.Forms.DateTimePicker();
            this.mHInicio = new System.Windows.Forms.DateTimePicker();
            this.lHFin = new System.Windows.Forms.DateTimePicker();
            this.lHinicio = new System.Windows.Forms.DateTimePicker();
            this.chkDomingo = new System.Windows.Forms.CheckBox();
            this.chkSabado = new System.Windows.Forms.CheckBox();
            this.chkViernes = new System.Windows.Forms.CheckBox();
            this.chkJueves = new System.Windows.Forms.CheckBox();
            this.chkMartes = new System.Windows.Forms.CheckBox();
            this.chkMiercoles = new System.Windows.Forms.CheckBox();
            this.chkLunes = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonEditar = new ValleVerde.RoundedButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nuevoHorario = new ValleVerde.RoundedButton();
            this.idHorario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domingo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lunes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.martes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.miercoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jueves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viernes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sabado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorario)).BeginInit();
            this.groupHorario.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHorario
            // 
            this.dgvHorario.AllowUserToAddRows = false;
            this.dgvHorario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHorario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHorario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idHorario,
            this.nombre,
            this.domingo,
            this.lunes,
            this.martes,
            this.miercoles,
            this.jueves,
            this.viernes,
            this.sabado});
            this.dgvHorario.Location = new System.Drawing.Point(12, 94);
            this.dgvHorario.Name = "dgvHorario";
            this.dgvHorario.RowHeadersVisible = false;
            this.dgvHorario.Size = new System.Drawing.Size(953, 298);
            this.dgvHorario.TabIndex = 1;
            this.dgvHorario.DoubleClick += new System.EventHandler(this.dgvHorario_DoubleClick);
            // 
            // groupHorario
            // 
            this.groupHorario.Controls.Add(this.aceptar);
            this.groupHorario.Controls.Add(this.label5);
            this.groupHorario.Controls.Add(this.label4);
            this.groupHorario.Controls.Add(this.label3);
            this.groupHorario.Controls.Add(this.label2);
            this.groupHorario.Controls.Add(this.dHFin);
            this.groupHorario.Controls.Add(this.dHInicio);
            this.groupHorario.Controls.Add(this.sHFin);
            this.groupHorario.Controls.Add(this.sHInicio);
            this.groupHorario.Controls.Add(this.vHFin);
            this.groupHorario.Controls.Add(this.vHInicio);
            this.groupHorario.Controls.Add(this.jHFin);
            this.groupHorario.Controls.Add(this.jHInicio);
            this.groupHorario.Controls.Add(this.miHFin);
            this.groupHorario.Controls.Add(this.miHInicio);
            this.groupHorario.Controls.Add(this.mHFin);
            this.groupHorario.Controls.Add(this.mHInicio);
            this.groupHorario.Controls.Add(this.lHFin);
            this.groupHorario.Controls.Add(this.lHinicio);
            this.groupHorario.Controls.Add(this.chkDomingo);
            this.groupHorario.Controls.Add(this.chkSabado);
            this.groupHorario.Controls.Add(this.chkViernes);
            this.groupHorario.Controls.Add(this.chkJueves);
            this.groupHorario.Controls.Add(this.chkMartes);
            this.groupHorario.Controls.Add(this.chkMiercoles);
            this.groupHorario.Controls.Add(this.chkLunes);
            this.groupHorario.Controls.Add(this.label1);
            this.groupHorario.Controls.Add(this.textNombre);
            this.groupHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupHorario.Location = new System.Drawing.Point(12, 398);
            this.groupHorario.Name = "groupHorario";
            this.groupHorario.Size = new System.Drawing.Size(953, 274);
            this.groupHorario.TabIndex = 2;
            this.groupHorario.TabStop = false;
            this.groupHorario.Text = "Agregar nuevo horario";
            this.groupHorario.Visible = false;
            // 
            // aceptar
            // 
            this.aceptar.BackColor = System.Drawing.Color.White;
            this.aceptar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.aceptar.FlatAppearance.BorderSize = 5;
            this.aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.aceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.aceptar.Image = global::ValleVerde.Properties.Resources.correcto;
            this.aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.aceptar.Location = new System.Drawing.Point(814, 229);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(103, 39);
            this.aceptar.TabIndex = 26;
            this.aceptar.Text = "Aceptar";
            this.aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.aceptar.UseVisualStyleBackColor = false;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(804, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "H. Fin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(350, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 18);
            this.label4.TabIndex = 24;
            this.label4.Text = "H. Fin";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(649, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "H. Inicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(204, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 18);
            this.label2.TabIndex = 22;
            this.label2.Text = "H. Inicio";
            // 
            // dHFin
            // 
            this.dHFin.AllowDrop = true;
            this.dHFin.CustomFormat = "hh:mm:ss tt";
            this.dHFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dHFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dHFin.Location = new System.Drawing.Point(764, 183);
            this.dHFin.Name = "dHFin";
            this.dHFin.ShowUpDown = true;
            this.dHFin.Size = new System.Drawing.Size(153, 26);
            this.dHFin.TabIndex = 21;
            this.dHFin.Value = new System.DateTime(2020, 7, 21, 20, 30, 0, 0);
            // 
            // dHInicio
            // 
            this.dHInicio.AllowDrop = true;
            this.dHInicio.CustomFormat = "hh:mm:ss tt";
            this.dHInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dHInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dHInicio.Location = new System.Drawing.Point(605, 183);
            this.dHInicio.Name = "dHInicio";
            this.dHInicio.ShowUpDown = true;
            this.dHInicio.Size = new System.Drawing.Size(153, 26);
            this.dHInicio.TabIndex = 20;
            this.dHInicio.Value = new System.DateTime(2020, 7, 21, 7, 30, 0, 0);
            // 
            // sHFin
            // 
            this.sHFin.AllowDrop = true;
            this.sHFin.CustomFormat = "hh:mm:ss tt";
            this.sHFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sHFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.sHFin.Location = new System.Drawing.Point(764, 142);
            this.sHFin.Name = "sHFin";
            this.sHFin.ShowUpDown = true;
            this.sHFin.Size = new System.Drawing.Size(153, 26);
            this.sHFin.TabIndex = 19;
            this.sHFin.Value = new System.DateTime(2020, 7, 21, 20, 30, 0, 0);
            // 
            // sHInicio
            // 
            this.sHInicio.AllowDrop = true;
            this.sHInicio.CustomFormat = "hh:mm:ss tt";
            this.sHInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sHInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.sHInicio.Location = new System.Drawing.Point(605, 142);
            this.sHInicio.Name = "sHInicio";
            this.sHInicio.ShowUpDown = true;
            this.sHInicio.Size = new System.Drawing.Size(153, 26);
            this.sHInicio.TabIndex = 18;
            this.sHInicio.Value = new System.DateTime(2020, 7, 21, 7, 30, 0, 0);
            // 
            // vHFin
            // 
            this.vHFin.AllowDrop = true;
            this.vHFin.CustomFormat = "hh:mm:ss tt";
            this.vHFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vHFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.vHFin.Location = new System.Drawing.Point(764, 101);
            this.vHFin.Name = "vHFin";
            this.vHFin.ShowUpDown = true;
            this.vHFin.Size = new System.Drawing.Size(153, 26);
            this.vHFin.TabIndex = 17;
            this.vHFin.Value = new System.DateTime(2020, 7, 21, 20, 30, 0, 0);
            // 
            // vHInicio
            // 
            this.vHInicio.AllowDrop = true;
            this.vHInicio.CustomFormat = "hh:mm:ss tt";
            this.vHInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vHInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.vHInicio.Location = new System.Drawing.Point(605, 101);
            this.vHInicio.Name = "vHInicio";
            this.vHInicio.ShowUpDown = true;
            this.vHInicio.Size = new System.Drawing.Size(153, 26);
            this.vHInicio.TabIndex = 16;
            this.vHInicio.Value = new System.DateTime(2020, 7, 21, 7, 30, 0, 0);
            // 
            // jHFin
            // 
            this.jHFin.AllowDrop = true;
            this.jHFin.CustomFormat = "hh:mm:ss tt";
            this.jHFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jHFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.jHFin.Location = new System.Drawing.Point(319, 230);
            this.jHFin.Name = "jHFin";
            this.jHFin.ShowUpDown = true;
            this.jHFin.Size = new System.Drawing.Size(153, 26);
            this.jHFin.TabIndex = 15;
            this.jHFin.Value = new System.DateTime(2020, 7, 21, 20, 30, 0, 0);
            // 
            // jHInicio
            // 
            this.jHInicio.AllowDrop = true;
            this.jHInicio.CustomFormat = "hh:mm:ss tt";
            this.jHInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jHInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.jHInicio.Location = new System.Drawing.Point(160, 230);
            this.jHInicio.Name = "jHInicio";
            this.jHInicio.ShowUpDown = true;
            this.jHInicio.Size = new System.Drawing.Size(153, 26);
            this.jHInicio.TabIndex = 14;
            this.jHInicio.Value = new System.DateTime(2020, 7, 21, 7, 30, 0, 0);
            // 
            // miHFin
            // 
            this.miHFin.AllowDrop = true;
            this.miHFin.CustomFormat = "hh:mm:ss tt";
            this.miHFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miHFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.miHFin.Location = new System.Drawing.Point(319, 183);
            this.miHFin.Name = "miHFin";
            this.miHFin.ShowUpDown = true;
            this.miHFin.Size = new System.Drawing.Size(153, 26);
            this.miHFin.TabIndex = 13;
            this.miHFin.Value = new System.DateTime(2020, 7, 21, 20, 30, 0, 0);
            // 
            // miHInicio
            // 
            this.miHInicio.AllowDrop = true;
            this.miHInicio.CustomFormat = "hh:mm:ss tt";
            this.miHInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miHInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.miHInicio.Location = new System.Drawing.Point(160, 183);
            this.miHInicio.Name = "miHInicio";
            this.miHInicio.ShowUpDown = true;
            this.miHInicio.Size = new System.Drawing.Size(153, 26);
            this.miHInicio.TabIndex = 12;
            this.miHInicio.Value = new System.DateTime(2020, 7, 21, 7, 30, 0, 0);
            // 
            // mHFin
            // 
            this.mHFin.AllowDrop = true;
            this.mHFin.CustomFormat = "hh:mm:ss tt";
            this.mHFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mHFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.mHFin.Location = new System.Drawing.Point(319, 142);
            this.mHFin.Name = "mHFin";
            this.mHFin.ShowUpDown = true;
            this.mHFin.Size = new System.Drawing.Size(153, 26);
            this.mHFin.TabIndex = 11;
            this.mHFin.Value = new System.DateTime(2020, 7, 21, 20, 30, 0, 0);
            // 
            // mHInicio
            // 
            this.mHInicio.AllowDrop = true;
            this.mHInicio.CustomFormat = "hh:mm:ss tt";
            this.mHInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mHInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.mHInicio.Location = new System.Drawing.Point(160, 142);
            this.mHInicio.Name = "mHInicio";
            this.mHInicio.ShowUpDown = true;
            this.mHInicio.Size = new System.Drawing.Size(153, 26);
            this.mHInicio.TabIndex = 10;
            this.mHInicio.Value = new System.DateTime(2020, 7, 21, 7, 30, 0, 0);
            // 
            // lHFin
            // 
            this.lHFin.AllowDrop = true;
            this.lHFin.CustomFormat = "hh:mm:ss tt";
            this.lHFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.lHFin.Location = new System.Drawing.Point(319, 98);
            this.lHFin.Name = "lHFin";
            this.lHFin.ShowUpDown = true;
            this.lHFin.Size = new System.Drawing.Size(153, 26);
            this.lHFin.TabIndex = 9;
            this.lHFin.Value = new System.DateTime(2020, 7, 21, 20, 30, 0, 0);
            // 
            // lHinicio
            // 
            this.lHinicio.AllowDrop = true;
            this.lHinicio.CustomFormat = "hh:mm:ss tt";
            this.lHinicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHinicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.lHinicio.Location = new System.Drawing.Point(160, 98);
            this.lHinicio.Name = "lHinicio";
            this.lHinicio.ShowUpDown = true;
            this.lHinicio.Size = new System.Drawing.Size(153, 26);
            this.lHinicio.TabIndex = 8;
            this.lHinicio.Value = new System.DateTime(2020, 7, 21, 7, 30, 0, 0);
            // 
            // chkDomingo
            // 
            this.chkDomingo.AutoSize = true;
            this.chkDomingo.Checked = true;
            this.chkDomingo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDomingo.Location = new System.Drawing.Point(494, 186);
            this.chkDomingo.Name = "chkDomingo";
            this.chkDomingo.Size = new System.Drawing.Size(106, 28);
            this.chkDomingo.TabIndex = 7;
            this.chkDomingo.Text = "Domingo";
            this.chkDomingo.UseVisualStyleBackColor = true;
            // 
            // chkSabado
            // 
            this.chkSabado.AutoSize = true;
            this.chkSabado.Checked = true;
            this.chkSabado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSabado.Location = new System.Drawing.Point(494, 143);
            this.chkSabado.Name = "chkSabado";
            this.chkSabado.Size = new System.Drawing.Size(94, 28);
            this.chkSabado.TabIndex = 6;
            this.chkSabado.Text = "Sabado";
            this.chkSabado.UseVisualStyleBackColor = true;
            // 
            // chkViernes
            // 
            this.chkViernes.AutoSize = true;
            this.chkViernes.Checked = true;
            this.chkViernes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViernes.Location = new System.Drawing.Point(494, 99);
            this.chkViernes.Name = "chkViernes";
            this.chkViernes.Size = new System.Drawing.Size(94, 28);
            this.chkViernes.TabIndex = 5;
            this.chkViernes.Text = "Viernes";
            this.chkViernes.UseVisualStyleBackColor = true;
            // 
            // chkJueves
            // 
            this.chkJueves.AutoSize = true;
            this.chkJueves.Checked = true;
            this.chkJueves.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkJueves.Location = new System.Drawing.Point(39, 231);
            this.chkJueves.Name = "chkJueves";
            this.chkJueves.Size = new System.Drawing.Size(89, 28);
            this.chkJueves.TabIndex = 4;
            this.chkJueves.Text = "Jueves";
            this.chkJueves.UseVisualStyleBackColor = true;
            // 
            // chkMartes
            // 
            this.chkMartes.AutoSize = true;
            this.chkMartes.Checked = true;
            this.chkMartes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMartes.Location = new System.Drawing.Point(39, 143);
            this.chkMartes.Name = "chkMartes";
            this.chkMartes.Size = new System.Drawing.Size(85, 28);
            this.chkMartes.TabIndex = 3;
            this.chkMartes.Text = "Martes";
            this.chkMartes.UseVisualStyleBackColor = true;
            // 
            // chkMiercoles
            // 
            this.chkMiercoles.AutoSize = true;
            this.chkMiercoles.Checked = true;
            this.chkMiercoles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMiercoles.Location = new System.Drawing.Point(39, 186);
            this.chkMiercoles.Name = "chkMiercoles";
            this.chkMiercoles.Size = new System.Drawing.Size(111, 28);
            this.chkMiercoles.TabIndex = 3;
            this.chkMiercoles.Text = "Miércoles";
            this.chkMiercoles.UseVisualStyleBackColor = true;
            // 
            // chkLunes
            // 
            this.chkLunes.AutoSize = true;
            this.chkLunes.Checked = true;
            this.chkLunes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLunes.Location = new System.Drawing.Point(39, 99);
            this.chkLunes.Name = "chkLunes";
            this.chkLunes.Size = new System.Drawing.Size(81, 28);
            this.chkLunes.TabIndex = 2;
            this.chkLunes.Text = "Lunes";
            this.chkLunes.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(298, 31);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(364, 29);
            this.textNombre.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LimeGreen;
            this.panel1.Controls.Add(this.buttonEditar);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.nuevoHorario);
            this.panel1.Location = new System.Drawing.Point(-3, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(986, 72);
            this.panel1.TabIndex = 3;
            // 
            // buttonEditar
            // 
            this.buttonEditar.BackColor = System.Drawing.Color.White;
            this.buttonEditar.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.buttonEditar.FlatAppearance.BorderSize = 5;
            this.buttonEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.buttonEditar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.buttonEditar.Image = global::ValleVerde.Properties.Resources.modificar24;
            this.buttonEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonEditar.Location = new System.Drawing.Point(357, 15);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(88, 43);
            this.buttonEditar.TabIndex = 2;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonEditar.UseVisualStyleBackColor = false;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ValleVerde.Properties.Resources.LOGO;
            this.pictureBox1.Location = new System.Drawing.Point(-3, -3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // nuevoHorario
            // 
            this.nuevoHorario.BackColor = System.Drawing.Color.White;
            this.nuevoHorario.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.nuevoHorario.FlatAppearance.BorderSize = 5;
            this.nuevoHorario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nuevoHorario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.nuevoHorario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.nuevoHorario.Image = global::ValleVerde.Properties.Resources.mas24;
            this.nuevoHorario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nuevoHorario.Location = new System.Drawing.Point(201, 15);
            this.nuevoHorario.Name = "nuevoHorario";
            this.nuevoHorario.Size = new System.Drawing.Size(140, 43);
            this.nuevoHorario.TabIndex = 0;
            this.nuevoHorario.Text = "Nuevo Horario";
            this.nuevoHorario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.nuevoHorario.UseVisualStyleBackColor = false;
            this.nuevoHorario.Click += new System.EventHandler(this.nuevoHorario_Click);
            // 
            // idHorario
            // 
            this.idHorario.HeaderText = "IDHorario";
            this.idHorario.Name = "idHorario";
            this.idHorario.Visible = false;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            // 
            // domingo
            // 
            this.domingo.HeaderText = "Domingo";
            this.domingo.Name = "domingo";
            // 
            // lunes
            // 
            this.lunes.HeaderText = "Lunes";
            this.lunes.Name = "lunes";
            // 
            // martes
            // 
            this.martes.HeaderText = "Martes";
            this.martes.Name = "martes";
            // 
            // miercoles
            // 
            this.miercoles.HeaderText = "Miércoles";
            this.miercoles.Name = "miercoles";
            // 
            // jueves
            // 
            this.jueves.HeaderText = "Jueves";
            this.jueves.Name = "jueves";
            // 
            // viernes
            // 
            this.viernes.HeaderText = "Viernes";
            this.viernes.Name = "viernes";
            // 
            // sabado
            // 
            this.sabado.HeaderText = "Sabado";
            this.sabado.Name = "sabado";
            // 
            // Horario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 681);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupHorario);
            this.Controls.Add(this.dgvHorario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Horario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Horario Promoción";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorario)).EndInit();
            this.groupHorario.ResumeLayout(false);
            this.groupHorario.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedButton nuevoHorario;
        private System.Windows.Forms.DataGridView dgvHorario;
        private System.Windows.Forms.GroupBox groupHorario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.DateTimePicker lHFin;
        private System.Windows.Forms.DateTimePicker lHinicio;
        private System.Windows.Forms.CheckBox chkDomingo;
        private System.Windows.Forms.CheckBox chkSabado;
        private System.Windows.Forms.CheckBox chkViernes;
        private System.Windows.Forms.CheckBox chkJueves;
        private System.Windows.Forms.CheckBox chkMartes;
        private System.Windows.Forms.CheckBox chkMiercoles;
        private System.Windows.Forms.CheckBox chkLunes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dHFin;
        private System.Windows.Forms.DateTimePicker dHInicio;
        private System.Windows.Forms.DateTimePicker sHFin;
        private System.Windows.Forms.DateTimePicker sHInicio;
        private System.Windows.Forms.DateTimePicker vHFin;
        private System.Windows.Forms.DateTimePicker vHInicio;
        private System.Windows.Forms.DateTimePicker jHFin;
        private System.Windows.Forms.DateTimePicker jHInicio;
        private System.Windows.Forms.DateTimePicker miHFin;
        private System.Windows.Forms.DateTimePicker miHInicio;
        private System.Windows.Forms.DateTimePicker mHFin;
        private System.Windows.Forms.DateTimePicker mHInicio;
        private RoundedButton aceptar;
        private System.Windows.Forms.Panel panel1;
        private RoundedButton buttonEditar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idHorario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn domingo;
        private System.Windows.Forms.DataGridViewTextBoxColumn lunes;
        private System.Windows.Forms.DataGridViewTextBoxColumn martes;
        private System.Windows.Forms.DataGridViewTextBoxColumn miercoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn jueves;
        private System.Windows.Forms.DataGridViewTextBoxColumn viernes;
        private System.Windows.Forms.DataGridViewTextBoxColumn sabado;
    }
}