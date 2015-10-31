using System.Windows;
using System.Diagnostics;
using CefSharp.MinimalExample.Wpf.ViewModels;

namespace CefSharp.MinimalExample.Wpf
{
    public partial class MainWindow : Window
    {
        public ButtonsModel Buttons { get; protected set; }

        public MainWindow()
        {
            InitializeComponent();

            Buttons = new ButtonsModel { Window = this, TabControl = this.tabControl };
            DataContext = Buttons;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Buttons.Bind();
        }
    }
}
