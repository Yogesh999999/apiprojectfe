using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace month3
{
    public partial class Emailcode1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string SendMail(string toEmail, string subject, string body)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("yogeshashh@gmail.com");
                mail.To.Add(toEmail);
                mail.Subject = subject;
                mail.Body = body;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(
                    "yogeshashh@gmail.com",
                    "dmyd xomy gnoz rgaz"
                );  


                smtp.Send(mail);
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return "ERROR: " + ex.Message;
            }
        }

    }
}