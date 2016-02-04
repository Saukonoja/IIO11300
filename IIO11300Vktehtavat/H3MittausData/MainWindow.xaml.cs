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
using JAMK.IT.IIO11300;

namespace H3MittausData {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        //luodaan lista mittaus-olioita varten
        List<MittausData> measured = new List<MittausData>();


        public MainWindow() {
            InitializeComponent();
            IniMyStuff();
        }
        private void IniMyStuff() {
            //omat ikkunaan liittyvät alustukset
            txtToday.Text = DateTime.Today.ToShortDateString();
        }

        private void btnSaveData_Click(object sender, RoutedEventArgs e) {
            //luodaan uusi mittausdata olio ja näytetään se käyttäjälle
            MittausData md = new MittausData(txtClock.Text, txtData.Text);
            //lbData.Items.Add(md);
            measured.Add(md);
            ApplyChanges();
        }
        private void ApplyChanges() {
            lbData.ItemsSource = null;
            lbData.ItemsSource = measured;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            //kirjoitetaan mitatut tiedostoon
            try {
                MittausData.SaveToFile(txtFileName.Text, measured);
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnRead_Click(object sender, RoutedEventArgs e) {
            //haetaan käyttäjän antamasta tiedostosta mitatut arvot
            try {
                measured = MittausData.ReadFromFile(txtFileName.Text);
                ApplyChanges();
                MessageBox.Show("Tiedot haettu onnistuneesti tiedostostoa " + txtFileName.Text);
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSerialize_Click(object sender, RoutedEventArgs e) {
            try {
                JAMK.IT.IIO11300.Serialisointi.SerialisoiXml(txtFileName.Text, measured);

            } 
            catch(Exception ex) {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnDeSerialize_Click(object sender, RoutedEventArgs e) {
            try {
                measured = JAMK.IT.IIO11300.Serialisointi.DeSerialisoiXml(txtFileName.Text);
                ApplyChanges();

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeSerializeBin_Click(object sender, RoutedEventArgs e) {
            try {
                JAMK.IT.IIO11300.Serialisointi.Serialisoi(txtFileName.Text, measured);
                ApplyChanges();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSerializeBin_Click(object sender, RoutedEventArgs e) {
            object obj = new object();
            try {
                JAMK.IT.IIO11300.Serialisointi.DeSerialisoi(txtFileName.Text, ref obj);
                measured = (List<MittausData>)obj;
                ApplyChanges();

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
