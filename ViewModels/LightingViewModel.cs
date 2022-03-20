using ReactiveUI;

namespace GingerMintSoft.Domotica.Gui.ViewModels
{
    public class LightingViewModel : ReactiveObject, IRoutableViewModel
    {
        // Reference to IScreen that owns the routable view model.
        public IScreen HostScreen { get; }

        // Unique identifier for the routable view model.
        public string UrlPathSegment { get; } = "Lighting";

        public LightingViewModel(IScreen screen) => HostScreen = screen;
    }
}