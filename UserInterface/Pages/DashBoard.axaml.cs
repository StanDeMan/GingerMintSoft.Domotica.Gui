using Avalonia.Controls;
using Avalonia.Markup.Xaml;


namespace GingerMintSoft.Domotica.Gui.UserInterface.Pages
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
