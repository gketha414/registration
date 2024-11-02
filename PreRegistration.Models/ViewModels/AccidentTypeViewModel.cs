using System.Collections.Generic;
using System.Web.Mvc;

namespace PreRegistration.Models.ViewModels
{
    public class AccidentTypeViewModel
    {
        public short AccidentTypeID { get; set; }
        public string Description { get; set; }
        public string NewDescription { get; set; }
        public bool IsActive { get; set; }
        public bool? Success { get; set; }

        public List<AccidentTypeViewModel> AllAccidentTypes { get; set; }
        public List<SelectListItem> AllAccidentTypesDD { get; set; }
    }
}
