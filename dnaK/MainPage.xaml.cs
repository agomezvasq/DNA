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

        public double t_gcc;
        public double t_ag;
        public int tBP;

        private void t_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            Sequence seq = new Sequence(t.Text);
            assemble(seq);
            view(seq);
        }

        private void t_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            Sequence seq = new Sequence(t.Text);

            Str sI = new Str(seq);
            sI.Width = double.NaN;

            if (stackPStrings.Children.Count == 0)
            {
                sI.Max = true;
                stackPStrings.Children.Add(sI);
            }
            else
            {
                foreach (Str sK in stackPStrings.Children)
                    sK.Max = false;

                int i = stackPStrings.Children.Count - 1;
                while (i >= 0 && ((Str)stackPStrings.Children[i]).getSequence().getSeq().Length < sI.getSequence().getSeq().Length)
                    i--;

                stackPStrings.Children.Insert(i + 1, sI);
                ((Str)stackPStrings.Children[0]).Max = true;
            }

            t.Text = "";
            write();
            match(sI, stackPStrings.Children.IndexOf(sI));
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

        public void view(Sequence s)
        {
            String dna = s.getStr();
            foreach (Str sI in stackPStrings.Children)
                dna = dna + sI.getSequence().getStr();
            Sequence sT = new Sequence(dna);

            GCs.Text = "string: " + s.getGC_C() + "%";
            AGs.Text = "string: " + s.getATGC_R();
            bps.Text = "string: " + s.bp() + "BP";

            GCt.Text = "total: " + sT.getGC_C() + "%";
            AGt.Text = "total: " + sT.getATGC_R();
            bpt.Text = "total: " + sT.bp() + "BP";
        }

        public void write()
        {
            String dna = "";
            foreach (Str sI in stackPStrings.Children)
                dna = dna + sI.getSequence().getStr();
            Sequence sT = new Sequence(dna);

            t_gcc = sT.getGC_C();
            t_ag = sT.getATGC_R();
            tBP = sT.bp();

            GCt.Text = "total: " + t_gcc + "%";
            AGt.Text = "total: " + t_ag;
            bpt.Text = "total: " + tBP + "BP";
        }

        public void match(Str sI, int id)
        {
            StackPanel sP = new StackPanel();
            sP.Width = double.NaN;
            sP.Height = 130d;
            sP.Orientation = Orientation.Horizontal;

            StringItemM sM = new StringItemM(sI.getSequence(), sP);

            for (int i=0; i<sI.getSequence().getSeq().Length; i++)
            {
                BP bp = new BP();
                bp.Base = sI.getSequence().getSeq()[i];

                sP.Children.Add(bp);
            }

            if (sI.Max)
            {
                sM.Max = true;

                maxStack.Children.Clear();
                maxStack.Children.Add(sP);
            }
            else
            {
                Canvas c = new Canvas();
                c.Width = 1440d;
                c.Height = 130d;
                c.Background = new SolidColorBrush(Color.FromArgb(127, 226, 226, 226));
                c.Visibility = Visibility.Collapsed;

                c.Children.Add(sP);
                matchDNA.Children.Insert(id, c);
            }

            stackSequences.Children.Add(sM);
        }
    }
}
