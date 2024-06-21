using System;
using System.Windows;
using System.Windows.Input;

namespace petshopmanagament
{
    /// <summary>
    /// MainWindow.xaml için etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        private DatabaseHelper db = new DatabaseHelper();

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        // Verileri yükler
        public void LoadData()
        {
            listCustomers.ItemsSource = db.GetCustomers();
            listPets.ItemsSource = db.GetPets();
            listSales.ItemsSource = db.GetSales();
        }

        // Pencere açma işlevleri
        private void OpenAddPetWindow(object sender, RoutedEventArgs e)
        {
            var addPetWindow = new AddPetWindow();
            addPetWindow.Show();
        }

        private void OpenAddCustomerWindow(object sender, RoutedEventArgs e)
        {
            var addCustomerWindow = new AddCustomerWindow();
            addCustomerWindow.Show();
        }

        private void OpenAddSaleWindow(object sender, RoutedEventArgs e)
        {
            var addSaleWindow = new AddSaleWindow();
            addSaleWindow.ShowDialog();
        }

        private void OpenPetSuppliesWindow(object sender, RoutedEventArgs e)
        {
            var petSuppliesWindow = new PetSuppliesWindow();
            petSuppliesWindow.ShowDialog();
        }

        // Müşteri işlemleri
        private void ListCustomers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listCustomers.SelectedItem is Customer selectedCustomer)
            {
                var updateWindow = new UpdateCustomerWindow(selectedCustomer);
                updateWindow.ShowDialog();
            }
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (listCustomers.SelectedItem is Customer selectedCustomer)
            {
                if (MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (db.DeleteCustomer(selectedCustomer.Id))
                    {
                        MessageBox.Show("Customer deleted successfully.");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete customer.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
            }
        }

        // Pet işlemleri
        private void ListPets_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listPets.SelectedItem is Pet selectedPet && selectedPet.Id != 0)
            {
                var updateWindow = new UpdatePetWindow(selectedPet);
                updateWindow.ShowDialog();
                LoadData();
            }
            else
            {
                MessageBox.Show("Invalid pet ID.");
            }
        }

        private void DeletePet_Click(object sender, RoutedEventArgs e)
        {
            if (listPets.SelectedItem is Pet selectedPet && selectedPet.Id != 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this pet?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (db.DeletePet(selectedPet.Id))
                    {
                        MessageBox.Show("Pet deleted successfully.");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete pet.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a pet to delete.");
            }
        }
    }
}
