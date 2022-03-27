using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Material.Icons.Avalonia;

namespace GingerMintSoft.Domotica.Gui.UserInterface.Controls
{
    public partial class ToggelButton : UserControl
    {
        private MaterialIcon _icon = new(); 

        public ToggelButton()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void ButtonOnClick(object? sender, RoutedEventArgs e)
        {
            var btnToggle = sender as ToggleButton;
            btnToggle.
        }
    }
}
