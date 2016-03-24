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

namespace H9Bookshop {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        private void dgBooks_SelectionChanged(object sender, RoutedEventArgs e) {
            spInfo.DataContext = dgBooks.SelectedItem;
        }
        private void btnGetTestBooks_Click(object sender, RoutedEventArgs e) {
            dgBooks.DataContext = Bookshop.GetTestBooks();
        }

        private void btnGetBooksSQL_Click(object sender, RoutedEventArgs e) {
            try {
                dgBooks.DataContext = Bookshop.GetBooks(true);
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            try {
                Book current = (Book)spInfo.DataContext;
                if (Bookshop.UpdateBook(current) > 0) {
                    MessageBox.Show(string.Format("Kirja {0} päivitetty tietokantaan onnistuneesti",current.ToString()));
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateNew_Click(object sender, RoutedEventArgs e) {
            if (btnCreateNew.Content.ToString() == "Uusi") { 
            //luodaan uusi kirja-olio
            Book newBook = new Book(0);
            newBook.Name = "Anna kirjan nimi";
            spInfo.DataContext = newBook;
                btnCreateNew.Content = "Tallenna uusi kantaan";
            } else {
                //tallennetaan
                Book current = (Book)spInfo.DataContext;
                Bookshop.InsertBook(current);
                dgBooks.DataContext = Bookshop.GetBooks(true);
                MessageBox.Show(string.Format("Kirja {0} tallennettu kantaan onnistuneesti", current.ToString()));
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            try {
                //poistetaan valittu kirja
                Book current = (Book)spInfo.DataContext;
                var retval = MessageBox.Show("Haluatko varmasti poistaa kirjan " + current.ToString(), "Wanhat kirjat kysyy", MessageBoxButton.YesNo);
                if (retval == MessageBoxResult.Yes) {
                    Bookshop.DeleteBook(current);
                    dgBooks.DataContext = Bookshop.GetBooks(true);
                    MessageBox.Show(string.Format("Kirja {0} poistetaan", current.ToString()));
                }
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
