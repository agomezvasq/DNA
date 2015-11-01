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
using Windows.UI.Xaml.Navigation;
using DNA;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace dnaK
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.t_gcc = 0;
            this.t_ag = 0;
        }

        private void appBarToggleButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        public int t_gcc;
        public int t_ag;
        public int tBP;

        private void t_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (t.Text.Length == 0)
                return;
            Sequence seq = new Sequence(t.Text);
            assemble(seq);
            updt(seq);
        }

        private void t_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

        }

        public void assemble(Sequence s)
        {
            DNASequence.Children.Clear();
            string e = s.getSeq();
            for (int i=0; i<e.Length; i++)
            {
                BP bp = new BP();
                bp.Base = e[i];

                DNASequence.Children.Add(bp);
            }
        }

        public void updt(Sequence s)
        {
            GCs.Text = "string: " + s.getGC_C() + "%";
            GCt.Text = "total: " + (t_gcc + s.getGC_C()) + "%";

            AGs.Text = "string: " + s.getATGC_R();
            AGt.Text = "total: " + (t_ag + s.getATGC_R());

            bps.Text = "string: " + s.bp() + "BP";
            bpt.Text = "total: " + (tBP + s.bp()) + "BP";
        }
    }
}
