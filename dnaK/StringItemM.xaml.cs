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
        private StackPanel st;
        private List<Canvas> c;

        public StringItemM(Sequence s, StackPanel st)
        {
            this.InitializeComponent();

            this.s = s;
            this.text.Text = s.getSeq();
            this.l.Text = s.getSeq().Length.ToString();

            this.st = st;
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
                } else
                {
                    g.Background = new SolidColorBrush(Colors.White);
                    g.RequestedTheme = ElementTheme.Default;
                }
                blue = value;
            }
        }

        public bool Show
        {
            get
            {
                return sw.IsOn;
            }
            set
            {
                if (value)
                    foreach (Canvas cT in c)
                        cT.Visibility = Visibility.Visible;
                else
                    foreach (Canvas cT in c)
                        cT.Visibility = Visibility.Collapsed;
                sw.IsOn = value;
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
    }
}
