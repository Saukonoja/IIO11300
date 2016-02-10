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

namespace JAMK.IT.IIO11300 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
           
            List<BLPlayer> players = new List<BLPlayer>();
            public MainWindow() {
            InitializeComponent();
           string []teams = new string[] { "Blues", "HIFK", "HPK", "Ilves", "JYP", "KalPa", "KooKoo",
            "Kärpät", "Lukko", "Pelicans", "SaiPa", "Sport", "Tappara", "TPS", "Ässät" };
            cbTeam.ItemsSource = teams;

        }

        private void btnCreatePlayer_Click(object sender, RoutedEventArgs e) {

        }

        private void btnSavePlayer_Click(object sender, RoutedEventArgs e) {

        }

        private void btnDeletePlayer_Click(object sender, RoutedEventArgs e) {

        }

        private void btnWritePlayers_Click(object sender, RoutedEventArgs e) {

        }

        private void btnQuit_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }

        private void cbTeam_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }
    }
}
