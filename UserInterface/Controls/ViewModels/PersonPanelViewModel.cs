using System.ComponentModel;
using System.Collections.ObjectModel;
using GingerMintSoft.Domotica.Gui.Extensions;
using GingerMintSoft.Domotica.Gui.UserInterface.Controls.Models;
using Avalonia.Controls;

namespace GingerMintSoft.Domotica.Gui.UserInterface.Controls.ViewModels
{
    public class PersonPanelViewModel
    {
        public ObservableCollection<Person> Persons => new()
        {
            new Person("Cyndi", "/Assets/cyndi-lauper.jpg", Person.EnmResidentialState.In),
            new Person("George", "/Assets/george-clooney.jpg", Person.EnmResidentialState.In),
            new Person("Harry", "/Assets/harry.jpg", Person.EnmResidentialState.In),
            new Person("Hermine", "/Assets/hermine.jpg", Person.EnmResidentialState.Out),
            new Person("Ron", "/Assets/ron.jpg", Person.EnmResidentialState.Out)
        };


        public PersonPanelViewModel()
        {
        }
    }
}
