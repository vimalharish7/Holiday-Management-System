using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.IO;

namespace FIT5032_Assignment_Portfolio_Final.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "{your api key}";

        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "Magnificent Melbourne Admin");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";          

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var bytes = File.ReadAllBytes("~/Uploads/");
            var file = Convert.ToBase64String(bytes);
            msg.AddAttachment("event_report.pdf", file);
            var response = client.SendEmailAsync(msg);
        }

    }
}
