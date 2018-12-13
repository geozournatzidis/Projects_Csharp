using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalGZ2
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = ConnectionToServer.Connection();

            string loggedUser = Login.LoginCheck();

            if (loggedUser != "")
            {
                Menu.DisplayMenu(loggedUser);
            }

        }
    }
}
