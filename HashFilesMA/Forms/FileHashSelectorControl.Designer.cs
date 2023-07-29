namespace HashFilesMA.Forms
{
    partial class FileHashSelectorControl
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileHashSelectorControl));
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSHA512 = new System.Windows.Forms.Button();
            this.btnSHA384 = new System.Windows.Forms.Button();
            this.btnSHA256 = new System.Windows.Forms.Button();
            this.btnSHA1 = new System.Windows.Forms.Button();
            this.btnMD5 = new System.Windows.Forms.Button();
            this.txtSHA512 = new System.Windows.Forms.TextBox();
            this.txtSHA384 = new System.Windows.Forms.TextBox();
            this.txtSHA256 = new System.Windows.Forms.TextBox();
            this.txtSHA1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMD5 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "MD5",
            "SHA1",
            "SHA256",
            "SHA384",
            "SHA512"});
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(216, 181);
            this.checkedListBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selecciona el tipo de hash a calcular";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSHA512);
            this.panel1.Controls.Add(this.btnSHA384);
            this.panel1.Controls.Add(this.btnSHA256);
            this.panel1.Controls.Add(this.btnSHA1);
            this.panel1.Controls.Add(this.btnMD5);
            this.panel1.Controls.Add(this.txtSHA512);
            this.panel1.Controls.Add(this.txtSHA384);
            this.panel1.Controls.Add(this.txtSHA256);
            this.panel1.Controls.Add(this.txtSHA1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtMD5);
            this.panel1.Controls.Add(this.checkedListBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 181);
            this.panel1.TabIndex = 3;
            // 
            // btnSHA512
            // 
            this.btnSHA512.FlatAppearance.BorderSize = 0;
            this.btnSHA512.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSHA512.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSHA512.Image = ((System.Drawing.Image)(resources.GetObject("btnSHA512.Image")));
            this.btnSHA512.Location = new System.Drawing.Point(615, 136);
            this.btnSHA512.Name = "btnSHA512";
            this.btnSHA512.Size = new System.Drawing.Size(24, 27);
            this.btnSHA512.TabIndex = 16;
            this.btnSHA512.UseVisualStyleBackColor = true;
            this.btnSHA512.Click += new System.EventHandler(this.btnCopyClipboard_Click);
            // 
            // btnSHA384
            // 
            this.btnSHA384.FlatAppearance.BorderSize = 0;
            this.btnSHA384.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSHA384.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSHA384.Image = ((System.Drawing.Image)(resources.GetObject("btnSHA384.Image")));
            this.btnSHA384.Location = new System.Drawing.Point(615, 106);
            this.btnSHA384.Name = "btnSHA384";
            this.btnSHA384.Size = new System.Drawing.Size(24, 27);
            this.btnSHA384.TabIndex = 15;
            this.btnSHA384.UseVisualStyleBackColor = true;
            this.btnSHA384.Click += new System.EventHandler(this.btnCopyClipboard_Click);
            // 
            // btnSHA256
            // 
            this.btnSHA256.FlatAppearance.BorderSize = 0;
            this.btnSHA256.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSHA256.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSHA256.Image = ((System.Drawing.Image)(resources.GetObject("btnSHA256.Image")));
            this.btnSHA256.Location = new System.Drawing.Point(615, 71);
            this.btnSHA256.Name = "btnSHA256";
            this.btnSHA256.Size = new System.Drawing.Size(24, 27);
            this.btnSHA256.TabIndex = 14;
            this.btnSHA256.UseVisualStyleBackColor = true;
            this.btnSHA256.Click += new System.EventHandler(this.btnCopyClipboard_Click);
            // 
            // btnSHA1
            // 
            this.btnSHA1.FlatAppearance.BorderSize = 0;
            this.btnSHA1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSHA1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSHA1.Image = ((System.Drawing.Image)(resources.GetObject("btnSHA1.Image")));
            this.btnSHA1.Location = new System.Drawing.Point(615, 39);
            this.btnSHA1.Name = "btnSHA1";
            this.btnSHA1.Size = new System.Drawing.Size(24, 27);
            this.btnSHA1.TabIndex = 13;
            this.btnSHA1.UseVisualStyleBackColor = true;
            this.btnSHA1.Click += new System.EventHandler(this.btnCopyClipboard_Click);
            // 
            // btnMD5
            // 
            this.btnMD5.FlatAppearance.BorderSize = 0;
            this.btnMD5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnMD5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMD5.Image = ((System.Drawing.Image)(resources.GetObject("btnMD5.Image")));
            this.btnMD5.Location = new System.Drawing.Point(615, 7);
            this.btnMD5.Name = "btnMD5";
            this.btnMD5.Size = new System.Drawing.Size(24, 27);
            this.btnMD5.TabIndex = 12;
            this.btnMD5.Tag = "";
            this.btnMD5.UseVisualStyleBackColor = true;
            this.btnMD5.Click += new System.EventHandler(this.btnCopyClipboard_Click);
            // 
            // txtSHA512
            // 
            this.txtSHA512.Location = new System.Drawing.Point(302, 143);
            this.txtSHA512.Name = "txtSHA512";
            this.txtSHA512.ReadOnly = true;
            this.txtSHA512.Size = new System.Drawing.Size(307, 20);
            this.txtSHA512.TabIndex = 11;
            // 
            // txtSHA384
            // 
            this.txtSHA384.Location = new System.Drawing.Point(302, 113);
            this.txtSHA384.Name = "txtSHA384";
            this.txtSHA384.ReadOnly = true;
            this.txtSHA384.Size = new System.Drawing.Size(307, 20);
            this.txtSHA384.TabIndex = 10;
            // 
            // txtSHA256
            // 
            this.txtSHA256.Location = new System.Drawing.Point(302, 78);
            this.txtSHA256.Name = "txtSHA256";
            this.txtSHA256.ReadOnly = true;
            this.txtSHA256.Size = new System.Drawing.Size(307, 20);
            this.txtSHA256.TabIndex = 9;
            // 
            // txtSHA1
            // 
            this.txtSHA1.Location = new System.Drawing.Point(302, 46);
            this.txtSHA1.Name = "txtSHA1";
            this.txtSHA1.ReadOnly = true;
            this.txtSHA1.Size = new System.Drawing.Size(307, 20);
            this.txtSHA1.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(222, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 18);
            this.label6.TabIndex = 7;
            this.label6.Text = "SHA512:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(222, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "SHA384:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(222, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "SHA256:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(222, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "SHA1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(222, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "MD5:";
            // 
            // txtMD5
            // 
            this.txtMD5.Location = new System.Drawing.Point(302, 14);
            this.txtMD5.Name = "txtMD5";
            this.txtMD5.ReadOnly = true;
            this.txtMD5.Size = new System.Drawing.Size(307, 20);
            this.txtMD5.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FileHashSelectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "FileHashSelectorControl";
            this.Size = new System.Drawing.Size(654, 221);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSHA512;
        private System.Windows.Forms.TextBox txtSHA384;
        private System.Windows.Forms.TextBox txtSHA256;
        private System.Windows.Forms.TextBox txtSHA1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMD5;
        private System.Windows.Forms.Button btnMD5;
        private System.Windows.Forms.Button btnSHA512;
        private System.Windows.Forms.Button btnSHA384;
        private System.Windows.Forms.Button btnSHA256;
        private System.Windows.Forms.Button btnSHA1;
        private System.Windows.Forms.Timer timer1;
    }
}
