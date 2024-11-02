using System;
using System.ComponentModel.DataAnnotations;

namespace PreRegistration.Models.ViewModels
{
    public class MinorInformationViewModel
    {
        public MinorViewModel MontherMinorInformation { get; set; }
        public MinorViewModel FatherMinorInformation { get; set; }
    }
    public class MinorViewModel
    {
        public int PersonID { get; set; }
        public int ResponsiblePartyID { get; set; }
        [Required, Display(Name = "First Name")]
        public string First_Name { get; set; }
        [Required, Display(Name = "Middle Name")]
        public string Middle_Init { get; set; }
        [Required, Display(Name = "Last Name")]
        public string Last_Name { get; set; }
        [Display(Name = "Permanent Street Address Line 1")]
        public string Address1 { get; set; }
        [Display(Name = "Permanent Street Address Line 2")]
        public string Address2 { get; set; }
        public string City { get; set; }
        [Required, Display(Name = "State/Province")]
        public string StateProvince { get; set; }
        [Required, Display(Name = "Zip Code")]
        public Nullable<long> ZipCode { get; set; }
        [DataType(DataType.Date)]
        [Required, Display(Name = "Date Of Birth")]
        public System.DateTime Dob { get; set; }
        public string Race { get; set; }
        [Display(Name = "Marital Status")]
        public string Marital_Status { get; set; }
        [Display(Name = "Social Security Number")]
        public string SSN { get; set; }
        [Required, Display(Name = "Home Phone Number")]
        public Nullable<long> HomePhone { get; set; }
        [Display(Name = "Cell Phone Number")]
        public Nullable<long> Cell_Phone { get; set; }
        [Display(Name = "Mailing Street Address Line 1")]
        public string MailAddress1 { get; set; }
        [Display(Name = "Mailing Street Address Line 2")]
        public string MailAddress2 { get; set; }
        [Display(Name = "City")]
        public string MailCity { get; set; }
        [Display(Name = "State/Province")]
        public string MailState { get; set; }
        [Display(Name = "Zip Code")]
        public Nullable<long> MailZip { get; set; }
        [Display(Name = "911 Street Address Line 1")]
        public string E911Address1 { get; set; }
        [Display(Name = "911 Street Address Line 2")]
        public string E911Address2 { get; set; }
        [Display(Name = "City")]
        public string E911City { get; set; }
        [Display(Name = "State/Province")]
        public string E911State { get; set; }
        [Display(Name = "Zip Code")]
        public Nullable<long> E911Zip { get; set; }
        [Display(Name = "Billing Street Address Line 1")]
        public string BillAddress1 { get; set; }
        [Display(Name = "Billing Street Address Line 2")]
        public string BillAddress2 { get; set; }
        [Display(Name = "City")]
        public string BillCity { get; set; }
        [Display(Name = "State/Province")]
        public string BillState { get; set; }
        [Display(Name = "Zip Code")]
        public Nullable<long> BillZip { get; set; }
        public string Employer { get; set; }
        [Display(Name = "Job Title")]
        public string Job_Title { get; set; }
        [Display(Name = "Employer Street Address Line 1")]
        public string EmployerAddress1 { get; set; }
        [Display(Name = "Employer Street Address Line 2")]
        public string EmployerAddress2 { get; set; }
        [Display(Name = "City")]
        public string EmployerCity { get; set; }
        [Display(Name = "State/Province")]
        public string EmployerState { get; set; }
        [Display(Name = "Zip Code")]
        public Nullable<long> EmployerZip { get; set; }
        [Display(Name = "Employer Phone Number")]
        public Nullable<long> EmployerPhone { get; set; }
    }
}
