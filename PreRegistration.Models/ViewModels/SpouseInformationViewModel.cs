using System;
using System.ComponentModel.DataAnnotations;

namespace PreRegistration.Models.ViewModels
{
    public class SpouseInformationViewModel
    {
        public int PersonID { get; set; }
        [Required, Display(Name = "Spouse First Name")]
        public string First_Name { get; set; }
        [Required, Display(Name = "Spouse Middle Name")]
        public string Middle_Name { get; set; }
        [Required, Display(Name = "Spouse Last Name")]
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
        [Required, Display(Name = "Date of Birth")]
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string Race { get; set; }
        [Display(Name = "Marital Status")]
        public string Marital_Status { get; set; }
        public string SSN { get; set; }
        [Required, Display(Name = "Home Phone Number")]
        public Nullable<long> Home_Phone { get; set; }
        [Display(Name = "Cell Phone Number")]
        public Nullable<long> Cell_Phone { get; set; }
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
        public Nullable<long> Employer_Phone { get; set; }
    }
}
