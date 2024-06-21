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
    /// Interaction logic for UpdatePetWindow.xaml
    /// </summary>
    public partial class UpdatePetWindow : Window
    {
        private DatabaseHelper db = new DatabaseHelper();
        private int PetId;

        public UpdatePetWindow(Pet pet)
        {
            InitializeComponent();
            PetId = pet.Id;
            txtName.Text = pet.Name;
            txtType.Text = pet.Type;
            txtBreed.Text = pet.Breed;
            txtAge.Text = pet.Age.ToString();
        }

        private void UpdatePet_Click(object sender, RoutedEventArgs e)
        {
            if (db.UpdatePet(PetId, txtName.Text, txtType.Text, txtBreed.Text, int.Parse(txtAge.Text)))
            {
                MessageBox.Show("Pet updated successfully!");
                this.Close();
                ((MainWindow)Application.Current.MainWindow).LoadData();
            }
            else
            {
                MessageBox.Show("Failed to update pet.");
            }
        }


    }
}
