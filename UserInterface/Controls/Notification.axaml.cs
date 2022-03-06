using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GingerMintSoft.Domotica.Gui.UserInterface.Controls
{
    public partial class Notification : UserControl
    {
        public Notification()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
