using GingerMintSoft.Domotica.Gui.Extensions;
using System.ComponentModel;

namespace GingerMintSoft.Domotica.Gui.UserInterface.Controls.Models
{
    public class Person
    {
        /// <summary>
        /// Person ctor
        /// </summary>
        /// <param name="name">Prename of Person</param>
        /// <param name="imagePath">Path and image name with extension</param>
        /// <param name="residentialState">EnmResidentialState</param>
        public Person(
            string name,
            string imagePath)
        {
            _name = name;
            _lastName = string.Empty;
            _imagePath = imagePath;
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        private string _imagePath;
        public string ImagePath
        {
            get => _imagePath;
            set => _imagePath = value;
        }
    }
}
