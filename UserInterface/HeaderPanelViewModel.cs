using Avalonia.Threading;
using ReactiveUI;
using System;
using System.ComponentModel;
using System.Globalization;

namespace GingerMintSoft.Domotica.Gui.ViewModels
{
    public class HeaderPanelViewModel : INotifyPropertyChanged
    {
        private readonly DispatcherTimer _timer;

        public HeaderPanelViewModel()
        {
            _timer = new DispatcherTimer 
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            _timer.Tick += (sender, args) => 
            {
                var date = DateTime.Now;

                ActualTime = 
                    $"{date.Hour:00}:{date.Minute:00}:{date.Second:00} Uhr";                // time

                ActualDate = 
                    $"{date.Day:00} " +                                                     // day
                    $"{date.ToString("MMMM", CultureInfo.GetCultureInfo("de-DE"))} " +      // month
                    $"{date.Year}";                                                         // year
            };

            _timer.Start();
        }

        string notification = "You have got";

        public string Notification
        {
            get => notification;
            set 
            {
                notification = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Notification)));
            }
        }

        string alert = "1 new alert";

        public string Alert
        {
            get => alert;
            set 
            {
                alert = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alert)));
            }
        }

        private string actualDate = "";
           
        public string ActualDate
        {
            get => actualDate;
            set 
            {
                actualDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActualDate)));
            }
        }

        private string actualTime = "";
           
        public string ActualTime
        {
            get => actualTime;
            set 
            {
                actualTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActualTime)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

