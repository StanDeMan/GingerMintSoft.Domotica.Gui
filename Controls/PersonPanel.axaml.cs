using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace GingerMintSoft.Domotica.Gui.Controls
{
    public partial class PersonPanel : UserControl
    {
        public PersonPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
