using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PreRegistration.Models.ViewModels
{
    public class StateViewModel
    {
        public string StateID { get; set; }
        [Display(Name = "State")]
        public string StateName { get; set; }
        public string NewStateName { get; set; }
        public bool IsActive { get; set; }
        public bool? Success { get; set; }

        public List<StateViewModel> AllStates { get; set; }
        public List<SelectListItem> AllStatesDD { get; set; }
    }
}
