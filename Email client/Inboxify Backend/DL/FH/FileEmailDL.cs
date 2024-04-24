using Email_client.BL;
using Inboxify_Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inboxify_Backend.DL.FH
{
    public class FileEmailDL : IEmailDL
    {
        private readonly string filePath = "emails.txt";
        public void AddEmail(Email email)
        {

            string emailData = $"{email.Get_ID()},{email.Get_Sender()},{email.Get_receiver()},{email.Get_Email_Subject()},{email.Get_Email_Body()},{email.Get_Email_Footer()},{email.Get_Tag()}";

            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine(emailData);
            }
        }
        public Email GetEmail(string subject, string sender)
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                if (data[3] == subject && data[1] == sender)
                {
                    Email email = new Email(int.Parse(data[0]), data[1], data[2], data[3], data[4], data[5], data[6]);
                    return email;
                }
            }
            return null;
        }
        public void UpdateTag(string tag)
        {

            string[] lines = File.ReadAllLines(filePath);

            List<string> updatedLines = new List<string>();

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                if (int.Parse(data[0]) == Connection.currentEmail.Get_ID())
                {

                    data[6] = tag;
                }

                string updatedLine = string.Join(",", data);

                updatedLines.Add(updatedLine);
            }

            File.WriteAllLines(filePath, updatedLines);
        }
    }
}
