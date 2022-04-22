using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GingerMintSoft.Domotica.Gui.Models
{
    public class Person
    {
        public enum EnmPersonState
        {
            In = 0,
            Out,
            Unknown
        }

        public Person(string name, string imagePath)
        {
            _name = name;
            _imagePath = imagePath;
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

        private EnmPersonState _personState;

        public EnmPersonState PersonState
        {
            get { return _personState; } 
            set { _personState = value; }
        }
    }
}
