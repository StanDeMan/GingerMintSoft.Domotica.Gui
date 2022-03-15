using System;
using System.ComponentModel;
using System.Globalization;
using Avalonia.Threading;

namespace GingerMintSoft.Domotica.Gui.UserInterface
{
    public class HeaderPanelViewModel : INotifyPropertyChanged
    {
        public HeaderPanelViewModel()
        {
            var timer = new DispatcherTimer 
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            timer.Tick += (sender, args) => 
            {
                var date = DateTime.Now;

                ActualTime = 
                    $"{date.Hour:00}:{date.Minute:00}:{date.Second:00} Uhr";                // time

                ActualDate = 
                    $"{date.Day:00} " +                                                     // day
                    $"{date.ToString("MMMM", CultureInfo.GetCultureInfo("de-DE"))} " +      // month
                    $"{date.Year}";                                                         // year
            };

            timer.Start();
        }

        string _notification = "You have got";

        public string Notification
        {
            get => _notification;
            set 
            {
                _notification = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Notification)));
            }
        }

        string _alert = "1 new alert";

        public string Alert
        {
            get => _alert;
            set 
            {
                _alert = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alert)));
            }
        }

        private string _actualDate = "";
           
        public string ActualDate
        {
            get => _actualDate;
            set 
            {
                _actualDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActualDate)));
            }
        }

        private string _actualTime = "";
           
        public string ActualTime
        {
            get => _actualTime;
            set 
            {
                _actualTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActualTime)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

