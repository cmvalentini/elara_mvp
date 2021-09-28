using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmailServiceDAL
    {
        System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
        public void EnviarEmail(string edestino, string mensaje){
              
            msg.To.Add(edestino);
            msg.Subject = "clave Elara";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Bcc.Add("valentini.carlos.marcelo@gmail.com");
            msg.Body = "  " + mensaje .ToString()+ "  .";
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;

            msg.From = new  System.Net.Mail.MailAddress("valentini.carlos.marcelo@gmail.com");

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.UseDefaultCredentials = false;
            cliente.Credentials = new System.Net.NetworkCredential("valentinicharly@gmail.com", "valentinicharly87");

            cliente.Port = 587;
            cliente.EnableSsl = true;

            cliente.Host = "smtp.gmail.com";

           
            cliente.Send(msg);
           

        }

    }
}
