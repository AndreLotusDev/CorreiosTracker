using CorreioTracker.SystemModels;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net;
using CorreioTracker.SystemHandler;
using CorreioTracker.ConfigHandler;
using AegisImplicitMail;
using CorreioTracker.DomainModels;

namespace CorreioTracker.Helpers
{
    public class EmailBuilder
    {
        public EmailSentModel EmailSentModel { get; set; }
        public EmailBot EmailBot { get; set; }
        public bool IsHtml { get; set; }

        public EmailBuilder(EmailSentModel emailSentModel, EmailBot emailBot, bool isHtml = true)
        {
            EmailBot = emailBot;
            IsHtml = isHtml;
            EmailSentModel = emailSentModel;
        }

        /// <summary>
        /// Configura e ja manda a mensagem
        /// </summary>
        public void ConfigureEmailServicePartnership()
        {
            try
            {
                #region Message

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(EmailBot.StmpMailBot);

                mailMessage.To.Add("andrsoares953@yahoo.com");

                mailMessage.Subject = EmailSentModel.Subject;

                mailMessage.Body = EmailSentModel.Body;
                mailMessage.Body += "<br/> Enviado por: " + EmailSentModel.Address;
                mailMessage.IsBodyHtml = IsHtml;
                #endregion

                ServicePointManager.Expect100Continue = false;
                using (var smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Port = 587;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;

                    smtpClient.Credentials = new NetworkCredential(EmailBot.StmpMailBot, EmailBot.SmtpPassBot);

                    smtpClient.Send(mailMessage);
                }
                    
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
