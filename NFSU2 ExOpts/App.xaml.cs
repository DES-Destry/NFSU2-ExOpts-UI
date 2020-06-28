using DESTRY.IO;
using DESTRY.IO.Debuging;
using DESTRY.IO.IniFiles;
using NFSU2_ExOpts.Models;
using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
using System.Windows;

namespace NFSU2_ExOpts
{
    public partial class App : Application
    {
        private static bool isSavedData = true;


        public static readonly string ApplicationDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Destry-Unimaster", "NFSU2 ExOpts");
        public static readonly string LastVersionFilePath = Path.Combine(ApplicationDataFolder, "last version", ".version");
        public static readonly string GameExePath = "speed2.exe";
        public static readonly string MainConfigPath = "scripts\\NFSU2ExtraOptionsSettings.ini";
        public static string CustomConfigPath = default;

        public static readonly string Version = "v0.8.1";
        public static readonly string ExOptsVersion = "v4.0.0.1337";

        public static string LastVersion = default;
        public static string ExOptsLastVersion = default;

        public static bool IsMainConfigOpened { get; private set; } = false;
        public static bool MainConfigExists { get; private set; } = false;
        public static bool GameExeExists { get; private set; } = false;
        public static bool ConnectionError { get; private set; } = false;

        public static bool IsSavedData
        {
            get => isSavedData;
            set
            {
                isSavedData = value;
                OnSavedDataChanged?.Invoke();
            }
        }

        public static IniFile MainConfig = new IniFile();
        public static IniFile ScreenFXConfig = new IniFile();
        public static AppSettings Settings = new AppSettings();

        public static event Action OnSavedDataChanged;
        public static event Action OnOutDataUpdated;
        public static event Action OnLastVersionDataGetted;


        static App()
        {
            try
            {
                if (!Directory.Exists(ApplicationDataFolder) ||
                    !Directory.Exists(Path.Combine(ApplicationDataFolder, "data")) ||
                    !Directory.Exists(Path.Combine(ApplicationDataFolder, "error reports")) ||
                    !Directory.Exists(Path.Combine(ApplicationDataFolder, "logs")) ||
                    !Directory.Exists(Path.Combine(ApplicationDataFolder, "last version")))
                {
                    CreateFolders();
                }
                else if (!File.Exists(Path.Combine(ApplicationDataFolder, "logs", "main.log")))
                {
                    CreateLogFile();
                }
                else if (!File.Exists(Path.Combine(ApplicationDataFolder, "data", "main.json")))
                {
                    CreateAppDataFile();
                }

                GetUpdates();

                AppData.InitAppDir(Path.Combine(ApplicationDataFolder, "data"));
                AppData.InitAppFile("main.json", false);

                Logs.InitLogsDirectory(Path.Combine(ApplicationDataFolder, "logs"));
                Logs.InitLogFile("main.log", false);

                Errors.InitErrorsPath(Path.Combine(ApplicationDataFolder, "error reports"));

                Logs.WriteLog("Application working has been started!", "INFO");

                AppSettings settings = AppData.ReadJson<AppSettings>();
                Settings = settings;

                MainConfigPath = Settings.ScriptPath;
                GameExePath = Settings.GamePath;

                Logs.WriteLog("Settings are readed and applied", "INFO");


                string[] environmentStrings = Environment.GetCommandLineArgs();

                if (environmentStrings.Length < 2)
                {
                    IsMainConfigOpened = true;

                    if (File.Exists(MainConfigPath))
                    {
                        MainConfigExists = true;
                        MainConfig.Load(MainConfigPath);

                        Logs.WriteLog($"Ini file has been loaded from {Path.GetFullPath(MainConfigPath)}", "INFO");
                    }
                    else
                    {
                        MainConfigExists = false;

                        Logs.WriteLog("Main script not found.", "ERROR");
                    }
                }
                else
                {
                    IsMainConfigOpened = false;
                    MainConfigExists = true;

                    CustomConfigPath = environmentStrings[1];
                    MainConfig.Load(environmentStrings[1]);

                    Logs.WriteLog($"Ini file has been loaded from {Path.GetFullPath(environmentStrings[1])}", "INFO");
                }
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }

        public static void UpdateConfig()
        {
            OnOutDataUpdated?.Invoke();

            Logs.WriteLog("All data was reloaded.", "INFO");
        }

        private static void CreateLogFile()
        {
            string[] header = new string[]
            {
                "===============================================================",
                "   Creator: Destry-Unimaster",
                "   Application: NFSU2 ExOpts",
                $"   This log file created at: {DateTime.Now: MM.dd.yyyy - HH:mm}",
                "==============================================================="
            };
            Logs.CreateLogFile(header);

            Logs.WriteLog("Log file has been created!", "INFO");
        }
        private static void CreateAppDataFile()
        {
            AppSettings appSettings = new AppSettings();
            AppData.WriteJson(appSettings);

            Settings = appSettings;
        }
        private static void CreateFolders()
        {
            Directory.CreateDirectory(Path.Combine(ApplicationDataFolder, "data"));
            Directory.CreateDirectory(Path.Combine(ApplicationDataFolder, "error reports"));
            Directory.CreateDirectory(Path.Combine(ApplicationDataFolder, "last version"));
            Directory.CreateDirectory(Path.Combine(ApplicationDataFolder, "logs"));

            CreateLogFile();
            CreateAppDataFile();
        }

        private async static void GetUpdates()
        {
            try
            {
                if (File.Exists(LastVersionFilePath))
                {
                    File.Delete(LastVersionFilePath);
                    Logs.WriteLog($"{LastVersionFilePath} has been deleted!", "INFO");
                }

                await Task.Run(async () =>
                {
                    WebClient wc = new WebClient();
                    await wc.DownloadFileTaskAsync(new Uri("https://github.com/DES-Destry/NFSU2-ExOpts-UI/raw/master/NFSU2%20ExOpts/.version.zip"), Path.Combine(ApplicationDataFolder, "last version", ".version.zip"));

                    Logs.WriteLog($"{Path.Combine(ApplicationDataFolder, "last version", ".version.zip")} has been downloaded from github!", "INFO");

                    using (ZipArchive archive = ZipFile.OpenRead(Path.Combine(ApplicationDataFolder, "last version", ".version.zip")))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            entry.ExtractToFile(Path.Combine(Path.Combine(ApplicationDataFolder, "last version"), entry.FullName));
                        }
                    }

                    File.Delete(Path.Combine(ApplicationDataFolder, "last version", ".version.zip"));

                    string[] lastVersionData = File.ReadAllLines(LastVersionFilePath);

                    LastVersion = lastVersionData[0];
                    ExOptsLastVersion = lastVersionData[1];

                    OnLastVersionDataGetted?.Invoke();
                });
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
                ConnectionError = true;

                OnLastVersionDataGetted?.Invoke();
            }
        }
    }
}
