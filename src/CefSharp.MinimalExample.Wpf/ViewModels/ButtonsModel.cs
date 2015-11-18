using CefSharp.MinimalExample.Wpf.Views;
using CefSharp.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace CefSharp.MinimalExample.Wpf.ViewModels
{
    public class BrowseTabModel : IObserver<IWpfWebBrowser>, IDisposable
    {
        // public event PropertyChangedEventHandler PropertyChanged;
        public IObserver<IWpfWebBrowser> Observer { get; set; }

        public void OnNext(IWpfWebBrowser value)
        {
            if (value == null)
                return;
            Header = value.Title; Update();
        }

        public void OnError(Exception error) { }
        public void OnCompleted() { }
        public void Dispose() { }

        public BrowseTab Content { get; set; }
        public TabItem Page { get; set; }
        public MainViewModel BrowseModel { [DebuggerStepThrough] get { return Content.browser.DataContext as MainViewModel; } }
        public ChromiumWebBrowser Browser { get; set; }

        public string Header { get; set; }
        public string Url { get; set; }

        public int Number { get; set; }

        public void Bind()
        {
            BrowseModel.Observer = this;
        }

        public void Update()
        {
            if (Browser == null)
            {
                Browser = BrowseModel.WebBrowser as ChromiumWebBrowser;
                if (this.Url != null)
                    Browser.Address = this.Url;

                Content.url.Text = Browser.Address;
            }

            var title = BrowseModel.Title;
            if (title != null)
            {
                Header = title;
                Content.url.Text = Browser.Address;

                var check = Page.Header;
                if (check is string)
                    Page.SetValue(HeaderedContentControl.HeaderProperty, title);
            }
        }

        public void ActivatePage() { }
    }


    public class ButtonsModel
    {
        public MainWindow Window { [DebuggerStepThrough] get; set; }
        public TabsContainer TabControl { [DebuggerStepThrough] get; set; }
        public Collection<BrowseTabModel> Pages { get; set; }

        public void Bind()
        {
            Pages = new Collection<BrowseTabModel>();

            var pages = TabControl.Items;
            foreach (TabPage page in pages)
            {
                var content = page.Content as BrowseTab;
                Pages.Add(new BrowseTabModel
                {
                    Number = Pages.Count,
                    Content = content,
                    Page = page,
                    Header = page.Header as string
                });
                Pages[Pages.Count - 1].Bind();
            }

            Pages[0].Url = "http://google.com";
            Pages[1].Url = "http://github.com";
            Pages[2].Url = "http://youtube.com";
        }
    }
}
