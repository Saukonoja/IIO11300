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
using System.Data.Entity;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace H11Bookshop {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        BookShopEntities ctx;
        ObservableCollection<Book> localBooks;
        ICollectionView view; // filtteröintiä varten
        bool IsBooks;
        public MainWindow() {
            InitializeComponent();
            IniMyStuff();
        }

        private void IniMyStuff() {
            //tänne kaikki tarvittava alustukset
            ctx = new BookShopEntities();
            ctx.Books.Load();
            localBooks = ctx.Books.Local;
            cbCountries.DataContext = localBooks.Select(n => n.country).Distinct();
            cbCountries.Visibility = Visibility.Visible;
            //view kirjojen filtterointia varte
            view = CollectionViewSource.GetDefaultView(localBooks);
        }

        private bool MyCountryFilter(object item) {
            if (cbCountries.SelectedIndex == -1)
                return true;
            else
                return (item as Book).country.Contains(cbCountries.SelectedItem.ToString());
        }

        private void btnGetCustomers_Click(object sender, RoutedEventArgs e) {
            var customers = ctx.Customers.ToList();
            dgBooks.DataContext = customers;
            IsBooks = false;
        }

        private void btnGetBooksEF_Click(object sender, RoutedEventArgs e) {
            dgBooks.DataContext = localBooks;
            IsBooks = true;
            cbCountries.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            try {
                ctx.SaveChanges();
            } catch (Exception ex) {

               MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateNew_Click(object sender, RoutedEventArgs e) {
            Book newBook;
            if (btnCreateNew.Content.ToString()=="Uusi") {
                newBook = new Book();
                newBook.name = "Anna kirjan nimi";
                spInfo.DataContext = newBook;
                btnCreateNew.Content = "Tallenna kantaan";
            } else {
                // lisätää uusi kirja ensin kontekstiin ja sieltä kantaan
                newBook = (Book)spInfo.DataContext;
                ctx.Books.Add(newBook);
                ctx.SaveChanges();
                btnCreateNew.Content = "Uusi";
                MessageBox.Show("Kirja " + newBook.DisplayName + " lisätty kantaan");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            Book current = (Book)spInfo.DataContext;
            var retval = MessageBox.Show("Haluatko varmasti poistaa kirjan " + current.DisplayName, "Wanhat lorjat pysyy", MessageBoxButton.YesNo);
            if (retval == MessageBoxResult.Yes) {
                ctx.Books.Remove(current);
                ctx.SaveChanges();
            }
        }

        private void dgBooks_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (IsBooks)
                spInfo.DataContext = dgBooks.SelectedItem;
            else
                spCustomer.DataContext = dgBooks.SelectedItem;
        }

        private void btnGetOrders_Click(object sender, RoutedEventArgs e) {
            string msg = "";
            Customer current = (Customer)spCustomer.DataContext;
            msg += string.Format("Asiakkaalla {0} OnAccessKey {1} tilausta:\n", current.DisplayName, current.OrderCount);
            foreach (var item in current.Orders) {
                msg += string.Format("Tilaus {0} sisältää {1} tilausriviä:\n", item.odate, item.Orderitems.Count);
                Decimal summa = 0;
                foreach (var oitem in item.Orderitems) {
                    msg += string.Format("- kirja {0} kappaletta {1}\n", oitem.Book.name, oitem.count);
                    summa += oitem.count * oitem.Book.price.Value;
                   
                }
                msg += string.Format("-- tilaus yhteensä {0}", summa);
            }
            MessageBox.Show(msg);
        }

        private void cbCountries_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            view.Filter = MyCountryFilter;
        }
    }
}
