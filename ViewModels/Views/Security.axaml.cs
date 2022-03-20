using ReactiveUI;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace GingerMintSoft.Domotica.Gui.ViewModels.Views
{
    public partial class Security : ReactiveUserControl<SecurityViewModel>
    {
        public Security()
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