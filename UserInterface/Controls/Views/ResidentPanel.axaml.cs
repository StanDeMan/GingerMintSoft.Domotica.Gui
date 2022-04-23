using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.ObjectModel;
using GingerMintSoft.Domotica.Gui.UserInterface.Controls.Models;
using GingerMintSoft.Domotica.Gui.UserInterface.Controls.ViewModels;

namespace GingerMintSoft.Domotica.Gui.UserInterface.Controls.Views
{
    public class ResidentPanel : UserControl
    {
        public ResidentPanel()
        {
            InitializeComponent();
            DataContext = new ResidentPanelViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
