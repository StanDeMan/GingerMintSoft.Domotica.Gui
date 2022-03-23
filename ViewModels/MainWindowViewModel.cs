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
        public static string Greeting => "Welcome to Domotica.Gui!";
        public RoutingState Router { get; } = new RoutingState();

        // The command that navigates to the dash board
        public ReactiveCommand<Unit, IRoutableViewModel> GoDashBoard { get; }

        // The command that navigates to appliances view
        public ReactiveCommand<Unit, IRoutableViewModel> GoAppliances { get; }

        // he command that navigates to air condition view 
        public ReactiveCommand<Unit, IRoutableViewModel> GoAirCondition { get; }

         // he command that navigates to lighting view 
        public ReactiveCommand<Unit, IRoutableViewModel> GoLighting { get; }

        // he command that navigates to communication view 
        public ReactiveCommand<Unit, IRoutableViewModel> GoCommunication { get; }

        // he command that navigates to security view 
        public ReactiveCommand<Unit, IRoutableViewModel> GoSecurity { get; }

        // he command that navigates to CCTV view 
        public ReactiveCommand<Unit, IRoutableViewModel> GoCcTv { get; }

        // he command that navigates to settings view 
        public ReactiveCommand<Unit, IRoutableViewModel> GoSettings { get; }

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
            Locator.CurrentMutable.Register(() => new Communication(), typeof(IViewFor<CommunicationViewModel>));
            Locator.CurrentMutable.Register(() => new Security(), typeof(IViewFor<SecurityViewModel>));
            Locator.CurrentMutable.Register(() => new CcTv(), typeof(IViewFor<CcTvViewModel>));
            Locator.CurrentMutable.Register(() => new Settings(), typeof(IViewFor<SettingsViewModel>));

            GoDashBoard = ReactiveCommand.CreateFromObservable(() => 
                Router.Navigate.Execute(new DashBoardViewModel(this)));

            GoAirCondition = ReactiveCommand.CreateFromObservable(() => 
                Router.Navigate.Execute(new AirConditionViewModel(this)));

            GoLighting = ReactiveCommand.CreateFromObservable(() => 
                Router.Navigate.Execute(new LightingViewModel(this)));

            GoAppliances = ReactiveCommand.CreateFromObservable(() => 
                Router.Navigate.Execute(new AppliancesViewModel(this)));

            GoCommunication = ReactiveCommand.CreateFromObservable(() => 
                Router.Navigate.Execute(new CommunicationViewModel(this)));

            GoSecurity = ReactiveCommand.CreateFromObservable(() => 
                Router.Navigate.Execute(new SecurityViewModel(this)));

            GoCcTv = ReactiveCommand.CreateFromObservable(() => 
                Router.Navigate.Execute(new CcTvViewModel(this)));

            GoSettings = ReactiveCommand.CreateFromObservable(() => 
                Router.Navigate.Execute(new SettingsViewModel(this)));
        }
    }
}