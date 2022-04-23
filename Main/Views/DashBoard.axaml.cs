using ReactiveUI;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using GingerMintSoft.Domotica.Gui.Main.ViewModels;

namespace GingerMintSoft.Domotica.Gui.Main.Views
{
    public class DashBoard : ReactiveUserControl<DashBoardViewModel>
    {
        public DashBoard()
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
