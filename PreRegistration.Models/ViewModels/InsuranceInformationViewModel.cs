using System;
using System.ComponentModel.DataAnnotations;

namespace PreRegistration.Models.ViewModels
{
    public class InsuranceInformationViewModel
    {
        public int PersonID { get; set; }
        [Display(Name = "Insurance Rank")]
        public short InsRank { get; set; }
        [Display(Name = "Insurance Plan Name")]
        public string InsPlanName { get; set; }
        [Display(Name = "Insurance Subscriber Name")]
        public string Subscriber_Name { get; set; }
        [Display(Name = "Relation PolicyHolder To Patient")]
        public string Rel_PolicyHolder_To_Patient { get; set; }
        [Display(Name = "Policy Number")]
        public string Policy_Number { get; set; }
        [Display(Name = "Group Number")]
        public string Group_Number { get; set; }
        [Display(Name = "Plan Code")]
        public string PlanCode { get; set; }
        [Display(Name = "Address 1")]
        public string InsAddress1 { get; set; }
        [Display(Name = "Address 2")]
        public string InsAddress2 { get; set; }
        [Display(Name = "City")]
        public string InsCity { get; set; }
        [Display(Name = "State")]
        public string InsState { get; set; }
        [Display(Name = "Zip Code")]
        public Nullable<long> InsZip { get; set; }
        [Display(Name = "Phone")]
        public Nullable<long> InsPhone { get; set; }
        [Display(Name = "Attachment Type")]
        public int AttachmentType { get; set; }
    }
}
