namespace HashFilesMA.Forms
{
    partial class FileHmacSelectorControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileHmacSelectorControl));
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClave = new HashFilesMA.Controles.ButtonCustom();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "HMACMD5",
            "HMACSHA1",
            "HMACSHA256",
            "HMACSHA384",
            "HMACSHA512"});
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(139, 170);
            this.checkedListBox1.TabIndex = 0;
            // 
            // panel1
            // 
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
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 170);
            this.panel1.TabIndex = 5;
            // 
            // txtSHA512
            // 
            this.txtSHA512.Location = new System.Drawing.Point(261, 135);
            this.txtSHA512.Name = "txtSHA512";
            this.txtSHA512.Size = new System.Drawing.Size(216, 20);
            this.txtSHA512.TabIndex = 11;
            // 
            // txtSHA384
            // 
            this.txtSHA384.Location = new System.Drawing.Point(261, 105);
            this.txtSHA384.Name = "txtSHA384";
            this.txtSHA384.Size = new System.Drawing.Size(216, 20);
            this.txtSHA384.TabIndex = 10;
            // 
            // txtSHA256
            // 
            this.txtSHA256.Location = new System.Drawing.Point(261, 70);
            this.txtSHA256.Name = "txtSHA256";
            this.txtSHA256.Size = new System.Drawing.Size(216, 20);
            this.txtSHA256.TabIndex = 9;
            // 
            // txtSHA1
            // 
            this.txtSHA1.Location = new System.Drawing.Point(261, 38);
            this.txtSHA1.Name = "txtSHA1";
            this.txtSHA1.Size = new System.Drawing.Size(216, 20);
            this.txtSHA1.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(157, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "HMACSHA512:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(157, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "HMACSHA384:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(157, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "HMACSHA256:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(157, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "HMACSHA1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(157, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "HMACMD5:";
            // 
            // txtMD5
            // 
            this.txtMD5.Location = new System.Drawing.Point(261, 3);
            this.txtMD5.Name = "txtMD5";
            this.txtMD5.Size = new System.Drawing.Size(216, 20);
            this.txtMD5.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Selecciona el tipo hmac calcular";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(243, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 18);
            this.label7.TabIndex = 17;
            this.label7.Text = "Clave:";
            // 
            // btnClave
            // 
            this.btnClave.BorderColor = System.Drawing.Color.Crimson;
            this.btnClave.BorderColor2 = System.Drawing.Color.RoyalBlue;
            this.btnClave.BorderDashStyle = System.Drawing.Drawing2D.DashCap.Round;
            this.btnClave.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.btnClave.BorderRadiusPercent = 0;
            this.btnClave.BorderSizePx = 0;
            this.btnClave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClave.GradientBorder = true;
            this.btnClave.GradientBorderAngle = 45;
            this.btnClave.Image = ((System.Drawing.Image)(resources.GetObject("btnClave.Image")));
            this.btnClave.Location = new System.Drawing.Point(297, 6);
            this.btnClave.Name = "btnClave";
            this.btnClave.Size = new System.Drawing.Size(42, 30);
            this.btnClave.TabIndex = 16;
            this.btnClave.UseVisualStyleBackColor = true;
            this.btnClave.Click += new System.EventHandler(this.btnClave_Click);
            // 
            // FileHmacSelectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnClave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "FileHmacSelectorControl";
            this.Size = new System.Drawing.Size(607, 212);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private Controles.ButtonCustom btnClave;
    }
}
