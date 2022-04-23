using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using GingerMintSoft.Domotica.Gui.Main.ViewModels;

namespace GingerMintSoft.Domotica.Gui.Main.Views
{
    public class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        private WindowState _oldWindowSize = WindowState.Maximized;

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
            if(WindowState != WindowState.FullScreen)
                _oldWindowSize = WindowState;

            WindowState = WindowState != WindowState.FullScreen
                ? WindowState.FullScreen 
                : _oldWindowSize;        
        }
    }
}
