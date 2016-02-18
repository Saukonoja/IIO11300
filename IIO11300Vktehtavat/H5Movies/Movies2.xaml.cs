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
using System.Windows.Shapes;
using System.Xml;

namespace H5Movies {
    /// <summary>
    /// Interaction logic for Movies2.xaml
    /// </summary>
    public partial class Movies2 : Window {
        public Movies2() {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            //haetaan XmlDataProviderin XML-tiedoston nimi
            string filu = xdpMovies.Source.LocalPath;
            //tallennetaan XmlDocument XML-tiedostoon
            xdpMovies.Document.Save(filu);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e) {
            //asetetaan textboxit viittaamaan pois datasta eli listasta ei ole valittuna mitään
            if (lbMovies.SelectedIndex >= 0){
                lbMovies.SelectedIndex = -1;
                btnCreate.Content = "Create";
            } else {
                try {
                    //lisätään uusi nodi XMLDocumenttiin
                    string filu = xdpMovies.Source.LocalPath;
                    //viittaus XML dokumenttiin
                    XmlDocument doc = xdpMovies.Document;
                    XmlNode root = doc.SelectSingleNode("/Movies");
                    //Luodaan uusi node
                    XmlNode newMovie = doc.CreateElement("Movie");
                    //lisätään nodelle tarvittavat attribuutit
                    XmlAttribute xa1 = doc.CreateAttribute("Name");
                    xa1.Value = txtName.Text;
                    newMovie.Attributes.Append(xa1);
                    XmlAttribute xa2 = doc.CreateAttribute("Director");
                    xa2.Value = txtDirector.Text;
                    newMovie.Attributes.Append(xa2);
                    XmlAttribute xa3 = doc.CreateAttribute("Country");
                    xa3.Value = txtCountry.Text;
                    newMovie.Attributes.Append(xa3);
                    XmlAttribute xa4 = doc.CreateAttribute("Checked");
                    xa4.Value = chkChecked.IsChecked.ToString();
                    newMovie.Attributes.Append(xa4);

                    //lisätään noodi juureen
                    root.AppendChild(newMovie);
                    //tallennetaan raakasti XmlDocument uusine nodeineen olemassaolevan päälle
                    xdpMovies.Document.Save(filu);

                    MessageBox.Show("New movie Created");
                    
                } 
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                finally {
                    btnCreate.Content = "Create new";
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            try {
                string filu = xdpMovies.Source.LocalPath;
                XmlDocument doc = xdpMovies.Document;
                XmlNode root = doc.SelectSingleNode("/Movies");
                XmlNode toBeDeleted = null;
                //haetaan XPathilla postettava node
                var item = doc.SelectSingleNode(string.Format("/Movies/Movie[@Name='{0}']", txtName.Text));
                if (item != null && MessageBox.Show("Are you sure you want to delete " + txtName.Text, "Movies", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                    toBeDeleted = item;
                }
                if (toBeDeleted != null) {
                    //poisteetaan noodi juuresta
                    root.RemoveChild(toBeDeleted);
                    xdpMovies.Document.Save(filu);
                    //listboxin osoitin
                    lbMovies.SelectedIndex = -1;
                }
            } catch (Exception ex) {
                

                MessageBox.Show(ex.Message);
            }
        }
    }
}
