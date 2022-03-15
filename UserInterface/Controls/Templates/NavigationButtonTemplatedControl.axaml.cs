using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;

namespace GingerMintSoft.Domotica.Gui.UserInterface.Controls.Templates
{
    public class NavigationButtonTemplatedControl : ContentControl
    {
        public NavigationButtonTemplatedControl()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public static readonly StyledProperty<IBitmap> ButtonImageProperty =
            AvaloniaProperty.Register<NavigationButtonTemplatedControl, IBitmap>(nameof(ButtonImage));

        public IBitmap ButtonImage
        {
            get => GetValue(ButtonImageProperty);
            set => SetValue(ButtonImageProperty, value);
        }

        public static readonly StyledProperty<bool> ButtonIsCheckedProperty =
            AvaloniaProperty.Register<NavigationButtonTemplatedControl, bool>(nameof(ButtonIsChecked));

        public bool ButtonIsChecked
        {
            get => GetValue(ButtonIsCheckedProperty);
            set => SetValue(ButtonIsCheckedProperty, value);
        }
    }
}
