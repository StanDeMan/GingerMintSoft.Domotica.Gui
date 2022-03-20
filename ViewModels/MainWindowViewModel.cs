using Splat;
using ReactiveUI;
using System;
using System.Reactive;
using GingerMintSoft.Domotica.Gui.Style;

namespace GingerMintSoft.Domotica.Gui.ViewModels
{
    using Views;

    public sealed class MainWindowViewModel : ReactiveObject, IScreen
    {
        public ReactiveCommand<Unit, Unit> ChangeTheme { get; }
        public string Greeting => "Welcome to Domotica.Gui!";
        public RoutingState Router { get; } = new RoutingState();

        // The command that navigates to the dash board
        public ReactiveCommand<Unit, IRoutableViewModel> GoDashBoard { get; }

        // The command that navigates to appliances view
        public ReactiveCommand<Unit, IRoutableViewModel> GoAppliances { get; }

        // he command that navigates to air condition view 
        public ReactiveCommand<Unit, IRoutableViewModel> GoAirCondition { get; }

         // he command that navigates to lighting view 
        public ReactiveCommand<Unit, IRoutableViewModel> GoLighting { get; }

        public MainWindowViewModel(StyleManager styles)
        {
            ChangeTheme = ReactiveCommand.Create(() => styles.UseTheme(styles.CurrentTheme switch
            {
                StyleManager.Theme.Heima => StyleManager.Theme.Citrus,
                StyleManager.Theme.Citrus => StyleManager.Theme.Sea,
                StyleManager.Theme.Sea => StyleManager.Theme.Rust,
                StyleManager.Theme.Rust => StyleManager.Theme.Candy,
                StyleManager.Theme.Candy => StyleManager.Theme.Magma,
                StyleManager.Theme.Magma => StyleManager.Theme.Heima,
                _ => throw new ArgumentOutOfRangeException(nameof(styles.CurrentTheme))
            }));

            Locator.CurrentMutable.Register(() => new DashBoard(), typeof(IViewFor<DashBoardViewModel>));
            Locator.CurrentMutable.Register(() => new AirCondition(), typeof(IViewFor<AirConditionViewModel>));
            Locator.CurrentMutable.Register(() => new Lighting(), typeof(IViewFor<LightingViewModel>));
            Locator.CurrentMutable.Register(() => new Appliances(), typeof(IViewFor<AppliancesViewModel>));

            GoDashBoard = ReactiveCommand.CreateFromObservable(() => 
                Router.Navigate.Execute(new DashBoardViewModel(this)));

            GoAirCondition = ReactiveCommand.CreateFromObservable(() => 
                Router.Navigate.Execute(new AirConditionViewModel(this)));

            GoLighting = ReactiveCommand.CreateFromObservable(() => 
                Router.Navigate.Execute(new LightingViewModel(this)));

            GoAppliances = ReactiveCommand.CreateFromObservable(() => 
                Router.Navigate.Execute(new AppliancesViewModel(this)));
        }
    }
}