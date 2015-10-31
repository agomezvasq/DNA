﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

        public string DNASequence
        {
            get
            {
                return text.Text;
            }
            set
            {
                if (value.Length <= 21)
                    text.FontSize = 5.6d;
                else
                    text.FontSize = 11.25d;
                text.Text = value;
            }
        }

        private void appBarButton_Click(object sender, RoutedEventArgs e)
        {
            ((StackPanel)this.Parent).Children.Remove(this);
        }
    }
}
