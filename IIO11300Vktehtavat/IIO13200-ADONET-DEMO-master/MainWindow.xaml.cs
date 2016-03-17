﻿//Koodannut ja testannut toimivaksi 6.3.2014 EsaSalmik
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
using JAMK.ICT;
using JAMK.ICT.Data;
using System.Data;

namespace JAMK.ICT.ADOBlanco {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private string ConnStr;
        private string TableName;
        private DataTable dt; //UI:n kaikki metodit käyttävät tätä samaa DataTablea
        private DataView dv;
        public MainWindow() {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff() {
            try {
                string messu = "";
                //TODO täytetään combobox asiakkaitten maitten nimillä
                //esimerkki kuinka App.Configissa oleva connectionstring luetaan
                ConnStr = JAMK.ICT.Properties.Settings.Default.Tietokanta;
                lbMessages.Content = ConnStr;
                TableName = JAMK.ICT.Properties.Settings.Default.Taulu;
                dt = DBPlacebo.GetAllCustomersFromSQLServer(ConnStr, TableName, "", out messu);
                //luodaan DataTablen oletusnäkymäst DataView
                dv = dt.DefaultView;
                FillMyCombo();
                lbMessages.Content = messu;
               
            } catch (Exception ex) {

                lbMessages.Content = ex.Message;
            }
           
        }
        private void FillMyCombo() {
           
           // cbCountries.ItemsSource = DBPlacebo.GetCitiesFromSQLServer(ConnStr, TableName).DefaultView;
           // cbCountries.DisplayMemberPath = "city";
           // cbCountries.SelectedValuePath = "city";
            var result = (from c in dt.AsEnumerable() select c.Field<string>("City")).Distinct().ToList();
            cbCountries.ItemsSource = result;
            
        }
        private void btnGet3_Click(object sender, RoutedEventArgs e) {
            dgCustomers.ItemsSource = DBPlacebo.GetTestCustomers().DefaultView;
        }

        private void btnGetAll_Click(object sender, RoutedEventArgs e) {
            //haetaan asiakastiedot palvelimelta
            string messu = "";
            try {
                dgCustomers.ItemsSource = dv;
            } 
            catch (Exception ex) {
                messu = ex.Message;
            } 
            finally {
                lbMessages.Content = messu;
            }
        }

        private void btnGetFrom_Click(object sender, RoutedEventArgs e) {
            //TODO
        }

        private void btnYield_Click(object sender, RoutedEventArgs e) {
            JAMK.ICT.JSON.JSONPlacebo2015 roskaa = new JAMK.ICT.JSON.JSONPlacebo2015();
            MessageBox.Show(roskaa.Yield());
        }

        private void cbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            SuodataVE2();
           /* string messu = "";
            string kaupunki = "";
            try {
                if (cbCountries.SelectedIndex >= 0) {
                    kaupunki = cbCountries.SelectedValue.ToString();
                    dgCustomers.ItemsSource = DBPlacebo.GetAllCustomersFromSQLServer(ConnStr, TableName, kaupunki, out messu).DefaultView;
                }
            } catch (Exception ex) {
                messu = ex.Message;
            } finally {
                lbMessages.Content = messu;
            }*/
        }
        private void SuodataVE2() {
            dv.RowFilter = string.Format("city='{0}'", cbCountries.SelectedValue.ToString());
        }
    }
}
