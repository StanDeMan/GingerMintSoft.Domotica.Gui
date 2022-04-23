using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using GingerMintSoft.Domotica.Gui.Main.ViewModels;

namespace GingerMintSoft.Domotica.Gui.Routing
{
    public class ViewLocator : IDataTemplate
    {
        public IControl Build(object data)
        {
            var name = data.GetType().FullName!.Replace("ViewModel", "View");
            var type = Type.GetType(name);

            return type != null 
                ? (Control)Activator.CreateInstance(type)! 
                : new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}
