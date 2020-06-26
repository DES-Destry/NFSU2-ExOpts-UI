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
                App.MainConfig["AlwaysRain", "Weather"] = alwaysRain;
                App.IsSavedData = false;

                Logs.WriteLog($"AlwaysRain(Weather) value has been changed to {value}", "INFO");

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
                    App.MainConfig["GeneralRainAmount", "Weather"] = generalRainAmount;
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
                    App.MainConfig["RoadReflectionAmount", "Weather"] = roadReflectionAmount;
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
                    App.MainConfig["RainSize", "Weather"] = rainSize;
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
                    App.MainConfig["RainIntensity", "Weather"] = rainIntensity;
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
                    App.MainConfig["RainCrossing", "Weather"] = rainCrossing;
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
                    App.MainConfig["RainSpeed", "Weather"] = rainSpeed;
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
                    App.MainConfig["RainGravity", "Weather"] = rainGravity;
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
                    AlwaysRain = App.MainConfig["AlwaysRain", "Weather"];
                    GeneralRainAmount = App.MainConfig["GeneralRainAmount", "Weather"];
                    RoadReflectionAmount = App.MainConfig["RoadReflectionAmount", "Weather"];
                    RainSize = App.MainConfig["RainSize", "Weather"];
                    RainIntensity = App.MainConfig["RainIntensity", "Weather"];
                    RainCrossing = App.MainConfig["RainCrossing", "Weather"];
                    RainSpeed = App.MainConfig["RainSpeed", "Weather"];
                    RainGravity = App.MainConfig["RainGravity", "Weather"];
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
