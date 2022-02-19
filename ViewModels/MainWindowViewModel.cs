using System;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;

namespace GingerMintSoft.Domotica.Gui.ViewModels
{
    public sealed class MainWindowViewModel : ReactiveValidationObject
    {
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
        }

        public string Greeting => "Welcome to Domotica.Gui!";

        public ReactiveCommand<Unit, Unit> ChangeTheme { get; }
    }
}
