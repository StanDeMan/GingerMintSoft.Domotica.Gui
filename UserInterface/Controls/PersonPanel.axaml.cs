using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;

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

    public class Persons : ObservableCollection<Person> 
    {
        public Persons()
        {
            Add(new Person("Cyndi", "/Assets/cyndi-lauper.jpg"));
            Add(new Person("George", "/Assets/george-clooney.jpg"));
            Add(new Person("Jeff", "/Assets/george-clooney.jpg"));
        }
    }
}
