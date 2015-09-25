using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DNA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int min_r = -1;
        int max_r = -1;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBox1.Text = encode(textBox.Text);
            updateR();
        }

        public void updateR()
        {
            string st = textBox.Text;
            if (st.Length == 0)
            {
                label.Content = "Text: 0 <= R <= 0 - 0 <= R4 <= 0";
                return;
            }
            if (min_r==-1 || max_r==-1)
            {
                min_r = st[0];
                max_r = st[0];
            }
            for (int i=0; i<st.Length; i++)
            {
                char c = st[i];
                if (c < min_r)
                    min_r = c;
                if (c > max_r)
                    max_r = c;
            }
            label.Content = "Text: "+ min_r + " <= R <= " + max_r + " - " + quat(min_r) + " <= R4 <= " + quat(max_r);
        }

        public static int quat(int k)
        {
            int qu = 0;
            int ran = 0;
            while (k>0)
            {
                qu += (k % 4) * (int) Math.Pow(10, ran);
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
