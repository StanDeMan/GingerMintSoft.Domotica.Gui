using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace GingerMintSoft.Domotica.Gui.Views
{
    public partial class MainWindow : Window
    {
        private bool _fullScreen;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void FullScreenClick(object sender, RoutedEventArgs e)
        {
            WindowState = _fullScreen 
                ? WindowState.Maximized 
                : WindowState.FullScreen;

            _fullScreen = !_fullScreen;
        }
    }
}
