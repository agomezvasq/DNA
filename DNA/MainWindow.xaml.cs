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
            if (textBox.Text.Length == 0)
            {
                textBox1.Clear();
                label.Content = "Text: 0 <= R <= 0 - 0 <= R4 <= 0";
                label_Copy1.Content = "%GC=0";
                label_Copy2.Content = "AT/GC=0.0";
                return;
            } 
            Sequence seq = new Sequence(textBox.Text);
            textBox1.Text = seq.getSeq();
            label.Content = "Text: " + seq.getMINRan() + " <= R <= " + seq.getMAXRan() 
                + " - " + Sequence.quat(seq.getMINRan()) + " <= R4 <= " + Sequence.quat(seq.getMAXRan());
            label_Copy1.Content = "%GC=" + seq.getGC_C();
            label_Copy2.Content = "AT/GC=" + seq.getATGC_R();
        }

  
    }
}
