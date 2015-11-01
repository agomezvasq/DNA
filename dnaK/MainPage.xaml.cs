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
            Sequence seq = new Sequence(t.Text);
            assemble(seq);
            updt(seq);
        }

        private void t_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            Sequence seq = new Sequence(t.Text);

            Str sI = new Str();
            sI.Width = double.NaN;
            sI.DNASequence = seq.getSeq();
            stackPStrings.Children.Add(sI);

            t.Text = "";
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

        private void stackPStrings_LayoutUpdated(object sender, object e)
        {
            if (stackPStrings.Children.Count <= 1)
                return;
            sortSequences();
        }

        public void sortSequences()
        {
            int c = stackPStrings.Children.Count;
            int[,] m = new int[c,2];
            for (int i=0; i<c; i++)
            {
                m[i,0] = i;
                m[i,1] = ((Str)stackPStrings.Children[i]).DNASequence.Length;
                ((Str)stackPStrings.Children[i]).Max = false;
            }

            int [,] mS = quickSort(m, 0, c-1);

            for (int k=0; k<c; k++)
            {
                Str sI = (Str) stackPStrings.Children[m[0,k]];
                stackPStrings.Children.Remove(sI);
                stackPStrings.Children.Insert(m[1,k], sI);
            }

            ((Str)stackPStrings.Children[c-1]).Max = true;
        }

        public int [,] quickSort(int [,] m, int lo, int hi)
        {
            int part = partition(m, lo, hi);
            if (lo < part - 1)
                quickSort(m, lo, part - 1);
            if (part < hi)
                quickSort(m, part, hi);

            return m;
        }

        public int partition(int [,] m, int lo, int hi)
        {
            int i = lo;
            int j = hi;
            int p = m[1, (lo + hi) / 2];

            while (i <= j)
            {
                if (m[1,i] < p)
                    i++;
                if (m[1,j] > p)
                    j--;
                if (i <= j)
                {
                    int temp1 = m[1,i];
                    int temp2 = m[0,i];
                    m[1,i] = m[1,j];
                    m[0,i] = m[0,j];
                    m[1,j] = temp1;
                    m[0,j] = temp2;
                    i++;
                    j--;
                }
            }

            return i;
        }
    }
}
