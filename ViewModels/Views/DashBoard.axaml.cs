using Avalonia.Controls;
using Avalonia.Markup.Xaml;


namespace GingerMintSoft.Domotica.Gui.ViewModels.Views
{
    public partial class DashBoard : UserControl
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
