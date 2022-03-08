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

                ActualDateTime = _actualDateTime = 
                    $"{date.Hour:00}:{date.Minute:00}:{date.Second:00} Uhr    " +
                    $"{date.Day:00} " +
                    $"{date.ToString("MMMM", CultureInfo.GetCultureInfo("de-DE"))} " +
                    $"{date.Year}";
            };

            _timer.Start();
        }

        string notification = "You have got 1 new alert";

        public string Notification
        {
            get => notification;
            set 
            {
                notification = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Notification)));
            }
        }

        private string _actualDateTime = "";
           
        public string ActualDateTime
        {
            get => _actualDateTime;
            set 
            {
                _actualDateTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActualDateTime)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

