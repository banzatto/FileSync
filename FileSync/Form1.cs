using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace FileSync
{
    public partial class frmFileSync : Form
    {

        public delegate void DelegateAtualizaTela(int qtde, String ultArq);

        DelegateAtualizaTela atualizatela;

        public ConfigSync configsync;

        public int QtdeArquivos = 0;
        public frmFileSync()
        {
            InitializeComponent();            
        }



        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            IniciarSync();            
        }

        public void IniciarSync()
        {
            if (!CheckConfig())
            {
                return;
            }
            if ((int)btnIniciar.Tag == 0)
            {
                SalvarConfiguracao(false);
                bw.RunWorkerAsync();
                btnIniciar.Tag = 1;
                atualizatela(QtdeArquivos, "");

            }
            else
            {
                bw.CancelAsync();
                btnIniciar.Tag = 0;
            }
            ConfigUI();
        }

        private bool CheckConfig()
        {
            bool ret = true;
            if (String.IsNullOrWhiteSpace(txtDirOrigem.Text))
            {
                MostraErro("Origem não pode estar em branco");
                ret = false;              
            } else
            {
                if (!Directory.Exists(txtDirOrigem.Text))
                {
                    MostraErro("Origem tem que existir");
                    ret = false;
                }
            }
            
            if (String.IsNullOrWhiteSpace(txtDirDestino.Text))
            {
                MostraErro("Destino não pode estar em branco");
                ret = false;
            }
            else
            {
                if (!Directory.Exists(txtDirDestino.Text))
                {
                    MostraErro("Destino tem que existir");
                    ret = false;
                }
            }
            if (String.IsNullOrWhiteSpace(txtFiltro.Text))
            {
                MostraErro("Filtro não pode estar em branco");
                ret = false;
            }

            return ret;
        }



        public void MostraErro(String msg)
        {
            MessageBox.Show(msg, "FileSync", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ConfigUI()
        {
            bool iniciado = (int)btnIniciar.Tag == 1;

            if (!iniciado)
            {
                btnIniciar.Text = "Iniciar";
            }
            else
            {
                btnIniciar.Text = "Parar";
            }

            
            txtDirDestino.Enabled = !iniciado;
            txtDirOrigem.Enabled = !iniciado;
            btnSelOrigem.Enabled = !iniciado;
            btnSelDestino.Enabled = !iniciado;
            txtFiltro.Enabled = !iniciado;
            txtLog.Enabled = !iniciado;
            btnLog.Enabled = !iniciado;
            btnCarregar.Enabled = !iniciado;
            btnGravar.Enabled = !iniciado;
            cmbTipoSubPasta.Enabled = !iniciado;
            cmbTipoSync.Enabled = !iniciado;
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            QtdeArquivos = 0;
            FileSystemWatcher watcher = new FileSystemWatcher();
            
            
            watcher.Path = txtDirOrigem.Text;
            watcher.Filter = txtFiltro.Text;
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName;

            watcher.IncludeSubdirectories = true;
            watcher.Created += Watcher_Created;
            watcher.Changed += Watcher_Changed;
            watcher.Deleted += Watcher_Deleted;
            watcher.Renamed += Watcher_Renamed;

            watcher.EnableRaisingEvents = true;


            while (bw.IsBusy)
            {
                if (bw.CancellationPending)
                {
                    e.Cancel = true;
                    watcher.EnableRaisingEvents = false;
                    watcher.Dispose();
                    break;
                }
            }


        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            

        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            

        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            if (!File.GetAttributes(e.FullPath).HasFlag(FileAttributes.Directory))
            {
                if (CopiaParaDestino(e.FullPath))
                {
                    QtdeArquivos++;
                    this.Invoke(atualizatela, QtdeArquivos, e.Name);
                }
            }

        }

        private void frmFileSync_Load(object sender, EventArgs e)
        {

            lblVersao.Text = "Versão "+ Application.ProductVersion;

            btnIniciar.Tag = 0;
            atualizatela = new DelegateAtualizaTela(AtualizaTela);
            CarregarConfiguracao();
            String[] args = Environment.GetCommandLineArgs();
           
            if ( Array.FindIndex(args, x=> x.Equals("autostart",StringComparison.InvariantCultureIgnoreCase)) >= 0)                                            
            {                
                IniciarSync();
            }


        }

        public void AtualizaTela(int qtde, String ultArq)
        {
            lblQtde.Text = qtde.ToString();
            lblUltimoArquivo.Text = ultArq;
        }

        private void btnSelOrigem_Click(object sender, EventArgs e)
        {
            dlgOrigem.SelectedPath = txtDirOrigem.Text;
           
            if (dlgOrigem.ShowDialog() == DialogResult.OK)
            {
                txtDirOrigem.Text = dlgOrigem.SelectedPath;
            }
        }

        private void btnSelDestino_Click(object sender, EventArgs e)
        {
            dlgDestino.SelectedPath = txtDirDestino.Text;
            if (dlgDestino.ShowDialog() == DialogResult.OK)
            {
                txtDirDestino.Text = dlgDestino.SelectedPath;
            }
        }


        
        public bool CopiaParaDestino(String nomeArq)
        {
            bool ret = false;

            DateTime dt = File.GetCreationTime(nomeArq);
            String subpasta = "";
            String[] partArq = nomeArq.Split(new Char[] { Path.DirectorySeparatorChar });
            switch (configsync.TipoSubPasta)
            {
                case ConfigSync.eTipoSubPasta.AAAA_MM:
                    subpasta = dt.ToString("yyyy_MM");
                    break;
                case ConfigSync.eTipoSubPasta.AAAA_e_MM:
                    subpasta = $"{dt:yyyy}\\{dt:MM}";
                    break;
                case ConfigSync.eTipoSubPasta.AAAA_MM_DD:
                    subpasta = dt.ToString("yyyy_MM_dd");
                    break;
                case ConfigSync.eTipoSubPasta.AAAA_e_MM_e_DD:
                    subpasta = $"{dt:yyyy}\\{dt:MM}\\{dt:dd}";
                    break;
                case ConfigSync.eTipoSubPasta.CopiaUltimaPasta:
                    if (partArq.Length - 2 >= 1)
                       subpasta = partArq[partArq.Length - 2];
                    break;
                case ConfigSync.eTipoSubPasta.Copia2UltimasPastas:
                    if (partArq.Length -3 >= 1)
                        subpasta = partArq[partArq.Length - 3] + '\\' + partArq[partArq.Length - 2];
                    break;
            }

            String destino = Path.Combine(configsync.Destino, subpasta);
            if (!Directory.Exists(destino))
            {
                Directory.CreateDirectory(destino);
                Log(configsync.Log, $"Criado pasta {destino}");
            }
            if (configsync.TipoSync == ConfigSync.eTipoSync.Copiar)
            {
                try
                {
                    File.Copy(nomeArq, Path.Combine(destino, Path.GetFileName(nomeArq)), true);
                    Log(configsync.Log, $"Arquivo {nomeArq} COPIADO para {destino}");
                } catch (Exception ex)
                {
                    Log(configsync.Log, $"ERRO ao copiar arquivo {nomeArq} para {destino} ERRO: {ex.Message}");
                }
                
            }
            else
            {
                try
                {
                    File.Move(nomeArq, Path.Combine(destino, Path.GetFileName(nomeArq)));
                    Log(configsync.Log, $"Arquivo {nomeArq} MOVIDO para {destino}");
                }
                catch (Exception ex)
                {
                    Log(configsync.Log, $"ERRO ao mover arquivo {nomeArq} para {destino} ERRO: {ex.Message}");
                }
            }

            ret = true;
            return ret;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            SalvarConfiguracao(true);
        }

        private void SalvarConfiguracao(bool GravarDisco)
        {
            configsync.Origem = txtDirOrigem.Text;
            configsync.Destino = txtDirDestino.Text;
            configsync.Filtro = txtFiltro.Text;
            configsync.Log = txtLog.Text;
            configsync.TipoSubPasta = (ConfigSync.eTipoSubPasta)cmbTipoSubPasta.SelectedIndex;
            configsync.TipoSync = (ConfigSync.eTipoSync)cmbTipoSync.SelectedIndex;

            if (GravarDisco)
                configsync.Salvar();

        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            CarregarConfiguracao();

        }

        private void CarregarConfiguracao()
        {

            configsync = new ConfigSync(Application.ExecutablePath);
            

            txtDirOrigem.Text = configsync.Origem;
            txtDirDestino.Text = configsync.Destino;
            txtFiltro.Text = configsync.Filtro;
            txtLog.Text = configsync.Log;
            cmbTipoSubPasta.SelectedIndex = (int)configsync.TipoSubPasta;
            cmbTipoSync.SelectedIndex = (int)configsync.TipoSync;
        }

        private void frmFileSync_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bw.IsBusy)
            {
                e.Cancel = true;
                MessageBox.Show("Primeiro pare a execução!");
            }
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            dlgLog.FileName = txtLog.Text;
            if (dlgLog.ShowDialog() == DialogResult.OK)
            {
                txtLog.Text = dlgLog.FileName;
            }
        }

        public void Log(String arquivo, String mensagem)
        {
            if (!String.IsNullOrWhiteSpace(arquivo))
            {            
                using (StreamWriter w = File.AppendText(arquivo))
                {
                    w.WriteLine("{0}  =>  {1}\r\n", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                        mensagem);
                }
            }
        }
    }
}
