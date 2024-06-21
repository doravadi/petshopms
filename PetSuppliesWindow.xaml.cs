using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;

namespace petshopmanagament
{
    /// <summary>
    /// PetSuppliesWindow için etkileşim mantığı
    /// </summary>
    public partial class PetSuppliesWindow : Window
    {
        private DatabaseHelper db = new DatabaseHelper();
        private string selectedImagePath; // Seçilen resmin yolu

        public PetSuppliesWindow()
        {
            InitializeComponent();
            LoadItems();
        }

        // Pet malzemeleri listesini yükler
        private void LoadItems()
        {
            listPetSupplies.ItemsSource = db.GetPetSupplies();
        }

        // Resim seçmek için dosya diyalog penceresi açar
        private string GetImagePath()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Title = "Select an image",
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            return null;
        }

        // Resim seçme butonu olayı
        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            selectedImagePath = GetImagePath();
            if (!string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Image selected: " + selectedImagePath);
            }
        }

        // Yeni pet malzemesi ekler
        private void AddNewSupply_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(txtPrice.Text, out decimal price) && !string.IsNullOrEmpty(selectedImagePath))
            {
                PetSupply newSupply = new PetSupply
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Price = price,
                    ImageUrl = selectedImagePath
                };
                db.AddPetSupply(newSupply);
                LoadItems();
            }
            else
            {
                MessageBox.Show("Please enter a valid price and select an image.");
            }
        }

        // Seçilen pet malzemesini siler
        private void DeleteSupply_Click(object sender, RoutedEventArgs e)
        {
            if (listPetSupplies.SelectedItem is PetSupply selectedSupply)
            {
                db.DeletePetSupply(selectedSupply.Id);
                LoadItems();
            }
        }

        // Seçilen pet malzemesini günceller
        private void UpdateSupply_Click(object sender, RoutedEventArgs e)
        {
            if (listPetSupplies.SelectedItem is PetSupply selectedSupply)
            {
                if (decimal.TryParse(txtPrice.Text, out decimal price) && !string.IsNullOrEmpty(selectedImagePath))
                {
                    selectedSupply.Name = txtName.Text;
                    selectedSupply.Description = txtDescription.Text;
                    selectedSupply.Price = price;
                    selectedSupply.ImageUrl = selectedImagePath;
                    db.UpdatePetSupply(selectedSupply);
                    LoadItems();
                }
                else
                {
                    MessageBox.Show("Please enter a valid price and select an image.");
                }
            }
        }

        // Satış sayfasına geçişi sağlar
        private void GoToSalesPage_Click(object sender, RoutedEventArgs e)
        {
            SalesPage salesPage = new SalesPage();
            salesPage.Show();
        }
    }
}
