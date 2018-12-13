using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace PersonalGZ2
{
   public class  Login
    {
        public static string LoginCheck()
        {
            SqlConnection connection = ConnectionToServer.Connection();

            try
            {
                connection.Open();
                Console.WriteLine("Login Screen \n------------\n");

                Console.Write("Enter Username: ");
                string entername = Console.ReadLine();
                Console.Write("Enter Password: ");
                string enterpass = Console.ReadLine();
                SqlCommand command = new SqlCommand($"SELECT COUNT (*) FROM Person WHERE Username = @uusername AND Password = @password", connection);
                command.Parameters.AddWithValue("@uusername", entername);
                command.Parameters.AddWithValue("@password", enterpass);
                int result = (int)command.ExecuteScalar();

                connection.Close();
                if (result > 0)
                {
                    Console.WriteLine("Login Successful!");
                    return entername;
                }
                else
                {
                    Console.WriteLine("Incorrect login. Please try again...");
                    return "";
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
