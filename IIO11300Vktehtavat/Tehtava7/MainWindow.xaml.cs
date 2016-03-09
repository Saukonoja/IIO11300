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
using System.Text.RegularExpressions;

namespace Tehtava7 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private void txtPassword_TextChanged(object sender, RoutedEventArgs e) {
            string pw = txtPassword.Password;
            int chars = pw.Count();
            int lower = pw.Count(char.IsLower);
            int upper = pw.Count(char.IsUpper);
            int number = pw.Count(char.IsNumber);
            int special = Regex.Matches(pw, "[^a-zA-Z0-9]").Count;

            int types = 0;
            if (lower > 0) types++;
            if (upper > 0) types++;
            if (number > 0) types++;
            if (special > 0) types++;

            if (chars == 0) {
                tbResult.Text = "Give Password";
                tbResult.Background = new SolidColorBrush(Colors.Gray);
            }
            else if (chars < 8 && chars > 0 && types >= 1) {
                tbResult.Text = "Bad";
                tbResult.Background = new SolidColorBrush(Colors.Red);
            }
            else if (chars < 12 && chars >= 8 && types >= 2) {
                tbResult.Text = "fair";
                tbResult.Background = new SolidColorBrush(Colors.Yellow);
            }
            else if (chars < 16 && chars >= 12 && types >= 3) {
                tbResult.Text = "Moderate";
                tbResult.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else if (chars >= 16 && chars > 0 && types == 4) {
                tbResult.Text = "Good";
                tbResult.Background = new SolidColorBrush(Colors.Green);
            }
            tbChar.Text = "Characters: " + pw.Length;
            tbLower.Text = "Lower case: " + lower.ToString();
            tbUpper.Text = "Upper case: " + upper.ToString();
            tbNumber.Text = "Numbers: " + number.ToString();
            tbSpecial.Text = "Specials: " + special.ToString();
        }
    }
}