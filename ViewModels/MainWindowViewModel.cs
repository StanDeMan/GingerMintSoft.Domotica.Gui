using Splat;
using ReactiveUI;
using System;
using System.Reactive;

namespace GingerMintSoft.Domotica.Gui.ViewModels
{
    using Views;

    public sealed class MainWindowViewModel : ReactiveObject, IScreen
    {
        public ReactiveCommand<Unit, Unit> ChangeTheme { get; }
        public string Greeting => "Welcome to Domotica.Gui!";
        public RoutingState Router { get; } = new RoutingState();

        // The command that navigates a user to first view model.
        public ReactiveCommand<Unit, IRoutableViewModel> GoDashBoard { get; }

        // The command that navigates a user back.
        public ReactiveCommand<Unit, IRoutableViewModel> GoAppliances { get; }

        public MainWindowViewModel(StyleManager styles)
        {
            ChangeTheme = ReactiveCommand.Create(() => styles.UseTheme(styles.CurrentTheme switch
            {
                StyleManager.Theme.Citrus => StyleManager.Theme.Sea,
                StyleManager.Theme.Sea => StyleManager.Theme.Rust,
                StyleManager.Theme.Rust => StyleManager.Theme.Candy,
                StyleManager.Theme.Candy => StyleManager.Theme.Magma,
                StyleManager.Theme.Magma => StyleManager.Theme.Citrus,
                _ => throw new ArgumentOutOfRangeException(nameof(styles.CurrentTheme))
            }));

            Locator.CurrentMutable.Register(() => new DashBoard(), typeof(IViewFor<DashBoardViewModel>));
            Locator.CurrentMutable.Register(() => new Appliances(), typeof(IViewFor<AppliancesViewModel>));

            GoDashBoard = ReactiveCommand.CreateFromObservable(() => 
                Router.Navigate.Execute(new DashBoardViewModel(this)));

            GoAppliances = ReactiveCommand.CreateFromObservable(() => 
                Router.Navigate.Execute(new AppliancesViewModel(this)));
        }
    }
}