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
    using System.Collections.Generic;
    
    public partial class MinorInformation
    {
        public int MinorID { get; set; }
        public int PersonID { get; set; }
        public int ResponsiblePartyID { get; set; }
        public string First_Name { get; set; }
        public string Middle_Init { get; set; }
        public string Last_Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public Nullable<long> ZipCode { get; set; }
        public Nullable<System.DateTime> Dob { get; set; }
        public string Race { get; set; }
        public string Marital_Status { get; set; }
        public string SSN { get; set; }
        public Nullable<long> HomePhone { get; set; }
        public Nullable<long> Cell_Phone { get; set; }
        public string MailAddress1 { get; set; }
        public string MailAddress2 { get; set; }
        public string MailCity { get; set; }
        public string MailState { get; set; }
        public Nullable<long> MailZip { get; set; }
        public string E911Address1 { get; set; }
        public string E911Address2 { get; set; }
        public string E911City { get; set; }
        public string E911State { get; set; }
        public Nullable<long> E911Zip { get; set; }
        public string BillAddress1 { get; set; }
        public string BillAddress2 { get; set; }
        public string BillCity { get; set; }
        public string BillState { get; set; }
        public Nullable<long> BillZip { get; set; }
        public string Employer { get; set; }
        public string Job_Title { get; set; }
        public string EmployerAddress1 { get; set; }
        public string EmployerAddress2 { get; set; }
        public string EmployerCity { get; set; }
        public string EmployerState { get; set; }
        public Nullable<long> EmployerZip { get; set; }
        public Nullable<long> EmployerPhone { get; set; }
    
        public virtual PatientDemographic PatientDemographic { get; set; }
        public virtual ResponsibleParty ResponsibleParty { get; set; }
    }
}