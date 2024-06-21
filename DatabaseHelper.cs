using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace petshopmanagament
{
    public class DatabaseHelper
    {
        private string connectionString = "Data Source=DESKTOP-RKKGETA;Initial Catalog=psms;Integrated Security=True;";

        // Veritabanı bağlantısı sağlama
        public SqlConnection GetConnection()
        {
            try
            {
                var connection = new SqlConnection(connectionString);
                connection.Open(); // Bağlantıyı aç
                Console.WriteLine("Database connection successful.");
                connection.Close(); // Bağlantıyı test ettikten sonra kapat
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to the database: " + ex.Message);
                return null;
            }
        }

        // Pet işlemleri
        public bool AddPet(string name, string type, string breed, int age)
        {
            using (var connection = GetConnection())
            {
                string query = "INSERT INTO Pets (Name, Type, Breed, Age) VALUES (@Name, @Type, @Breed, @Age)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@Breed", breed);
                command.Parameters.AddWithValue("@Age", age);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public List<Pet> GetPets()
        {
            var pets = new List<Pet>();
            using (var connection = GetConnection())
            {
                var command = new SqlCommand("SELECT Id, Name, Type, Breed, Age FROM Pets", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    pets.Add(new Pet
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Type = reader["Type"].ToString(),
                        Breed = reader["Breed"].ToString(),
                        Age = Convert.ToInt32(reader["Age"])
                    });
                }
                reader.Close();
            }
            return pets;
        }

        public bool UpdatePet(int petId, string name, string type, string breed, int age)
        {
            using (var connection = GetConnection())
            {
                string query = "UPDATE Pets SET Name = @Name, Type = @Type, Breed = @Breed, Age = @Age WHERE Id = @PetId";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PetId", petId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Type", type);
                command.Parameters.AddWithValue("@Breed", breed);
                command.Parameters.AddWithValue("@Age", age);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool DeletePet(int petId)
        {
            using (var connection = GetConnection())
            {
                var command = new SqlCommand("DELETE FROM Pets WHERE Id = @PetId", connection);
                command.Parameters.AddWithValue("@PetId", petId);
                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Müşteri işlemleri
        public bool AddCustomer(string name, string email, string phone)
        {
            using (var connection = GetConnection())
            {
                string query = "INSERT INTO Customers (Name, Email, Phone) VALUES (@Name, @Email, @Phone)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Phone", phone);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public List<Customer> GetCustomers()
        {
            var customers = new List<Customer>();
            using (var connection = GetConnection())
            {
                var command = new SqlCommand("SELECT Id, Name, Email, Phone FROM Customers", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString()
                    });
                }
                reader.Close();
            }
            return customers;
        }

        public bool UpdateCustomer(int customerId, string name, string email, string phone)
        {
            using (var connection = GetConnection())
            {
                string query = "UPDATE Customers SET Name = @Name, Email = @Email, Phone = @Phone WHERE Id = @CustomerId";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerId", customerId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Phone", phone);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            using (var connection = GetConnection())
            {
                var command = new SqlCommand("DELETE FROM Customers WHERE Id = @CustomerId", connection);
                command.Parameters.AddWithValue("@CustomerId", customerId);
                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        // Satış işlemleri
        public bool AddSale(int customerId, int petId, DateTime saleDate, decimal saleAmount)
        {
            using (var connection = GetConnection())
            {
                string query = "INSERT INTO Sales (CustomerID, PetID, Date, Amount) VALUES (@CustomerID, @PetID, @Date, @Amount)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerId);
                command.Parameters.AddWithValue("@PetID", petId);
                command.Parameters.AddWithValue("@Date", saleDate);
                command.Parameters.AddWithValue("@Amount", saleAmount);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0;
            }
        }

        public List<Sale> GetSales()
        {
            var sales = new List<Sale>();
            using (var connection = GetConnection())
            {
                string query = @"SELECT s.ID, s.Date, s.Amount, c.Id as CustomerId, c.Name as CustomerName, p.Id as PetId, p.Name as PetName
                                FROM Sales s
                                JOIN Customers c ON s.CustomerID = c.Id
                                JOIN Pets p ON s.PetID = p.Id";
                var command = new SqlCommand(query, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sales.Add(new Sale
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Date = Convert.ToDateTime(reader["Date"]),
                        Amount = Convert.ToDecimal(reader["Amount"]),
                        Customer = new Customer
                        {
                            Id = Convert.ToInt32(reader["CustomerId"]),
                            Name = reader["CustomerName"].ToString()
                        },
                        Pet = new Pet
                        {
                            Id = Convert.ToInt32(reader["PetId"]),
                            Name = reader["PetName"].ToString()
                        }
                    });
                }
                reader.Close();
            }
            return sales;
        }

        // Pet malzemesi işlemleri
        public void AddPetSupply(PetSupply supply)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("INSERT INTO PetSupplies (Name, Description, Price, ImageUrl) VALUES (@Name, @Description, @Price, @ImageUrl)", connection);
                command.Parameters.AddWithValue("@Name", supply.Name);
                command.Parameters.AddWithValue("@Description", supply.Description);
                command.Parameters.AddWithValue("@Price", supply.Price);
                command.Parameters.AddWithValue("@ImageUrl", supply.ImageUrl);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<PetSupply> GetPetSupplies()
        {
            var supplies = new List<PetSupply>();
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT Id, Name, Description, Price, ImageUrl FROM PetSupplies", connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    supplies.Add(new PetSupply
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                        Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                        ImageUrl = reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? null : reader.GetString(reader.GetOrdinal("ImageUrl"))
                    });
                }
                reader.Close();
            }
            return supplies;
        }

        public void UpdatePetSupply(PetSupply supply)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("UPDATE PetSupplies SET Name = @Name, Description = @Description, Price = @Price, ImageUrl = @ImageUrl WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", supply.Id);
                command.Parameters.AddWithValue("@Name", supply.Name);
                command.Parameters.AddWithValue("@Description", supply.Description);
                command.Parameters.AddWithValue("@Price", supply.Price);
                command.Parameters.AddWithValue("@ImageUrl", supply.ImageUrl);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeletePetSupply(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("DELETE FROM PetSupplies WHERE ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
