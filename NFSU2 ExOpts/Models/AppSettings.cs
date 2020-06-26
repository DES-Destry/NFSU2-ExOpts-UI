using System.Runtime.Serialization;

namespace NFSU2_ExOpts.Models
{
    [DataContract]
    public class AppSettings
    {
        [DataMember]
        public string ScriptPath { get; set; }
        [DataMember]
        public string GamePath { get; set; }

        public AppSettings()
        {
            ScriptPath = App.MainConfigPath;
            GamePath = App.GameExePath;
        }

        public AppSettings(string scriptPath, string gamePath)
        {
            ScriptPath = scriptPath;
            GamePath = gamePath;
        }
    }
}
