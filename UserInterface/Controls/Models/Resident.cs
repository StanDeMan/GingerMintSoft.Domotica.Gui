using System.ComponentModel;
using GingerMintSoft.Domotica.Gui.Extensions;

namespace GingerMintSoft.Domotica.Gui.UserInterface.Controls.Models
{
    public class Resident : INotifyPropertyChanged
    {
        public enum EnmResidentialState
        {
            [EnumStringValue("IN")]
            In = 0,
            [EnumStringValue("OUT")]
            Out,
            [EnumStringValue("UNKNOWN")]
            Unknown
        }

        // TODO: gets calculated later...
        private readonly int _residentialNonPresenceTime = 2;

        public Resident(
            string firstName = "",
            string lastName = "", 
            string imagePath = "", 
            EnmResidentialState state = EnmResidentialState.Unknown)
        {
            _firstName = firstName;
            _imagePath = imagePath;
            _lastName = lastName;
            ResidentialState = state;
        }

        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set 
            { 
                _firstName = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set 
            { 
                _lastName = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
            }
        }

        private string _imagePath;
        public string ImagePath
        {
            get => _imagePath;
            set 
            { 
                _imagePath = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImagePath)));

                // update dependent
                IsImagePresent = IsImagePresent;
            }        
        }

        // ReSharper disable once NotAccessedField.Local
        private bool _isImagePresent;
        public bool IsImagePresent
        {
            get => !string.IsNullOrEmpty(ImagePath);

            set 
            { 
                _isImagePresent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsImagePresent)));
            }
        }

        private EnmResidentialState _residentialState;
        public EnmResidentialState ResidentialState
        {
            get => _residentialState;
            set 
            {
                _residentialState = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResidentialState)));

                // update dependent
                IsAbsent = IsAbsent;
                ResidentialStateNotification = ResidentialStateNotification;
                ResidentialStateOutNotification = ResidentialStateOutNotification;
            }
        }

        // ReSharper disable once NotAccessedField.Local
        private bool _isAbsent;
        public bool IsAbsent
        {
            get => ResidentialState == EnmResidentialState.Out;

            set
            {
                _isAbsent = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAbsent)));
            }
        }

        // ReSharper disable once NotAccessedField.Local
        private string? _residentialStateNotification;
        public string? ResidentialStateNotification
        {
            get => ResidentialState.GetStringValue() 
                ?? EnmResidentialState.Unknown.GetStringValue();

            set
            { 
                _residentialStateNotification = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResidentialStateNotification)));
            }
        }

        // ReSharper disable once NotAccessedField.Local
        private string? _residentialStateOutNotification;
        public string? ResidentialStateOutNotification
        {
            get => ResidentialState == EnmResidentialState.Out 
                ? $"For {_residentialNonPresenceTime} h now"
                : string.Empty;

            set
            { 
                _residentialStateOutNotification = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResidentialStateOutNotification)));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
