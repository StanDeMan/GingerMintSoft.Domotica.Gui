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

        /// <summary>
        /// Residential person with some state
        /// </summary>
        /// <param name="firstName">Person first name</param>
        /// <param name="lastName">Person Lastname</param>
        /// <param name="imagePath">Person image with path and file</param>
        /// <param name="state">Residential state: In, Out, etc.</param>
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

        /// <summary>
        //  Person Firstname
        /// </summary>
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

        /// <summary>
        /// Person Lastname
        /// </summary>
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

        /// <summary>
        /// Person image with related path
        /// </summary>
        private string _imagePath;
        public string ImagePath
        {
            get => _imagePath;

            set 
            { 
                _imagePath = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImagePath)));

                // update dependent
                IsImagePresent = CheckIsImagePresent();
            }        
        }

        /// <summary>
        /// Check if person image present
        /// </summary>
        // ReSharper disable once NotAccessedField.Local
        public bool IsImagePresent
        {
            get => CheckIsImagePresent();

            set 
            { 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsImagePresent)));
            }
        }

        /// <summary>
        /// Person residential state: in, out, etc.
        /// </summary>
        private EnmResidentialState _residentialState;
        public EnmResidentialState ResidentialState
        {
            get => _residentialState;

            set 
            {
                _residentialState = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResidentialState)));

                // update dependent
                IsOut = CheckIsOut();
                ResidentialStateNotification = CheckResidentialStateNotification();
                ResidentialStateOutNotification = CheckResidentialStateOutNotification();
            }
        }

        /// <summary>
        /// Check if person is out of residence
        /// </summary>
        // ReSharper disable once NotAccessedField.Local
        public bool IsOut
        {
            get => CheckIsOut();

            set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsOut)));
            }
        }

        /// <summary>
        /// Person state notification as text: "In", "Out"
        /// </summary>
        // ReSharper disable once NotAccessedField.Local
        public string? ResidentialStateNotification
        {
            get => CheckResidentialStateNotification();

            set
            { 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResidentialStateNotification)));
            }
        }

        /// <summary>
        /// Persons absence in half hour parts
        /// </summary>
        // ReSharper disable once NotAccessedField.Local
        public string? ResidentialStateOutNotification
        {
            get => CheckResidentialStateOutNotification();

            set
            { 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResidentialStateOutNotification)));
            }
        }

        # region Check resident states
        private bool CheckIsImagePresent()
        {
            return !string.IsNullOrEmpty(ImagePath);
        }

        private bool CheckIsOut()
        {
            return ResidentialState == EnmResidentialState.Out;
        }

        private string? CheckResidentialStateNotification()
        {
            return ResidentialState.GetStringValue() 
                ?? EnmResidentialState.Unknown.GetStringValue();
        }

        private string? CheckResidentialStateOutNotification()
        {
            return ResidentialState == EnmResidentialState.Out 
                ? $"For {_residentialNonPresenceTime} h now"
                : string.Empty;
        }

        #endregion Check resident states

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
