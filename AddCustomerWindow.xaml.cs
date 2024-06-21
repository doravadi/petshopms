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
    /// Interaction logic for AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        public AddCustomerWindow()
        {
            InitializeComponent();
        }
        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;

            DatabaseHelper db = new DatabaseHelper();
            if (db.AddCustomer(name, email, phone))
            {
                MessageBox.Show("Customer added successfully!");
                ((MainWindow)Application.Current.MainWindow).LoadData();
            }
            else
            {
                MessageBox.Show("Failed to add customer.");
            }
        }


    }
}
