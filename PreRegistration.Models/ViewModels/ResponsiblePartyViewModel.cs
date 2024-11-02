using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PreRegistration.Models.ViewModels
{
    public class ResponsiblePartyViewModel
    {

        public int ResponsiblePartyID { get; set; }
        [Display(Name = "Responsible Party Description")]
        public string ResponsiblePartyDescription { get; set; }
        public string NewResponsiblePartyDescription { get; set; }
        public bool IsActive { get; set; }
        public bool? Success { get; set; }

        public List<ResponsiblePartyViewModel> AllResponsibleParties { get; set; }
        public List<SelectListItem> AllResponsiblePartiesDD { get; set; }
    }
}
