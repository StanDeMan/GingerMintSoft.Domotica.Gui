using ReactiveUI;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using GingerMintSoft.Domotica.Gui.Main.ViewModels;

namespace GingerMintSoft.Domotica.Gui.Main.Views
{
    public class Appliances : ReactiveUserControl<AppliancesViewModel>
    {
        public Appliances()
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
