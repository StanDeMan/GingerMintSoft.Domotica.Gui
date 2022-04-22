using GingerMintSoft.Domotica.Gui.Extensions;

namespace GingerMintSoft.Domotica.Gui.Models
{
    public class Person
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

        public Person(string name, string imagePath, EnmResidentialState residentialState)
        {
            _name = name;
            _imagePath = imagePath;
            _residentialState = residentialState;
        }

        private string _name;
        public string Name
        {
            get => _name; 
            set => _name = value; 
        }

        private string _imagePath;
        public string ImagePath
        {
            get => _imagePath; 
            set => _imagePath = value; 
        }

        private EnmResidentialState _residentialState = EnmResidentialState.Unknown;
        public EnmResidentialState ResidentialState 
        {
            get => _residentialState;  
            set => _residentialState = value; 
        }

        public bool IsAbsent => _residentialState == EnmResidentialState.Out;

        public bool IsImagePresent => string.IsNullOrEmpty(_imagePath) 
            ? false 
            : true;

        public string? ResidentialStateNotification => _residentialState.GetStringValue() 
            ?? EnmResidentialState.Unknown.GetStringValue();

        public string? ResidentialStateNonPresenceNotification => _residentialState == EnmResidentialState.Out 
            ? $"For {_residentialNonPresenceTime} h now"
            : string.Empty;
    }
}
