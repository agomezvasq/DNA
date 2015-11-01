using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNA
{
    class Match
    {
        private Sequence m;
        private Sequence n;
        private int[] chars;
        private List<Int32> mR;

        public Match(Sequence m, Sequence n)
        {
            this.m = m;
            this.n = n;

            chars = assign(n);
            this.mR = match(m, n, chars);
        }
        
        public static int[] assign(Sequence n)
        {
            string s = n.getSeq();
            int[] chars = new int[256];
            for (int j=0; j<256; j++)
                chars[j] = s.Length;
            for (int i=0; i<s.Length-1; i++)
                chars[s[i]] = s.Length - i - 1;
            return chars;
        }

        public static List<Int32> match(Sequence a, Sequence b, int [] chars)
        {
            string m = a.getSeq();
            string n = b.getSeq();

            string[] ma = new string[m.Length - 1];

            for (int i=0; i<n.Length-1; i++)
                for (int j=0; j<m.Length-1; j++)
                    if (n[i]==m[j] && n[i+1]==m[j+1])
                        ma[j] = "" + n[i] + n[i + 1];

            int max = 0;
            int iMax = -1;
            for (int p=0; p<m.Length-1; p++)
                if ()
            
            /*
            int i = m.Length - 1;
            while (i < n.Length)
            {
                int j = m.Length - 1;
                //MessageBox.Show("n[i]: " + n[i] + "; m[j]: " + m[j]);
                int tmp = i;
                while (j >= 0 && n[i] == m[j])
                {
                    //MessageBox.Show("n[i]: " + n[i] + "; m[j]: " + m[j]);
                    j--;
                    i--;
                }
                //MessageBox.Show("i: " + i + "; j: " + j);
                i = tmp;
                if (j < 0)
                {
                    ls.Add(i - m.Length + 1);
                    i += m.Length;
                }
                else
                {
                    i += chars[n[i]];
                    //if (i < n.Length) 
                    //MessageBox.Show("ni: " + i + "; " + n[i] + ": " + chars[n[i]]);
                }
            }
            return ls;
            */
        }
    }
}
