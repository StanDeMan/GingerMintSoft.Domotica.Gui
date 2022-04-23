using ReactiveUI;

namespace GingerMintSoft.Domotica.Gui.Main.ViewModels
{
    public class AirConditionViewModel : ReactiveObject, IRoutableViewModel
    {
        // Reference to IScreen that owns the routable view model.
        public IScreen HostScreen { get; }

        // Unique identifier for the routable view model.
        public string UrlPathSegment { get; } = "AirConditioning";

        public AirConditionViewModel(IScreen screen) => HostScreen = screen;
    }
}
