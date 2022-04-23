using System;
using System.Linq;
using System.Collections.ObjectModel;
using Avalonia.Threading;
using GingerMintSoft.Domotica.Gui.UserInterface.Controls.Models;

namespace GingerMintSoft.Domotica.Gui.UserInterface.Controls.ViewModels
{
    public class ResidentPanelViewModel
    {
        // residential persons
        public ObservableCollection<Resident> Residents { get; set; }

        public ResidentPanelViewModel(ObservableCollection<Resident> residents)
        {
            Residents = residents;
        }

        public ResidentPanelViewModel()
        {
            Residents = new ObservableCollection<Resident>
            {
                new Resident("Cyndi", "Lauper", "/Assets/Images/cyndi-lauper.jpg", Resident.EnmResidentialState.In),
                new Resident("George", "Clooney", "/Assets/Images/george-clooney.jpg", Resident.EnmResidentialState.In),
                new Resident("Harry", "Potter", "/Assets/Images/harry.jpg", Resident.EnmResidentialState.In),
                new Resident("Hermine", "Granger", "/Assets/Images/hermine.jpg", Resident.EnmResidentialState.Out),
                new Resident("Ron", "Weasley", "/Assets/Images/ron.jpg", Resident.EnmResidentialState.Out)
            };

            // Fake data MVVM test
            var timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(5)
            };

            timer.Tick += (_, _) =>
            {
                var resident = Residents.FirstOrDefault(r => r.FirstName == "Ron");
                if (resident == null) return;

                resident.ResidentialState = resident.ResidentialState == Resident.EnmResidentialState.Out
                    ? Resident.EnmResidentialState.In
                    : Resident.EnmResidentialState.Out;

                resident.ImagePath = resident.ResidentialState == Resident.EnmResidentialState.Out
                    ? "/Assets/ron.jpg"
                    : "";
            };

            timer.Start();
        }
    }
}
