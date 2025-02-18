//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PreRegistration.Models
{
    using System;
    
    public partial class usp_FindByID_Person_Result
    {
        public int PersonID { get; set; }
        public short SectionID { get; set; }
        public short HospitalID { get; set; }
        public Nullable<bool> In_Hospital_Directory { get; set; }
        public string HospitalService { get; set; }
        public string PrimaryCarePhys { get; set; }
        public System.DateTime AdmitDate { get; set; }
        public Nullable<bool> PatientHereBefore { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public string Entitlement { get; set; }
        public string Gender { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public Nullable<long> ZipCode { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Race { get; set; }
        public string Marital_Status { get; set; }
        public string SSN { get; set; }
        public long Home_Phone { get; set; }
        public Nullable<long> Cell_Phone { get; set; }
        public string Email_Address { get; set; }
        public string Church_Choice { get; set; }
        public string Mailing_Address1 { get; set; }
        public string Mailing_Address2 { get; set; }
        public string MailingCity { get; set; }
        public string MailingState { get; set; }
        public Nullable<long> MailingZip { get; set; }
        public string E911Address1 { get; set; }
        public string E911Address2 { get; set; }
        public string E911City { get; set; }
        public string E911State { get; set; }
        public Nullable<long> E911Zip { get; set; }
        public int ResponsiblePartyID { get; set; }
        public string GuarNameIfOther { get; set; }
        public string Bill_Address1 { get; set; }
        public string Bill_Address2 { get; set; }
        public string Bill_City { get; set; }
        public string Bill_State { get; set; }
        public Nullable<long> Bill_ZipCode { get; set; }
        public string Employer { get; set; }
        public string Job_Title { get; set; }
        public string EmployerAddress1 { get; set; }
        public string EmployerAddress2 { get; set; }
        public string EmployerCity { get; set; }
        public string EmployerState { get; set; }
        public Nullable<long> EmployerZip { get; set; }
        public Nullable<long> EmployerPhone { get; set; }
        public string Status { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ProcessDate { get; set; }
    }
}
