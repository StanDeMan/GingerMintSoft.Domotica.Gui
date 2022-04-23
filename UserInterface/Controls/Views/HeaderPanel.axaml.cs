using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using GingerMintSoft.Domotica.Gui.UserInterface.Controls.ViewModels;

namespace GingerMintSoft.Domotica.Gui.UserInterface.Controls.Views
{
    public partial class HeaderPanel : UserControl
    {
        public HeaderPanel()
        {
            InitializeComponent();
            DataContext = new HeaderPanelViewModel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
