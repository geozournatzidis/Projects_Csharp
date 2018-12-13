using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalGZ2
{
    class Message
    {
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public DateTime update { get; private set; }
        public string Sender { get; private set; }
        public string Receiver { get; private set; }
        public string Text { get; private set; }

        public Message(int id, DateTime date, string sender, string receiver, string text)
        {
            Id = id;
            Date = date;
            Sender = sender;
            Receiver = receiver;
            Text = text;
        }

        public static void NewMessage(string sender, string receiver)
        {
            SqlConnection connection = ConnectionToServer.Connection();
            int messageId;
            DateTime date = DateTime.Now;
            string messDate = date.ToString("dd/MM/yyyy  HH:mm:ss");

            try
            {
                connection.Open();
                Console.Write("Message: ");
                string newmessage = Console.ReadLine();
                int senderId = ConnectionToServer.GetUserId(sender);
                int receiverId = ConnectionToServer.GetUserId(receiver);
                SqlCommand cmd = new SqlCommand($"INSERT INTO Message (Date, Sender, Receiver, Text) VALUES('{messDate}','{senderId}','{receiverId}','{newmessage}');SELECT SCOPE_IDENTITY();", connection);
                messageId = System.Convert.ToInt32(cmd.ExecuteScalar());
                string userscontact = $"{sender} to {receiver}";
                TextFile.MessagesToText(messDate, sender, receiver, newmessage);


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

        public static void ReadUserMessages(string username)
        {
            SqlConnection connection = ConnectionToServer.Connection();

            try
            {
                int userId = 0;
                using (connection)
                {
                    userId = ConnectionToServer.GetUserId(username);
                    connection.Open();
                    Console.WriteLine("Your Messages are: \n");
                    SqlCommand command = new SqlCommand($"SELECT Id, Date, Sender, Receiver, Text FROM Message WHERE sender = {userId}", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int messId = reader.GetInt32(0);
                        string receiver = ConnectionToServer.GetUserName(Int32.Parse(reader["Receiver"].ToString()));
                        Console.WriteLine(String.Format("Message Id:" + $"{messId}\n" + "From:" + username + $"\nTo:{receiver}\n" + "Message: " + $"{reader[4]}\n"));
                    }
                    reader.Close();

                    Console.WriteLine("Press enter to exit");
                    Console.ReadLine(); 
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

        public static void ReadReceivedMessages(string username)
        {
            SqlConnection connection = ConnectionToServer.Connection();

            try
            {
                int userId = 0;
                using (connection)
                {
                    userId = ConnectionToServer.GetUserId(username);
                    connection.Open();
                    Console.WriteLine("Messages that received: \n");
                    SqlCommand command = new SqlCommand($"SELECT Id, Date, Sender, Receiver, Text FROM Message WHERE Receiver = {userId}", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int messId = reader.GetInt32(0);
                        string sender = ConnectionToServer.GetUserName(Int32.Parse(reader["Sender"].ToString()));
                        Console.WriteLine(String.Format("Message Id:" + $"{messId}\n" + "From:" + username + $"\nTo:{sender}\n" + "Message: " + $"{reader[4]}\n"));
                    }

                    Console.WriteLine("Press enter key to exit");
                    Console.ReadLine();

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

        public static void DeleteMessage(int messageId)
        {
            SqlConnection connection = ConnectionToServer.Connection();

            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"DELETE FROM Message WHERE Id = {messageId}", connection);
                    int deleted = command.ExecuteNonQuery();
                    if (deleted > 0)
                    {
                        Console.WriteLine($"{deleted} rows deleted successfully");
                    }
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

        public static void EditMessage(int messageId)
        {

            SqlConnection connection = ConnectionToServer.Connection();

            try
            {
                using (connection)
                {
                    Console.Write("Message: ");
                    string upMessage = Console.ReadLine();
                    connection.Open();
                    SqlCommand command = new SqlCommand($"UPDATE Message SET Text = '{upMessage}' WHERE Id = '{messageId}'", connection);
                    int update = command.ExecuteNonQuery();
                    if (update > 0)
                    {
                        Console.WriteLine("Update successfull");
                    }
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


    }
}
