using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using MimeKit;
using MailKit.Net.Smtp;

namespace WebApplication7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : Controller
    {
        private readonly ILogger<TokenController> _logger;
        SqlOperation sqlOperation = new SqlOperation();
        string errorMsg = string.Empty;
        public TokenController(ILogger<TokenController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public ActionResult Get(string email)
        {
            string token = GenerateToken();
            if (IsValidEmail(email) && sqlOperation.AddToken(token))
            {
                SendToken(email, token);
                return StatusCode(200);
            }

            return Problem(errorMsg);
        }
        private string GenerateToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());
            return token;
        }
        private async void SendToken(string email, string token)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "tanksproga@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("Hello", email));
            emailMessage.Subject = "тема";
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = token
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("tanksproga@gmail.com", "tanks123");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
        private bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                errorMsg = "Mail is not valid!";
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                errorMsg = "Mail is not valid!";
                return false;
            }
        }
    }
}
