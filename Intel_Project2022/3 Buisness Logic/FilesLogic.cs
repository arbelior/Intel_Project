//using Magnum.FileSystem;
using Amazon.SecurityToken.Model;
using FluentEmail.Core;
using FluentEmail.Smtp;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using FluentEmail.Core.Interfaces;
using FluentEmail.Core.Models;



namespace IntelPro
{
    public class FilesLogic : BaseLogic
    {
      
        public void GetFile(CommentModel Comment)
        {

            StreamWriter writer = File.AppendText($@"C:\D.E Intel\{Comment.Subject}");
            writer.WriteLine(Comment.Comment);
            writer.WriteLine("");
            writer.WriteLine("From: " + Comment.name + " " + Comment.WWId);
            writer.WriteLine("Date: " + DateTime.Now);
            writer.WriteLine("--------------------------------------------------------------------------------------");
            writer.Close();
        }

        public async Task<string> SendMail(CommentModel comment)
        {

            var sender = new SmtpSender(() => new SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials = false,
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("arbelior@gmail.com","lior1985"),
                EnableSsl = true,
            });

            StringBuilder template = new();
            template.AppendLine(value: "Dear Lior");
            template.AppendLine(value: $"<p> {comment.Comment}</p>");
            template.AppendLine(value: $"From {comment.name}  {comment.WWId}" );

            Email.DefaultSender = sender;

            var email = Email
                .From("Dr.E_App@gmail.com", comment.name)
                .To("arbelior@gmail.com", "Lior")
                .Subject(comment.Subject)
                .UsingTemplate(template.ToString(),true);
              
              

            try
            {
                await email.SendAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
