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
                    App.MainConfig["Minimum", "LapControllers"] = minimum;
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
                    minimum = value;
                    OnPropertyChanged();
                }
                else
                {
                    Logs.WriteLog($"Minimum(LapControllers) value not changed. It's bullshit. Lastest change not applied.", "INFO");
                    if (result > 127)
                    {
                        Minimum = "127";
                    }
                    else
                    {
                        if (minimum.Length > 0)
                        {
                            Minimum = value.Remove(value.Length - 1, 1);
                        }
                        else
                        {
                            Minimum = string.Empty;
                        }
                    }
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
                    App.MainConfig["Maximum", "LapControllers"] = maximum;
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
                    maximum = string.Empty;
                    OnPropertyChanged();
                }
                else
                {
                    Logs.WriteLog($"Maximum(LapControllers) value not changed. It's bullshit. Waiting normal input...", "INFO");
                    if (result > 127)
                    {
                        Maximum = "127";
                    }
                    else
                    {
                        if (maximum.Length > 0)
                        {
                            Maximum = value.Remove(value.Length - 1, 1);
                        }
                        else
                        {
                            Maximum = string.Empty;
                        }
                    }
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
                    App.MainConfig["KOEnabled", "LapControllers"] = koEnabled;
                    App.IsSavedData = false;

                    Logs.WriteLog($"KOEnabled(LapControllers) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"KOEnabled(LapControllers) value not changed. It's empty. Waiting normal input...", "INFO");
                    koEnabled = string.Empty;
                    OnPropertyChanged();
                }
                else
                {
                    Logs.WriteLog($"KOEnabled(LapControllers) value not changed. It's bullshit. Waiting normal input...", "INFO");
                    if (result > 127)
                    {
                        KoEnabled = "127";
                    }
                    else
                    {
                        if (koEnabled.Length > 0)
                        {
                            KoEnabled = value.Remove(value.Length - 1, 1);
                        }
                        else
                        {
                            KoEnabled = string.Empty;
                        }
                    }
                    OnPropertyChanged();
                }
            }
        }

        public LapsControllerPageViewModel()
        {
            try
            {
                App.OnOutDataUpdated += SetValues;
                SetValues();
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }

        private void SetValues()
        {
            try
            {
                if (!App.MainConfig.IsEmpty)
                {
                    Minimum = App.MainConfig["Minimum", "LapControllers"];
                    Maximum = App.MainConfig["Maximum", "LapControllers"];
                    KoEnabled = App.MainConfig["KOEnabled", "LapControllers"];
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
