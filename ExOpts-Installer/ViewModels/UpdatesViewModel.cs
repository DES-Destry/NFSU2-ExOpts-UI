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
        private const float B_TO_MB_NUM_CONVERT = 1048576;   // *** bytes / 1048576(1024 * 1024) = *** MB

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

        private async void UpdateAsync()
        {
            await KillExOptsTaskAsync();
            await DownloadAsync();
            await InstallAsync();
            await RebootAppAsync();
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
            DownloadProgress = 0;
            DownloadMax = 100;

            WebClient wc = new WebClient();
            wc.DownloadProgressChanged += OnPercentageChanged;

            await wc.DownloadFileTaskAsync(new Uri(FILE_URL), "update.zip");

            DownloadingState = "Downloading: done!";
        }
        private async Task InstallAsync()
        {
            await Task.Run(() =>
            {
                using (ZipArchive archive = ZipFile.OpenRead("update.zip"))
                {
                    InstallProgress = 0;
                    InstallMax = archive.Entries.Count;
                    InstallState = "Installing(1/2 stage - 0%):";

                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        entry.ExtractToFile(Path.Combine("update", entry.FullName));
                        InstallProgress += 1;
                        InstallState = $"Installing(1/2 stage - {((float)installProgress / (float)installMax)*100:###.#}%):";
                    }
                }
                Logs.WriteLog($"\"{Path.GetFullPath("update.zip")}\" has been unpacked.", "INFO");

                File.Delete("update.zip");

                InstallProgress = 0;
                string[] newUIFiles = Directory.GetFiles("update");
                string[] newExOptsFiles = Directory.GetFiles("update\\scripts");
                InstallMax = newUIFiles.Length + newExOptsFiles.Length - 1;
                InstallState = "Installing(2/2 stage - 0%):";


                foreach (string file in newUIFiles)
                {
                    if (!file.Contains("ExOpts-Installer.exe"))
                    {
                        File.Move(file, Path.GetFileName(file));
                        InstallProgress += 1;
                        InstallState = $"Installing(2/2 stage - {((float)installProgress / (float)installMax) * 100:###.#}%):";
                    }
                }

                Logs.WriteLog("Important UI files has been installed", "INFO");

                foreach (string file in newExOptsFiles)
                {
                    if (!file.Contains("NFSU2ExtraOptionsSettings.ini"))
                    {
                        File.Move(file, Path.Combine("scripts", Path.GetFileName(file)));
                        InstallProgress += 1;
                    }
                    else
                    {
                        IniFile oldConfig = new IniFile();
                        IniFile newConfig = new IniFile();

                        oldConfig.Load("scripts\\NFSU2ExtraOptionsSettings.ini");
                        newConfig.Load("update\\scripts\\NFSU2ExtraOptionsSettings.ini");

                        IniFile mergedConfig = IniFile.Merge(oldConfig, newConfig);

                        oldConfig.Clear();
                        newConfig.Clear();
                        File.Delete("scripts\\NFSU2ExtraOptionsSettings.ini");
                        mergedConfig.SaveAs("scripts\\NFSU2ExtraOptionsSettings.ini");

                        InstallProgress += 1;
                        InstallState = "Installing(2/2 stage - 100%):";
                    }
                }

                Logs.WriteLog("Important Extra Options files has been installed", "INFO");
                Logs.WriteLog("Update has been installed installed", "INFO");
            });
        }
        private async Task RebootAppAsync()
        {
            await Task.Run(() =>
            {
                Process.Start("NFSU2 ExOpts.exe");
                Logs.WriteLog("Main app lanched. Soon intaller will be shutdown.", "INFO");
                Application.Current.Shutdown();
            });
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
    }
}
