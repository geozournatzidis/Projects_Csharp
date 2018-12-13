using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalGZ2
{

    enum Role
    {
        SIMPLE, EDITOR, DELETOR, ADMIN
    }
    class User 
    {
        public int Id { get; internal set; }
        public string NickName { get; internal set; }
        public string UserName { get; internal set; }
        public string Password { get; internal set; }
        public string Role { get; internal set; }

        public User()
        {

        }

        public User(int id, string nickname, string username, string password, string role)
        {
            Id = id;
            NickName = nickname;
            UserName = username;
            Password = password;
            Role = role;
        }

        public static void CreateUser()
        {
            SqlConnection connection = ConnectionToServer.Connection();

            string username, role, nickname, password;

            try
            {
                Console.WriteLine("New user entry:");
                Console.Write("Enter Nickname: ");
                nickname = Console.ReadLine();

                do
                {
                    Console.Write("Enter username: ");
                    username = Console.ReadLine();

                } while (User.UserExist(username));

                Console.Write("Enter password: ");
                password = Console.ReadLine();


                do
                {
                    Console.WriteLine("Select user's role: Simple, Editor, Deleter, Admin");
                    role = Console.ReadLine().ToUpper();

                    if (role == "SIMPLE" || role == "EDITOR" || role == "DELETER" || role == "ADMIN")
                        Console.WriteLine("Role selected: " + role);
                    else
                        Console.WriteLine("Try again");


                } while (!(role == "SIMPLE" || role == "EDITOR" || role == "DELETER" || role == "ADMIN"));


                connection.Open();
                SqlCommand userInput = new SqlCommand($"INSERT INTO Person(Nickname, Username, Password, Role) VALUES('{nickname}','{username}','{password}','{role}');SELECT SCOPE_IDENTITY();", connection);
                int id = System.Convert.ToInt32(userInput.ExecuteScalar());

                User user = new User(id, nickname, username, password, role);

                connection.Close();

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

        public static void DeleteUser(string username)
        {
            SqlConnection connection = ConnectionToServer.Connection();
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"DELETE FROM Person WHERE Username = '{username}'", connection);
                int del = command.ExecuteNonQuery();
                if (del > 0)
                {
                    Console.WriteLine("User successfully deleted!");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateUserName(string username)
        {
            SqlConnection connection = ConnectionToServer.Connection();

            try
            {
                Console.WriteLine($"Current username is {username}");
                Console.Write("Enter new username: ");
                string username2 = Console.ReadLine();

                connection.Open();

                SqlCommand command = new SqlCommand($"UPDATE Person SET username = '{username2}' WHERE userName = '{username}'", connection);
                int updatename = command.ExecuteNonQuery();
                if (updatename > 0)
                {
                    Console.WriteLine("Username updated successfully!");
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

        public static void UpdateUserPassWord(string username)
        {
            SqlConnection connection = ConnectionToServer.Connection();

            try
            {
                Console.Write("Enter new username: ");
                string password1 = Console.ReadLine();

                connection.Open();

                SqlCommand command = new SqlCommand($"UPDATE Person SET password = '{password1}' WHERE username = '{username}'", connection);
                int updatepass = command.ExecuteNonQuery();
                if (updatepass > 0)
                {
                    Console.WriteLine("Password updated successfully!");
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

        public static void ChangeRole()
        {
            SqlConnection connection = ConnectionToServer.Connection();

            try
            {
                Console.Write("Enter Username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Select user's role: Simple, Editor, Deleter, Admin");
                string newrole = Console.ReadLine().ToUpper();

                connection.Open();

                SqlCommand command = new SqlCommand($"UPDATE Person SET Role = '{newrole}' WHERE userName = '{username}'", connection);
                int updateRole = command.ExecuteNonQuery();
                if (updateRole > 0)
                {
                    Console.WriteLine("User's role updated successfully!");
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

        public static void ReadUser(string username)
        {
            SqlConnection connection = ConnectionToServer.Connection();

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"SELECT Id, Nickname, Username, Password, Role FROM Person WHERE username = '{username}'", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    Console.WriteLine(reader["Id"].ToString());
                    Console.WriteLine(reader["Nickname"].ToString());
                    Console.WriteLine(reader["Username"].ToString());
                    Console.WriteLine(reader["Password"].ToString());
                    Console.WriteLine(reader["Role"].ToString());
                }

                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
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

        public static void ReadAllUsers()
        {
            SqlConnection connection = ConnectionToServer.Connection();
            List<User> users = new List<User>();

            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"SELECT Id, Nickname, Username, Password, Role FROM Person", connection);
                SqlDataReader reader = command.ExecuteReader();
                Console.WriteLine("Users: ");

                while (reader.Read())
                {
                    User user = new User()
                    {
                        Id = reader.GetInt32(0),
                        NickName = reader["Nickname"].ToString(),
                        UserName = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        Role = reader["Role"].ToString()

                    };
                    users.Add(user);
                }
                foreach (User u in users)
                {
                    Console.WriteLine($"Id: {u.Id}");
                    Console.WriteLine($"Username: {u.UserName}");
                    Console.WriteLine($"Nickname: {u.NickName}");
                    Console.WriteLine($"Password: {u.Password}");
                    Console.WriteLine($"Role: {u.Role}");
                }
                reader.Close();

                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
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

        public static bool UserExist(string username)
        {
            bool exists = false;
            SqlConnection connection = ConnectionToServer.Connection();

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand($"SELECT COUNT (*) Username FROM Person WHERE username = '{username}'", connection);
                cmd.Parameters.AddWithValue("@username", username);
                int match = (int)cmd.ExecuteScalar();

                if (match > 0)
                {
                    Console.WriteLine("Username exists!");
                    exists = true;
                }

                else
                {
                    Console.WriteLine("Username does not exist!");
                    exists = false;
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
            return exists;
        }
    }


}
