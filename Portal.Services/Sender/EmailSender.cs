using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using Portal.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Services.Sender
{
    public class EmailSender : ISender
    {
        public async Task SendAsync(string message, string to)
        {
            
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("سایت وبلاگی", "parsa.cc19@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", to));
            emailMessage.Body = new TextPart(TextFormat.Plain)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.relay.uri", 25, SecureSocketOptions.None).ConfigureAwait(false);
                await client.SendAsync(emailMessage).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
}
