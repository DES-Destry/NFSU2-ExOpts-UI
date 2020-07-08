using Microsoft.Win32;
using NFSU2_ExOpts.Models;
using System.Windows.Input;

namespace NFSU2_ExOpts.ViewModels
{
    class SettingsPresetsPageViewModel : BaseViewModel
    {
        public ICommand LoadToMainCommand => new BaseCommand(obj => LoadToMain());
        public ICommand LoadAsPresetCommand => new BaseCommand(obj => LoadAsPreset());
        public ICommand SaveAsNewPresetCommand => new BaseCommand(obj => SaveAsNewPreset());


        private void LoadToMain()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Title = "Load settings preset and apply to main config.",
                Filter = "Extra Options u2 settings preset(*.u2preset)|*.u2preset"
            };

            if (fileDialog.ShowDialog() == true)
            {
                App.MainConfig.Clear();
                App.MainConfig.Load(fileDialog.FileName);

                App.UpdateConfig();

                App.IsSavedData = true;
                App.IsMainConfigOpened = true;
            }
        }
        private void LoadAsPreset()
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Title = "Load settings preset and open preset.",
                Filter = "Extra Options u2 settings preset(*.u2preset)|*.u2preset"
            };

            if (fileDialog.ShowDialog() == true)
            {
                App.CustomConfigPath = fileDialog.FileName;

                App.MainConfig.Clear();
                App.MainConfig.Load(fileDialog.FileName);

                App.UpdateConfig();

                App.IsSavedData = true;
                App.IsMainConfigOpened = false;
            }
        }
        private void SaveAsNewPreset()
        {
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                Title = "Save as new settings preset.",
                Filter = "Extra Options u2 settings preset(*.u2preset)|*.u2preset"
            };

            if (fileDialog.ShowDialog() == true)
            {
                App.MainConfig.SaveAs(fileDialog.FileName);
            }
        }
    }
}
