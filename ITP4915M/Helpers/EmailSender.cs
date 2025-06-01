using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using ITP4915M.AppLogic.Exceptions;
using static ITP4915M.Helpers.SecretConf;

namespace ITP4915M.Helpers;

public static class EmailSender
{

    public static string GetEmailAddress()
    {
        var username = Environment.GetEnvironmentVariable("Username");
        var domain = Environment.GetEnvironmentVariable("Domain");
        return $"{username}{domain}";
        
    }

    public static MimeMessage CreateEmail(string recevier, string receiverAddress, string subject, in string msg)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(Environment.GetEnvironmentVariable("DisplayedName"), GetEmailAddress()));
        message.To.Add(new MailboxAddress(recevier, receiverAddress));
        message.Subject = subject;
        message.Body = new TextPart(TextFormat.Html)
        {
            Text = msg
        };

        return message;
    }


    public static async Task SendEmail(string recevier, string receiverAddress, string subject, string msg)
    {
        
        var message = CreateEmail(recevier, receiverAddress, subject, in msg);

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(Environment.GetEnvironmentVariable("ServerURL"), int.Parse(Environment.GetEnvironmentVariable("Port")), false);
            await client.AuthenticateAsync(GetEmailAddress(), Environment.GetEnvironmentVariable("Password"));

            if (client.IsConnected)
            {
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
            else
            {
                throw new OperationFailException("Sent Email Fail");
            }
        }
    }
}