using DESTRY.IO.Debuging;
using System;

namespace NFSU2_ExOpts.ViewModels
{
    class LapsControllerPageViewModel : BaseViewModel
    {
        private string minimum = "0";
        private string maximum = "0";
        private string koEnabled = "0";

        public string Minimum
        {
            get
            {
                return minimum;
            }
            set
            {
                if (int.TryParse(value, out int result) && result >= 0 && result <= 127)
                {
                    minimum = result.ToString();
                    App.IniFile["Minimum", "LapControllers"] = minimum;
                    App.IsSavedData = false;

                    if (int.Parse(Maximum) < int.Parse(minimum))
                    {
                        Maximum = minimum;
                    }

                    Logs.WriteLog($"Minimum(LapControllers) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"Minimum(LapControllers) value not changed. It's empty. Waiting normal input...", "INFO");
                    OnPropertyChanged();
                }
                else
                {
                    Minimum = minimum.Remove(minimum.Length - 1, 1);
                    Logs.WriteLog($"Minimum(LapControllers) value not changed. It's bullshit. Waiting normal input...", "INFO");
                    OnPropertyChanged();
                }
            }
        }
        public string Maximum
        {
            get
            {
                return maximum;
            }
            set
            {
                if (int.TryParse(value, out int result) && result >= 0 && result <= 127)
                {
                    maximum = result.ToString();
                    App.IniFile["Maximum", "LapControllers"] = maximum;
                    App.IsSavedData = false;

                    if (int.Parse(maximum) < int.Parse(Minimum))
                    {
                        Minimum = maximum;
                    }

                    Logs.WriteLog($"Maximum(LapControllers) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"Maximum(LapControllers) value not changed. It's empty. Waiting normal input...", "INFO");
                    OnPropertyChanged();
                }
                else
                {
                    Maximum = maximum.Remove(maximum.Length - 1, 1);
                    Logs.WriteLog($"Maximum(LapControllers) value not changed. It's bullshit. Waiting normal input...", "INFO");
                    OnPropertyChanged();
                }
            }
        }
        public string KoEnabled
        {
            get
            {
                return koEnabled;
            }
            set
            {
                if (int.TryParse(value, out int result) && result >= 0 && result <= 127)
                {
                    koEnabled = result.ToString();
                    App.IniFile["KOEnabled", "LapControllers"] = koEnabled;
                    App.IsSavedData = false;

                    Logs.WriteLog($"KOEnabled(LapControllers) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"KOEnabled(LapControllers) value not changed. It's empty. Waiting normal input...", "INFO");
                    OnPropertyChanged();
                }
                else
                {
                    KoEnabled = koEnabled.Remove(koEnabled.Length - 1, 1);
                    Logs.WriteLog($"KOEnabled(LapControllers) value not changed. It's bullshit. Waiting normal input...", "INFO");
                    OnPropertyChanged();
                }
            }
        }

        public LapsControllerPageViewModel()
        {
            SetValues();
        }

        private void SetValues()
        {
            try
            {
                if (!App.IniFile.IsEmpty)
                {
                    Minimum = App.IniFile["Minimum", "LapControllers"];
                    Maximum = App.IniFile["Maximum", "LapControllers"];
                    KoEnabled = App.IniFile["KOEnabled", "LapControllers"];
                }
                else
                {
                    Minimum = Maximum = KoEnabled = "NULL";
                }
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
    }
}
