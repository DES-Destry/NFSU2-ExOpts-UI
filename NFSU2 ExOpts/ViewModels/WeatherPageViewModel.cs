using DESTRY.IO.Debuging;
using System;

namespace NFSU2_ExOpts.ViewModels
{
    class WeatherPageViewModel : BaseViewModel
    {
        private string alwaysRain;
        private string generalRainAmount;
        private string roadReflectionAmount;
        private string rainSize;
        private string rainIntensity;
        private string rainCrossing;
        private string rainSpeed;
        private string rainGravity;

        public string AlwaysRain
        {
            get
            {
                return alwaysRain;
            }
            set
            {
                alwaysRain = value;
                App.IniFile["AlwaysRain", "Weather"] = alwaysRain;
                App.IsSavedData = false;

                OnPropertyChanged();
            }
        }
        public string GeneralRainAmount
        {
            get
            {
                return generalRainAmount;
            }
            set
            {
                if (double.TryParse(value.Replace(".", ","), out double result) && result >= 0)
                {
                    generalRainAmount = result.ToString().Replace(",", ".");
                    App.IniFile["GeneralRainAmount", "Weather"] = generalRainAmount;
                    App.IsSavedData = false;

                    Logs.WriteLog($"GeneralRainAmount(Weather) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"GeneralRainAmount(Weather) value not changed. It's empty. Waiting normal input...", "INFO");
                    generalRainAmount = value;
                    OnPropertyChanged();
                }
            }
        }
        public string RoadReflectionAmount
        {
            get
            {
                return roadReflectionAmount;
            }
            set
            {
                if (double.TryParse(value.Replace(".", ","), out double result) && result >= 0)
                {
                    roadReflectionAmount = result.ToString().Replace(",", ".");
                    App.IniFile["RoadReflectionAmount", "Weather"] = roadReflectionAmount;
                    App.IsSavedData = false;

                    Logs.WriteLog($"RoadReflectionAmount(Weather) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"GeneralRainAmount(Weather) value not changed. It's empty. Waiting normal input...", "INFO");
                    roadReflectionAmount = value;
                    OnPropertyChanged();
                }
            }
        }
        public string RainSize
        {
            get
            {
                return rainSize;
            }
            set
            {
                if (double.TryParse(value.Replace(".", ","), out double result) && result >= 0)
                {
                    rainSize = result.ToString().Replace(",", ".");
                    App.IniFile["RainSize", "Weather"] = rainSize;
                    App.IsSavedData = false;

                    Logs.WriteLog($"RainSize(Weather) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"GeneralRainAmount(Weather) value not changed. It's empty. Waiting normal input...", "INFO");
                    rainSize = value;
                    OnPropertyChanged();
                }
            }
        }
        public string RainIntensity
        {
            get
            {
                return rainIntensity;
            }
            set
            {
                if (double.TryParse(value.Replace(".", ","), out double result) && result >= 0)
                {
                    rainIntensity = result.ToString().Replace(",", ".");
                    App.IniFile["RainIntensity", "Weather"] = rainIntensity;
                    App.IsSavedData = false;

                    Logs.WriteLog($"RainIntensity(Weather) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"GeneralRainAmount(Weather) value not changed. It's empty. Waiting normal input...", "INFO");
                    rainIntensity = value;
                    OnPropertyChanged();
                }
            }
        }
        public string RainCrossing
        {
            get
            {
                return rainCrossing;
            }
            set
            {
                if (double.TryParse(value.Replace(".", ","), out double result) && result >= 0)
                {
                    rainCrossing = result.ToString().Replace(",", ".");
                    App.IniFile["RainCrossing", "Weather"] = rainCrossing;
                    App.IsSavedData = false;

                    Logs.WriteLog($"RainCrossing(Weather) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"RainCrossing(Weather) value not changed. It's empty. Waiting normal input...", "INFO");
                    rainCrossing = value;
                    OnPropertyChanged();
                }
            }
        }
        public string RainSpeed
        {
            get
            {
                return rainSpeed;
            }
            set
            {
                if (double.TryParse(value.Replace(".", ","), out double result) && result >= 0)
                {
                    rainSpeed = result.ToString().Replace(",", ".");
                    App.IniFile["RainSpeed", "Weather"] = rainSpeed;
                    App.IsSavedData = false;

                    Logs.WriteLog($"RainSpeed(Weather) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"RainSpeed(Weather) value not changed. It's empty. Waiting normal input...", "INFO");
                    rainSpeed = value;
                    OnPropertyChanged();
                }
            }
        }
        public string RainGravity
        {
            get
            {
                return rainGravity;
            }
            set
            {
                if (double.TryParse(value.Replace(".", ","), out double result) && result >= 0)
                {
                    rainGravity = result.ToString().Replace(",", ".");
                    App.IniFile["RainGravity", "Weather"] = rainGravity;
                    App.IsSavedData = false;

                    Logs.WriteLog($"RainGravity(Weather) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else
                {
                    Logs.WriteLog($"RainGravity(Weather) value not changed. It's bullshit. Lastest change not applied.", "INFO");
                    rainGravity = value;
                    OnPropertyChanged();
                }
            }
        }

        public WeatherPageViewModel()
        {
            SetValues();
        }

        private void SetValues()
        {
            try
            {
                if (!App.IniFile.IsEmpty)
                {
                    AlwaysRain = App.IniFile["AlwaysRain", "Weather"];
                    GeneralRainAmount = App.IniFile["GeneralRainAmount", "Weather"];
                    RoadReflectionAmount = App.IniFile["RoadReflectionAmount", "Weather"];
                    RainSize = App.IniFile["RainSize", "Weather"];
                    RainIntensity = App.IniFile["RainIntensity", "Weather"];
                    RainCrossing = App.IniFile["RainCrossing", "Weather"];
                    RainSpeed = App.IniFile["RainSpeed", "Weather"];
                    RainGravity = App.IniFile["RainGravity", "Weather"];
                }
                else
                {
                    AlwaysRain = GeneralRainAmount = RoadReflectionAmount = RainSize = RainIntensity = RainCrossing = RainSpeed = RainGravity = "NULL";
                }
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
    }
}
