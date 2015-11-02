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
        private Sequence [] mR;

        public Match(Sequence m, Sequence n)
        {
            this.m = m;
            this.n = n;

            this.mR = match(m, n);
        }

        public static Sequence [] match(Sequence a, Sequence b)
        {
            string m = a.getSeq();
            string n = b.getSeq();

            string[] mA = new string[m.Length - 1];

            for (int i = 0; i < n.Length - 1; i++)
                for (int j = 0; j < m.Length - 1; j++)
                    if (n[i] == m[j] && n[i + 1] == m[j + 1])
                        mA[j] = "" + n[i] + n[i + 1];

            int max = 0;

            Sequence[] sA = new Sequence[m.Length - 1];
            for (int k = 0; k < m.Length - 1; k++) 
            {
                if (mA[k] != null)
                {
                    int l = 1;
                    string str = "" + mA[k];
                    while (k + l < m.Length - 1 && mA[k + l] != null)
                    {
                        str = str + (mA[k + l])[1];
                        l++;
                    }
                    if (l > max)
                    {
                        max = l;
                        sA = new Sequence[m.Length - 1];
                    }
                    if (l == max)
                        sA[k] = new Sequence(str);
                }
            }
            return sA;
        }

        public Sequence getM() { return this.m; }
        public Sequence getN() { return this.n; }
        public Sequence [] getRes() { return this.mR; }
    }
}
