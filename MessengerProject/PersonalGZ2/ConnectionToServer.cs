using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalGZ2
{
    class ConnectionToServer : User
    {

        public static SqlConnection Connection()
        {
            string connectionString =
            @"Server = KARATEKAS\SQLEXPRESS;Database = PersonalGZ; Trusted_Connection = True;";

            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }

        public static int GetUserId(string username)
        {
            SqlConnection connection = ConnectionToServer.Connection();
            int id = 0;

            try
            {
                connection.Open();
                SqlCommand cmdLogin = new SqlCommand($"SELECT Id FROM Person WHERE username = '{username}'", connection);
                SqlDataReader reader = cmdLogin.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                reader.Close();
                //Console.WriteLine(id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return id;

        }

        public static string GetUserName(int Id)
        {
            SqlConnection connection = ConnectionToServer.Connection();
            string UserName = "";

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"SELECT Username FROM Person WHERE Id = '{Id}'", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    UserName = reader["Username"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return  UserName;
        }

        public static string GetUserRole(string username)
        {
            SqlConnection connection = ConnectionToServer.Connection();
            string userRole = "";

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"Select Role FROM Person WHERE username = '{username}'", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                   userRole = reader["Role"].ToString();
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
            return userRole;
        }

    }
}
