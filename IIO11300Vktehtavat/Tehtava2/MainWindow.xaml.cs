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

namespace JAMK.IT.IIO11300
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            cbComboBox.Items.Add("Lotto");
            cbComboBox.Items.Add("Viking");
            cbComboBox.Items.Add("Euro");
           
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtNumberOf.Text = ("1").ToString();
            txtDrawnNumbers.Text=("").ToString();
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            try {
                txtDrawnNumbers.Text = String.Empty;
                BLlotto lotto = new BLlotto();
                for (int i = 0; i < int.Parse(txtNumberOf.Text); i++)
                {
                    txtDrawnNumbers.AppendText(lotto.draw(cbComboBox.Text));
                    txtDrawnNumbers.AppendText(Environment.NewLine);
                }
            }

            catch(Exception exception)
            {
                MessageBox.Show("Exception 52398528958292x998y0900");
            }
            
           
        }
    }

  

}
