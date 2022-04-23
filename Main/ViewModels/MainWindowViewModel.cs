using Splat;
using ReactiveUI;
using System;
using System.Reactive;
using GingerMintSoft.Domotica.Gui.Main.Views;
using GingerMintSoft.Domotica.Gui.Style;
using System.Reflection;

namespace GingerMintSoft.Domotica.Gui.Main.ViewModels
{
    public sealed class MainWindowViewModel : ReactiveObject, IScreen
    {
        public ReactiveCommand<Unit, Unit> ChangeTheme { get; }

        public RoutingState Router { get; } = new RoutingState();

        // The command that navigates to the dash board
        public ReactiveCommand<Unit, IRoutableViewModel> NavigateToDashBoard { get; }

        // The command that navigates to appliances view
        public ReactiveCommand<Unit, IRoutableViewModel> NavigateToAppliances { get; }

        // The command that navigates to air condition view 
        public ReactiveCommand<Unit, IRoutableViewModel> NavigateToAirCondition { get; }

        // The command that navigates to lighting view 
        public ReactiveCommand<Unit, IRoutableViewModel> NavigateToLighting { get; }

        // The command that navigates to communication view 
        public ReactiveCommand<Unit, IRoutableViewModel> NavigateToCommunication { get; }

        // The command that navigates to security view 
        public ReactiveCommand<Unit, IRoutableViewModel> NavigateToSecurity { get; }

        // The command that navigates to CCTV view 
        public ReactiveCommand<Unit, IRoutableViewModel> NavigateToCcTv { get; }

        // The command that navigates to settings view 
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

            Locator.CurrentMutable.RegisterViewsForViewModels(Assembly.GetExecutingAssembly());

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