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
using System.Data.SqlClient;

namespace Tehtava8 {
   
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btnGetCustomers_Click(object sender, RoutedEventArgs e) {
            try {
                //yhteys
                using (SqlConnection conn = new SqlConnection(Tehtava8.Properties.Settings.Default.Tietokanta)) {
                    string sql = "SELECT firstname, lastname, address, city FROM vCustomers GROUP BY lastname, firstname, address, city";
                    //dataadapter
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable("winecustomers");
                    da.Fill(dt);
                    //sidotaan datatable listboxiin
                    lbCustomers.DataContext = dt;
                    lbCustomers.DisplayMemberPath = "lastname";
                    conn.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void lbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            DataRowView drv = lbCustomers.SelectedItem as DataRowView;
            string firstname = "";
            string lastname = "";
            string address = "";
            string city = "";

            if (drv != null) {
                firstname = drv.Row[lbCustomers.DisplayMemberPath = "firstname"] as string;
                lastname = drv.Row[lbCustomers.DisplayMemberPath = "lastname"] as string;
                address = drv.Row[lbCustomers.DisplayMemberPath = "address"] as string;
                city = drv.Row[lbCustomers.DisplayMemberPath = "city"] as string;
            }
            lbCustomers.DisplayMemberPath = "lastname";
            txtFname.Text = firstname;
            txtLname.Text = lastname;
            txtAddress.Text = address;
            txtCity.Text = city;
        }
    }
}
