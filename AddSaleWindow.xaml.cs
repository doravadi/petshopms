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

namespace petshopmanagament
{
    /// <summary>
    /// Interaction logic for AddSaleWindow.xaml
    /// </summary>
    public partial class AddSaleWindow : Window
    {
        private DatabaseHelper db = new DatabaseHelper();
        public AddSaleWindow()
        {
            InitializeComponent();
            LoadComboboxData();
        }
        private void LoadComboboxData()
        {
            // Müşteri bilgilerini yükleyin
            cbCustomers.ItemsSource = db.GetCustomers();
            cbCustomers.DisplayMemberPath = "Name";  // Customer nesnesindeki hangi özellik gösterilsin
            cbCustomers.SelectedValuePath = "Id";    // ComboBox'dan seçilen öğenin değeri

            // Pet bilgilerini yükleyin
            cbPets.ItemsSource = db.GetPets();
            cbPets.DisplayMemberPath = "Name";       // Pet nesnesindeki hangi özellik gösterilsin
            cbPets.SelectedValuePath = "Id";         // ComboBox'dan seçilen öğenin değeri
        }
        private void AddSale_Click(object sender, RoutedEventArgs e)
        {
            int customerId = (cbCustomers.SelectedItem as Customer).Id;
            int petId = (cbPets.SelectedItem as Pet).Id;
            DateTime saleDate = dpSaleDate.SelectedDate ?? DateTime.Now;
            decimal saleAmount = decimal.Parse(txtSaleAmount.Text);

            if (db.AddSale(customerId, petId, saleDate, saleAmount))
            {
                MessageBox.Show("Sale added successfully!");
                this.Close();
                ((MainWindow)Application.Current.MainWindow).LoadData();

            }
            else
            {
                MessageBox.Show("Failed to add sale.");
            }
        }

    }
}
