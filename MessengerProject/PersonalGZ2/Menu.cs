using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalGZ2
{
    class Menu
    {
        static public void DisplayMenu(string loggedUser)
        {
            System.Threading.Thread.Sleep(1500);
            Console.Clear();
            Console.WriteLine("Hello " + loggedUser);
            Console.WriteLine();

            string userRole = ConnectionToServer.GetUserRole(loggedUser);

            switch(userRole)
            {
                case "SIMPLE":
                    Console.WriteLine("Simple user's Menu");
                    Console.WriteLine();
                    Console.WriteLine("1. Read your sented Message");
                    Console.WriteLine("2. Read your recieved Messages");
                    Console.WriteLine("3. Send new Message");
                    Console.WriteLine("4. Exit");
                    int resultSimp;

                    if (!int.TryParse(Console.ReadLine(), out resultSimp) || resultSimp > 4 || resultSimp < 1)
                    {
                        Console.WriteLine("Invalid Entry, wait a sec and try Again.");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        Menu.DisplayMenu(loggedUser);
                    }

                    if ( resultSimp == 1)
                    {
                        Console.Clear();
                        Message.ReadUserMessages(loggedUser);
                        Console.Clear();
                        Menu.DisplayMenu(loggedUser);
                    }

                    if (resultSimp == 2)
                    {
                        Console.Clear();
                        Message.ReadReceivedMessages(loggedUser);
                        Console.Clear();
                        Menu.DisplayMenu(loggedUser);
                    }

                    if (resultSimp == 3)
                    {
                        Console.Clear();
                        Console.Write("Enter username: ");
                        string usernameSeD = Console.ReadLine();
                        Message.NewMessage(loggedUser, usernameSeD);
                        Console.Clear();
                        Menu.DisplayMenu(loggedUser); 
                    }

                    if (resultSimp == 4)
                    {
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        System.Threading.Thread.Sleep(1000);
                        Environment.Exit(0);
                    }

                    break;

                case "EDITOR":
                    Console.WriteLine("Editor's Menu");
                    Console.WriteLine();
                    Console.WriteLine("1. Read sended messages");
                    Console.WriteLine("2. Read received messases ");
                    Console.WriteLine("3. Send a new Message");
                    Console.WriteLine("4. Edit Message");
                    Console.WriteLine("5. Exit");
                    int resultEdit;

                    if (!int.TryParse(Console.ReadLine(), out resultEdit) || resultEdit > 5 || resultEdit < 1)
                    {
                        Console.WriteLine("Invalid Entry, wait a sec and try Again.");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        Menu.DisplayMenu(loggedUser);
                    }


                    if (resultEdit == 1)
                    {
                        Console.Clear();
                        Message.ReadUserMessages(loggedUser);
                        Console.Clear();
                        Menu.DisplayMenu(loggedUser);
                    }

                    if (resultEdit == 2)
                    {
                        Console.Clear();
                        Message.ReadReceivedMessages(loggedUser);
                        Console.Clear();
                        Menu.DisplayMenu(loggedUser);
                    }

                    if (resultEdit == 3)
                    {
                        Console.Clear();
                        Console.Write("Enter The username you want to send to: ");
                        string receiver = Console.ReadLine();
                        Message.NewMessage(loggedUser, receiver);
                        Console.Clear();
                        Menu.DisplayMenu(loggedUser);

                    }

                    if (resultEdit == 4)
                    {
                        Console.Write("Enter Messages Id: ");
                        int MessId;
                        if (!int.TryParse(Console.ReadLine(), out MessId))
                        {
                            Console.WriteLine("Invalid Entry, Please try again..");
                        }
                        Message.EditMessage(MessId);
                        Console.Clear();
                        Menu.DisplayMenu(loggedUser);
                    }

                    if (resultEdit == 5)
                    {
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        System.Threading.Thread.Sleep(1000);
                        Environment.Exit(0);
                    }


                    break;

                case "DELETER":
                    Console.WriteLine("Deleter's Menu");
                    Console.WriteLine();
                    Console.WriteLine("1. Read sended messages");
                    Console.WriteLine("2. Read received messases ");
                    Console.WriteLine("3. Send a new Message");
                    Console.WriteLine("4. Edit Message");
                    Console.WriteLine("5. Delete Message");
                    Console.WriteLine("6. Exit");
                    int resultDel;

                    if (!int.TryParse(Console.ReadLine(), out resultDel) || resultDel > 6 || resultDel < 1)
                    {
                        Console.WriteLine("Invalid Entry, wait a sec and try Again.");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        Menu.DisplayMenu(loggedUser);
                    }

                    if (resultDel == 1)
                    {
                        Console.Clear();
                        Message.ReadUserMessages(loggedUser);
                        Console.Clear();
                        Menu.DisplayMenu(loggedUser);
                    }

                    if (resultDel == 2)
                    {
                        Console.Clear();
                        Message.ReadReceivedMessages(loggedUser);
                        Console.Clear();
                        Menu.DisplayMenu(loggedUser);
                    }

                    if (resultDel == 3)
                    {
                        Console.Clear();
                        Console.Write("Enter The username you want to send to: ");
                        string receiver = Console.ReadLine();
                        Message.NewMessage(loggedUser, receiver);
                        Console.Clear();
                        Menu.DisplayMenu(loggedUser);

                    }

                    if (resultDel == 4)
                    {
                        Console.Write("Enter Messages Id: ");
                        int MessId;
                        if (!int.TryParse(Console.ReadLine(), out MessId))
                        {
                            Console.WriteLine("Invalid Entry, Please try again..");
                        }
                        Message.EditMessage(MessId);
                        Console.Clear();
                        Menu.DisplayMenu(loggedUser);
                    }

                    if (resultDel == 5)
                    {
                        Console.WriteLine("Enter message's Id: ");
                        int MessId;
                        if (!int.TryParse(Console.ReadLine(), out MessId))
                        {
                            Console.WriteLine("Invalid Entry, Please try again..");
                        }
                        Message.DeleteMessage(MessId);
                        Console.Clear();
                        Menu.DisplayMenu(loggedUser);
                    }

                    if (resultDel == 6)
                    {
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        System.Threading.Thread.Sleep(1000);
                        Environment.Exit(0);
                    }

                    break;

                case "ADMIN":
                    Console.WriteLine("Administrator Menu");
                    Console.WriteLine();
                    Console.WriteLine("1. Message's Options");
                    Console.WriteLine("2. User's Options");
                    Console.WriteLine("3. Exit");
                    int resultAdm;

                    if (!int.TryParse(Console.ReadLine(), out resultAdm) || resultAdm > 3 || resultAdm < 1)
                    {
                        Console.WriteLine("Invalid Entry, wait a sec and try Again.");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        Menu.DisplayMenu(loggedUser);
                    }

                    if (resultAdm == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Administrator's Message's Menu");
                        Console.WriteLine();
                        Console.WriteLine("1. Read sended messages");
                        Console.WriteLine("2. Read received messases ");
                        Console.WriteLine("3. Send a new Message");
                        Console.WriteLine("4. Edit Message");
                        Console.WriteLine("5. Delete Message");
                        Console.WriteLine("6. Exit");
                        int resultAdmMess;

                        if (!int.TryParse(Console.ReadLine(), out resultAdmMess) || resultAdmMess > 6 || resultAdmMess < 1)
                        {
                            Console.WriteLine("Invalid Entry, wait a sec and try Again.");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            Menu.DisplayMenu(loggedUser);
                        }

                        if (resultAdmMess == 1)
                        {
                            Console.Clear();
                            Message.ReadUserMessages(loggedUser);
                            Console.Clear();
                            Menu.DisplayMenu(loggedUser);
                        }

                        if (resultAdmMess == 2)
                        {
                            Console.Clear();
                            Message.ReadReceivedMessages(loggedUser);
                            Console.Clear();
                            Menu.DisplayMenu(loggedUser);
                        }

                        if (resultAdmMess == 3)
                        {
                            Console.Clear();
                            Console.Write("Enter The username you want to send to: " );
                            string receiver = Console.ReadLine();
                            Message.NewMessage(loggedUser, receiver);
                            Console.Clear();
                            Menu.DisplayMenu(loggedUser);

                        }

                        if (resultAdmMess == 4)
                        {
                            Console.Write("Enter Messages Id: ");
                            int MessId;
                            if (!int.TryParse(Console.ReadLine(), out MessId))
                            {
                                Console.WriteLine("Invalid Entry, Please try again..");
                            }
                            Message.EditMessage(MessId);
                            Console.Clear();
                            Menu.DisplayMenu(loggedUser);
                        }

                        if (resultAdmMess == 5)
                        {
                            Console.WriteLine("Enter message's Id: ");
                            int MessId;
                            if (!int.TryParse(Console.ReadLine(), out MessId))
                            {
                                Console.WriteLine("Invalid Entry, Please try again..");
                            }
                            Message.DeleteMessage(MessId);
                            Console.Clear();
                            Menu.DisplayMenu(loggedUser);
                        }

                        if (resultAdmMess == 6)
                        {
                            Console.Clear();
                            Menu.DisplayMenu(loggedUser);
                        }
                    }

                    if (resultAdm == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Administrator's User's Menu");
                        Console.WriteLine();
                        Console.WriteLine("1. Create new User");
                        Console.WriteLine("2. Update User's Name");
                        Console.WriteLine("3. Update User's Password");
                        Console.WriteLine("4. View User");
                        Console.WriteLine("5. View All Users");
                        Console.WriteLine("6. Delete User");
                        Console.WriteLine("7. Exit");

                        int resultAdmUser;

                        if (!int.TryParse(Console.ReadLine(), out resultAdmUser) || resultAdmUser > 7 || resultAdmUser < 1)
                        {
                            Console.WriteLine("Invalid Entry, wait a sec and try Again.");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            Menu.DisplayMenu(loggedUser);
                        }

                        if (resultAdmUser == 1)
                        {
                            Console.Clear();
                            User.CreateUser();
                            Console.Clear();
                            Menu.DisplayMenu(loggedUser);
                        }
                        
                        if (resultAdmUser == 2)
                        {
                            Console.Clear();
                            Console.Write ("Enter User name: ");
                            string usernameOld = Console.ReadLine();
                            User.UpdateUserName(usernameOld);
                            Console.Clear();
                            Menu.DisplayMenu(loggedUser);
                        }

                        if (resultAdmUser == 3)
                        {
                            Console.Clear();
                            Console.Write("Enter username: ");
                            User.UpdateUserPassWord(loggedUser);
                            Console.Clear();
                            Menu.DisplayMenu(loggedUser);
                        }

                        if (resultAdmUser == 4)
                        {
                            Console.Clear();
                            Console.Write("Enter username: ");
                            string usernameRd = Console.ReadLine();
                            User.ReadUser(usernameRd);
                            Console.Clear();
                            Menu.DisplayMenu(loggedUser);
                        }

                        if (resultAdmUser == 5)
                        {
                            Console.Clear();
                            User.ReadAllUsers();
                            Console.Clear();
                            Menu.DisplayMenu(loggedUser);
                        }

                        if (resultAdmUser == 6)
                        {
                            Console.Clear();
                            string usernameDel = Console.ReadLine();
                            User.DeleteUser(usernameDel);
                            Console.Clear();
                            Menu.DisplayMenu(loggedUser);
                        }

                        if (resultAdmUser == 7)
                        {
                            Console.Clear();
                            Menu.DisplayMenu(loggedUser);
                        }
                    }

                    if (resultAdm == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Goodbye!");
                        System.Threading.Thread.Sleep(1000);
                        Environment.Exit(0);
                    }
                    //return Convert.ToInt32(result);
                    break;
                default:
                    break;
            }
        }
    }
}

