using ReactiveUI;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace GingerMintSoft.Domotica.Gui.ViewModels.Views
{
    public class CcTv : ReactiveUserControl<CcTvViewModel>
    {
        public CcTv()
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