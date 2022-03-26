using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GingerMintSoft.Domotica.Gui.UserInterface.Controls
{
    public partial class ToggelButton : UserControl
    {
        public ToggelButton()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
