using System.Net.Mail;
using System.Net;
using Microsoft.Build.ObjectModelRemoting;

namespace projectUMG.Data
{
    public class Email
    {
        public void Send(string email, string tokon)
        {
            
        }

        void Address(string correo_reseptor, string token)
        {
            string correo_emisor = "";
            string clave_emisor = "";

            MailAddress receptor = new(correo_reseptor);
            MailAddress emisor = new(correo_emisor);
            MailMessage email = new(receptor, emisor);

            email.Subject = "validacion  de la cuenta";
            email.Body = "para activar el uasuario ingrese al siguiente link: " + token;
            SmtpClient smtp = new();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(correo_emisor, clave_emisor);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

    }
}