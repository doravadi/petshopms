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
    /// Interaction logic for UpdateCustomerWindow.xaml
    /// </summary>
    public partial class UpdateCustomerWindow : Window
    {
        private DatabaseHelper db = new DatabaseHelper();
        private int CustomerId;  // Müşteri ID'sini saklamak için bir alan

        // Constructor, seçilen müşteriyi alır
        public UpdateCustomerWindow(Customer customer)
        {
            InitializeComponent();
            CustomerId = customer.Id;  // Müşteri ID'sini kaydet
            txtName.Text = customer.Name;
            txtEmail.Text = customer.Email;
            txtPhone.Text = customer.Phone;
        }

        // Güncelle butonuna tıklanınca çalışacak metod
        private void UpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (db.UpdateCustomer(CustomerId, txtName.Text, txtEmail.Text, txtPhone.Text))
            {
                MessageBox.Show("Customer updated successfully!");
                this.Close(); // Güncelleme başarılı ise pencereyi kapat
                ((MainWindow)Application.Current.MainWindow).LoadData();
            }
            else
            {
                MessageBox.Show("Failed to update customer.");  // Güncelleme başarısız ise hata mesajı göster
            }
        }
    }
}
