namespace HashFilesMA
{
    partial class FrmHash
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHash));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHASH = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxTipoHash = new System.Windows.Forms.ComboBox();
            this.txtHASHComp = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tolNombreArchivo = new System.Windows.Forms.ToolStripStatusLabel();
            this.backProcressFile = new System.ComponentModel.BackgroundWorker();
            this.lblProgreso = new System.Windows.Forms.Label();
            this.btnCancelar = new HashFilesMA.Controles.ButtonCustom();
            this.btnComparar = new HashFilesMA.Controles.ButtonCustom();
            this.btnOpenFile = new HashFilesMA.Controles.ButtonCustom();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "HASH:";
            // 
            // txtHASH
            // 
            this.txtHASH.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHASH.Location = new System.Drawing.Point(60, 59);
            this.txtHASH.Multiline = true;
            this.txtHASH.Name = "txtHASH";
            this.txtHASH.ReadOnly = true;
            this.txtHASH.Size = new System.Drawing.Size(308, 26);
            this.txtHASH.TabIndex = 2;
            // 
            // progressBar1
            // 
            this.progressBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.ProgressBar;
            this.progressBar1.Location = new System.Drawing.Point(245, 354);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(386, 33);
            this.progressBar1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbxTipoHash);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.btnComparar);
            this.groupBox1.Controls.Add(this.txtHASHComp);
            this.groupBox1.Controls.Add(this.txtHASH);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(27, 175);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 145);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comparar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tipo hash:";
            // 
            // cbxTipoHash
            // 
            this.cbxTipoHash.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipoHash.FormattingEnabled = true;
            this.cbxTipoHash.Location = new System.Drawing.Point(90, 20);
            this.cbxTipoHash.Name = "cbxTipoHash";
            this.cbxTipoHash.Size = new System.Drawing.Size(121, 24);
            this.cbxTipoHash.TabIndex = 9;
            this.cbxTipoHash.SelectedIndexChanged += new System.EventHandler(this.cbxTipoHash_SelectedIndexChanged);
            // 
            // txtHASHComp
            // 
            this.txtHASHComp.AllowDrop = true;
            this.txtHASHComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHASHComp.Location = new System.Drawing.Point(476, 61);
            this.txtHASHComp.Name = "txtHASHComp";
            this.txtHASHComp.Size = new System.Drawing.Size(320, 24);
            this.txtHASHComp.TabIndex = 3;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tolNombreArchivo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 445);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(857, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(51, 17);
            this.toolStripStatusLabel1.Text = "Archivo:";
            // 
            // tolNombreArchivo
            // 
            this.tolNombreArchivo.Name = "tolNombreArchivo";
            this.tolNombreArchivo.Size = new System.Drawing.Size(0, 17);
            // 
            // backProcressFile
            // 
            this.backProcressFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backProcressFile_DoWork);
            // 
            // lblProgreso
            // 
            this.lblProgreso.AutoSize = true;
            this.lblProgreso.BackColor = System.Drawing.Color.Transparent;
            this.lblProgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgreso.Location = new System.Drawing.Point(415, 361);
            this.lblProgreso.Name = "lblProgreso";
            this.lblProgreso.Size = new System.Drawing.Size(31, 18);
            this.lblProgreso.TabIndex = 7;
            this.lblProgreso.Text = "0%";
            // 
            // btnCancelar
            // 
            this.btnCancelar.AllowDrop = true;
            this.btnCancelar.BorderColor = System.Drawing.Color.Coral;
            this.btnCancelar.BorderColor2 = System.Drawing.Color.Crimson;
            this.btnCancelar.BorderDashStyle = System.Drawing.Drawing2D.DashCap.Round;
            this.btnCancelar.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.btnCancelar.BorderRadiusPercent = 100;
            this.btnCancelar.BorderSizePx = 2;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.GradientBorder = true;
            this.btnCancelar.GradientBorderAngle = 45;
            this.btnCancelar.Location = new System.Drawing.Point(657, 91);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(139, 38);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseCompatibleTextRendering = true;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnComparar
            // 
            this.btnComparar.AllowDrop = true;
            this.btnComparar.BorderColor = System.Drawing.Color.LightSeaGreen;
            this.btnComparar.BorderColor2 = System.Drawing.Color.DodgerBlue;
            this.btnComparar.BorderDashStyle = System.Drawing.Drawing2D.DashCap.Round;
            this.btnComparar.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.btnComparar.BorderRadiusPercent = 50;
            this.btnComparar.BorderSizePx = 2;
            this.btnComparar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComparar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComparar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComparar.GradientBorder = true;
            this.btnComparar.GradientBorderAngle = 45;
            this.btnComparar.Location = new System.Drawing.Point(326, 91);
            this.btnComparar.Name = "btnComparar";
            this.btnComparar.Size = new System.Drawing.Size(139, 38);
            this.btnComparar.TabIndex = 4;
            this.btnComparar.Text = "Comparar";
            this.btnComparar.UseCompatibleTextRendering = true;
            this.btnComparar.UseVisualStyleBackColor = true;
            this.btnComparar.Click += new System.EventHandler(this.btnComparar_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.AllowDrop = true;
            this.btnOpenFile.BorderColor = System.Drawing.Color.Crimson;
            this.btnOpenFile.BorderColor2 = System.Drawing.Color.CornflowerBlue;
            this.btnOpenFile.BorderDashStyle = System.Drawing.Drawing2D.DashCap.Round;
            this.btnOpenFile.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.btnOpenFile.BorderRadiusPercent = 20;
            this.btnOpenFile.BorderSizePx = 3;
            this.btnOpenFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFile.GradientBorder = true;
            this.btnOpenFile.GradientBorderAngle = 45;
            this.btnOpenFile.Location = new System.Drawing.Point(281, 12);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(314, 157);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Click para abrir el archivo\r\n -o- \r\nArrastra el archivo";
            this.btnOpenFile.UseCompatibleTextRendering = true;
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            this.btnOpenFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnOpenFile_DragDrop);
            this.btnOpenFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnOpenFile_DragEnter);
            this.btnOpenFile.DragLeave += new System.EventHandler(this.btnOpenFile_DragLeave);
            // 
            // FrmHash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 467);
            this.Controls.Add(this.lblProgreso);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnOpenFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmHash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MD5";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Controles.ButtonCustom btnOpenFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHASH;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtHASHComp;
        private Controles.ButtonCustom btnComparar;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tolNombreArchivo;
        private System.ComponentModel.BackgroundWorker backProcressFile;
        private Controles.ButtonCustom btnCancelar;
        private System.Windows.Forms.ComboBox cbxTipoHash;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblProgreso;
    }
}

