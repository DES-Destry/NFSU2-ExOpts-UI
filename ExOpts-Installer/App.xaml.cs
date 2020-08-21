using DESTRY.IO.Debuging;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace ExOpts_Installer
{
    public partial class App : Application
    {
        private const int UI_VERSION_ROW = 1 - 1;
        private const int EXOPTS_VERSION_ROW = 2 - 1;
        private const int ROW_WHERE_STARTS_NOTES = 10 - 1;
        private const string VERSION_DATA_DOWNLOAD_URL = "https://github.com/DES-Destry/NFSU2-ExOpts-UI/raw/master/NFSU2%20ExOpts/.version.zip";


        public static readonly string ApplicationDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Destry-Unimaster", "NFSU2 ExOpts");
        public static readonly string LastVersionFilePath = Path.Combine(ApplicationDataFolder, "last version", ".version");

        public static readonly string Version = "v0.8.61 beta";
        public static readonly string ExOptsVersion = "v5.0.0.1337";

        public static string LastVersion = default;
        public static string ExOptsLastVersion = default;
        public static string VersionNotes = string.Empty;

        public static bool ConnectionError { get; private set; } = false;

        public static event Action OnLastVersionDataGetted;


        static App()
        {
            try
            {
                InitFiles();
                SetLastVersion();

                Logs.WriteLog("Application working has been started!", "INFO");
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }

        private static void CreateLogFile()
        {
            string[] header = new string[]
            {
                "===============================================================",
                "   Creator: Destry-Unimaster",
                "   Application: ExOpts-Installer",
                $"   This log file created at: {DateTime.Now: MM.dd.yyyy - HH:mm}",
                "==============================================================="
            };
            Logs.CreateLogFile(header);

            Logs.WriteLog("Log file has been created!", "INFO");
        }
        private static void CreateFolders()
        {
            Directory.CreateDirectory(Path.Combine(ApplicationDataFolder, "error reports", "installer"));
            Directory.CreateDirectory(Path.Combine(ApplicationDataFolder, "last version"));
            Directory.CreateDirectory(Path.Combine(ApplicationDataFolder, "logs"));

            CreateLogFile();
        }

        private static void InitFiles()
        {
            Logs.InitLogsDirectory(Path.Combine(ApplicationDataFolder, "logs"));
            Logs.InitLogFile("installer.log", false);

            Errors.InitErrorsPath(Path.Combine(ApplicationDataFolder, "error reports", "installer"));

            if (!Directory.Exists(ApplicationDataFolder) ||
                !Directory.Exists(Path.Combine(ApplicationDataFolder, "error reports", "installer")) ||
                !Directory.Exists(Path.Combine(ApplicationDataFolder, "logs")) ||
                !Directory.Exists(Path.Combine(ApplicationDataFolder, "last version")))
            {
                CreateFolders();
            }
            else if (!File.Exists(Path.Combine(ApplicationDataFolder, "logs", "installer.log")))
            {
                CreateLogFile();
            }
        }

        private async static void SetLastVersion()
        {
            try
            {
                StringBuilder builder = new StringBuilder();

                if (File.Exists(LastVersionFilePath))
                {
                    File.Delete(LastVersionFilePath);
                    Logs.WriteLog($"{LastVersionFilePath} has been deleted!", "INFO");
                }

                await DownloadLastVersionData();

                string[] lastVersionData = File.ReadAllLines(LastVersionFilePath);

                LastVersion = lastVersionData[UI_VERSION_ROW];
                ExOptsLastVersion = lastVersionData[EXOPTS_VERSION_ROW];

                for (int i = ROW_WHERE_STARTS_NOTES; i <= lastVersionData.Length - 1; i++)
                {
                    builder.AppendLine(lastVersionData[i]);
                }
                VersionNotes = builder.ToString();

                OnLastVersionDataGetted?.Invoke();
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
                ConnectionError = true;

                OnLastVersionDataGetted?.Invoke();
            }
        }

        private static async Task DownloadLastVersionData()
        {
            string lastVersionArchivePath = Path.Combine(ApplicationDataFolder, "last version", ".version.zip");

            WebClient wc = new WebClient();
            await wc.DownloadFileTaskAsync(new Uri(VERSION_DATA_DOWNLOAD_URL), lastVersionArchivePath);

            Logs.WriteLog($"{lastVersionArchivePath} has been downloaded from github!", "INFO");

            using (ZipArchive archive = ZipFile.OpenRead(lastVersionArchivePath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    entry.ExtractToFile(Path.Combine(ApplicationDataFolder, "last version", entry.FullName));
                }
            }

            File.Delete(lastVersionArchivePath);
        }
    }
}
