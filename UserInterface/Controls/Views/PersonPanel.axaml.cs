using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.ObjectModel;
using GingerMintSoft.Domotica.Gui.UserInterface.Controls.Models;
using GingerMintSoft.Domotica.Gui.UserInterface.Controls.ViewModels;

namespace GingerMintSoft.Domotica.Gui.UserInterface.Controls.Views
{
    public class PersonPanel : UserControl
    {
        public PersonPanel()
        {
            InitializeComponent();
            DataContext = new PersonPanelViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
