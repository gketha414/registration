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
        public string EmailHealth = ConfigurationManager.AppSettings["EmailHealth"].ToString();

        //public bool SendEmail(EHCheckMaster ehCheckMaster, int employeeId)
        //{
        //    bool emailSuccess = false;
            
        //    MailMessage mail = new MailMessage
        //    {
        //        IsBodyHtml = true
        //    };

        //    mail.To.Add(ehCheckMaster?.EmailAddr);
        //    mail.To.Add("EmployeeHealthDept@centrahealth.com");
        //    mail.Bcc.Add("brenda.wilson@centrahealth.com");
        //    mail.Bcc.Add("webmaster@centrahealth.com");

        //    log.Log("Sending email for employeeId: " + employeeId +"To: " + mail.To);

        //    string topBody = "";
        //    string topBodyNote = "Employee symptoms have been recorded and electronically submitted to Employee Health.  "
        //        + "Thank you! ";

        //    string chkReadBody = "<b style=\'font-size: 12pt;\'>This has been electronically sent to Employee Health.  Please save or print this page for your records.<br /><br />Thank you.</b>";
        //    string Subject = "Employee Health - Symptom Recorder Email for " + ehCheckMaster.LastName + "-" + employeeId.ToString();

        //    topBody = "<b><u>Employee Symptom Recorder Application</u></b>";

        //    string hoursInBody = string.Empty;

        //    var addrFrom = new MailAddress(EmailFrom, EmailHealth);
        //    mail.From = addrFrom;
        //    mail.Subject = Subject;

        //    mail.Body = "<HTML><BODY style=\"font-family: Comic Sans MS; font-size: 12pt;\">" + topBody
        //        + "<br /><br />"
        //        + topBodyNote
        //        + "<br /><br />"
        //        + "<b><u>Your Name:           </u></b>" + ehCheckMaster.FullName //hdnName.Value
        //        + "<br /><br />"
        //        + "<b><u>Your Lawson Number:  </u></b>" + ehCheckMaster.EmployeeID
        //        + "<br /><br />"
        //        + "<b><u>Your Department:     </u></b>" + ehCheckMaster.DeptName
        //        + "<br /><br />"
        //        + "<b><u>Your Dept Number:    </u></b>" + ehCheckMaster.CostCenter
        //        + "<br /><br />"
        //        + "<b><u>Employee's temperature or symptoms have caused this email to be sent to Employee Health.  </u></b><br />"
        //        + "<br /><br /><br />"
        //        + chkReadBody
        //        + "</BODY></HTML>"; // body

        //    try
        //    {
        //        using (SmtpClient smtp = new SmtpClient())
        //        {
        //            smtp.Host = EmailHost;
        //            log.Log("Eamil body: " + mail.Body);
        //            smtp.Send(mail);
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Log("Failed to send an email" + ex);
        //        return emailSuccess;
        //    }
        //}
    }
}
