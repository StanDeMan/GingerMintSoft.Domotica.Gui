using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GingerMintSoft.Domotica.Gui.UserInterface.Controls
{
    public partial class NavigationPanel : UserControl
    {
        public NavigationPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
