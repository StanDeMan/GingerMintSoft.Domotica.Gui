using System.ComponentModel;
using GingerMintSoft.Domotica.Gui.Extensions;

namespace GingerMintSoft.Domotica.Gui.UserInterface.Controls.Models
{
    public class Resident : Person, INotifyPropertyChanged
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
            string name, 
            string imagePath = "", 
            EnmResidentialState state = EnmResidentialState.Unknown) : base(name, imagePath)
        {
            Name = name;    
            ImagePath = imagePath;  
            ResidentialState = state;
        }

        public string FirstName
        {
            get => Name;
            set 
            { 
                Name = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            }
        }

        public string ImagePathAndName
        {
            get => ImagePath;
            set 
            { 
                ImagePath = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImagePath)));

                // update dependant
                IsImagePresent = IsImagePresent;
            }        
        }

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

                // update dependant
                IsAbsent = IsAbsent;
                ResidentialStateNotification = ResidentialStateNotification;
                ResidentialStateOutNotification = ResidentialStateOutNotification;
            }
        }

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
