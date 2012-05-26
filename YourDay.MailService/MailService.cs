using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using YourDay.POCO;
using YourDay.DAL;
using System.Timers;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using YourDay.Constants;

namespace YourDay.MailService
{
    public partial class MailService : ServiceBase
    {

        private static int last = 0;
        private static int take = 10;

        public MailService()
        {
            InitializeComponent();
        }


        Timer timer;
        protected override void OnStart(string[] args)
        {
            timer = new Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
            
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var mails = GetMailQueue();
            ProcessMailQueue(mails);

        }

        protected override void OnStop()
        {
            timer.Stop();
        }

        private IEnumerable<MailQueue> GetMailQueue()
        {
            using (MailEntities context = new MailEntities())
            {
                var mails = context.MailQueue
                    .Include("MailType")
                    .Include("User")
                        .Where(x => !x.IsProcessed)
                        .OrderBy(x => x.Id)
                        .Take(take);
                if(mails.Count() > 0)
                    last = mails.Max(x => x.Id);
                var result = mails.ToList();

                foreach (var m in mails)
                {
                    m.IsProcessed = true;
                }
                context.SaveChanges();

                return result;
            }
        }
        private void ProcessMailQueue(IEnumerable<MailQueue> queue)
        {
            foreach (MailQueue mail in queue)
            {
                //if (mail.Id < last)
                //    continue;
                SendMail(mail.User.EMail, MailProcesser.GetActualMail(mail), mail.MailType.Subject);
            }
        
        }

       

        private void SendMail(string mail, string html, string subject)
        {
            string smtpHost = ConfigurationManager.AppSettings["smtphost"];
            int smtpPort = Int32.Parse(ConfigurationManager.AppSettings["smtpPort"]);
            string login = ConfigurationManager.AppSettings["smtplogin"];
            string pass = ConfigurationManager.AppSettings["smtppassword"];
            SmtpClient client = new SmtpClient(smtpHost, smtpPort);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(login, pass);
            string from = ConfigurationManager.AppSettings["smtpFrom"];
            string to = mail;
            string body = html;
            MailMessage mess = new MailMessage(from, to, subject, body);
            client.Send(mess);
        }
    }
}
