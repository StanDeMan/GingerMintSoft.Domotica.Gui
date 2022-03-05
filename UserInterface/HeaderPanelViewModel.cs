using ReactiveUI;

namespace GingerMintSoft.Domotica.Gui.ViewModels
{
    public class HeaderPanelViewModel : ReactiveObject
    {
        // Reference to IScreen that owns the routable view model.
        public IScreen HostScreen { get; }

        // Unique identifier for the routable view model.
        public string UrlPathSegment { get; } = "HeaderPanel";

        public HeaderPanelViewModel(IScreen screen) => HostScreen = screen;
    }
}

