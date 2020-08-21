using DESTRY.IO.Debuging;
using DESTRY.IO.IniFiles;
using ExOpts_Installer.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ExOpts_Installer.ViewModels
{
    class UpdatesViewModel : BaseViewModel
    {
        private const string FILE_URL = "https://github.com/DES-Destry/NFSU2-ExOpts-UI/raw/master/Releases/LastVersion.zip";
        private const string UPDATE_ARCHIVE_PATH = "update.zip";
        private const float B_TO_MB_NUM_CONVERT = 1048576;   // *** bytes / 1048576(1024 * 1024) = *** MB
        private const int COUNT_OF_INSTALL_STAGES = 2;

        private string sizeInMB = string.Empty;

        private string uiVersions = "loading...";
        private string exoptsVersions = "loading...";
        private string versionNotes = string.Empty;
        private string downloadState = "Downloading: ";
        private string installState = "Installing: ";

        private Brush uiVersionState = (Brush)Application.Current.TryFindResource("WhiteBrush");
        private Brush exoptsVersionState = (Brush)Application.Current.TryFindResource("WhiteBrush");

        private int downloadProgress = 0;
        private int downloadMax = 1;
        private int installProgress = 0;
        private int installMax = 1;

        private int currentInstallStage = 0;

        private bool updateIsEnabled = false;


        public string UIVersions
        {
            get
            {
                return uiVersions;
            }
            set
            {
                uiVersions = value;
                OnPropertyChanged();
            }
        }
        public string ExOptsVersions
        {
            get
            {
                return exoptsVersions;
            }
            set
            {
                exoptsVersions = value;
                OnPropertyChanged();
            }
        }
        public string VersionNotes
        {
            get
            {
                return versionNotes;
            }
            set
            {
                versionNotes = value;
                OnPropertyChanged();
            }
        }
        public string DownloadingState
        {
            get
            {
                return downloadState;
            }
            set
            {
                downloadState = value;
                OnPropertyChanged();
            }
        }
        public string InstallState
        {
            get
            {
                return installState;
            }
            set
            {
                installState = value;
                OnPropertyChanged();
            }
        }

        public Brush UIVersionState
        {
            get
            {
                return uiVersionState;
            }
            set
            {
                uiVersionState = value;
                OnPropertyChanged();
            }
        }
        public Brush ExOptsVersionState
        {
            get
            {
                return exoptsVersionState;
            }
            set
            {
                exoptsVersionState = value;
                OnPropertyChanged();
            }
        }

        public int DownloadProgress
        {
            get
            {
                return downloadProgress;
            }
            set
            {
                downloadProgress = value;
                OnPropertyChanged();
            }
        }
        public int DownloadMax
        {
            get
            {
                return downloadMax;
            }
            set
            {
                downloadMax = value;
                OnPropertyChanged();
            }
        }
        public int InstallProgress
        {
            get
            {
                return installProgress;
            }
            set
            {
                installProgress = value;
                OnPropertyChanged();
            }
        }
        public int InstallMax
        {
            get
            {
                return installMax;
            }
            set
            {
                installMax = value;
                OnPropertyChanged();
            }
        }

        public bool UpdateIsEnabled
        {
            get
            {
                return updateIsEnabled;
            }
            set
            {
                updateIsEnabled = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateCommand => new BaseCommand(obj => UpdateAsync());


        public UpdatesViewModel()
        {
            App.OnLastVersionDataGetted += GettedLastVersion;
        }

        private void GettedLastVersion()
        {
            if (!App.ConnectionError)
            {
                if (App.Version != App.LastVersion)
                {
                    UIVersionState = (Brush)Application.Current.TryFindResource("MainBrush");
                    UIVersions = $"UI Version: {App.Version} => {App.LastVersion}";

                    UpdateIsEnabled = true;
                }
                else
                {
                    UIVersions = $"UI Version: {App.Version}";
                }

                if (App.ExOptsVersion != App.ExOptsLastVersion)
                {
                    ExOptsVersionState = (Brush)Application.Current.TryFindResource("MainBrush");
                    ExOptsVersions = $"Extra Options Version: {App.ExOptsVersion} => {App.ExOptsLastVersion}";

                    UpdateIsEnabled = true;
                }
                else
                {
                    ExOptsVersions = $"Extra Options Version: {App.ExOptsVersion}";
                }

                VersionNotes = App.VersionNotes;

                CheckSizeAsync();

                Logs.WriteLog("Last version data recieved", "INFO");
                Logs.WriteLog($"Size of last version updete: {sizeInMB} MB", "INFO");
            }
            else
            {
                UIVersions = $"UI Version: {App.Version} => CONNECTION ERROR";
                UIVersions = $"Extra Options Version: {App.ExOptsVersion} => CONNECTION ERROR";

                UIVersionState = (Brush)Application.Current.TryFindResource("ConnectionErrorBrush");
                ExOptsVersionState = (Brush)Application.Current.TryFindResource("ConnectionErrorBrush");
            }
        }

        private async Task UpdateAsync()
        {
            try
            {
                await KillExOptsTaskAsync();
                await DownloadAsync();
                await InstallAsync();
                RebootApp();
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }

        private async Task KillExOptsTaskAsync()
        {
            try
            {
                await Task.Run(() =>
                {
                    var processes = Process.GetProcesses();
                    foreach (var process in processes)
                    {
                        if (process.ProcessName.Contains("NFSU2 ExOpts"))
                        {
                            process.Kill();
                            Logs.WriteLog("NFSU2 ExOpts.exe process has been killed.", "INFO");
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                if (ex is UnauthorizedAccessException)
                {
                    await KillExOptsTaskAsync();
                    Logs.WriteLog("NFSU2 ExOpts.exe process has been not killed. UnauthorizedAccessException. New try to kill this process.", "INFO");
                }
                else
                {
                    Errors.WriteError(ex);
                }
            }
        }
        private async Task DownloadAsync()
        {
            try
            {
                if (File.Exists(UPDATE_ARCHIVE_PATH))
                {
                    File.Delete(UPDATE_ARCHIVE_PATH);
                }

                DownloadProgress = 0;
                DownloadMax = 100;

                WebClient wc = new WebClient();
                wc.DownloadProgressChanged += OnPercentageChanged;

                await wc.DownloadFileTaskAsync(new Uri(FILE_URL), UPDATE_ARCHIVE_PATH);

                DownloadingState = "Downloading: done!";
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
        private async Task InstallAsync()
        {
            try
            {
                await UnpackArchiveAsync();

                string[] updateFiles = Directory.GetFiles("update", "*.*", SearchOption.AllDirectories);
                InstallUpdateFiles(updateFiles);

                Logs.WriteLog("Update has been installed installed", "INFO");
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
        private void RebootApp()
        {
            try
            {
                Process.Start("NFSU2 ExOpts.exe");
                Logs.WriteLog("Main app lanched. Soon intaller will be shutdown.", "INFO");
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }

        private async Task UnpackArchiveAsync()
        {
            await Task.Run(() =>
            {
                if (Directory.Exists("update"))
                {
                    Directory.Delete("update", true);
                }

                using (ZipArchive archive = ZipFile.OpenRead(UPDATE_ARCHIVE_PATH))
                {
                    StartNewInstallStage(1, archive.Entries.Count);
                    Directory.CreateDirectory("update");

                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName == "scripts/")
                        {
                            Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "update", "scripts"));
                        }
                        else
                        {
                            entry.ExtractToFile(Path.Combine(Environment.CurrentDirectory, "update", entry.FullName));
                        }
                        IncreaseInstallProgress();
                    }
                }
                Logs.WriteLog($"\"{Path.GetFullPath(UPDATE_ARCHIVE_PATH)}\" has been unpacked.", "INFO");

                File.Delete(UPDATE_ARCHIVE_PATH);
            });
        }
        private void InstallUpdateFiles(string[] files)
        {
            if (files != null)
            {
                StartNewInstallStage(2, files.Length);
                foreach (string file in files)
                {
                    bool isScriptFile = new FileInfo(file).Directory.Name == "script";

                    string oldFileName;

                    if (isScriptFile)
                    {
                        oldFileName = Path.GetFileName(Path.Combine(Environment.CurrentDirectory, "script", Path.GetFileName(file)));
                    }
                    else
                    {
                        oldFileName = Path.GetFileName(Path.Combine(Environment.CurrentDirectory, Path.GetFileName(file)));
                    }

                    if (file.Contains("NFSU2ExtraOptionsSettings.ini"))
                    {
                        string oldConfigFile = Path.Combine("scripts", "NFSU2ExtraOptionsSettings.ini");
                        string updateConfigFile = Path.Combine("update", oldConfigFile);

                        if (File.Exists(oldConfigFile))
                        {
                            IniFile oldConfig = new IniFile();
                            IniFile newConfig = new IniFile();

                            oldConfig.Load(oldConfigFile);
                            newConfig.Load(updateConfigFile);

                            IniFile mergedConfig = IniFile.Merge(oldConfig, newConfig);

                            File.Delete(oldConfigFile);
                            mergedConfig.SaveAs(oldConfigFile);

                            oldConfig.Clear();
                            newConfig.Clear();

                            File.Delete(updateConfigFile);
                        }
                        else
                        {
                            File.Move(file, oldFileName);
                        }
                    }
                    else if (!file.Contains("ExOpts-Installer.exe") && !file.Contains("DESTRY.dll"))
                    {
                        if (File.Exists(oldFileName))
                        {
                            File.Delete(oldFileName);
                        }
                        File.Move(file, oldFileName);
                    }

                    IncreaseInstallProgress();
                }

                Logs.WriteLog("Update files has been installed", "INFO");
            }

            Logs.WriteLog("Update files has been not installed. Files to install has been null", "ERROR");
        }

        private async void CheckSizeAsync()
        {
            try
            {
                HttpWebRequest request = WebRequest.CreateHttp(FILE_URL);
                using (WebResponse response = await request.GetResponseAsync())
                {
                    var size = response.ContentLength;
                    float shortSize = size / B_TO_MB_NUM_CONVERT;
                    sizeInMB = shortSize.ToString("##.##");
                }
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
        private void OnPercentageChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadProgress = e.ProgressPercentage;
            DownloadingState = $"Downloading ({e.ProgressPercentage}% ({Math.Round((float)e.BytesReceived / B_TO_MB_NUM_CONVERT, 2)} MB/{sizeInMB} MB)):";
        }
        private void StartNewInstallStage(int installStage, int maximum)
        {
            currentInstallStage = installStage;

            InstallProgress = 0;
            InstallMax = maximum;
            InstallState = $"Installing({currentInstallStage}/{COUNT_OF_INSTALL_STAGES} stage - 0%):";
        }
        private void IncreaseInstallProgress()
        {
            InstallProgress += 1;
            InstallState = $"Installing({currentInstallStage}/{COUNT_OF_INSTALL_STAGES} stage - {(float)installProgress / (float)installMax * 100:###.#}%):";
        }
    }
}
