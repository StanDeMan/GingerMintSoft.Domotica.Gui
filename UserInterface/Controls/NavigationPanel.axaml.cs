using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.VisualTree;

namespace GingerMintSoft.Domotica.Gui.UserInterface.Controls
{
    public class NavigationPanel : UserControl
    {
        public NavigationPanel()
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

            foreach (var child in (btnToggle?.Parent).GetVisualChildren())
            {
                if (child is ToggleButton tb) tb.IsChecked = false;
            }

            btnToggle!.IsChecked = true;
        }
    }
}
