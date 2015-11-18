using System.Windows;

namespace CefSharp.MinimalExample.Wpf
{
    public partial class App : Application
    {
        static App()
        {
            var dir = System.AppDomain.CurrentDomain.BaseDirectory;
        }

        public App()
        {
            Cef.Initialize(new CefSettings());
        }
    }
}
