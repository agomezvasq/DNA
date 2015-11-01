using System;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace dnaK
{
    public sealed partial class BP : UserControl
    {
        private int basei;

        private BitmapImage Au;
        private BitmapImage Cu;
        private BitmapImage Gu;
        private BitmapImage Tu;
        private BitmapImage Uu;
        private BitmapImage Ad;
        private BitmapImage Cd;
        private BitmapImage Gd;
        private BitmapImage Td;
        private BitmapImage Ud;

        public BP()
        {
            this.InitializeComponent();
            Au = new BitmapImage(new Uri("ms-appx:///Assets/Base/Au.png"));
            Cu = new BitmapImage(new Uri("ms-appx:///Assets/Base/Cu.png"));
            Gu = new BitmapImage(new Uri("ms-appx:///Assets/Base/Gu.png"));
            Tu = new BitmapImage(new Uri("ms-appx:///Assets/Base/Tu.png"));
            Uu = new BitmapImage(new Uri("ms-appx:///Assets/Base/Uu.png"));

            Ad = new BitmapImage(new Uri("ms-appx:///Assets/Base/Ad.png"));
            Cd = new BitmapImage(new Uri("ms-appx:///Assets/Base/Cd.png"));
            Gd = new BitmapImage(new Uri("ms-appx:///Assets/Base/Gd.png"));
            Td = new BitmapImage(new Uri("ms-appx:///Assets/Base/Td.png"));
            Ud = new BitmapImage(new Uri("ms-appx:///Assets/Base/Ud.png"));
        }

        public int Base
        {
            get
            {
                return basei;
            }
            set
            {
                switch (value)
                {
                    case 'A':
                        bU.Source = Au;
                        bUk.Text = "A";
                        bD.Source = Td;
                        bDk.Text = "T";
                        break;
                    case 'C':
                        bU.Source = Cu;
                        bUk.Text = "C";
                        bD.Source = Gd;
                        bDk.Text = "G";
                        break;
                    case 'G':
                        bU.Source = Gu;
                        bUk.Text = "G";
                        bD.Source = Cd;
                        bDk.Text = "C";
                        break;
                    case 'T':
                        bU.Source = Tu;
                        bUk.Text = "T";
                        bD.Source = Ad;
                        bDk.Text = "A";
                        break;
                    case 'U':
                        bU.Source = Uu;
                        bUk.Text = "U";
                        bD.Source = Ad;
                        bDk.Text = "A";
                        break;
                    case 'Ä':
                        bU.Source = Au;
                        bUk.Text = "A";
                        bD.Source = Ud;
                        bDk.Text = "U";
                        break;
                }

                basei = value;
            }
        }
    }
}
