using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DNA
{
    class Sequence
    {

        protected string s;
        protected string e;

        protected double atgc_rat;
        protected double gcc;

        protected int at;
        protected int gc;

        protected int min_r;
        protected int max_r;

        public Sequence(string s)
        {
            this.s = s;
            this.e = encode(s);

            int[] dat = data(e);
            this.min_r = dat[0];
            this.max_r = dat[1];
            this.at = dat[2];
            this.gc = dat[3];

            this.gcc = Math.Round((double)this.gc / ((double)this.at + (double)this.gc) * 100, 1);
            this.atgc_rat = Math.Round((double)this.at / (double)this.gc, 1);
        }

        public string getSeq()    { return this.e; }
        public string getStr()    { return this.s; }
        public int getAT()        { return this.at; }
        public int getGC()        { return this.gc; }

        public double getATGC_R() { return this.atgc_rat; }
        public double getGC_C()   { return this.gcc; }
        public int getMINRan()    { return this.min_r; }
        public int getMAXRan()    { return this.max_r; }

        public int getAmino(char c)
        {
            if (c == 'A' || c == 'U')
                return at / 2;
            if (c == 'G' || c == 'C')
                return gc / 2;
            return 0;
        }

        public static int [] data(string s)
        {
            int min_r = -1, max_r = -1;
            int at = 0, gc = 0;
            if (s.Length == 0)
            {
                return new int[] { 0, 0, 0, 0 };
            }
            if (min_r == -1 || max_r == -1)
            {
                min_r = s[0];
                max_r = s[0];
            }
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c < min_r)
                    min_r = c;
                if (c > max_r)
                    max_r = c;
                if (c == 'A' || c == 'U')
                    at+=2;
                if (c == 'G' || c == 'C')
                    gc+=2;
            }
            return new int[] { min_r, max_r, at, gc };
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
                    nstr = ACGU(r % 4) + nstr;
                    r /= 4;
                }
                if (mfst.Equals(""))
                    mfst = nstr;
                else
                    mfst = mfst + nstr;
            }
            return mfst;
        }

        public static char ACGU(int a)
        {
            switch (a)
            {
                case 0: return 'A';
                case 1: return 'C';
                case 2: return 'G';
                case 3: return 'U';
            }
            return (char)0;
        }
    }
}
