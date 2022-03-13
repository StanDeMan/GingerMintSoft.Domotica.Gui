using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace GingerMintSoft.Domotica.Gui.ViewModels.Views
{
    public class MainWindow : ReactiveWindow<MainWindowViewModel>
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

        public void FullScreenOnClick(object sender, RoutedEventArgs e)
        {
            WindowState = _fullScreen 
                ? WindowState.Maximized 
                : WindowState.FullScreen;

            _fullScreen = !_fullScreen;
        }
    }
}
