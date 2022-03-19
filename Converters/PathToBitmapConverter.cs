using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace GingerMintSoft.Domotica.Gui.Converters
{
    public class PathToBitmapConverter : IValueConverter
    {
        [SuppressMessage("CodeQuality", "IDE0052:Remove unread private members", Justification = "<Pending>")]
        private static readonly PathToBitmapConverter Instance = new();

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) return null;

            if (value is string rawUri && targetType.IsAssignableFrom(typeof(Bitmap)))
            {
                // Allow for assembly overrides
                var uri = rawUri.StartsWith("avares://") 
                    ? new Uri(rawUri) 
                    : new Uri($"avares://{Assembly.GetEntryAssembly()?.GetName().Name}{rawUri}");

                return new Bitmap(AvaloniaLocator.Current
                    .GetService<IAssetLoader>()?
                    .Open(uri));
            }

            throw new NotSupportedException();
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
