using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSync
{
    public class ConfigSync
    {

        public enum eTipoSubPasta
        {
            NaoCriarPasta = 0,
            AAAA_MM = 1,
            AAAA_e_MM = 2,
            AAAA_MM_DD = 3,
            AAAA_e_MM_e_DD = 4,
            CopiaUltimaPasta = 5,
            Copia2UltimasPastas = 6
        }

        public enum eTipoSync
        {   
            Copiar = 0,
            Mover = 1
        }

        public String Arquivo { get; set; }
        public String Origem { get; set; }
        public String Destino { get; set; }
        public String Filtro { get; set; }
        public String Log { get; set; }

        public eTipoSubPasta TipoSubPasta { get; set; }

        public eTipoSync TipoSync { get; set; }




        public ConfigSync(string arquivo)
        {
            this.Arquivo = arquivo;

            Configuration config = ConfigurationManager.OpenExeConfiguration(Arquivo);
            
            if (config.AppSettings.Settings["Origem"] != null)
               this.Origem = config.AppSettings.Settings["Origem"].Value;

            if (config.AppSettings.Settings["Destino"] != null)
                this.Destino = config.AppSettings.Settings["Destino"].Value;

            if (config.AppSettings.Settings["Filtro"] != null)
                this.Filtro = config.AppSettings.Settings["Filtro"].Value;

            if (config.AppSettings.Settings["Log"] != null)
                this.Log = config.AppSettings.Settings["Log"].Value;


            try
            {
                this.TipoSubPasta = (ConfigSync.eTipoSubPasta)Enum.Parse(typeof(ConfigSync.eTipoSubPasta), config.AppSettings.Settings["TipoSubPasta"].Value);
            } catch
            {
                this.TipoSubPasta = eTipoSubPasta.NaoCriarPasta;
            }

            try
            {
                this.TipoSync = (ConfigSync.eTipoSync)Enum.Parse(typeof(ConfigSync.eTipoSync), config.AppSettings.Settings["TipoSync"].Value);
            } catch
            {
                this.TipoSync = eTipoSync.Copiar;
            }
            
        }

        public void Salvar()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Arquivo);

            config.AppSettings.Settings.Remove("Origem");
            config.AppSettings.Settings.Add("Origem", Origem);

            config.AppSettings.Settings.Remove("Destino");
            config.AppSettings.Settings.Add("Destino", Destino);

            config.AppSettings.Settings.Remove("Filtro");
            config.AppSettings.Settings.Add("Filtro",Filtro);

            config.AppSettings.Settings.Remove("Log");
            config.AppSettings.Settings.Add("Log", Log);

            config.AppSettings.Settings.Remove("TipoSubPasta");
            config.AppSettings.Settings.Add("TipoSubPasta",TipoSubPasta.ToString());

            config.AppSettings.Settings.Remove("TipoSync");
            config.AppSettings.Settings.Add("TipoSync", TipoSync.ToString());

            config.Save(ConfigurationSaveMode.Minimal);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
