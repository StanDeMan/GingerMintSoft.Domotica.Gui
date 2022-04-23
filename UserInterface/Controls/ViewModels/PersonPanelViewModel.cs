using System.Collections.ObjectModel;
using GingerMintSoft.Domotica.Gui.UserInterface.Controls.Models;

namespace GingerMintSoft.Domotica.Gui.UserInterface.Controls.ViewModels
{
    public class PersonPanelViewModel
    {
        // residential persons
        private ObservableCollection<Person> _persons = new();
        public ObservableCollection<Person> Persons
        {
            get => _persons;
            set => _persons = value;
        }

        public PersonPanelViewModel(ObservableCollection<Person> persons)
        {
            Persons = persons;
        }

        public PersonPanelViewModel()
        {
            Persons = new ObservableCollection<Person>
            {
                new Person("Cyndi", "/Assets/cyndi-lauper.jpg", Person.EnmResidentialState.In),
                new Person("George", "/Assets/george-clooney.jpg", Person.EnmResidentialState.In),
                new Person("Harry", "/Assets/harry.jpg", Person.EnmResidentialState.In),
                new Person("Hermine", "/Assets/hermine.jpg", Person.EnmResidentialState.Out),
                new Person("Ron", "/Assets/ron.jpg", Person.EnmResidentialState.Out)
            };
        }
    }
}
