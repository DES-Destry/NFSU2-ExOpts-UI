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
        [DataMember]
        public string TexmodPath { get; set; }

        public AppSettings()
        {
            ScriptPath = App.MainConfigPath;
            GamePath = App.GameExePath;
            TexmodPath = App.TexmodExePath;
        }
        public AppSettings(string scriptPath, string gamePath, string texmodPath)
        {
            ScriptPath = scriptPath;
            GamePath = gamePath;
            TexmodPath = texmodPath;
        }
    }
}
