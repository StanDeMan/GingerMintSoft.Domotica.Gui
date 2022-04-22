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
            Add(new Person("Cyndi", "/Assets/cyndi-lauper.jpg"));
            Add(new Person("George", "/Assets/george-clooney.jpg"));
            Add(new Person("Harry", "/Assets/harry.jpg"));
            Add(new Person("Hermine", "/Assets/hermine.jpg"));
            Add(new Person("Ron", "/Assets/ron.jpg"));
        }
    }
}
