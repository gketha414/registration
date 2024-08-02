using System;
using System.ComponentModel.DataAnnotations;

namespace PreRegistration.Models.ViewModels
{
    public class PatientDemographicsViewModel : IViewModel
    {
        public int PersonID { get; set; }
        public short SectionID { get; set; }
        [Required, Display(Name = "Choose Location For Service")]
        public short HospitalID { get; set; }
        [Required, Display(Name = "Would You Like To Be Listed In Our Hospital Directory?")]
        public Nullable<bool> In_Hospital_Directory { get; set; }
        public string HospitalServiceOther { get; set; }
        [Required, Display(Name = "Service You Are Registering For")]
        public string HospitalService { get; set; }
        [Required, Display(Name = "Primary Care Physician")]
        public string PrimaryCarePhys { get; set; }
        [Required, Display(Name = "Expected Admit Date or Due Date")]
        [DataType(DataType.Date)]
        public string AdmitDate { get; set; }
        [Display(Name = "Have you been a patient here before? If so, is your name the same?")]
        public Nullable<bool> PatientHereBefore { get; set; }
        [Required, Display(Name = "Legal First Name")]
        public string First_Name { get; set; }
        [Required, Display(Name = "Middle Initial")]
        public string Middle_Name { get; set; }
        [Required, Display(Name = "Legal Last Name")]
        public string Last_Name { get; set; }
        public string Entitlement { get; set; }
        [Required]
        public string Gender { get; set; }
        [Display(Name = "Permanent Street Address Line 1")]
        public string Address1 { get; set; }
        [Display(Name = "Permanent Street Address Line 2")]
        public string Address2 { get; set; }
        public string City { get; set; }
        [Required, Display(Name = "State/Province")]
        public string StateProvince { get; set; }
        [Required, Display(Name = "Zip Code")]
        public Nullable<long> ZipCode { get; set; }
        [Required, Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public System.DateTime BirthDate { get; set; }
        public string Race { get; set; }
        [Display(Name = "Marital Status")]
        public string Marital_Status { get; set; }
        [Display(Name = "Social Security Number")]
        public string SSN { get; set; }
        [Required, Display(Name = "Home Phone Number")]
        public long Home_Phone { get; set; }
        [ Display(Name = "Cell Phone Number")]
        public Nullable<long> Cell_Phone { get; set; }
        [Display(Name = "Email Address")]
        public string Email_Address { get; set; }
        [Display(Name = "Church Name and City (If Applicable)")]
        public string Church_Choice { get; set; }

        [Display(Name = "Mailing Street Address Line 1")]
        public string Mailing_Address1 { get; set; }
        [Display(Name = "Mailing Street Address Line 2")]
        public string Mailing_Address2 { get; set; }
        [Display(Name = "City")]
        public string MailingCity { get; set; }
        [Display(Name = "State/Province")]
        public string MailingState { get; set; }
        [Display(Name = "Zip Code")]
        public Nullable<long> MailingZip { get; set; }

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

        [Display(Name = "Who is Guarantor or Responsible Party for this patient?")]
        public int ResponsiblePartyID { get; set; }
        [Display(Name = "If Other, Please List Guarantor Here")]
        public string GuarNameIfOther { get; set; }

        [Display(Name = "Billing Street Address Line 1")]
        public string Bill_Address1 { get; set; }
        [Display(Name = "Billing Street Address Line 2")]
        public string Bill_Address2 { get; set; }
        [Display(Name = "City")]
        public string Bill_City { get; set; }
        [Display(Name = "State/Province")]
        public string Bill_State { get; set; }
        [Display(Name = "Zip Code")]
        public Nullable<long> Bill_ZipCode { get; set; }

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
        public string Status { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ProcessDate { get; set; }
        public string UserGroup { get; set; }
    }
}
