﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace dnaK
{
    public sealed partial class Str : UserControl
    {
        public Str()
        {
            this.InitializeComponent();
        }

        private bool blue;

        public string DNASequence
        {
            get
            {
                return text.Text;
            }
            set
            {
                l.Text = value.Length.ToString();
                text.Text = value;
            }
        }

        public bool Max
        {
            get
            {
                return blue;
            }
            set
            {
                if (value)
                {
                    g.Background = new SolidColorBrush(Color.FromArgb(255, 27, 161, 226));
                    g.RequestedTheme = ElementTheme.Dark;
                }
                else
                {
                    g.Background = new SolidColorBrush(Colors.White);
                    g.RequestedTheme = ElementTheme.Default;
                }
                blue = value;
            }
        }

        private void appBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (Max && ((StackPanel)this.Parent).Children.Count > 1) 
            {
                Max = false;
                ((Str)((StackPanel)this.Parent).Children[1]).Max = true;
            }
            ((StackPanel)this.Parent).Children.Remove(this);
        }
    }
}
