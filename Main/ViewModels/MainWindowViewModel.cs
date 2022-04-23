using Splat;
using ReactiveUI;
using System;
using System.Reactive;
using GingerMintSoft.Domotica.Gui.Main.Views;
using GingerMintSoft.Domotica.Gui.Style;

namespace GingerMintSoft.Domotica.Gui.Main.ViewModels
{
    public sealed class MainWindowViewModel : ReactiveObject, IScreen
    {
        public ReactiveCommand<Unit, Unit> ChangeTheme { get; }
        public static string Greeting => "Welcome to Domotica.Gui!";
        public RoutingState Router { get; } = new RoutingState();

        // The command that navigates to the dash board
        public ReactiveCommand<Unit, IRoutableViewModel> NavigateToDashBoard { get; }

        // The command that navigates to appliances view
        public ReactiveCommand<Unit, IRoutableViewModel> NavigateToAppliances { get; }

        // he command that navigates to air condition view 
        public ReactiveCommand<Unit, IRoutableViewModel> NavigateToAirCondition { get; }

        // he command that navigates to lighting view 
        public ReactiveCommand<Unit, IRoutableViewModel> NavigateToLighting { get; }

        // he command that navigates to communication view 
        public ReactiveCommand<Unit, IRoutableViewModel> NavigateToCommunication { get; }

        // he command that navigates to security view 
        public ReactiveCommand<Unit, IRoutableViewModel> NavigateToSecurity { get; }

        // he command that navigates to CCTV view 
        public ReactiveCommand<Unit, IRoutableViewModel> NavigateToCcTv { get; }

        // he command that navigates to settings view 
        public ReactiveCommand<Unit, IRoutableViewModel> NavigateToSettings { get; }

        public MainWindowViewModel(MainWindow window)
        {
            StyleManager? styles = new(window);

            ChangeTheme = ReactiveCommand.Create(() => styles.UseTheme(theme: styles.CurrentTheme switch
            {
                StyleManager.Theme.Heima => StyleManager.Theme.Citrus,
                StyleManager.Theme.Citrus => StyleManager.Theme.Sea,
                StyleManager.Theme.Sea => StyleManager.Theme.Rust,
                StyleManager.Theme.Rust => StyleManager.Theme.Candy,
                StyleManager.Theme.Candy => StyleManager.Theme.Magma,
                StyleManager.Theme.Magma => StyleManager.Theme.Heima,
                _ => throw new ArgumentException(nameof(styles.CurrentTheme))
            }));

            Locator.CurrentMutable.Register(() => new DashBoard(), typeof(IViewFor<DashBoardViewModel>));
            Locator.CurrentMutable.Register(() => new AirCondition(), typeof(IViewFor<AirConditionViewModel>));
            Locator.CurrentMutable.Register(() => new Lighting(), typeof(IViewFor<LightingViewModel>));
            Locator.CurrentMutable.Register(() => new Appliances(), typeof(IViewFor<AppliancesViewModel>));
            Locator.CurrentMutable.Register(() => new Communication(), typeof(IViewFor<CommunicationViewModel>));
            Locator.CurrentMutable.Register(() => new Security(), typeof(IViewFor<SecurityViewModel>));
            Locator.CurrentMutable.Register(() => new CcTv(), typeof(IViewFor<CcTvViewModel>));
            Locator.CurrentMutable.Register(() => new Settings(), typeof(IViewFor<SettingsViewModel>));

            NavigateToDashBoard = ReactiveCommand.CreateFromObservable(() =>
                Router.Navigate.Execute(new DashBoardViewModel(this)));

            NavigateToAirCondition = ReactiveCommand.CreateFromObservable(() =>
                Router.Navigate.Execute(new AirConditionViewModel(this)));

            NavigateToLighting = ReactiveCommand.CreateFromObservable(() =>
                Router.Navigate.Execute(new LightingViewModel(this)));

            NavigateToAppliances = ReactiveCommand.CreateFromObservable(() =>
                Router.Navigate.Execute(new AppliancesViewModel(this)));

            NavigateToCommunication = ReactiveCommand.CreateFromObservable(() =>
                Router.Navigate.Execute(new CommunicationViewModel(this)));

            NavigateToSecurity = ReactiveCommand.CreateFromObservable(() =>
                Router.Navigate.Execute(new SecurityViewModel(this)));

            NavigateToCcTv = ReactiveCommand.CreateFromObservable(() =>
                Router.Navigate.Execute(new CcTvViewModel(this)));

            NavigateToSettings = ReactiveCommand.CreateFromObservable(() =>
                Router.Navigate.Execute(new SettingsViewModel(this)));
        }
    }
}