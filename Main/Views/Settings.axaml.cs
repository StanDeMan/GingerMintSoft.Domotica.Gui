using ReactiveUI;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using GingerMintSoft.Domotica.Gui.Main.ViewModels;

namespace GingerMintSoft.Domotica.Gui.Main.Views
{
    public partial class Settings : ReactiveUserControl<SettingsViewModel>
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.WhenActivated(_ => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}
