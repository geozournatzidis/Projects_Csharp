using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalGZ2
{
    class TextFile
    {
        public static void MessagesToText(string date, string sender, string receiver, string text)
        {
            if (!File.Exists(System.IO.Directory.GetCurrentDirectory() + "\\messages.txt"))
                File.Create(System.IO.Directory.GetCurrentDirectory() + "\\messages.txt");

            File.AppendAllText(System.IO.Directory.GetCurrentDirectory() + "\\messages.txt", date + " ::::: " + sender + " ::::: " + receiver + " ::::: " + text + Environment.NewLine);
        }
    }
}
