using System;
using System.Collections.ObjectModel;
using Avalonia.Threading;
using GingerMintSoft.Domotica.Gui.UserInterface.Controls.Models;

namespace GingerMintSoft.Domotica.Gui.UserInterface.Controls.ViewModels
{
    public class ResidentPanelViewModel
    {
        // residential persons
        private ObservableCollection<Resident> _residents = new();
        public ObservableCollection<Resident> Residents
        {
            get => _residents;
            set => _residents = value;
        }

        public ResidentPanelViewModel(ObservableCollection<Resident> residents)
        {
            Residents = residents;
        }

        public ResidentPanelViewModel()
        {
            Residents = new ObservableCollection<Resident>
            {
                new Resident("Cyndi", "/Assets/cyndi-lauper.jpg", Resident.EnmResidentialState.In),
                new Resident("George", "/Assets/george-clooney.jpg", Resident.EnmResidentialState.In),
                new Resident("Harry", "/Assets/harry.jpg", Resident.EnmResidentialState.In),
                new Resident("Hermine", "/Assets/hermine.jpg", Resident.EnmResidentialState.Out),
                new Resident("Ron", "/Assets/ron.jpg", Resident.EnmResidentialState.Out)
            };

            // Fake data MVVM test
            //var timer = new DispatcherTimer
            //{
            //    Interval = TimeSpan.FromSeconds(5)
            //};

            //timer.Tick += (sender, args) =>
            //{
            //    Residents[0].ResidentialState = Residents[0].ResidentialState == Resident.EnmResidentialState.Out
            //        ? Resident.EnmResidentialState.In
            //        : Resident.EnmResidentialState.Out;

            //    Residents[0].ImagePathAndName = Residents[0].ResidentialState == Resident.EnmResidentialState.In 
            //    ? "" 
            //    : "/Assets/cyndi-lauper.jpg";
            //};

            //timer.Start();
        }
    }
}
