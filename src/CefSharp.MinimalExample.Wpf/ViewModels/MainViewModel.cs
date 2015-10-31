using CefSharp.MinimalExample.Wpf.Mvvm;
using CefSharp.Wpf;
using System;
using System.ComponentModel;
using System.Windows;

namespace CefSharp.MinimalExample.Wpf.ViewModels
{
    public class BrowserService : IObservable<IWpfWebBrowser>
    {
        public IDisposable Subscribe(IObserver<IWpfWebBrowser> observer) { return null; }
    }

    public class MainViewModel : IObserver<IWpfWebBrowser>, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public IObserver<IWpfWebBrowser> Observer { get; set; }

        public void OnNext(IWpfWebBrowser value) { }
        public void OnError(Exception error) { }
        public void OnCompleted() { }
        public void Dispose() { }

        private IWpfWebBrowser webBrowser;
        public IWpfWebBrowser WebBrowser
        {
            get { return webBrowser; }
            set { PropertyChanged.ChangeAndNotify(ref webBrowser, value, () => WebBrowser); }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { PropertyChanged.ChangeAndNotify(ref title, value, () => Title); }
        }

        public MainViewModel()
        {
            PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (Observer != null && e.PropertyName == "WebBrowser")
            {
                Observer.OnNext(webBrowser);
            }

            if (e.PropertyName == "Title")
            {
                Application.Current.MainWindow.Title = "CefSharp.MinimalExample.Wpf - " + Title;
                if (Observer != null)
                    Observer.OnNext(webBrowser);
            }
        }
    }
}
