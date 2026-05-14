using System.Diagnostics.CodeAnalysis;
using Npgsql;
using System.Net.NetworkInformation;
using NotificationModelLibrary;

namespace NotificationDLLibrary.Database
{
    
    public class PgDatabaseConnection
    {
        string connectionString="Host=localhost;Port=5432;Database=dummydb;Username=postgres;Password=ajay";
        NpgsqlConnection connection;

        public PgDatabaseConnection()
        {
            connection = new NpgsqlConnection(connectionString);
        }
        
        string Id="100";
        public void insertUserIntoDatabase(User user)
        {
            int UserNum=Convert.ToInt32(Id);
            user.userId=(++UserNum).ToString();
            Id=UserNum.ToString();
            string InsertQuery =
                $"INSERT INTO Users(UserId, Name, EmailId, Phone) " +
                $"VALUES('{Id}', '{user.Name}', '{user.EmailId}', '{user.Phone}')";
            NpgsqlCommand command = new NpgsqlCommand(InsertQuery, connection);
            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("User successfully inserted");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }

        public void UpdateUserDetails(string Id,string data, string field)
        {
            string UpdateCommand = "";
            if (field == "Name")
            {
                UpdateCommand = $"Update Users set Name='{data}' where userId='{Id}'";
            }
            else if (field == "Email")
            {
                UpdateCommand = $"Update Users set EmailId='{data}' where userId='{Id}'";
            }
            else if (field == "Phone")
            {
                UpdateCommand = $"Update Users set Phone='{data}' where userId='{Id}'";
            }
            else
            {
                throw new Exception("Invalid field");
            }

            NpgsqlCommand command = new NpgsqlCommand(UpdateCommand, connection);
            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("User successfully updated");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public Dictionary<string,User> GetAllUsers()
        {
            Dictionary<string,User> users = new Dictionary<string,User>();
            string query = "Select * from Users";
            NpgsqlCommand command=new NpgsqlCommand(query,connection);
            try
            {
                connection.Open();
                NpgsqlDataReader reader=command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User();
                    user.userId = reader["UserId"].ToString();
                    user.Name = reader["Name"].ToString();
                    user.EmailId = reader["EmailId"].ToString();
                    user.Phone = reader["Phone"].ToString();
                    users.Add(user.userId,user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return users;

        }

        public User GetUserById(string Id)
        {
            User user = new User();
            string query = $"SELECT * FROM Users WHERE UserId = '{Id}'";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user.Name = reader["Name"].ToString();
                    user.EmailId = reader["EmailId"].ToString();
                    user.Phone = reader["Phone"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return user;

        }

        public User DeleteUserById(string Id)
        {
            User user = new User();
            string query = $"DELETE FROM Users WHERE UserId = '{Id}'";
            NpgsqlCommand command=new NpgsqlCommand(query, connection);
            try
            {
                connection.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("User successfully Deleted");
                }
                else
                {
                    Console.WriteLine("User not found");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return user;
        }
    }
    
}