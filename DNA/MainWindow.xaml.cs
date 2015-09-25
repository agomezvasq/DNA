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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            textBox1.Text = encode(textBox.Text);
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
