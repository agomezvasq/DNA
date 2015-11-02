using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using DNA;
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
    public sealed partial class StringItemM : UserControl
    {
        private Sequence s;
        private List<StackPanel> st;

        public StringItemM(Sequence s, List<StackPanel> st)
        {
            this.st = st;

            this.InitializeComponent();

            this.s = s;
            this.text.Text = s.getSeq();
            this.l.Text = s.getSeq().Length.ToString();
        }

        private bool blue;

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
                    pr.Visibility = Visibility.Collapsed;
                } else
                {
                    g.Background = new SolidColorBrush(Colors.White);
                    g.RequestedTheme = ElementTheme.Default;
                    pr.Visibility = Visibility.Visible;
                }
                blue = value;
            }
        }

        public string PMatch
        {
            get
            {
                return pr.Text;
            }
            set
            {
                pr.Text = value;
            }
        }

        public Sequence getSequence() { return this.s; }

        private void sw_Toggled(object sender, RoutedEventArgs e)
        {
            if (sw.IsOn)
                foreach (StackPanel sP in st)
                    sP.Visibility = Visibility.Visible;
            else
                foreach (StackPanel sP in st)
                    sP.Visibility = Visibility.Collapsed;
        }

        private void UserControl_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            text.Text = s.getStr();
        }

        private void UserControl_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            text.Text = s.getSeq();
        }
    }
}
