﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CefSharp.MinimalExample.Wpf.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class BrowseTab : UserControl
    {
        public BrowseTab()
        {
            InitializeComponent();

            //browser.KeyDown += browser_KeyDown;
        }

        //void browser_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.S)
        //    {
        //        e.Handled = true;
        //    }
        //}
    }
}
