using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PreRegistration.Models.ViewModels
{
    public class HospitalViewModel
    {
        public short HospitalID { get; set; }
        [Display(Name = "Hospital Name")]
        public string HospitalName { get; set; }
        public string NewHospitalName { get; set; }
        public bool IsActive { get; set; }
        public bool? Success { get; set; }

        public List<HospitalViewModel> AllHospitals { get; set; }
        public List<SelectListItem> AllHospitalsDD { get; set; }
    }
}
