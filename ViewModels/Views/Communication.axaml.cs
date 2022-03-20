using ReactiveUI;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;

namespace GingerMintSoft.Domotica.Gui.ViewModels.Views
{
    public class Communication : ReactiveUserControl<CommunicationViewModel>
    {
        public Communication()
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
