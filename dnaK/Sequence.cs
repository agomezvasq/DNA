using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DNA
{
    public class Sequence
    {
        protected string s;
        protected string e;

        protected double atgc_rat;
        protected double gcc;

        protected int at;
        protected int gc;

        public Sequence(string s)
        {
            this.s = s;
            this.e = encode(s);

            int[] dat = data(e);
            this.at = dat[0];
            this.gc = dat[1];

            this.gcc = Math.Round((double)this.gc / ((double)this.at + (double)this.gc) * 100, 1);
            this.atgc_rat = Math.Round((double)this.at / (double)this.gc, 1);
        }

        public string getSeq()    { return this.e; }
        public string getStr()    { return this.s; }
        public int getAT()        { return this.at; }
        public int getGC()        { return this.gc; }
        public int bp()           { return this.e.Length; }
        public double getATGC_R() { return this.atgc_rat; }
        public double getGC_C()   { return this.gcc; }

        public int getN(char c)
        {
            if (c == 'A' || c == 'T')
                return at / 2;
            if (c == 'G' || c == 'C')
                return gc / 2;
            return 0;
        }

        public static int [] data(string s)
        {
            int at = 0, gc = 0;
            if (s.Length == 0)
            {
                return new int[] { 0, 0 };
            }
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == 'A' || c == 'T')
                    at+=2;
                if (c == 'G' || c == 'C')
                    gc+=2;
            }
            return new int[] { at, gc };
        }

        public static int quat(int k)
        {
            int qu = 0;
            int ran = 0;
            while (k > 0)
            {
                qu += (k % 4) * (int)Math.Pow(10, ran);
                k /= 4;
                ran++;
            }
            return qu;
        }

        public static string encode(string s)
        {
            string mfst = "";
            for (int i = 0; i < s.Length; i++)
            {
                int r = s[i];
                string nstr = "";
                while (r > 0)
                {
                    nstr = ACGT(r % 4) + nstr;
                    r /= 4;
                }
                if (mfst.Equals(""))
                    mfst = nstr;
                else
                    mfst = mfst + nstr;
            }
            return mfst;
        }

        public static char ACGT(int a)
        {
            switch (a)
            {
                case 0: return 'A';
                case 1: return 'C';
                case 2: return 'G';
                case 3: return 'T';
            }
            return (char)0;
        }
    }
}
