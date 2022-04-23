using ReactiveUI;

namespace GingerMintSoft.Domotica.Gui.Main.ViewModels
{
    public class CcTvViewModel : ReactiveObject, IRoutableViewModel
    {
        // Reference to IScreen that owns the routable view model.
        public IScreen HostScreen { get; }

        // Unique identifier for the routable view model.
        public string UrlPathSegment { get; } = "CCTV";

        public CcTvViewModel(IScreen screen) => HostScreen = screen;
    }
}
