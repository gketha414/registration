using System;

namespace PreRegistration.Models.ViewModels
{
    public class InsuranceInformationViewModel
    {
        public int PersonID { get; set; }
        public short InsRank { get; set; }
        public string InsPlanName { get; set; }
        public string Subscriber_Name { get; set; }
        public string Rel_PolicyHolder_To_Patient { get; set; }
        public string Policy_Number { get; set; }
        public string Group_Number { get; set; }
        public string PlanCode { get; set; }
        public string InsAddress1 { get; set; }
        public string InsAddress2 { get; set; }
        public string InsCity { get; set; }
        public string InsState { get; set; }
        public Nullable<long> InsZip { get; set; }
        public Nullable<long> InsPhone { get; set; }
    }
}
