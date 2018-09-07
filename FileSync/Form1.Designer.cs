namespace FileSync
{
    partial class frmFileSync
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFileSync));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dlgOrigem = new System.Windows.Forms.FolderBrowserDialog();
            this.dlgDestino = new System.Windows.Forms.FolderBrowserDialog();
            this.txtDirOrigem = new System.Windows.Forms.TextBox();
            this.txtDirDestino = new System.Windows.Forms.TextBox();
            this.btnSelOrigem = new System.Windows.Forms.Button();
            this.btnSelDestino = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.bw = new System.ComponentModel.BackgroundWorker();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.lblQtde = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUltimoArquivo = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCarregar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.lblVersao = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTipoSubPasta = new System.Windows.Forms.ComboBox();
            this.cmbTipoSync = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnLog = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.dlgLog = new System.Windows.Forms.SaveFileDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(514, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Este programa sincroniza arquivos copiando/movendo arquivos de um diretório de or" +
    "igem para um destino assim que um arquivo for colocado na pasta de origem\r\n.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Diretório de origem";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Diretório de destino";
            // 
            // txtDirOrigem
            // 
            this.txtDirOrigem.Location = new System.Drawing.Point(16, 98);
            this.txtDirOrigem.Name = "txtDirOrigem";
            this.txtDirOrigem.Size = new System.Drawing.Size(459, 22);
            this.txtDirOrigem.TabIndex = 3;
            // 
            // txtDirDestino
            // 
            this.txtDirDestino.Location = new System.Drawing.Point(16, 161);
            this.txtDirDestino.Name = "txtDirDestino";
            this.txtDirDestino.Size = new System.Drawing.Size(459, 22);
            this.txtDirDestino.TabIndex = 4;
            // 
            // btnSelOrigem
            // 
            this.btnSelOrigem.Location = new System.Drawing.Point(482, 98);
            this.btnSelOrigem.Name = "btnSelOrigem";
            this.btnSelOrigem.Size = new System.Drawing.Size(42, 23);
            this.btnSelOrigem.TabIndex = 5;
            this.btnSelOrigem.Text = "...";
            this.btnSelOrigem.UseVisualStyleBackColor = true;
            this.btnSelOrigem.Click += new System.EventHandler(this.btnSelOrigem_Click);
            // 
            // btnSelDestino
            // 
            this.btnSelDestino.Location = new System.Drawing.Point(481, 160);
            this.btnSelDestino.Name = "btnSelDestino";
            this.btnSelDestino.Size = new System.Drawing.Size(42, 23);
            this.btnSelDestino.TabIndex = 6;
            this.btnSelDestino.Text = "...";
            this.btnSelDestino.UseVisualStyleBackColor = true;
            this.btnSelDestino.Click += new System.EventHandler(this.btnSelDestino_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(391, 395);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(129, 39);
            this.btnIniciar.TabIndex = 7;
            this.btnIniciar.Tag = "";
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // bw
            // 
            this.bw.WorkerReportsProgress = true;
            this.bw.WorkerSupportsCancellation = true;
            this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "FileSync";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Location = new System.Drawing.Point(13, 451);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(265, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "Quantidade de arquivos sincronizados:";
            // 
            // lblQtde
            // 
            this.lblQtde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblQtde.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblQtde.Location = new System.Drawing.Point(278, 451);
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(245, 28);
            this.lblQtde.TabIndex = 9;
            this.lblQtde.Text = "0";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(13, 479);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 28);
            this.label5.TabIndex = 10;
            this.label5.Text = "Último arquivo:";
            // 
            // lblUltimoArquivo
            // 
            this.lblUltimoArquivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUltimoArquivo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUltimoArquivo.Location = new System.Drawing.Point(16, 498);
            this.lblUltimoArquivo.Name = "lblUltimoArquivo";
            this.lblUltimoArquivo.Size = new System.Drawing.Size(507, 28);
            this.lblUltimoArquivo.TabIndex = 11;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(16, 217);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(507, 22);
            this.txtFiltro.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Filtro";
            // 
            // btnCarregar
            // 
            this.btnCarregar.Location = new System.Drawing.Point(13, 395);
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.Size = new System.Drawing.Size(129, 39);
            this.btnCarregar.TabIndex = 14;
            this.btnCarregar.Tag = "";
            this.btnCarregar.Text = "Carregar Padrão";
            this.btnCarregar.UseVisualStyleBackColor = true;
            this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(149, 395);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(129, 39);
            this.btnGravar.TabIndex = 15;
            this.btnGravar.Tag = "";
            this.btnGravar.Text = "Gravar Padrão";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // lblVersao
            // 
            this.lblVersao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersao.Location = new System.Drawing.Point(304, 549);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(223, 22);
            this.lblVersao.TabIndex = 16;
            this.lblVersao.Text = "Versão";
            this.lblVersao.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 318);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(292, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "Tipo de subpasta dentro da pasta de destino";
            // 
            // cmbTipoSubPasta
            // 
            this.cmbTipoSubPasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoSubPasta.FormattingEnabled = true;
            this.cmbTipoSubPasta.Items.AddRange(new object[] {
            "Não criar pasta no destino",
            "Por ano e mês (AAAA_MM)",
            "Por ano\\mês (AAAA\\MM)",
            "Por ano, mês e dia (AAAA_MM_DD)",
            "Por ano\\mês\\dia (AAAA\\MM\\DD)",
            "Copiar a última pasta  do arquivo",
            "Copiar as duas últimas pastas do arquivo"});
            this.cmbTipoSubPasta.Location = new System.Drawing.Point(16, 338);
            this.cmbTipoSubPasta.Name = "cmbTipoSubPasta";
            this.cmbTipoSubPasta.Size = new System.Drawing.Size(310, 24);
            this.cmbTipoSubPasta.TabIndex = 19;
            // 
            // cmbTipoSync
            // 
            this.cmbTipoSync.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoSync.FormattingEnabled = true;
            this.cmbTipoSync.Items.AddRange(new object[] {
            "Copiar arquivos",
            "Mover arquivos"});
            this.cmbTipoSync.Location = new System.Drawing.Point(346, 338);
            this.cmbTipoSync.Name = "cmbTipoSync";
            this.cmbTipoSync.Size = new System.Drawing.Size(178, 24);
            this.cmbTipoSync.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(346, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 17);
            this.label8.TabIndex = 20;
            this.label8.Text = "Tipo de Sync";
            // 
            // btnLog
            // 
            this.btnLog.Location = new System.Drawing.Point(481, 278);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(42, 23);
            this.btnLog.TabIndex = 24;
            this.btnLog.Text = "...";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(16, 279);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(459, 22);
            this.txtLog.TabIndex = 23;
            // 
            // dlgLog
            // 
            this.dlgLog.Filter = "Arquivos de log|*.log|Todos os arquivos|*.*";
            this.dlgLog.Title = "Salvar log em";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 256);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(353, 17);
            this.label9.TabIndex = 25;
            this.label9.Text = "Arquivo de log (Deixar em branco para não gravar log)";
            // 
            // frmFileSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 580);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.cmbTipoSync);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbTipoSubPasta);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnCarregar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.lblUltimoArquivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblQtde);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.btnSelDestino);
            this.Controls.Add(this.btnSelOrigem);
            this.Controls.Add(this.txtDirDestino);
            this.Controls.Add(this.txtDirOrigem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmFileSync";
            this.Text = "FileSync - Sincronizador de arquivos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFileSync_FormClosing);
            this.Load += new System.EventHandler(this.frmFileSync_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog dlgOrigem;
        private System.Windows.Forms.FolderBrowserDialog dlgDestino;
        private System.Windows.Forms.TextBox txtDirOrigem;
        private System.Windows.Forms.TextBox txtDirDestino;
        private System.Windows.Forms.Button btnSelOrigem;
        private System.Windows.Forms.Button btnSelDestino;
        private System.Windows.Forms.Button btnIniciar;
        private System.ComponentModel.BackgroundWorker bw;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblQtde;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUltimoArquivo;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCarregar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbTipoSubPasta;
        private System.Windows.Forms.ComboBox cmbTipoSync;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.SaveFileDialog dlgLog;
        private System.Windows.Forms.Label label9;
    }
}

