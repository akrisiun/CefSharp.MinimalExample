using System.Windows;

namespace CefSharp.MinimalExample.Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public interface IWeb : IWebBrowser
    {}

    public interface IBr : IBrowser
    {}

    //public class BrBrowser : IBr
    //{ 
    //}
}
