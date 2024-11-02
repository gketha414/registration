using PreRegistration.Models.ViewModels;
using System;
using System.Configuration;
using System.Net.Mail;

namespace PreRegistration.Models.Helpers
{
    public class EmailHelper
    {
        Logger log = new Logger();
        public string EmailHost = ConfigurationManager.AppSettings["EmailHost"].ToString();
        public string EmailFrom = ConfigurationManager.AppSettings["EmailFrom"].ToString();
        public string EmailTo = ConfigurationManager.AppSettings["EmailTo"].ToString();
        public string PatientURL = ConfigurationManager.AppSettings["PatientURL"].ToString();

        public bool SendEmailToPatient(PatientDemographicsViewModel patientDemographicsViewModel, int patientId)
        {
            bool emailSuccess = false;

            MailMessage mail = new MailMessage
            {
                IsBodyHtml = true
            };

            mail.To.Add(patientDemographicsViewModel?.Email_Address);
            mail.To.Add("EmployeeHealthDept@centrahealth.com");

            log.Log("Sending email for patient: " + patientId + "To: " + mail.To);

            string topBody = "";
            string topBodyNote = "Patient Registration have been Submitted.  "
                + "Thank you! ";

            string chkReadBody = "<b style=\'font-size: 12pt;\'>This has been electronically sent to Patient.  Please save or print this page for your records.<br /><br />Thank you.</b>";
            string Subject = "Patient Confirmation Email for " + patientDemographicsViewModel.Last_Name+", " + patientDemographicsViewModel.First_Name+ "-" + patientId.ToString();

            topBody = "<b><u>Pateint Pre-Registration Application</u></b>";

            string hoursInBody = string.Empty;

            var addrFrom = new MailAddress(EmailFrom);
            mail.From = addrFrom;
            mail.Subject = Subject;
            string viewPatientURL = string.Format(@"<a href='{0}' title='View Patient' >{1}</a>", PatientURL+ patientId.ToString(), patientId);

            mail.Body = "<HTML><BODY style=\"font-family: Calibri; font-size: 12pt;\">" + topBody
                + "<br /><br />"
                + topBodyNote
                + "<br /><br />"
                + "<b><u>Your Name:        </u></b>" + patientDemographicsViewModel.Last_Name + ", " + patientDemographicsViewModel.First_Name
                + "<br /><br />"
                + "<b><u>Your Patient Number:  </u></b>"+ viewPatientURL

                + "<br /><br /><br />"
                + chkReadBody
                + "</BODY></HTML>"; // body

            try
            {
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = EmailHost;
                    log.Log("Eamil body: " + mail.Body);
                    smtp.Send(mail);
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Log("Failed to send an email" + ex);
                return emailSuccess;
            }
        }


        public bool SendEmailToAdmin(PatientDemographicsViewModel patientDemographicsViewModel, int patientId)
        {
            bool emailSuccess = false;

            MailMessage mail = new MailMessage
            {
                IsBodyHtml = true
            };

            mail.To.Add(EmailTo);

            log.Log("Sending email for patient: " + patientId + "To: " + mail.To);

            string topBody = "";
            string topBodyNote = "Patient Registration have been Submitted For  "+ patientDemographicsViewModel.Last_Name + ", " + patientDemographicsViewModel.First_Name
                + " Thank you! ";

            string chkReadBody = "<b style=\'font-size: 12pt;\'>This has been electronically sent to Patient.  Please save or print this page for your records.<br /><br />Thank you.</b>";
            string Subject = "Patient Registration have been Submitted For  " + patientDemographicsViewModel.Last_Name + ", " + patientDemographicsViewModel.First_Name + "-" + patientId.ToString();

            topBody = "<b><u>Pateint Pre-Registration Application</u></b>";

            string hoursInBody = string.Empty;

            var addrFrom = new MailAddress(EmailFrom);
            mail.From = addrFrom;
            mail.Subject = Subject;
            string viewPatientURL = string.Format(@"<a href='{0}' title='View Patient' >{1}</a>", PatientURL + patientId.ToString(), patientId);

            mail.Body = "<HTML><BODY style=\"font-family: Calibri; font-size: 12pt;\">" + topBody
                + "<br /><br />"
                + topBodyNote
                + "<br /><br />"
                + "<b><u>Your Name:        </u></b>" + patientDemographicsViewModel.Last_Name + ", " + patientDemographicsViewModel.First_Name
                + "<br /><br />"
                + "<b><u>Your Patient Number:  </u></b>" + viewPatientURL

                + "<br /><br /><br />"
                + chkReadBody
                + "</BODY></HTML>"; // body

            try
            {
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = EmailHost;
                    log.Log("Eamil body: " + mail.Body);
                    smtp.Send(mail);
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Log("Failed to send an email" + ex);
                return emailSuccess;
            }
        }
    }
}
