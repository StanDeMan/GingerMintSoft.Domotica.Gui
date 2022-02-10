using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GingerMintSoft.Domotica.Gui.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //WindowState = WindowState.FullScreen;

            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
