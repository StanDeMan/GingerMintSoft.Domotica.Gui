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

        // gets calculated later...
        int _residentialNonPresentTime = 2;

        public Person(string name, string imagePath, EnmResidentialState residentialState)
        {
            _name = name;
            _imagePath = imagePath;
            _residentialState = residentialState;
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _imagePath;

        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; }
        }

        private EnmResidentialState _residentialState;

        public EnmResidentialState ResidentialState
        {
            get { return _residentialState; } 
            set { _residentialState = value; }
        }

        public string? ResidentialStateNotification => _residentialState.GetStringValue() 
            ?? EnmResidentialState.Unknown.GetStringValue();

        public string? ResidentialStateNonPresentNotification
        {
            get 
            {
                return _residentialState == EnmResidentialState.Out 
                    ? $"For {_residentialNonPresentTime} h now" : 
                    string.Empty;
            }
        }

    }
}
