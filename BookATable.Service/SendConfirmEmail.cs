using BookATable.Entity;
using System;
using System.Net;
using System.Net.Mail;

namespace BookATable.Service
{
    public class SendConfirmEmail
    {

        private string confirmationEmailUrl = "http://localhost:55626/Users/ValidateEmail";
        //private string confirmationEmailUrl = "http://bookatable1.azurewebsites.net/Users/ValidateEmail/";

        public void SendConfirmationEmailAsync(User user)
        {
            string callbackUrl = $"{confirmationEmailUrl}?userId={user.ID}&validationCode={user.ValidationCode}";
            string link = $"<a href='{ callbackUrl}'>here</a>!";
            SendConfirmationEmail(user.Email, "BookATable registration request", $"To confirm your account click  -> {link}");
        }

        public void SendConfirmationEmail(string email, string name, string comment)
        {

            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("vklalev@gmail.com", "9706306026")
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("vklalev@gmail.com")
                };
                mailMessage.To.Add(email);
                mailMessage.Body = comment;
                mailMessage.IsBodyHtml = true;
                mailMessage.Subject = name;
                client.EnableSsl = true;
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                //TODO: Log the exception
                throw new ApplicationException($"Unable to load : '{ex.Message}'.");
            }

        }
    }
}
