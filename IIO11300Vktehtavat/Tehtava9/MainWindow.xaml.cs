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
using System.Data;

namespace Tehtava9 {

    public partial class MainWindow : Window {
        private string ConnStr;
        private string TableName;
        private DataTable dt;
        public MainWindow() {
            InitializeComponent();
            try {
                ConnStr = Tehtava9.Properties.Settings.Default.Tietokanta;
                TableName = Tehtava9.Properties.Settings.Default.Table;
            } catch (Exception ex) {
                lbMessages.Content = ex.Message;
            }
        }

        private void btnGetCustomers_Click(object sender, RoutedEventArgs e) {
            this.ReadCustomers();
        }

        private void btnCreateNew_Click(object sender, RoutedEventArgs e) {
            this.CreateCustomer();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            this.DeleteCustomer();
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e) {

        }

        private void ReadCustomers() {
            string message = "";
            int rowCount = 0;
            try {
                dt = Customer.GetAllCustomersFromSQLSerever(ConnStr, TableName, out message);
                rowCount = dt.Rows.Count;
                dgCustomers.ItemsSource = dt.DefaultView;
            } catch (Exception ex) {
                message = ex.Message;
            } finally {
                lbMessages.Content = rowCount + message;
            }
        }
        private void CreateCustomer() {
            string message = "";
            try {
                if (!string.IsNullOrWhiteSpace(txtFirstname.Text) && !string.IsNullOrWhiteSpace(txtLastname.Text)
                     && !string.IsNullOrWhiteSpace(txtAddress.Text) && !string.IsNullOrWhiteSpace(txtZip.Text)
                     && !string.IsNullOrWhiteSpace(txtCity.Text)) {
                    Customer.CreateNewCustomer(ConnStr, TableName, out message, txtFirstname.Text, txtLastname.Text, txtAddress.Text, txtZip.Text, txtCity.Text);
                    this.ReadCustomers();
                } else {
                    message = "Jokin kenttä jäi tyhjäksi!";
                }
            } catch (Exception ex) {
                message = ex.Message;
            } finally {
                lbMessages.Content = message;
            }
        }

        private void DeleteCustomer() {
            string message = "";
            if (dgCustomers.SelectedCells.Count > 0) {
                DataRowView drv = (DataRowView)dgCustomers.SelectedItem;
                string firstname = (drv["firstname"].ToString());
                string lastname = (drv["lastname"]).ToString();
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Haluatko varmasti poistaa asiakkaan " + firstname + " " + lastname + "?", "Viinikellarin asiakkaat",
                System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes) {
                    try {
                        Customer.DeleteCustomer(ConnStr, TableName, out message, lastname);
                        this.ReadCustomers();

                    } catch (Exception ex) {
                        message = ex.Message;
                    } finally {
                        lbMessages.Content = message;
                    }
                }
            } else {

                lbMessages.Content = "Valitse ensin poistettava asiakas.";
            }
        }

        private void dgCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            DataRowView drv = (DataRowView)dgCustomers.SelectedItem;
            string id = (drv["id"].ToString());
            string firstname = (drv["firstname"].ToString());
            string lastname = (drv["lastname"]).ToString();
            lbMessages.Content = id + ":" + firstname + " " + lastname;
        }
    }
}
