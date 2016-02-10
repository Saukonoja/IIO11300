using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace JAMK.IT.IIO11300 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            txtDirectory.Text = ConfigurationManager.AppSettings["DefPath"].ToString();
            txtResult.Text = ConfigurationManager.AppSettings["ResDefPath"].ToString();
        }

        private void btnGetfiles_Click(object sender, RoutedEventArgs e) {
            try {
                DirectoryInfo dirInfo = new DirectoryInfo(txtDirectory.Text);
                FileInfo[] files = dirInfo.GetFiles("*.txt");
                foreach (FileInfo file in files) {
                    lbFound.Items.Add(file.Name);
                }
                tbNotice.Text = "Found " + lbFound.Items.Count.ToString() + " files";
                }
            catch(Exception exc) {
                tbNotice.Text = "Attempted to access a path that is not on the disk.";
            }
        }

        private void btnMerge_Click(object sender, RoutedEventArgs e) {
            string path = txtDirectory.Text;
            StringBuilder sb = new StringBuilder();
            try {
                for (int i = 0; i < lbFound.Items.Count; i++) {
                    sb.Append(File.ReadAllText(path + "\\" + lbFound.Items[i].ToString()));
                    }
                tbNotice.Text = "Files merged";
                } 
            catch (Exception exc) {
                tbNotice.Text = "Cannot read file";
            }

            try {
                File.WriteAllText(txtResult.Text, sb.ToString());
            }
            catch (Exception exc) {
                tbNotice.Text = "Cannot access file path";
            }
        }
    }
}

