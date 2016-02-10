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
    public partial class MainWindow : Window {          
            List<Player> players = new List<Player>();
            public MainWindow() {
            InitializeComponent();
           string []teams = new string[] { "Blues", "HIFK", "HPK", "Ilves", "JYP", "KalPa", "KooKoo",
            "Kärpät", "Lukko", "Pelicans", "SaiPa", "Sport", "Tappara", "TPS", "Ässät" };
            cbTeam.ItemsSource = teams;
        }
        private void btnCreatePlayer_Click(object sender, RoutedEventArgs e) {
            try {
                if (!string.IsNullOrWhiteSpace(txtFname.Text) &&
                    !string.IsNullOrWhiteSpace(txtLname.Text) &&
                    !string.IsNullOrWhiteSpace(txtPrice.Text) &&
                    cbTeam.SelectedItem != null) {
                    Player player = new Player(txtFname.Text, txtLname.Text, int.Parse(txtPrice.Text), cbTeam.SelectedValue.ToString());
                    bool exists = players.Any(Player => Player.Fullname == player.Fullname);
                    if (exists) {
                        player = null;
                        tbStatus.Text = "Player already exists";
                    } else {
                        players.Add(player);         
                        ApplyChanges();                      
                        tbStatus.Text = "New player created";
                        Clear();
                    }
                } else {
                    tbStatus.Text = "Fill all fields";
                }
            }
            catch (Exception ex) {
                tbStatus.Text = ex.ToString();
            }
        }
        private void btnSavePlayer_Click(object sender, RoutedEventArgs e) {
            try {
                Player player = lbPlayers.SelectedItem as Player;
                player.Fname = txtFname.Text;
                player.Lname = txtLname.Text;
                player.Team = cbTeam.SelectedValue.ToString();
                player.Price = int.Parse(txtPrice.Text);
                Clear();
                ApplyChanges();
                tbStatus.Text = "Player " + player.Fullname + " tallennettu";
            }
            catch (Exception ex) {
                tbStatus.Text = ex.ToString();
            }
        }
        private void btnDeletePlayer_Click(object sender, RoutedEventArgs e) {
            try {
                players.RemoveAt(lbPlayers.Items.IndexOf(lbPlayers.SelectedItem));
                tbStatus.Text = "Pelaaja poistettu";
            }
            catch (Exception ex) {
                tbStatus.Text = ex.ToString();
            }
            ApplyChanges();
        }
        private void btnWritePlayers_Click(object sender, RoutedEventArgs e) {
            try {
                Player.SaveToFile(players);
                tbStatus.Text = "Players written to file";
            }
            catch(Exception ex) {
                tbStatus.Text = ex.ToString();
            }
        }
        private void btnQuit_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
        private void ApplyChanges() {
            lbPlayers.ItemsSource = null;
            lbPlayers.ItemsSource = players;
        }
        private void Clear() {
            txtFname.Text = "";
            txtLname.Text = "";
            txtPrice.Text = "";
            cbTeam.SelectedValue = "";
            
        }
        private void lbPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            Player player = lbPlayers.SelectedItem as Player;
            if (player == null) { return; }
            txtFname.Text = player.Fname;
            txtLname.Text = player.Lname;
            txtPrice.Text = player.Price.ToString();
            cbTeam.SelectedValue = player.Team;

        }
    }
}
