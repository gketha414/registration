using System.Collections.Generic;
using System.Web.Mvc;

namespace PreRegistration.Models.ViewModels
{
    public class RaceViewModel
    {
        public short RaceID { get; set; }
        public string Description { get; set; }
        public string NewDescription { get; set; }
        public bool IsActive { get; set; }
        public bool? Success { get; set; }

        public List<RaceViewModel> AllRaces { get; set; }
    }
}
