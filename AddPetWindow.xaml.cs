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
    /// Interaction logic for AddPetWindow.xaml
    /// </summary>
    public partial class AddPetWindow : Window
    {
        public AddPetWindow()
        {
            InitializeComponent();
        }
        private void AddPet_Click(object sender, RoutedEventArgs e)
        {
            var name = txtName.Text;
            var type = txtType.Text;
            var breed = txtBreed.Text;
            var age = int.Parse(txtAge.Text);

            DatabaseHelper db = new DatabaseHelper();
            if (db.AddPet(name, type, breed, age))
            {
                MessageBox.Show("Pet added successfully!");
                ((MainWindow)Application.Current.MainWindow).LoadData();


            }
            else
            {
                MessageBox.Show("Failed to add pet.");
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Pencereyi kapat
        }

    }
}
