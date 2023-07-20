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
            this.prgFileHash = new System.Windows.Forms.ProgressBar();
            this.btnCancelar = new HashFilesMA.Controles.ButtonCustom();
            this.btnComparar = new HashFilesMA.Controles.ButtonCustom();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tolNombreArchivo = new System.Windows.Forms.ToolStripStatusLabel();
            this.backProcressFile = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configuracionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.habilitarNotificacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.fileHashSelectorControl1 = new HashFilesMA.Forms.FileHashSelectorControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.fileHmacSelectorControl1 = new HashFilesMA.Forms.FileHmacSelectorControl();
            this.btnOpenFile = new HashFilesMA.Controles.ButtonCustom();
            this.lblProgreso = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // prgFileHash
            // 
            this.prgFileHash.AccessibleRole = System.Windows.Forms.AccessibleRole.ProgressBar;
            this.prgFileHash.Location = new System.Drawing.Point(255, 541);
            this.prgFileHash.Name = "prgFileHash";
            this.prgFileHash.Size = new System.Drawing.Size(386, 33);
            this.prgFileHash.TabIndex = 3;
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
            this.btnCancelar.Location = new System.Drawing.Point(526, 474);
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
            this.btnComparar.BorderRadiusPercent = 100;
            this.btnComparar.BorderSizePx = 2;
            this.btnComparar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComparar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComparar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComparar.GradientBorder = true;
            this.btnComparar.GradientBorderAngle = 45;
            this.btnComparar.Location = new System.Drawing.Point(174, 474);
            this.btnComparar.Name = "btnComparar";
            this.btnComparar.Size = new System.Drawing.Size(139, 38);
            this.btnComparar.TabIndex = 4;
            this.btnComparar.Text = "Comparar";
            this.btnComparar.UseCompatibleTextRendering = true;
            this.btnComparar.UseVisualStyleBackColor = true;
            this.btnComparar.Click += new System.EventHandler(this.btnComparar_Click);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 609);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(896, 22);
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuracionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(896, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configuracionesToolStripMenuItem
            // 
            this.configuracionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.habilitarNotificacionesToolStripMenuItem});
            this.configuracionesToolStripMenuItem.Name = "configuracionesToolStripMenuItem";
            this.configuracionesToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.configuracionesToolStripMenuItem.Text = "Configuraciones";
            // 
            // habilitarNotificacionesToolStripMenuItem
            // 
            this.habilitarNotificacionesToolStripMenuItem.Checked = true;
            this.habilitarNotificacionesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.habilitarNotificacionesToolStripMenuItem.Name = "habilitarNotificacionesToolStripMenuItem";
            this.habilitarNotificacionesToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.habilitarNotificacionesToolStripMenuItem.Text = "Habilitar notificaciones";
            this.habilitarNotificacionesToolStripMenuItem.Click += new System.EventHandler(this.habilitarNotificacionesToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 155);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(872, 313);
            this.tabControl1.TabIndex = 9;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.fileHashSelectorControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(864, 287);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hash";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // fileHashSelectorControl1
            // 
            this.fileHashSelectorControl1.Location = new System.Drawing.Point(127, 30);
            this.fileHashSelectorControl1.Name = "fileHashSelectorControl1";
            this.fileHashSelectorControl1.Size = new System.Drawing.Size(552, 221);
            this.fileHashSelectorControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.fileHmacSelectorControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(864, 287);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "HMAC";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // fileHmacSelectorControl1
            // 
            this.fileHmacSelectorControl1.Location = new System.Drawing.Point(173, 39);
            this.fileHmacSelectorControl1.Name = "fileHmacSelectorControl1";
            this.fileHmacSelectorControl1.Size = new System.Drawing.Size(547, 208);
            this.fileHmacSelectorControl1.TabIndex = 0;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.AllowDrop = true;
            this.btnOpenFile.BorderColor = System.Drawing.Color.Crimson;
            this.btnOpenFile.BorderColor2 = System.Drawing.Color.CornflowerBlue;
            this.btnOpenFile.BorderDashStyle = System.Drawing.Drawing2D.DashCap.Round;
            this.btnOpenFile.BorderLineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            this.btnOpenFile.BorderRadiusPercent = 7;
            this.btnOpenFile.BorderSizePx = 3;
            this.btnOpenFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenFile.GradientBorder = true;
            this.btnOpenFile.GradientBorderAngle = 45;
            this.btnOpenFile.Location = new System.Drawing.Point(277, 30);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(343, 119);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Click para abrir el archivo\r\n -o- \r\nArrastra el archivo";
            this.btnOpenFile.UseCompatibleTextRendering = true;
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            this.btnOpenFile.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnOpenFile_DragDrop);
            this.btnOpenFile.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnOpenFile_DragEnter);
            this.btnOpenFile.DragLeave += new System.EventHandler(this.btnOpenFile_DragLeave);
            // 
            // lblProgreso
            // 
            this.lblProgreso.AutoSize = true;
            this.lblProgreso.BackColor = System.Drawing.Color.Transparent;
            this.lblProgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgreso.Location = new System.Drawing.Point(433, 548);
            this.lblProgreso.Name = "lblProgreso";
            this.lblProgreso.Size = new System.Drawing.Size(31, 18);
            this.lblProgreso.TabIndex = 7;
            this.lblProgreso.Text = "0%";
            // 
            // FrmHash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 631);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnComparar);
            this.Controls.Add(this.lblProgreso);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.prgFileHash);
            this.Controls.Add(this.btnOpenFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmHash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hash";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Controles.ButtonCustom btnOpenFile;
        private System.Windows.Forms.ProgressBar prgFileHash;
        private Controles.ButtonCustom btnComparar;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tolNombreArchivo;
        private System.ComponentModel.BackgroundWorker backProcressFile;
        private Controles.ButtonCustom btnCancelar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuracionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem habilitarNotificacionesToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblProgreso;
        private Forms.FileHashSelectorControl fileHashSelectorControl1;
        private Forms.FileHmacSelectorControl fileHmacSelectorControl1;
    }
}

