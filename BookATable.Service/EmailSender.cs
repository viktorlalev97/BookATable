using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.NotificationServices
{
    public class EmailSender
    {
        private string _adminEmail = "vklalev@gmail.com";
        private string _adminPass = "9706306026";
        public void SendEmail(string email, string name, string comment)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_adminEmail, _adminPass)
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(email)
                };
                mailMessage.To.Add(_adminEmail);
                mailMessage.Body = $"{ name} with email { email} send you the next comment: { comment}";
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = "Email request from landing page....";
                client.EnableSsl = true;
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                throw new ApplicationException($"Unable to load : '{ex.Message}'.");
            }
        }


        //public SmtpClient Client { get; set; }

        //Send email using mailtrap.io
        //public EmailSender()
        //{
        //    Client = new SmtpClient("smtp.mailtrap.io", 2525)
        //    {
        //        Credentials = new NetworkCredential("d4ce53a0171ba3", "4edf8f094c2e45"),
        //        EnableSsl = true
        //    };
        //}

        //public void SendMail(string email, string name, string comment)
        //{
        //    Client.Send(email, "infinite.love@abv.bg", name, comment);
        //}



    }
}
