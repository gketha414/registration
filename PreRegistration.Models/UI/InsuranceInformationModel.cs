﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PreRegistration.Models.UI
{
    public class InsuranceInformationModel
    {
        public int PersonID { get; set; }
        [Display(Name = "Insurance Rank")]
        public short InsRank { get; set; }
        [Display(Name = "Insurance Plan Name")]
        public string InsPlanName { get; set; }
        [Display(Name = "Insured's Name")]
        public string Subscriber_Name { get; set; }
        [Display(Name = "Relation PolicyHolder To Patient")]
        public string Rel_PolicyHolder_To_Patient { get; set; }
        [Display(Name = "Policy Number")]
        public string Policy_Number { get; set; }
        [Display(Name = "Group Number")]
        public string Group_Number { get; set; }
        [Display(Name = "Plan Code")]
        public string PlanCode { get; set; }
        [Display(Name = "Address")]
        public string InsAddress { get; set; }
        [Display(Name = "Phone")]
        public Nullable<long> InsPhone { get; set; }
    }
}
