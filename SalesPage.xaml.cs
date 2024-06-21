using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SalesPage.xaml
    /// </summary>
    public partial class SalesPage : Window
    {
        public ObservableCollection<PetSupply> Cart { get; set; } = new ObservableCollection<PetSupply>();
        private DatabaseHelper db = new DatabaseHelper();

        public SalesPage()
        {
            InitializeComponent();
            cbCustomers.ItemsSource = db.GetCustomers();
            listItemsToPurchase.ItemsSource = db.GetPetSupplies();
            cartItems.ItemsSource = Cart;
            Cart.CollectionChanged += Cart_CollectionChanged;
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            var supply = (sender as Button).CommandParameter as PetSupply;
            var textBox = ((sender as Button).Parent as StackPanel).Children.OfType<TextBox>().First();
            int quantityToAdd = int.Parse(textBox.Text);  // Miktarı TextBox'tan al

            var existingItem = Cart.FirstOrDefault(item => item.Id == supply.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantityToAdd;  // Miktarı artır
            }
            else
            {
                Cart.Add(new PetSupply
                {
                    Id = supply.Id,
                    Name = supply.Name,
                    Price = supply.Price,
                    ImageUrl = supply.ImageUrl,
                    Quantity = quantityToAdd  // İlk miktarı ayarla
                });
            }
            UpdateTotal();
        }

        private void RemoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            var supply = (sender as Button).CommandParameter as PetSupply;
            if (supply.Quantity > 1)
            {
                supply.Quantity--;
            }
            else
            {
                Cart.Remove(supply);
            }
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            decimal total = Cart.Sum(item => item.Price * item.Quantity);
            txtTotal.Text = $"Total: {total:C}";
        }

        private void CompletePurchase_Click(object sender, RoutedEventArgs e)
        {
            if (cbCustomers.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer.");
                return;
            }

            string receipt = "Receipt\n---------\n";
            receipt += $"Customer: {((Customer)cbCustomers.SelectedItem).Name}\n\nItems Purchased:\n";

            foreach (var item in Cart)
            {
                receipt += $"{item.Name} - ${item.Price} x {item.Quantity} = ${item.Price * item.Quantity}\n";
            }

            receipt += $"\nTotal: {txtTotal.Text}\n\nThank you for your purchase!";

            MessageBox.Show(receipt);
            Cart.Clear();
        }

        private void Cart_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateTotal();
        }
    }
}
