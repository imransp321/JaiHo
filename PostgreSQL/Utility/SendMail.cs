using System;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace PostgreSQL.Utility
{
    public static class SendMail
    {
        // SMTP Server
        public const string SMTP_SERVER = "mailgso.it.volvo.net";
        public const string SMTP_FROM_ADDRESS = "support.serviceweb@volvo.com";
        public const string SMTP_FOOTER = "\n\nDO NOT REPLY TO THIS EMAIL ADDRESS\n\nPLEASE CONTACT SERVICEWEB SUPPORT IF YOU HAVE QUESTIONS ABOUT THIS EMAIL";

        public static void Email(string toMailAddress)
        {
            var fromName = "Imran";
            try
            {
                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(SMTP_FROM_ADDRESS, fromName);
                    message.To.Add(new MailAddress(toMailAddress));
                    message.Subject = "Reset-Password Link";
                    message.Body = ResetPasswordEmailBody();
                    message.BodyEncoding = Encoding.ASCII;
                    message.IsBodyHtml = true;

                    if (message.To.Any())
                    {
                        var client = new SmtpClient(SMTP_SERVER);
                        client.Send(message);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string ResetPasswordEmailBody()
        {
            string messageBody = "<font>FORGOT YOUR PASSWORD? </font><br><br>";
            string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
            string htmlTableEnd = "</table>";
            string htmlHeaderRowStart = "<tr style=\"background-color:#6FA1D2; color:#ffffff;\">";
            string htmlHeaderRowEnd = "</tr><br/>";
            string htmlTrStart = "<tr style=\"color:#555555;\">";
            string htmlTrEnd = "</tr>";
            string htmlTdStart = "<td>";
            string htmlTdEnd = "</td><br/>";
            messageBody += htmlTableStart;
            messageBody += htmlHeaderRowStart;
            messageBody += htmlTdStart + "Reset your Password using the link below," + htmlTdEnd;
            messageBody += htmlHeaderRowEnd;
            messageBody += htmlTrStart + htmlTdStart + "www.google.com" + htmlTdEnd + htmlTrEnd;
            messageBody += htmlTdStart + "The link is valid only for 15 mins" + htmlTdEnd;
            messageBody += htmlTrStart + htmlTdStart + "Thanks,<br/> Support" + htmlTdEnd + htmlTrEnd;
            messageBody = messageBody + htmlTableEnd;
            return messageBody;
        }
    }
}