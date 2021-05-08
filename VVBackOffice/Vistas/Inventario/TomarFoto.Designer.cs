namespace ValleVerde
{
    partial class TomarFoto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TomarFoto));
            this.pictureBoxC = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.btnO = new ValleVerde.RoundedButton();
            this.btnT = new ValleVerde.RoundedButton();
            this.roundedButton2 = new ValleVerde.RoundedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxC)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxC
            // 
            this.pictureBoxC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxC.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxC.Name = "pictureBoxC";
            this.pictureBoxC.Size = new System.Drawing.Size(676, 550);
            this.pictureBoxC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxC.TabIndex = 0;
            this.pictureBoxC.TabStop = false;
            // 
            // btnO
            // 
            this.btnO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnO.BackColor = System.Drawing.Color.White;
            this.btnO.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnO.FlatAppearance.BorderSize = 5;
            this.btnO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnO.Location = new System.Drawing.Point(250, 590);
            this.btnO.Name = "btnO";
            this.btnO.Size = new System.Drawing.Size(194, 46);
            this.btnO.TabIndex = 9;
            this.btnO.Text = "Empezar";
            this.btnO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnO.UseVisualStyleBackColor = false;
            this.btnO.Visible = false;
            this.btnO.Click += new System.EventHandler(this.roundedButton4_Click);
            // 
            // btnT
            // 
            this.btnT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnT.BackColor = System.Drawing.Color.White;
            this.btnT.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnT.FlatAppearance.BorderSize = 5;
            this.btnT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.btnT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.btnT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnT.Location = new System.Drawing.Point(468, 590);
            this.btnT.Name = "btnT";
            this.btnT.Size = new System.Drawing.Size(194, 46);
            this.btnT.TabIndex = 10;
            this.btnT.Text = "Tomar foto";
            this.btnT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnT.UseVisualStyleBackColor = false;
            this.btnT.Click += new System.EventHandler(this.roundedButton1_Click);
            // 
            // roundedButton2
            // 
            this.roundedButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.roundedButton2.BackColor = System.Drawing.Color.White;
            this.roundedButton2.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.roundedButton2.FlatAppearance.BorderSize = 5;
            this.roundedButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundedButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.roundedButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.roundedButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roundedButton2.Location = new System.Drawing.Point(27, 590);
            this.roundedButton2.Name = "roundedButton2";
            this.roundedButton2.Size = new System.Drawing.Size(194, 46);
            this.roundedButton2.TabIndex = 11;
            this.roundedButton2.Text = "Cancelar";
            this.roundedButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.roundedButton2.UseVisualStyleBackColor = false;
            this.roundedButton2.Click += new System.EventHandler(this.roundedButton2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBoxC);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(676, 550);
            this.panel1.TabIndex = 12;
            // 
            // TomarFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 648);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.roundedButton2);
            this.Controls.Add(this.btnT);
            this.Controls.Add(this.btnO);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TomarFoto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TomarFoto";
            this.Load += new System.EventHandler(this.TomarFoto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxC)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxC;
        private RoundedButton btnO;
        private RoundedButton btnT;
        private RoundedButton roundedButton2;
        private System.Windows.Forms.Panel panel1;
    }
}