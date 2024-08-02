using System;
using System.Configuration;
using System.Net.Mail;
using System.Text;

namespace PreRegistration.Models.Helpers
{
    public class SendEmails
    {
        Logger _log = new Logger();
        public string EmailUrl = ConfigurationManager.AppSettings["EmailUrl"].ToString();
        private string FromEmailAddr = ConfigurationManager.AppSettings["FromEmailAddr"].ToString();
        private string NotificationEmail = ConfigurationManager.AppSettings["NotificationEmail"].ToString();
        private string EmailFormURL = ConfigurationManager.AppSettings["EmailFormURL"].ToString();

        public void SendConfirmationEmail(string email, int formId)
        {
            _log.Log("Sending email to: " + email + "formId; " + formId);

            string eAddr = email;
            try
            {
                MailMessage mail = new MailMessage();
                MailAddress addrTo = new MailAddress(eAddr);
                mail.IsBodyHtml = true;
                mail.To.Add(addrTo);
                //mail.To.Add(eAddr);
                //mail.Bcc.Add("webmaster@centrahealth.com");

                string topBody = "Thank you for completing the Respiratory Protection Waive form.  It will now be reviewed by Employee Care.";
                string Subject = "Confirmation: Respiratory Protection Waive Form Submitted";

                MailAddress addrFrom = new MailAddress(FromEmailAddr);
                mail.From = addrFrom;
                mail.Subject = Subject;  // subject

                mail.Body = "<HTML><BODY style=\"font-family: Comic Sans MS; font-size: 12pt;\"><br /><br />" + topBody 
                    + "<br /><b><u>Your Respiratory Protection Waive Form number: </u></b>" + formId.ToString()
                    + "<br />"
                    + "</BODY></HTML>"; // body

                SmtpClient smtp = new SmtpClient
                {
                    Host = "mailrelay.centrahealth.com"
                };
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                _log.Log("Send Confirmation Email failed to deliver" + ex);
            }

        }

        public void SendNotificationEmail(int formId)
        {
            _log.Log("Sending notification email to: " + NotificationEmail + "formId; " + formId);

            string eAddr = NotificationEmail;
            try
            {
                MailMessage mail = new MailMessage();
                MailAddress addrTo = new MailAddress(eAddr);
                mail.IsBodyHtml = true;
                mail.To.Add(addrTo);
                //mail.To.Add(eAddr);
               // mail.Bcc.Add("webmaster@centrahealth.com");

                string topBody = "A new Respiratory Protection Waive form has been submitted for review.";
                string Subject = "Notification: Respiratory Protection Waive Form Submitted";

                MailAddress addrFrom = new MailAddress(FromEmailAddr);
                mail.From = addrFrom;
                mail.Subject = Subject;  // subject

                EmailFormURL = EmailFormURL.Replace("{formId}", formId.ToString());

                mail.Body = "<HTML><BODY style=\"font-family: Comic Sans MS; font-size: 12pt;\"><br /><br />" + topBody
                    + "<br /><b><u>Your Respiratory Protection Waive Form number: </u></b> <a href = '" + EmailFormURL + "'>" + formId + "</a>​"
                           + "<br />"
                    + "</BODY></HTML>"; // body

                SmtpClient smtp = new SmtpClient
                {
                    Host = "mailrelay.centrahealth.com"
                };
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                _log.Log("Send Confirmation Email failed to deliver" + ex);
            }

        }

