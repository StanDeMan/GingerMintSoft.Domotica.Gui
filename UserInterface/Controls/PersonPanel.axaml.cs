using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using GingerMintSoft.Domotica.Gui.Models;

namespace GingerMintSoft.Domotica.Gui.UserInterface.Controls
{
    public partial class PersonPanel : UserControl
    {
        public PersonPanel()
        {
            InitializeComponent();

            var listBoxPersons = this.FindControl<ListBox>("listBoxPersons");
            listBoxPersons.Items = new Persons();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }

    public class Persons : ObservableCollection<Person> 
    {
        public Persons()
        {
            Add(new Person("Cyndi", "/Assets/cyndi-lauper.jpg", Person.EnmResidentialState.In));
            Add(new Person("George", "/Assets/george-clooney.jpg", Person.EnmResidentialState.In));
            Add(new Person("Harry", "/Assets/harry.jpg", Person.EnmResidentialState.In));
            Add(new Person("Hermine", "/Assets/hermine.jpg", Person.EnmResidentialState.Out));
            Add(new Person("Ron", "/Assets/ron.jpg", Person.EnmResidentialState.Out));
        }
    }
}