        public bool SendFluVacCompletedEmail(string email, int formId)
        {
            _log.Log("Sending notification email to: " + NotificationEmail + "formId; " + formId);

            string eAddr = email;

            MailMessage mail = new MailMessage();
            MailAddress addrTo = new MailAddress(eAddr);
            mail.IsBodyHtml = true;
            mail.To.Add(addrTo);

            string topBody = "A new Respiratory Protection Waive form has been submitted for review.";
            string Subject = "COMPLETED: Respiratory Protection Waive Form";

            MailAddress addrFrom = new MailAddress(FromEmailAddr);
            mail.From = addrFrom;
            mail.Subject = Subject;  // subject

            StringBuilder sb = new StringBuilder();
            //sb.Append(Environment.NewLine + "<br/>");
            //sb.Append(Environment.NewLine + "<br/>");
            sb.Append("Your Respiratory Protection Waive form has been reviewed and all information is complete and accurate.  No further action is needed on your behalf.");
            sb.Append(Environment.NewLine + "<br/>");
            sb.Append(Environment.NewLine + "<br/>");
            sb.Append("Thank you again for completing your Respiratory Protection Waive form!");

            mail.Body = "<HTML><BODY style=\"font-family: Arial; font-size: 12pt;\">" + sb.ToString()
                + "<br /><br />"
                 + "<b><u>Your Respiratory Protection Waive Form number: </u></b>" + formId.ToString()
                + "</BODY></HTML>"; // body

            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "mailrelay.centrahealth.com"
                };

                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                _log.Log("Respiratory Protection Waive form completed email did not send for employee " + email + ":   " + ex.ToString());
                return false;
            }
        }

        public bool SendFluVacNeedsReviewEmail(string email, int formId)
        {
            _log.Log("Sending notification email to: " + NotificationEmail + "formId; " + formId);

            string eAddr = email;

            MailMessage mail = new MailMessage();
            MailAddress addrTo = new MailAddress(eAddr);
            mail.IsBodyHtml = true;
            mail.To.Add(addrTo);

            string Subject = "ACTION REQURIED: Respiratory Protection Waive Form";

            MailAddress addrFrom = new MailAddress(FromEmailAddr);
            mail.From = addrFrom;
            mail.Subject = Subject;  // subject

            StringBuilder sb = new StringBuilder();

            sb.Append("Your Respiratory Protection Waive Form has been reviewed and needs your attention. Please click the link below, review comments made by Employee Care." +
                "Once received, a nurse will review the re-submitted information.");
            sb.Append(Environment.NewLine + "<br/>");
            sb.Append(Environment.NewLine + "<br/>");
           
            mail.Body = "<HTML><BODY style=\"font-family: Arial; font-size: 12pt;\">" + sb.ToString()
                + "<br /><br />"
                 + "<br /><b><u>Your Respiratory Protection Waive Form number: </u></b> <a href = '" + EmailFormURL + "'>" + formId + "</a>​"
                + "</BODY></HTML>"; // body

            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mailrelay.centrahealth.com";
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                _log.Log("Flu Vaccine needs review email did not send for employee " + email + ":   " + ex.ToString());
                return false;
            }
        }

        public void SendStatusChangeEmail(int formId)
        {
            _log.Log("Sending status change email to: " + NotificationEmail + "formId; " + formId);

            string eAddr = NotificationEmail;
            try
            {
                MailMessage mail = new MailMessage();
                MailAddress addrTo = new MailAddress(eAddr);
                mail.IsBodyHtml = true;
                mail.To.Add(addrTo);

                string topBody = "Respiratory Protection Waive form has been updated for review.";
                string Subject = "UPDATE: Respiratory Protection Waive Form Submitted";

                MailAddress addrFrom = new MailAddress(FromEmailAddr);
                mail.From = addrFrom;
                mail.Subject = Subject;  // subject

                EmailFormURL = EmailFormURL.Replace("{formId}", formId.ToString());

                mail.Body = "<HTML><BODY style=\"font-family: Comic Sans MS; font-size: 12pt;\"><br /><br />" + topBody
                    + "<br /><b><u>Your Respiratory Protection Waive Form number: </u></b> <a href = '" + EmailFormURL + "'>" + formId + "</a>​"
                           + "<br />"
                    + "</BODY></HTML>"; // body

                SmtpClient smtp = new SmtpClient
                {
                    Host = "mailrelay.centrahealth.com"
                };
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                _log.Log("Send Status Change Email failed to deliver" + ex);
            }

        }

    }
}
